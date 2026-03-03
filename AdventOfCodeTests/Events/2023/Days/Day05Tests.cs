using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day05Tests
{
    private readonly Day05 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("35", _systemUnderTest.Part1("Events/2023/TestData/5.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("46", _systemUnderTest.Part2("Events/2023/TestData/5.txt"));
    }
}