using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

[TestFixture]
public class Day08Tests
{
    private readonly Day08 _systemUnderTest = new();

    [TestCase("Events/2023/TestData/8a.txt", "2")]
    [TestCase("Events/2023/TestData/8b.txt", "6")]
    public void Part1Test(string inputFilePath, string expectedSteps)
    {
        Assert.That(_systemUnderTest.Part1(inputFilePath), Is.EqualTo(expectedSteps));
    }

    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("Events/2023/TestData/8c.txt"), Is.EqualTo("6"));
    }
}