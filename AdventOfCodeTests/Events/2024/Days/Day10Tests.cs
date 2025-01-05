using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

[TestFixture]
public class Day10Tests
{
    private readonly Day10 _systemUnderTest = new();
    
    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("Events/2024/TestData/10.txt"), Is.EqualTo("36"));
    } 
    
    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("Events/2024/TestData/10.txt"), Is.EqualTo("81"));
    } 
}