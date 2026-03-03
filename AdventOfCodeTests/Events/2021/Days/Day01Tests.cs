using AdventOfCode.Events._2021.Days;

namespace AdventOfCodeTests.Events._2021.Days;

public class Day01Tests
{
    private readonly Day01 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("7", _systemUnderTest.Part1("Events/2021/TestData/1.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("5", _systemUnderTest.Part2("Events/2021/TestData/1.txt"));
    }
}