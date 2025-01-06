using AdventOfCode.Events._2018.Days;

namespace AdventOfCodeTests.Events._2018;

[TestFixture]
public class Day01Tests
{
    [TestCase("+1, +1, +1", "3")]
    [TestCase("+1, +1, -2", "0")]
    [TestCase("-1, -2, -3", "-6")]
    public void Part1Test(string inputString, string expectedOutput)
    {
        var input = inputString.Split(", ");
        
        var output = Day01.Part1Impl(input);
        
        Assert.That(output, Is.EqualTo(expectedOutput));
    }
    
    [TestCase("+1, -1", "0")]
    [TestCase("+3, +3, +4, -2, -4", "10")]
    [TestCase("-6, +3, +8, +5, -6", "5")]
    [TestCase("+7, +7, -2, -7, -4", "14")]
    public void Part2Test(string inputString, string expectedOutput)
    {
        var input = inputString.Split(", ");
        
        var output = Day01.Part2Impl(input);
        
        Assert.That(output, Is.EqualTo(expectedOutput));
    }
}