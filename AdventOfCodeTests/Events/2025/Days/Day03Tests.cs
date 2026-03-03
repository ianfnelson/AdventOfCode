using AdventOfCode.Events._2025.Days;

namespace AdventOfCodeTests.Events._2025.Days;

public class Day03Tests
{
    private readonly Day03 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("357", _systemUnderTest.Part1("Events/2025/TestData/3.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("3121910778619", _systemUnderTest.Part2("Events/2025/TestData/3.txt"));
    }
}