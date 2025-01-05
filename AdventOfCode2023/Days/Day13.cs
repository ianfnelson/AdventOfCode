namespace AdventOfCode2023.Days;

public class Day13 : DayBase
{
    public override int Day => 13;

    protected override string Part1(IEnumerable<string> inputData)
    {
        return DoPuzzle(inputData, false);
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return DoPuzzle(inputData, true);
    }

    private static string DoPuzzle(IEnumerable<string> inputData, bool smudged)
    {
        return ParsePatterns(inputData)
            .Select(x => FindMirror(x, smudged))
            .Sum(x => x.Score)
            .ToString();
    }

    private static Mirror FindMirror(Pattern pattern, bool smudged)
    {
        if (FindMirror(pattern.Rows, smudged, out var rowsAbove))
            return new Mirror(rowsAbove!.Value, MirrorType.Horizontal);

        if (FindMirror(pattern.Columns, smudged, out var columnsToTheLeft))
            return new Mirror(columnsToTheLeft!.Value, MirrorType.Vertical);

        throw new ArgumentOutOfRangeException(nameof(pattern));
    }

    private static bool FindMirror(IList<string> lines, bool smudged, out int? position)
    {
        position = null;
        for (var trialPosition = 1; trialPosition < lines.Count; trialPosition++)
        {
            if (!IsMirror(lines, trialPosition, smudged)) continue;
            position = trialPosition;
            return true;
        }

        return false;
    }

    private static bool IsMirror(IList<string> lines, int trialPosition, bool smudged)
    {
        var maximumDeviation = Math.Min(trialPosition - 1, lines.Count - trialPosition - 1);

        var differenceCount = 0;

        for (var deviation = 0; deviation <= maximumDeviation; deviation++)
        {
            var lineA = lines[trialPosition - deviation - 1];
            var lineB = lines[trialPosition + deviation];

            differenceCount += lineA.Where((t, i) => t != lineB[i]).Count();

            if (differenceCount > (smudged ? 1 : 0)) return false;
        }

        return true;
    }

    private static IEnumerable<Pattern> ParsePatterns(IEnumerable<string> inputData)
    {
        var batch = new List<string>();
        foreach (var line in inputData)
        {
            if (string.IsNullOrEmpty(line))
            {
                yield return new Pattern(batch);
                batch = new List<string>();
                continue;
            }

            batch.Add(line);
        }

        yield return new Pattern(batch);
    }

    private class Mirror(int position, MirrorType type)
    {
        public int Position { get; } = position;

        public MirrorType Type { get; } = type;

        public int Score => Type == MirrorType.Vertical ? Position : Position * 100;
    }

    private class Pattern
    {
        public Pattern(IEnumerable<string> rows)
        {
            Rows = rows.ToList();

            Columns = new List<string>();
            for (var i = 0; i < Rows[0].Length; i++)
            {
                var column =
                    Rows
                        .Select(x => x.Substring(i, 1))
                        .Aggregate("", (a, b) => a + b);

                Columns.Add(column);
            }
        }

        public IList<string> Rows { get; }
        public IList<string> Columns { get; }
    }

    private enum MirrorType
    {
        Vertical,
        Horizontal
    }
}