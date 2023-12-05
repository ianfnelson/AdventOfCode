using AdventOfCode2023.Days;

namespace AdventOfCode2023Tests.Days;

[TestFixture]
public class Day02Tests
{
    private readonly Day02 _systemUnderTest = new();

    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("TestData/2.txt"), Is.EqualTo("8"));
    }

    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("TestData/2.txt"), Is.EqualTo("2286"));
    }
}