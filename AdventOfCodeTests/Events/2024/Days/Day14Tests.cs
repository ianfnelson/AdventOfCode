using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day14Tests
{
    [Fact]
    public void Part1Test()
    {
        var inputData = File.ReadLines("Events/2024/TestData/14.txt");

        var map = new Day14.Map(inputData, 7, 11);

        map.Wait(100);

        Assert.Equal(12, map.SafetyFactor);
    }
}