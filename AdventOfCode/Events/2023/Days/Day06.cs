using System.Text.RegularExpressions;

namespace AdventOfCode.Events._2023.Days;

public class Day06 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        return ParsePart1Races(inputData)
            .Select(x => x.WinningWays)
            .Aggregate(1L, (a, b) => a * b)
            .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return ParsePart2Race(inputData).WinningWays.ToString();
    }

    private static IEnumerable<Race> ParsePart1Races(IEnumerable<string> inputData)
    {
        var lines = inputData.ToList();
        var times = Regex.Matches(lines[0], @"\d+");
        var distances = Regex.Matches(lines[1], @"\d+");

        for (var i = 0; i < times.Count; i++)
        {
            yield return new Race(long.Parse(times[i].Value), long.Parse(distances[i].Value));
        }
    }

    private static Race ParsePart2Race(IEnumerable<string> inputData)
    {
        var lines = inputData.ToList();
        var time = long.Parse(Regex.Match(lines[0].Replace(" ", ""), @"\d+").Value);
        var distance = long.Parse(Regex.Match(lines[1].Replace(" ", ""), @"\d+").Value);
        return new Race(time, distance);
    }

    private class Race(long time, long distance)
    {
        public long Time { get; } = time;
        public long Distance { get; } = distance;

        public long WinningWays
        {
            get
            {
                // We want the range of integers x such that x * (t-x) > d
                // Therefore must find roots of the quadratic x^2 - tx + d > 0
                var determinant = Math.Sqrt(Time * Time - 4.0 * 1.0 * Distance);

                var lowestTime = Math.Floor((Time - determinant) / 2.0)+1;
                var highestTime = Math.Ceiling((Time + determinant) / 2.0)-1;

                return Convert.ToInt64(highestTime - lowestTime + 1.0);
            }
        }
    }

    public override int Day => 6;
}