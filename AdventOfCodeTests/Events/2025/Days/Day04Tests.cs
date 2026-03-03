using AdventOfCode.Events._2025.Days;

namespace AdventOfCodeTests.Events._2025.Days;

public class Day04Tests
{
    private readonly Day04 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("13", _systemUnderTest.Part1("Events/2025/TestData/4.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("43", _systemUnderTest.Part2("Events/2025/TestData/4.txt"));
    }
}