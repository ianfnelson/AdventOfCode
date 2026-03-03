using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day04Tests
{
    private readonly Day04 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("18", _systemUnderTest.Part1("Events/2024/TestData/4.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("9", _systemUnderTest.Part2("Events/2024/TestData/4.txt"));
    }
}