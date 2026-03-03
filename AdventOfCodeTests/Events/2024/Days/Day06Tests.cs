using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day06Tests
{
    private readonly Day06 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("41", _systemUnderTest.Part1("Events/2024/TestData/6.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("6", _systemUnderTest.Part2("Events/2024/TestData/6.txt"));
    }
}