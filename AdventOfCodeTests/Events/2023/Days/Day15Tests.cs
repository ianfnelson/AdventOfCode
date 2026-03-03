using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day15Tests
{
    private readonly Day15 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("1320", _systemUnderTest.Part1("Events/2023/TestData/15.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("145", _systemUnderTest.Part2("Events/2023/TestData/15.txt"));
    }

    [Theory]
    [InlineData("rn=1", 30)]
    [InlineData("cm-", 253)]
    [InlineData("qp=3", 97)]
    public void RunHashingAlgorithm(string step, int expectedResult)
    {
        Assert.Equal(expectedResult, Day15.RunHashingAlgorithm(step));
    }
}