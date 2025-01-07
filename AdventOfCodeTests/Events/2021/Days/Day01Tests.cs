using AdventOfCode.Events._2021.Days;

namespace AdventOfCodeTests.Events._2021.Days;

[TestFixture]
public class Day01Tests
{
    private readonly Day01 _systemUnderTest = new();

    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("Events/2021/TestData/1.txt"), Is.EqualTo("7"));
    }
    
    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("Events/2021/TestData/1.txt"), Is.EqualTo("5"));
    }
}