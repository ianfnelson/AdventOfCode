using AdventOfCode.Events._2025.Days;

namespace AdventOfCodeTests.Events._2025.Days;

public class Day01Tests
{
    private readonly Day01 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("3", _systemUnderTest.Part1("Events/2025/TestData/1.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("6", _systemUnderTest.Part2("Events/2025/TestData/1.txt"));
    }
}