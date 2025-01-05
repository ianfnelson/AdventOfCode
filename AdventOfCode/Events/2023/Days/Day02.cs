using AdventOfCode.Common;

namespace AdventOfCode.Events._2023.Days;

public class Day02 : DayBase
{
    public override int Day => 2;

    protected override string Part1(IEnumerable<string> inputData)
    {
        var initialSelection = new Selection { Red = 12, Green = 13, Blue = 14 };

        return inputData
            .Select(ParseGame)
            .Where(game => IsPossible(game, initialSelection))
            .Sum(game => game.Id)
            .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return inputData
            .Select(ParseGame)
            .Select(MinimumViableSelection)
            .Sum(x => x.Power)
            .ToString();
    }

    private static bool IsPossible(Game game, Selection initial)
    {
        return game
            .Selections
            .All(s =>
                s.Red <= initial.Red &&
                s.Green <= initial.Green &&
                s.Blue <= initial.Blue);
    }

    private static Selection MinimumViableSelection(Game game)
    {
        return new Selection
        {
            Red = game.Selections.Max(x => x.Red),
            Green = game.Selections.Max(x => x.Green),
            Blue = game.Selections.Max(x => x.Blue)
        };
    }

    private static Game ParseGame(string record)
    {
        var recordSections = record.Split(": ");

        var game = new Game { Id = int.Parse(recordSections[0][5..]) };

        foreach (var selectionRecord in recordSections[1].Split("; "))
            game.Selections.Add(ParseSelection(selectionRecord));

        return game;
    }

    private static Selection ParseSelection(string record)
    {
        var selection = new Selection();
        var groups = record.Split(", ");

        foreach (var group in groups)
        {
            var kvp = group.Split(" ");
            var quantity = int.Parse(kvp[0]);
            var colour = kvp[1];

            switch (colour)
            {
                case "red":
                    selection.Red = quantity;
                    break;
                case "green":
                    selection.Green = quantity;
                    break;
                case "blue":
                    selection.Blue = quantity;
                    break;
            }
        }

        return selection;
    }

    private class Game
    {
        public int Id { get; init; }
        public List<Selection> Selections { get; } = new();
    }

    private class Selection
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        public int Power => Red * Green * Blue;
    }
}