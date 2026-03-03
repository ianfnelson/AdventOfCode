using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day15Tests
{
    private readonly Day15 _systemUnderTest = new();

    [Theory]
    [InlineData("15a.txt", "2028")]
    [InlineData("15b.txt", "10092")]
    public void Part1Test(string filename, string expected)
    {
        Assert.Equal(expected, _systemUnderTest.Part1($"Events/2024/TestData/{filename}"));
    }

    [Theory]
    [InlineData("15c.txt", "618")]
    [InlineData("15b.txt", "9021")]
    [InlineData("15d.txt", "1430")]
    public void Part2Test(string filename, string expected)
    {
        Assert.Equal(expected, _systemUnderTest.Part2($"Events/2024/TestData/{filename}"));
    }
}