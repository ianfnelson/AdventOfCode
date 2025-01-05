using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

[TestFixture]
public class Day05Tests
{
    private readonly Day05 _systemUnderTest = new();
    
    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("Events/2024/TestData/5.txt"), Is.EqualTo("143"));
    } 
    
    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("Events/2024/TestData/5.txt"), Is.EqualTo("123"));
    } 
}