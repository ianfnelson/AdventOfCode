using System.Text.RegularExpressions;
using AdventOfCode.Common;

namespace AdventOfCode.Events._2023.Days;

public class Day11 : DayBase
{
    public override int Day => 11;

    protected override string Part1(IEnumerable<string> inputData)
    {
        return DoPuzzle(inputData, 2);
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return DoPuzzle(inputData, 1000000);
    }

    public static string DoPuzzle(IEnumerable<string> inputData, int expansionFactor)
    {
        var universe = ParseInput(inputData);

        return ShortestPathBetweenAllGalaxies(universe, expansionFactor).ToString();
    }

    private static Universe ParseInput(IEnumerable<string> inputData)
    {
        var galaxies = ParseGalaxies(inputData).ToList();
        var emptyRows = FindEmptyRows(galaxies).ToList();
        var emptyColumns = FindEmptyColumns(galaxies).ToList();

        return new Universe
        {
            Galaxies = galaxies,
            EmptyColumns = emptyColumns,
            EmptyRows = emptyRows
        };
    }

    private static IEnumerable<Galaxy> ParseGalaxies(IEnumerable<string> inputData)
    {
        var y = 0;
        foreach (var line in inputData)
        {
            var galaxies = Regex.Matches(line, "#");
            foreach (Match galaxy in galaxies) yield return new Galaxy(galaxy.Index, y);

            y++;
        }
    }

    private static IEnumerable<int> FindEmptyColumns(IList<Galaxy> galaxies)
    {
        return Enumerable
            .Range(0, galaxies.Max(x => x.X))
            .Where(x => galaxies.All(g => g.X != x));
    }

    private static IEnumerable<int> FindEmptyRows(IList<Galaxy> galaxies)
    {
        return Enumerable
            .Range(0, galaxies.Max(y => y.Y))
            .Where(y => galaxies.All(g => g.Y != y));
    }

    private static long ShortestPathBetweenAllGalaxies(Universe universe, int expansionFactor)
    {
        var total = 0L;
        for (var i = 0; i < universe.Galaxies.Count; i++)
        {
            var a = universe.Galaxies[i];

            for (var j = i + 1; j < universe.Galaxies.Count; j++)
            {
                var b = universe.Galaxies[j];

                var extraVertical = 
                    universe.EmptyRows.Count(y => y < Math.Max(a.Y, b.Y) && y > Math.Min(a.Y, b.Y)) *
                                    (expansionFactor - 1);
                var extraHorizontal =
                    universe.EmptyColumns.Count(x => x < Math.Max(a.X, b.X) && x > Math.Min(a.X, b.X)) *
                    (expansionFactor - 1);

                total +=
                    Math.Abs(a.X - b.X) +
                    Math.Abs(a.Y - b.Y) +
                    extraHorizontal +
                    extraVertical;
            }
        }

        return total;
    }

    private class Universe
    {
        public List<Galaxy> Galaxies { get; set; }
        public List<int> EmptyRows { get; set; }
        public List<int> EmptyColumns { get; set; }
    }

    private class Galaxy(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
    }
}