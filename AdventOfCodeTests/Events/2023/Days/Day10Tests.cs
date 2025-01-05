using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

[TestFixture]
public class Day10Tests
{
    private readonly Day10 _systemUnderTest = new();

    [TestCase("Events/2023/TestData/10a.txt", "4")]
    [TestCase("Events/2023/TestData/10b.txt", "8")]
    public void Part1Test(string inputFilePath, string expectedSteps)
    {
        Assert.That(_systemUnderTest.Part1(inputFilePath), Is.EqualTo(expectedSteps));
    }

    // [Test]
    // public void Part2Test()
    // {
    //     Assert.That(_systemUnderTest.Part2("TestData/8c.txt"), Is.EqualTo("6"));
    // }
}