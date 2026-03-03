using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day10Tests
{
    private readonly Day10 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("36", _systemUnderTest.Part1("Events/2024/TestData/10.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("81", _systemUnderTest.Part2("Events/2024/TestData/10.txt"));
    }
}