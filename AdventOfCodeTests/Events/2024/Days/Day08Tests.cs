using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day08Tests
{
    private readonly Day08 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("14", _systemUnderTest.Part1("Events/2024/TestData/8.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("34", _systemUnderTest.Part2("Events/2024/TestData/8.txt"));
    }
}