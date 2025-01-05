using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

[TestFixture]
public class Day19Tests
{
    private readonly Day19 _systemUnderTest = new();

    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("Events/2023/TestData/19.txt"), Is.EqualTo("19114"));
    }
    
    // [Test]
    // public void Part2Test()
    // {
    //     Assert.That(_systemUnderTest.Part2("TestData/19.txt"), Is.EqualTo("167409079868000"));
    // }
}