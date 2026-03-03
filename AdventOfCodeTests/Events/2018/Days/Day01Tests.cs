using AdventOfCode.Events._2018.Days;

namespace AdventOfCodeTests.Events._2018.Days;

public class Day01Tests
{
    [Theory]
    [InlineData("+1, +1, +1", "3")]
    [InlineData("+1, +1, -2", "0")]
    [InlineData("-1, -2, -3", "-6")]
    public void Part1Test(string inputString, string expectedOutput)
    {
        var input = inputString.Split(", ");

        var output = Day01.Part1Impl(input);

        Assert.Equal(expectedOutput, output);
    }

    [Theory]
    [InlineData("+1, -1", "0")]
    [InlineData("+3, +3, +4, -2, -4", "10")]
    [InlineData("-6, +3, +8, +5, -6", "5")]
    [InlineData("+7, +7, -2, -7, -4", "14")]
    public void Part2Test(string inputString, string expectedOutput)
    {
        var input = inputString.Split(", ");

        var output = Day01.Part2Impl(input);

        Assert.Equal(expectedOutput, output);
    }
}