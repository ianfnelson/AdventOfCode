using AdventOfCode2023.Days;

namespace AdventOfCode2023Tests.Days;

[TestFixture]
public class Day05Tests
{
    private readonly Day05 _systemUnderTest = new();

    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("TestData/5.txt"), Is.EqualTo("35"));
    }

    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("TestData/5.txt"), Is.EqualTo("46"));
    }
}