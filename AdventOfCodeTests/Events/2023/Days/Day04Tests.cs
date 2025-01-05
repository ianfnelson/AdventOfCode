using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

[TestFixture]
public class Day04Tests
{
    private readonly Day04 _systemUnderTest = new();

    [Test]
    public void Part1Test()
    {
        Assert.That(_systemUnderTest.Part1("Events/2023/TestData/4.txt"), Is.EqualTo("13"));
    }

    [Test]
    public void ParseCardTest()
    {
        const string inputLine = "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1";

        var card = Day04.ParseCard(inputLine);
        Assert.Multiple(() =>
        {
            Assert.That(card.Id, Is.EqualTo(3));
            Assert.That(card.WinningNumbers, Is.EquivalentTo(new[] { 1, 21, 53, 59, 44 }));
            Assert.That(card.OurNumbers, Is.EquivalentTo(new[] { 69, 82, 63, 72, 16, 21, 14, 1 }));
            Assert.That(card.CopiesHeld, Is.EqualTo(1));
        });
    }

    [Test]
    public void Part2Test()
    {
        Assert.That(_systemUnderTest.Part2("Events/2023/TestData/4.txt"), Is.EqualTo("30"));
    }
}