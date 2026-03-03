using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day24Tests
{
    private readonly Day24 _systemUnderTest = new();

    [Theory]
    [InlineData("24a.txt", "4")]
    [InlineData("24b.txt", "2024")]
    public void Part1Test(string filename, string expectedResult)
    {
        Assert.Equal(expectedResult, _systemUnderTest.Part1($"Events/2024/TestData/{filename}"));
    }

    // [Fact]
    // public void Part2Test()
    // {
    //     Assert.Equal("co,de,ka,ta", _systemUnderTest.Part2("TestData/23.txt"));
    // }
}