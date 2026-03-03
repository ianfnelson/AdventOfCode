using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day11Tests
{
    private readonly Day11 _systemUnderTest = new();

    [Theory]
    [InlineData("125 17",1, 3)]
    [InlineData("125 17",2, 4)]
    [InlineData("125 17",3, 5)]
    [InlineData("125 17",4, 9)]
    [InlineData("125 17",5, 13)]
    [InlineData("125 17",6, 22)]
    [InlineData("125 17",25, 55312)]
    public void Stones_Blink(string input, int blinkCount, int expectedStonesCount)
    {
        var stones = new Day11.Stones(input);

        stones.Blink(blinkCount);

        Assert.Equal(expectedStonesCount, stones.Count);
    }
}