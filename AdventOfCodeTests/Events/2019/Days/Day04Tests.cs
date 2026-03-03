using AdventOfCode.Events._2019.Days;

namespace AdventOfCodeTests.Events._2019.Days;

public class Day04Tests
{
    [Theory]
    [InlineData(111111,true)]
    [InlineData(223450,false)]
    [InlineData(123789,false)]
    public void MeetsCriteriaPart1(int value, bool expectedResult)
    {
        Assert.Equal(expectedResult, Day04.MeetsCriteria(value, 1));
    }

    [Theory]
    [InlineData(112233,true)]
    [InlineData(123444,false)]
    [InlineData(111122,true)]
    public void MeetsCriteriaPart2(int value, bool expectedResult)
    {
        Assert.Equal(expectedResult, Day04.MeetsCriteria(value, 2));
    }
}