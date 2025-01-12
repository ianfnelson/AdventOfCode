using AdventOfCode.Events._2022.Days;

namespace AdventOfCodeTests.Events._2022.Days;

[TestFixture]
public class Day02Tests
{
    private readonly Day02 _systemUnderTest = new();
    
    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("Events/2022/TestData/2.txt"), Is.EqualTo("15"));
    }
    
    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("Events/2022/TestData/2.txt"), Is.EqualTo("12"));
    }
}