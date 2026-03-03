using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day10Tests
{
    private readonly Day10 _systemUnderTest = new();

    [Theory]
    [InlineData("Events/2023/TestData/10a.txt", "4")]
    [InlineData("Events/2023/TestData/10b.txt", "8")]
    public void Part1Test(string inputFilePath, string expectedSteps)
    {
        Assert.Equal(expectedSteps, _systemUnderTest.Part1(inputFilePath));
    }

    // [Fact]
    // public void Part2Test()
    // {
    //     Assert.Equal("6", _systemUnderTest.Part2("TestData/8c.txt"));
    // }
}