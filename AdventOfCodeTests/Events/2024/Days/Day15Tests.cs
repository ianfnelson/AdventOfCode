using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

[TestFixture]
public class Day15Tests
{
    private readonly Day15 _systemUnderTest = new();

    [TestCase("15a.txt", "2028")]
    [TestCase("15b.txt", "10092")]
    public void Part1Test(string filename, string expected)
    {
        Assert.That(_systemUnderTest.Part1($"Events/2024/TestData/{filename}"), Is.EqualTo(expected));
    }
    
    [TestCase("15c.txt", "618")]
    [TestCase("15b.txt", "9021")]
    [TestCase("15d.txt", "1430")]
    public void Part2Test(string filename, string expected)
    {
        Assert.That(_systemUnderTest.Part2($"Events/2024/TestData/{filename}"), Is.EqualTo(expected));
    }
}