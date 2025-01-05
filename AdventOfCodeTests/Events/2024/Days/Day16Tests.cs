using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

[TestFixture]
public class Day16Tests
{
    private readonly Day16 _systemUnderTest = new();

    [TestCase("16a.txt", "7036")]
    [TestCase("16b.txt", "11048")]
    public void Part1Test(string filename, string expected)
    {
        Assert.That(_systemUnderTest.Part1($"Events/2024/TestData/{filename}"), Is.EqualTo(expected));
    }
}