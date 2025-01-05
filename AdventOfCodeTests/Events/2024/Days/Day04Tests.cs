using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

[TestFixture]
public class Day04Tests
{
    private readonly Day04 _systemUnderTest = new();
    
    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("Events/2024/TestData/4.txt"), Is.EqualTo("18"));
    }
    
    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("Events/2024/TestData/4.txt"), Is.EqualTo("9"));
    }
}