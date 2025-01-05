using System.Text.RegularExpressions;

namespace AdventOfCode.Events._2023.Days;

public class Day04 : DayBase
{
    public override int Day => 4;

    protected override string Part1(IEnumerable<string> inputData)
    {
        return inputData
            .Select(ParseCard)
            .Sum(x => x.Points)
            .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        var cardDictionary = inputData
            .Select(ParseCard)
            .ToDictionary(x => x.Id, x => x);

        PerformCardCopying(cardDictionary);

        return cardDictionary.Sum(x => x.Value.CopiesHeld).ToString();
    }

    private static void PerformCardCopying(IDictionary<int, Card> cardDictionary)
    {
        foreach (var card in cardDictionary.Values)
            for (var i = 0; i < card.WinningNumberCount; i++)
                cardDictionary[card.Id + i + 1].CopiesHeld += cardDictionary[card.Id].CopiesHeld;
    }

    public static Card ParseCard(string inputLine)
    {
        var matches = Regex.Matches(inputLine, @"^Card +(\d+):( +\d+)+ \|( +\d+)+$");

        var id = int.Parse(matches[0].Groups[1].Value);
        var winningNumbers = ParseIntegerCaptures(matches[0].Groups[2]);
        var ourNumbers = ParseIntegerCaptures(matches[0].Groups[3]);

        return new Card(id, winningNumbers, ourNumbers);
    }

    private static IEnumerable<int> ParseIntegerCaptures(Group group)
    {
        return group.Captures.Select(x => int.Parse(x.Value));
    }

    public class Card(int id, IEnumerable<int> winningNumbers, IEnumerable<int> ourNumbers)
    {
        public int Id { get; } = id;
        public List<int> WinningNumbers { get; } = winningNumbers.ToList();
        public List<int> OurNumbers { get; } = ourNumbers.ToList();
        public int CopiesHeld { get; set; } = 1;

        public int WinningNumberCount => OurNumbers.Count(x => WinningNumbers.Contains(x));

        public int Points
        {
            get
            {
                if (WinningNumberCount == 0) return 0;

                return Enumerable.Repeat(2, WinningNumberCount - 1).Aggregate(1, (a, b) => a * b);
            }
        }
    }
}