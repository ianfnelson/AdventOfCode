using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day12Tests
{
    private readonly Day12 _systemUnderTest = new();

    [Theory]
    [InlineData("12a.txt", "140")]
    [InlineData("12b.txt", "772")]
    [InlineData("12c.txt", "1930")]
    public void Part1Test(string filename, string expected)
    {
        Assert.Equal(expected, _systemUnderTest.Part1($"Events/2024/TestData/{filename}"));
    }

    [Theory]
    [InlineData("12a.txt", "80")]
    [InlineData("12b.txt", "436")]
    [InlineData("12c.txt", "1206")]
    [InlineData("12d.txt", "236")]
    [InlineData("12e.txt", "368")]
    public void Part2Test(string filename, string expected)
    {
        Assert.Equal(expected, _systemUnderTest.Part2($"Events/2024/TestData/{filename}"));
    }
}