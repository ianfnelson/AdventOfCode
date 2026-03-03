using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day07Tests
{
    private readonly Day07 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("3749", _systemUnderTest.Part1("Events/2024/TestData/7.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("11387", _systemUnderTest.Part2("Events/2024/TestData/7.txt"));
    }
}