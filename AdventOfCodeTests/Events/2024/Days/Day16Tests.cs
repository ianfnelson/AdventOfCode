using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day16Tests
{
    private readonly Day16 _systemUnderTest = new();

    [Theory]
    [InlineData("16a.txt", "7036")]
    [InlineData("16b.txt", "11048")]
    public void Part1Test(string filename, string expected)
    {
        Assert.Equal(expected, _systemUnderTest.Part1($"Events/2024/TestData/{filename}"));
    }
}