using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

[TestFixture]
public class Day15Tests
{
    private readonly Day15 _systemUnderTest = new();

    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("Events/2023/TestData/15.txt"), Is.EqualTo("1320"));
    }
    
    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("Events/2023/TestData/15.txt"), Is.EqualTo("145"));
    }

    [TestCase("rn=1", 30)]
    [TestCase("cm-", 253)]
    [TestCase("qp=3", 97)]
    public void RunHashingAlgorithm(string step, int expectedResult)
    {
        Assert.That(Day15.RunHashingAlgorithm(step), Is.EqualTo(expectedResult));
    }
}