using AdventOfCode.Common;

namespace AdventOfCode.Events._2023.Days;

public class Day24 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        throw new NotImplementedException();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        throw new NotImplementedException();
    }

    private static IList<Hailstone> ParseInput(IEnumerable<string> inputData)
    {
        return inputData.Select(ParseLine)
            .ToList();
    }

    private static Hailstone ParseLine(string inputLine)
    {
        var parts = inputLine.Split(" @ ");

        var p = parts[0].Split(", ").Select(long.Parse).ToList();
        var v = parts[1].Split(", ").Select(long.Parse).ToList();

        return new Hailstone(p[0], p[1], p[2], v[0], v[1], v[2]);

    }
    
    public override int Day => 24;

    private class Hailstone(long px, long py, long pz, long vx, long vy, long vz)
    {
        public long PositionX { get; set; } = px;
        public long PositionY { get; set; } = py;
        public long PositionZ { get; set; } = pz;

        public long VelocityX { get; set; } = vx;
        public long VelocityY { get; set; } = vy;
        public long VelocityZ { get; set; } = vz;
    }
}