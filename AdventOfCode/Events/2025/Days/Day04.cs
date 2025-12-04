using AdventOfCode.Common;

namespace AdventOfCode.Events._2025.Days;

public class Day04 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        var puzzle = new Puzzle(inputData.ToList());
        return puzzle.NextAccessibleRolls.Count.ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        var puzzle = new Puzzle(inputData.ToList());
        return puzzle.RecursivelyAccessibleRollsCount.ToString();
    }

    private class Puzzle
    {
        public Puzzle(IList<string> inputData)
        {
            for (var y = 0; y < inputData.Count; y++)
            {
                for (var x = 0; x < inputData[y].Length; x++)
                {
                    var c = inputData[y][x];

                    if (c == '.') continue;

                    var coordinate = new Coordinate(x, y); 
                    Rolls.Add(coordinate);
                }
            }
        }

        public HashSet<Coordinate> Rolls = new();

        public HashSet<Coordinate> NextAccessibleRolls
        {
            get
            {
                var result = new HashSet<Coordinate>();

                foreach (var roll in Rolls)
                {
                    var surroundingRollCount = roll.SurroundingCoordinates.Count(coord => Rolls.Contains(coord));

                    if (surroundingRollCount < 4)
                    {
                        result.Add(roll);
                    }
                }

                return result;
            }
        }

        public int RecursivelyAccessibleRollsCount
        {
            get
            {
                var runningTotal = 0;
                while (true)
                {
                    var accessible = NextAccessibleRolls;

                    if (accessible.Count == 0) return runningTotal;

                    foreach (var accessibleRoll in accessible)
                    {
                        Rolls.Remove(accessibleRoll);
                    }

                    runningTotal += accessible.Count;
                }
            }
        }
    }

    public override int Day => 4;
}