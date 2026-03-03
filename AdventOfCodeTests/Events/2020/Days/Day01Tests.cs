using AdventOfCode.Events._2020.Days;

namespace AdventOfCodeTests.Events._2020.Days;

public class Day01Tests
{
    private readonly Day01 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("514579", _systemUnderTest.Part1("Events/2020/TestData/1.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("241861950", _systemUnderTest.Part2("Events/2020/TestData/1.txt"));
    }
}