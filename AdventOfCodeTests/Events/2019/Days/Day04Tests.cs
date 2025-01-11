using AdventOfCode.Events._2019.Days;

namespace AdventOfCodeTests.Events._2019.Days;

[TestFixture]
public class Day04Tests
{
    [TestCase(111111,true)]
    [TestCase(223450,false)]
    [TestCase(123789,false)]
    public void MeetsCriteriaPart1(int value, bool expectedResult)
    {
        Assert.That(Day04.MeetsCriteria(value, 1), Is.EqualTo(expectedResult));
    }
    
    [TestCase(112233,true)]
    [TestCase(123444,false)]
    [TestCase(111122,true)]
    public void MeetsCriteriaPart2(int value, bool expectedResult)
    {
        Assert.That(Day04.MeetsCriteria(value, 2), Is.EqualTo(expectedResult));
    }
}