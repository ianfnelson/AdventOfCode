using AdventOfCode.Events._2025.Days;

namespace AdventOfCodeTests.Events._2025.Days;

[TestFixture]
public class Day06Tests
{
    private readonly Day06 _systemUnderTest = new();

    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("Events/2025/TestData/6.txt"), Is.EqualTo("4277556"));
    }
    
    // [Test]
    // public void Part2Test()
    // {
    //     Assert.That(_systemUnderTest.Part2("Events/2025/TestData/5.txt"), Is.EqualTo("14"));
    // }
}