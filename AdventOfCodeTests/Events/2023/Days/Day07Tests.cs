using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day07Tests
{
    private readonly Day07 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("6440", _systemUnderTest.Part1("Events/2023/TestData/7.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("5905", _systemUnderTest.Part2("Events/2023/TestData/7.txt"));
    }
}