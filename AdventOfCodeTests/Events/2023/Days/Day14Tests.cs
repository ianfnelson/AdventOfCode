using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day14Tests
{
    private readonly Day14 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("136", _systemUnderTest.Part1("Events/2023/TestData/14.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("64", _systemUnderTest.Part2("Events/2023/TestData/14.txt"));
    }
}