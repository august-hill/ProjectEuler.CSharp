#!/bin/bash
# benchmark.sh - Run all Project Euler C# solutions and collect benchmark data
set -euo pipefail

REPO_DIR="$(cd "$(dirname "$0")" && pwd)"
LANG="csharp"
OUTPUT="${REPO_DIR}/benchmark_results.json"
PROBLEMS=""

while [[ $# -gt 0 ]]; do
    case $1 in
        --problems) PROBLEMS="$2"; shift 2 ;;
        --output) OUTPUT="$2"; shift 2 ;;
        *) echo "Unknown arg: $1"; exit 1 ;;
    esac
done

if [ -n "$PROBLEMS" ]; then
    IFS=',' read -ra PROB_LIST <<< "$PROBLEMS"
else
    PROB_LIST=()
    for d in "$REPO_DIR"/problem_*/; do
        num=$(basename "$d" | sed 's/problem_//')
        PROB_LIST+=("$num")
    done
fi

PLATFORM=$(uname -m)
DOTNET_VERSION=$(dotnet --version 2>/dev/null || echo "unknown")
TIMESTAMP=$(date -u +"%Y-%m-%dT%H:%M:%SZ")

echo "Project Euler C# Benchmarks"
echo "==========================="
echo "Platform: $PLATFORM | .NET: $DOTNET_VERSION"
echo "Problems: ${#PROB_LIST[@]}"
echo ""

RESULTS_JSON="{\"language\":\"$LANG\",\"platform\":\"$PLATFORM\",\"compiler\":\".NET $DOTNET_VERSION\",\"timestamp\":\"$TIMESTAMP\",\"problems\":{"
FIRST=true
PASS=0
FAIL=0

for NUM in "${PROB_LIST[@]}"; do
    PROB_DIR="$REPO_DIR/problem_$NUM"
    SRC="$PROB_DIR/Program.cs"

    if [ ! -f "$SRC" ]; then
        echo "  SKIP $NUM: no Program.cs"
        continue
    fi

    TIME_OUT=$(mktemp)
    PROG_OUT=$(mktemp)
    (cd "$PROB_DIR" && /usr/bin/time -l dotnet run -c Release --no-restore >"$PROG_OUT" 2>"$TIME_OUT") || true

    BENCH_LINE=$(grep '^BENCHMARK|' "$PROG_OUT" 2>/dev/null || echo "")
    if [ -z "$BENCH_LINE" ]; then
        echo "  FAIL $NUM: no BENCHMARK line"
        rm -f "$TIME_OUT" "$PROG_OUT"
        FAIL=$((FAIL + 1))
        continue
    fi

    ANSWER=$(echo "$BENCH_LINE" | sed 's/.*answer=\([^|]*\).*/\1/')
    TIME_NS=$(echo "$BENCH_LINE" | sed 's/.*time_ns=\([^|]*\).*/\1/')
    ITERS=$(echo "$BENCH_LINE" | sed 's/.*iterations=\([^|]*\).*/\1/')
    PEAK_RSS=$(grep "maximum resident set size" "$TIME_OUT" 2>/dev/null | awk '{print $1}' || echo "0")
    SLOC=$(wc -l < "$SRC" | tr -d ' ')
    SBYTES=$(wc -c < "$SRC" | tr -d ' ')

    if [ "$TIME_NS" -lt 1000 ] 2>/dev/null; then DISPLAY_TIME="${TIME_NS} ns"
    elif [ "$TIME_NS" -lt 1000000 ] 2>/dev/null; then DISPLAY_TIME="$(echo "scale=1; $TIME_NS / 1000" | bc) us"
    elif [ "$TIME_NS" -lt 1000000000 ] 2>/dev/null; then DISPLAY_TIME="$(echo "scale=1; $TIME_NS / 1000000" | bc) ms"
    else DISPLAY_TIME="$(echo "scale=2; $TIME_NS / 1000000000" | bc) s"
    fi

    echo "  $NUM: answer=$ANSWER  time=$DISPLAY_TIME  rss=${PEAK_RSS}B  sloc=$SLOC"

    if [ "$FIRST" = true ]; then FIRST=false; else RESULTS_JSON+=","; fi
    RESULTS_JSON+="\"$NUM\":{\"answer\":$ANSWER,\"time_ns\":$TIME_NS,\"iterations\":$ITERS,\"peak_rss_bytes\":$PEAK_RSS,\"source_lines\":$SLOC,\"source_bytes\":$SBYTES}"
    PASS=$((PASS + 1))
    rm -f "$TIME_OUT" "$PROG_OUT"
done

RESULTS_JSON+="}}"
echo "$RESULTS_JSON" | python3 -m json.tool > "$OUTPUT" 2>/dev/null || echo "$RESULTS_JSON" > "$OUTPUT"
echo ""
echo "Results: $PASS passed, $FAIL failed"
echo "Written to: $OUTPUT"
