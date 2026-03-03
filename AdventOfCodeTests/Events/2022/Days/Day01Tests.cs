using AdventOfCode.Events._2022.Days;

namespace AdventOfCodeTests.Events._2022.Days;

public class Day01Tests
{
    private readonly Day01 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("24000", _systemUnderTest.Part1("Events/2022/TestData/1.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("45000", _systemUnderTest.Part2("Events/2022/TestData/1.txt"));
    }
}