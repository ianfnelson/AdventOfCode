using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day04Tests
{
    private readonly Day04 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("13", _systemUnderTest.Part1("Events/2023/TestData/4.txt"));
    }

    [Fact]
    public void ParseCardTest()
    {
        const string inputLine = "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1";

        var card = Day04.ParseCard(inputLine);
        Assert.Equal(3, card.Id);
        Assert.Equal(new[] { 1, 21, 53, 59, 44 }, card.WinningNumbers);
        Assert.Equal(new[] { 69, 82, 63, 72, 16, 21, 14, 1 }, card.OurNumbers);
        Assert.Equal(1, card.CopiesHeld);
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("30", _systemUnderTest.Part2("Events/2023/TestData/4.txt"));
    }
}