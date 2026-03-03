using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day19Tests
{
    private readonly Day19 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("6", _systemUnderTest.Part1("Events/2024/TestData/19.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("16", _systemUnderTest.Part2("Events/2024/TestData/19.txt"));
    }
}