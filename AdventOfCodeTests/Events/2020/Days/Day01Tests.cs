using AdventOfCode.Events._2020.Days;

namespace AdventOfCodeTests.Events._2020.Days;

[TestFixture]
public class Day01Tests
{
    private readonly Day01 _systemUnderTest = new();
    
    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("Events/2020/TestData/1.txt"), Is.EqualTo("514579"));
    }
    
    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("Events/2020/TestData/1.txt"), Is.EqualTo("241861950"));
    }
}