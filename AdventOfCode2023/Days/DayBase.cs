namespace AdventOfCode2023.Days;

public abstract class DayBase : IDay
{
    protected abstract int Part1(IEnumerable<string> inputData);
    protected abstract int Part2(IEnumerable<string> inputData);

    public abstract int Day { get; }

    public int Part1(string path)
    {
        return Part1(File.ReadLines(path));
    }

    public int Part2(string path)
    {
        return Part2(File.ReadLines(path));
    }
}