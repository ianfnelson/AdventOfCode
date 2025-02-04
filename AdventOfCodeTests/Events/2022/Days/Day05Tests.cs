using AdventOfCode.Events._2022.Days;

namespace AdventOfCodeTests.Events._2022.Days;

[TestFixture]
public class Day05Tests
{
    private readonly Day05 _systemUnderTest = new();
    
    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("Events/2022/TestData/5.txt"), Is.EqualTo("CMZ"));
    }
    
    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("Events/2022/TestData/5.txt"), Is.EqualTo("MCD"));
    }
}