using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Days;

public class Day03 : DayBase
{
    public override int Day => 3;

    protected override int Part1(IEnumerable<string> inputData)
    {
        return ParseSchematic(inputData.ToList())
            .Numbers
            .Where(sn => sn.IsPartNumber)
            .Sum(x => x.Value);
    }

    protected override int Part2(IEnumerable<string> inputData)
    {
        return ParseSchematic(inputData.ToList())
            .Asterisks
            .Where(x => x.IsGear)
            .Sum(x => x.GearRatio);
    }

    private static Schematic ParseSchematic(IReadOnlyList<string> inputData)
    {
        var schematic = new Schematic();
        schematic.Numbers = ParseSchematicNumbers(inputData).ToList();
        schematic.Asterisks = ParseSchematicAsterisks(inputData, schematic.Numbers).ToList();
        return schematic;
    }

    private static IEnumerable<SchematicAsterisk> ParseSchematicAsterisks(IReadOnlyList<string> inputData,
        List<SchematicNumber> schematicNumbers)
    {
        for (var lineCounter = 0; lineCounter < inputData.Count; lineCounter++)
        {
            var line = inputData[lineCounter];

            var matchCollection = Regex.Matches(line, @"\*");

            foreach (Match match in matchCollection)
            {
                var location = new Location(lineCounter, match.Index, match.Index);
                yield return new SchematicAsterisk(location)
                {
                    AdjacentNumbers = FindAdjacentNumbers(location, schematicNumbers).ToList()
                };
            }
        }
    }

    private static IEnumerable<SchematicNumber> FindAdjacentNumbers(Location location,
        IReadOnlyList<SchematicNumber> schematicNumbers)
    {
        var numbersOnSameRow = schematicNumbers.Where(sn => sn.Location.Row == location.Row);
        foreach (var sn in numbersOnSameRow)
            if (sn.Location.EndIndex == location.StartIndex - 1 || sn.Location.StartIndex == location.EndIndex + 1)
                yield return sn;

        var numbersOnAdjacentRows =
            schematicNumbers.Where(sn => sn.Location.Row == location.Row - 1 || sn.Location.Row == location.Row + 1);
        foreach (var sn in numbersOnAdjacentRows)
            if (!(sn.Location.EndIndex < location.StartIndex - 1 || sn.Location.StartIndex > location.StartIndex + 1))
                yield return sn;
    }

    private static IEnumerable<SchematicNumber> ParseSchematicNumbers(IReadOnlyList<string> inputData)
    {
        for (var lineCounter = 0; lineCounter < inputData.Count; lineCounter++)
        {
            var line = inputData[lineCounter];

            var matchCollection = Regex.Matches(line, @"\d+");

            if (matchCollection.Any())
            {
                var adjacentLines = new List<string>();
                if (lineCounter > 0) adjacentLines.Add(inputData[lineCounter - 1]);
                if (lineCounter < inputData.Count - 1) adjacentLines.Add(inputData[lineCounter + 1]);

                foreach (Match match in matchCollection)
                {
                    var location = new Location(lineCounter, match.Index, match.Index + match.Length - 1);

                    yield return new SchematicNumber(location, int.Parse(match.Value))
                    {
                        AdjacentSymbols = FindAdjacentSymbols(location, line, adjacentLines).ToList()
                    };
                }
            }
        }
    }

    private static IEnumerable<char> FindAdjacentSymbols(Location location, string line,
        IEnumerable<string> adjacentLines)
    {
        var surroundingText = GetSurroundingText(location, line, adjacentLines);

        var matches = Regex.Matches(surroundingText, "[^0-9.]");

        foreach (Match match in matches) yield return match.Value.ToCharArray()[0];
    }

    private static string GetSurroundingText(Location location, string line, IEnumerable<string> adjacentLines)
    {
        var surroundingText = new StringBuilder();

        var matchIsAtLeftOfLine = location.StartIndex == 0;
        var leftIndexOfSurroundingText = matchIsAtLeftOfLine ? 0 : location.StartIndex - 1;
        if (!matchIsAtLeftOfLine) surroundingText.Append(line.Substring(leftIndexOfSurroundingText, 1));

        var matchIsAtRightOfLine = location.EndIndex + 1 == line.Length;
        var rightIndexOfSurroundingText =
            matchIsAtRightOfLine ? location.EndIndex : location.EndIndex + 1;
        if (!matchIsAtRightOfLine) surroundingText.Append(line.Substring(rightIndexOfSurroundingText, 1));

        foreach (var adjacentLine in adjacentLines)
            surroundingText.Append(adjacentLine.Substring(leftIndexOfSurroundingText,
                rightIndexOfSurroundingText + 1 - leftIndexOfSurroundingText));

        return surroundingText.ToString();
    }

    private class Schematic
    {
        public List<SchematicNumber> Numbers { get; set; } = new();

        public List<SchematicAsterisk> Asterisks { get; set; } = new();
    }

    private class SchematicNumber(Location location, int value)
    {
        public Location Location { get; } = location;

        public int Value { get; } = value;

        public List<char> AdjacentSymbols { get; init; } = new();

        public bool IsPartNumber => AdjacentSymbols.Count != 0;
    }

    private class SchematicAsterisk(Location location)
    {
        public Location Location { get; set; } = location;

        public List<SchematicNumber> AdjacentNumbers { get; init; } = new();

        public bool IsGear => AdjacentNumbers.Count == 2;

        public int GearRatio => !IsGear ? 0 : AdjacentNumbers[0].Value * AdjacentNumbers[1].Value;
    }
    
    private class Location(int row, int startIndex, int endIndex)
    {
        public int Row { get; } = row;

        public int StartIndex { get; } = startIndex;

        public int EndIndex { get; } = endIndex;
    }
}