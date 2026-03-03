using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day01Tests
{
    private readonly Day01 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("11", _systemUnderTest.Part1("Events/2024/TestData/1.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("31", _systemUnderTest.Part2("Events/2024/TestData/1.txt"));
    }
}