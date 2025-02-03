using AdventOfCode.Events._2022.Days;

namespace AdventOfCodeTests.Events._2022.Days;


[TestFixture]
public class Day04Tests
{
    private readonly Day04 _systemUnderTest = new();
    
    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("Events/2022/TestData/4.txt"), Is.EqualTo("2"));
    }
    
    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("Events/2022/TestData/4.txt"), Is.EqualTo("4"));
    }
}