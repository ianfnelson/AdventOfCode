namespace AdventOfCode.Framework;

public interface IDay
{
    int Day { get; }
    int Year { get; }

    string Part1(string path);
    string Part2(string path);
}