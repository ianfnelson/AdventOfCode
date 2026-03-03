using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day09Tests
{
    private readonly Day09 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("114", _systemUnderTest.Part1("Events/2023/TestData/9.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("2", _systemUnderTest.Part2("Events/2023/TestData/9.txt"));
    }
}