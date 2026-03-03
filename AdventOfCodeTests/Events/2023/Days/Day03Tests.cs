using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day03Tests
{
    private readonly Day03 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("4361", _systemUnderTest.Part1("Events/2023/TestData/3.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("467835", _systemUnderTest.Part2("Events/2023/TestData/3.txt"));
    }
}