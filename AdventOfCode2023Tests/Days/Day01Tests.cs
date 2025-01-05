using AdventOfCode2023.Days;

namespace AdventOfCode2023Tests.Days;

[TestFixture]
public class Day01Tests
{
    private readonly Day01 _systemUnderTest = new();

    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("TestData/1a.txt"), Is.EqualTo("142"));
    }

    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("TestData/1b.txt"), Is.EqualTo("281"));
    }

    [TestCase("treb7uchet", 77, Description = "one digit")]
    [TestCase("1abc2e", 12, Description = "two digits")]
    [TestCase("a1b2c3d4e5f", 15, Description = "more than two digits")]
    public void GetPart1CalibrationValue(string input, int expectedCalibrationValue)
    {
        Assert.That(Day01.GetPart1CalibrationValue(input), Is.EqualTo(expectedCalibrationValue));
    }
    
    [TestCase("two", 22, Description = "one match - words")]
    [TestCase("twothree", 23, Description = "two matches - words")]
    [TestCase("twofournine", 29, Description = "more than two matches - words")]
    [TestCase("2", 22, Description = "one match - digits")]
    [TestCase("23", 23, Description = "two matches - digits")]
    [TestCase("249", 29, Description = "more than two matches - digits")]
    [TestCase("eighthree", 83, Description = "Sneaky overlapping words")]
    public void GetPart2CalibrationValue(string input, int expectedCalibrationValue)
    {
        Assert.That(Day01.GetPart2CalibrationValue(input), Is.EqualTo(expectedCalibrationValue));
    }
}