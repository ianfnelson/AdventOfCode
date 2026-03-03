using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day01Tests
{
    private readonly Day01 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("142", _systemUnderTest.Part1("Events/2023/TestData/1a.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("281", _systemUnderTest.Part2("Events/2023/TestData/1b.txt"));
    }

    [Theory]
    [InlineData("treb7uchet", 77)] // one digit
    [InlineData("1abc2e", 12)] // two digits
    [InlineData("a1b2c3d4e5f", 15)] // more than two digits
    public void GetPart1CalibrationValue(string input, int expectedCalibrationValue)
    {
        Assert.Equal(expectedCalibrationValue, Day01.GetPart1CalibrationValue(input));
    }

    [Theory]
    [InlineData("two", 22)] // one match - words
    [InlineData("twothree", 23)] // two matches - words
    [InlineData("twofournine", 29)] // more than two matches - words
    [InlineData("2", 22)] // one match - digits
    [InlineData("23", 23)] // two matches - digits
    [InlineData("249", 29)] // more than two matches - digits
    [InlineData("eighthree", 83)] // Sneaky overlapping words
    public void GetPart2CalibrationValue(string input, int expectedCalibrationValue)
    {
        Assert.Equal(expectedCalibrationValue, Day01.GetPart2CalibrationValue(input));
    }
}