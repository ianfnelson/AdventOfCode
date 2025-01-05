using AdventOfCode2023.Days;

namespace AdventOfCode2023Tests.Days;

[TestFixture]
public class Day11Tests
{
    [TestCase(2, "374")]
    [TestCase(10, "1030")]
    [TestCase(100, "8410")]
    public void DoPuzzleTest(int expansionFactor, string expectedResult)
    {
        var inputData = File.ReadLines("TestData/11.txt");
        
        Assert.That(Day11.DoPuzzle(inputData, expansionFactor), Is.EqualTo(expectedResult));
    }
}