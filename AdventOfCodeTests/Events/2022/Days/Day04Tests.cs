using AdventOfCode.Events._2022.Days;

namespace AdventOfCodeTests.Events._2022.Days;

public class Day04Tests
{
    private readonly Day04 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("2", _systemUnderTest.Part1("Events/2022/TestData/4.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("4", _systemUnderTest.Part2("Events/2022/TestData/4.txt"));
    }
}