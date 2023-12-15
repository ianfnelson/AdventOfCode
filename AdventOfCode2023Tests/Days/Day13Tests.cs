using AdventOfCode2023.Days;

namespace AdventOfCode2023Tests.Days;

[TestFixture]
public class Day13Tests
{
    private readonly Day13 _systemUnderTest = new();

    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("TestData/13.txt"), Is.EqualTo("405"));
    }

    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("TestData/13.txt"), Is.EqualTo("400"));
    }
}