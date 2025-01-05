using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

[TestFixture]
public class Day16Tests
{
    private readonly Day16 _systemUnderTest = new();

    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("Events/2023/TestData/16.txt"), Is.EqualTo("46"));
    }
    
    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("Events/2023/TestData/16.txt"), Is.EqualTo("51"));
    }
}