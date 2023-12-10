using AdventOfCode2023.Days;

namespace AdventOfCode2023Tests.Days;

[TestFixture]
public class Day10Tests
{
    private readonly Day10 _systemUnderTest = new();

    [TestCase("TestData/10a.txt", "4")]
    [TestCase("TestData/10b.txt", "8")]
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