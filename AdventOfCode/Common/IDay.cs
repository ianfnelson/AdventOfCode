namespace AdventOfCode.Common;

public interface IDay
{
    int Day { get; }

    string Part1(string path);
    string Part2(string path);
}