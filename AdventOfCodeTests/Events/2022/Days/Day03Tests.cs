using AdventOfCode.Events._2022.Days;

namespace AdventOfCodeTests.Events._2022.Days;

[TestFixture]
public class Day03Tests
{
    private readonly Day03 _systemUnderTest = new();
    
    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("Events/2022/TestData/3.txt"), Is.EqualTo("157"));
    }
    
    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("Events/2022/TestData/3.txt"), Is.EqualTo("70"));
    }
}