namespace AdventOfCode.Events._2022.Days;

public class Day04 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        return ParseInput(inputData)
            .Count(p => p.Item1.Contains(p.Item2) || p.Item2.Contains(p.Item1))
            .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return ParseInput(inputData)
            .Count(p => p.Item1.Overlaps(p.Item2))
            .ToString();
    }

    private static IEnumerable<Tuple<Range, Range>> ParseInput(IEnumerable<string> inputData)
    {
        foreach(var line in inputData)
        {
            var pairs = line.Split(",");
            var range1 = Range.Parse(pairs[0]);
            var range2 = Range.Parse(pairs[1]);

            yield return new Tuple<Range, Range>(range1, range2);
        }
    }
    
    public class Range(int start, int end)
    {
        public int Start { get; } = start;

        public int End { get; } = end;

        public bool Contains(Range other)
        {
            return Start <= other.Start && End >= other.End;
        }

        public bool Overlaps(Range other)
        {
            return Start <= other.End && End >= other.Start;
        }

        public static Range Parse(string input)
        {
            var numbers = input.Split("-");
            return new Range(int.Parse(numbers[0]), int.Parse(numbers[1]));
        }
    }

    public override int Day => 4;
}