using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

[TestFixture]
public class Day11Tests
{
    [TestCase(2, "374")]
    [TestCase(10, "1030")]
    [TestCase(100, "8410")]
    public void DoPuzzleTest(int expansionFactor, string expectedResult)
    {
        var inputData = File.ReadLines("Events/2023/TestData/11.txt");
        
        Assert.That(Day11.DoPuzzle(inputData, expansionFactor), Is.EqualTo(expectedResult));
    }
}