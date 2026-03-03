using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day05Tests
{
    private readonly Day05 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("143", _systemUnderTest.Part1("Events/2024/TestData/5.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("123", _systemUnderTest.Part2("Events/2024/TestData/5.txt"));
    }
}