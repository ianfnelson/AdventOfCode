namespace AdventOfCode2023.Days;

public interface IDay
{
    int Day { get; }

    int Part1(string path);
    int Part2(string path);
}