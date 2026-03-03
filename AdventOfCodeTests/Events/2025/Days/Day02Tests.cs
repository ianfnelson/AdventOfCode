using AdventOfCode.Events._2025.Days;

namespace AdventOfCodeTests.Events._2025.Days;

public class Day02Tests
{
    private readonly Day02 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("1227775554", _systemUnderTest.Part1("Events/2025/TestData/2.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("4174379265", _systemUnderTest.Part2("Events/2025/TestData/2.txt"));
    }
}