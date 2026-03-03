using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day11Tests
{
    [Theory]
    [InlineData(2, "374")]
    [InlineData(10, "1030")]
    [InlineData(100, "8410")]
    public void DoPuzzleTest(int expansionFactor, string expectedResult)
    {
        var inputData = File.ReadLines("Events/2023/TestData/11.txt");

        Assert.Equal(expectedResult, Day11.DoPuzzle(inputData, expansionFactor));
    }
}