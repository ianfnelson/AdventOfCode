using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day02Tests
{
    private readonly Day02 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("8", _systemUnderTest.Part1("Events/2023/TestData/2.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("2286", _systemUnderTest.Part2("Events/2023/TestData/2.txt"));
    }
}