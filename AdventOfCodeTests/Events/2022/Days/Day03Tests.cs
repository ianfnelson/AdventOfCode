using AdventOfCode.Events._2022.Days;

namespace AdventOfCodeTests.Events._2022.Days;

public class Day03Tests
{
    private readonly Day03 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("157", _systemUnderTest.Part1("Events/2022/TestData/3.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("70", _systemUnderTest.Part2("Events/2022/TestData/3.txt"));
    }
}