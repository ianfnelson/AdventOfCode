using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day09Tests
{
    private readonly Day09 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("1928", _systemUnderTest.Part1("Events/2024/TestData/9.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("2858", _systemUnderTest.Part2("Events/2024/TestData/9.txt"));
    }
}