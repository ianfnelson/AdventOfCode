namespace AdventOfCode2023.Days;

public class Day07 : DayBase
{
    private readonly Dictionary<char, Card> _cards = new()
    {
        { '2', new Card('2', 2, 2) },
        { '3', new Card('3', 3, 3) },
        { '4', new Card('4', 4, 4) },
        { '5', new Card('5', 5, 5) },
        { '6', new Card('6', 6, 6) },
        { '7', new Card('7', 7, 7) },
        { '8', new Card('8', 8, 8) },
        { '9', new Card('9', 9, 9) },
        { 'T', new Card('T', 10, 10) },
        { 'J', new Card('J', 11, 1) },
        { 'Q', new Card('Q', 12, 12) },
        { 'K', new Card('K', 13, 13) },
        { 'A', new Card('A', 14, 14) }
    };

    private readonly Dictionary<string, HandType> _handTypes = new()
    {
        { "5", new HandType("5", "Five of a Kind", 7) },
        { "41", new HandType("41", "Four of a kind", 6) },
        { "32", new HandType("32", "Full house", 5) },
        { "311", new HandType("311", "Three of a kind", 4) },
        { "221", new HandType("221", "Two pair", 3) },
        { "2111", new HandType("2111", "One pair", 2) },
        { "11111", new HandType("11111", "High card", 1) }
    };

    public override int Day => 7;

    protected override string Part1(IEnumerable<string> inputData)
    {
        return DoPuzzle(inputData, false, card => card.RatingRegularS);
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return DoPuzzle(inputData, true, card => card.RatingJacksWild);
    }

    private string DoPuzzle(IEnumerable<string> inputData, bool jacksWild, Func<Card, byte> cardRating)
    {
        var rankedHands = inputData.Select(x => ParseHand(x, jacksWild))
            .OrderBy(x => x.HandType.Rating)
            .ThenBy(x => cardRating(x.Cards[0]))
            .ThenBy(x => cardRating(x.Cards[1]))
            .ThenBy(x => cardRating(x.Cards[2]))
            .ThenBy(x => cardRating(x.Cards[3]))
            .ThenBy(x => cardRating(x.Cards[4]))
            .ToList();

        return CalculateWinnings(rankedHands);
    }
    
    private static string CalculateWinnings(IList<Hand> rankedHands)
    {
        var winnings = 0;
        for (var rank = 1; rank <= rankedHands.Count; rank++) winnings += rank * rankedHands[rank - 1].Bid;

        return winnings.ToString();
    }

    private Hand ParseHand(string inputData, bool jacksAreWild)
    {
        var parts = inputData.Split(" ");

        var bid = int.Parse(parts[1]);
        var cards = parts[0].ToCharArray().Select(x => _cards[x]).ToList();
        var handType = DetermineHandType(cards, jacksAreWild);

        return new Hand(cards, bid, handType);
    }

    private HandType DetermineHandType(List<Card> cards, bool jacksAreWild)
    {
        var cardsToEvaluate = !jacksAreWild ? cards : DetermineEquivalentHandIfJacksWild(cards);

        var cardGroup = cardsToEvaluate.GroupBy(x => x.Character)
            .Select(x => x.Count().ToString())
            .OrderByDescending(x => x)
            .Aggregate("", (a, b) => a + b);

        var handType = _handTypes[cardGroup];

        return handType;
    }

    private List<Card> DetermineEquivalentHandIfJacksWild(List<Card> cards)
    {
        // If no cards are jokers, return the hand unchanged
        if (cards.All(x => x.Character != 'J'))
        {
            return cards;
        }
        
        // If all cards are jokers, return a hand of all aces.
        if (cards.All(x => x.Character == 'J'))
            return new List<Card>
            {
                _cards['A'],
                _cards['A'],
                _cards['A'],
                _cards['A'],
                _cards['A']
            };

        // Find the best non-joker card in the hand. Jokers will imitate this card.
        var replacementCard = cards
            .Where(x => x.Character != 'J')
            .GroupBy(x => x.Character)
            .OrderByDescending(k => k.Count())
            .ThenByDescending(k => k.First().RatingJacksWild)
            .First()
            .Select(x => x)
            .First();

        return cards.Select(card => card.Character == 'J' ? replacementCard : card).ToList();
    }

    private class HandType(string cardGroups, string name, byte rating)
    {
        public string CardGroups { get; set; } = cardGroups;
        public string Name { get; set; } = name;
        public byte Rating { get; } = rating;
    }

    private class Card(char character, byte ratingRegular, byte ratingJacksWild)
    {
        public char Character { get; } = character;
        public byte RatingRegular { get; } = ratingRegular;
        public byte RatingJacksWild { get; } = ratingJacksWild;
    }

    private class Hand(List<Card> cards, int bid, HandType handType)
    {
        public int Bid { get; } = bid;
        public List<Card> Cards { get; } = cards;
        public HandType HandType { get; } = handType;
    }
}