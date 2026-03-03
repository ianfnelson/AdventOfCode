using AdventOfCode.Events._2022.Days;

namespace AdventOfCodeTests.Events._2022.Days;

public class Day05Tests
{
    private readonly Day05 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("CMZ", _systemUnderTest.Part1("Events/2022/TestData/5.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("MCD", _systemUnderTest.Part2("Events/2022/TestData/5.txt"));
    }
}