using AdventOfCode.Common;
using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day18Tests
{
    [Fact]
    public void Part1()
    {
        var inputData = File.ReadAllLines("Events/2024/TestData/18.txt");
        var puzzle = new Day18.Puzzle(inputData, 6);

        var shortestPath = puzzle.ShortestPathAfter(12);

        Assert.Equal(22, shortestPath);
    }

    [Fact]
    public void Part2()
    {
        var inputData = File.ReadAllLines("Events/2024/TestData/18.txt");
        var puzzle = new Day18.Puzzle(inputData, 6);

        var firstCutOff = puzzle.FirstCutOff();

        Assert.Equal(new Coordinate(6,1), firstCutOff);
    }
}