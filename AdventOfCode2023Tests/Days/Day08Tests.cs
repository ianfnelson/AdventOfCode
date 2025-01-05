using AdventOfCode2023.Days;

namespace AdventOfCode2023Tests.Days;

[TestFixture]
public class Day08Tests
{
    private readonly Day08 _systemUnderTest = new();

    [TestCase("TestData/8a.txt", "2")]
    [TestCase("TestData/8b.txt", "6")]
    public void Part1Test(string inputFilePath, string expectedSteps)
    {
        Assert.That(_systemUnderTest.Part1(inputFilePath), Is.EqualTo(expectedSteps));
    }

    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("TestData/8c.txt"), Is.EqualTo("6"));
    }
}