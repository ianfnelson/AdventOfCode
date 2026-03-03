using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day08Tests
{
    private readonly Day08 _systemUnderTest = new();

    [Theory]
    [InlineData("Events/2023/TestData/8a.txt", "2")]
    [InlineData("Events/2023/TestData/8b.txt", "6")]
    public void Part1Test(string inputFilePath, string expectedSteps)
    {
        Assert.Equal(expectedSteps, _systemUnderTest.Part1(inputFilePath));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("6", _systemUnderTest.Part2("Events/2023/TestData/8c.txt"));
    }
}