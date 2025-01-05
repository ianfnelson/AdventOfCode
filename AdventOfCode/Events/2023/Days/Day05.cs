using System.Text.RegularExpressions;

namespace AdventOfCode.Events._2023.Days;

public class Day05 : DayBase
{
    public override int Day => 5;

    protected override string Part1(IEnumerable<string> inputData)
    {
        var almanac = ParseAlmanac(inputData);

        return almanac.Part1Seeds
            .Select(seed => almanac.FindCategory("seed", "location", seed))
            .Min()
            .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        var almanac = ParseAlmanac(inputData);

        return almanac.Part2Seeds
            .Select(seed => almanac.FindCategory("seed", "location", seed))
            .Min()
            .ToString();
    }

    private static Almanac ParseAlmanac(IEnumerable<string> inputData)
    {
        var lines = inputData.ToList();

        var almanac = new Almanac
        {
            Part1Seeds = lines[0]
                .Replace("seeds: ", "")
                .Split(" ")
                .Select(long.Parse)
                .ToList(),
            Maps = ParseMaps(lines.Skip(2)).ToList()
        };

        return almanac;
    }

    private static IEnumerable<Map> ParseMaps(IEnumerable<string> lines)
    {
        var map = new Map();

        var isHeaderRow = true;

        foreach (var line in lines)
        {
            if (isHeaderRow)
            {
                var matches = Regex.Matches(line, "^([a-z]*)-to-([a-z]*) map:$");
                map.SourceCategory = matches[0].Groups[1].Value;
                map.DestinationCategory = matches[0].Groups[2].Value;
                isHeaderRow = false;
                continue;
            }

            if (string.IsNullOrEmpty(line))
            {
                yield return map;
                map = new Map();
                isHeaderRow = true;
                continue;
            }

            var values = line.Split(" ").Select(long.Parse).ToArray();
            map.Ranges.Add(new Range(values[0], values[1], values[2]));
        }

        yield return map;
    }

    private class Almanac
    {
        public List<long> Part1Seeds { get; init; } = new();

        public IEnumerable<long> Part2Seeds
        {
            get
            {
                for (var i = 0; i < Part1Seeds.Count; i += 2)
                {
                    Console.WriteLine(i + " of " + Part1Seeds.Count);
                    for (var j = 0; j < Part1Seeds[i + 1]; j++) yield return Part1Seeds[i] + j;
                }
            }
        }

        public List<Map> Maps { get; init; } = new();

        public long FindCategory(string sourceCategory, string destinationCategory, long source)
        {
            var map = Maps.Single(x => x.SourceCategory == sourceCategory);

            var target = map.FindDestination(source);

            if (map.DestinationCategory == destinationCategory) return target;

            return FindCategory(map.DestinationCategory, destinationCategory, target);
        }
    }

    private class Map
    {
        public string SourceCategory { get; set; }

        public string DestinationCategory { get; set; }

        public List<Range> Ranges { get; } = new();

        public long FindDestination(long source)
        {
            foreach (var range in Ranges)
                if (range.SourceStart <= source && range.SourceEnd >= source)
                    return source + range.DestinationOffset;

            return source;
        }
    }

    private class Range(long destinationStart, long sourceStart, long length)
    {
        public long SourceStart { get; set; } = sourceStart;
        public long SourceEnd { get; set; } = sourceStart + length - 1;
        public long DestinationOffset { get; set; } = destinationStart - sourceStart;
    }
}