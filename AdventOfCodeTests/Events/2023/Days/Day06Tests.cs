using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day06Tests
{
    private readonly Day06 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("288", _systemUnderTest.Part1("Events/2023/TestData/6.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("71503", _systemUnderTest.Part2("Events/2023/TestData/6.txt"));
    }
}