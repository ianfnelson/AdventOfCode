using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Events._2023.Days;

public class Day14 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        var platform = ParseInput(inputData.ToList());
        TiltNorth(platform);
        return platform.LoadOnNorthBeams.ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        var platform = ParseInput(inputData.ToList());
        var platformString = platform.ToString();

        var configurations = new List<Tuple<string, int>>();
        
        do
        {
            configurations.Add(new Tuple<string, int>(platformString, platform.LoadOnNorthBeams));

            TiltNorth(platform);
            TiltWest(platform);
            TiltSouth(platform);
            TiltEast(platform);

            platformString = platform.ToString();
        } while (configurations.All(x => x.Item1 !=  platformString));
        
        var firstSeen = configurations.FindIndex(x => x.Item1 == platformString);
        var match = configurations[firstSeen + (1000000000 - firstSeen) % (configurations.Count - firstSeen)];

        return match.Item2.ToString();
    }

    private static Platform ParseInput(IList<string> inputData)
    {
        var rocks = new List<Rock>();
        var y = 0;
        var width = inputData[0].Length;
        foreach (var row in inputData)
        {
            var matches = Regex.Matches(row, @"O|#");
            foreach (Match match in matches)
            {
                rocks.Add(new Rock(match.Value == "O" ? RockType.Rounded : RockType.Cube, match.Index, y));
            }

            y++;
        }

        return new Platform(rocks, y, width);
    }
    
    public override int Day => 14;

    private static void TiltNorth(Platform platform)
    {
        var sets = platform.Rocks.GroupBy(rock => rock.X);

        foreach (var set in sets)
        {
            var rocks = set.OrderBy(rock => rock.Y).ToList();
            foreach (var roundedRock in rocks.Where(x => x.Type == RockType.Rounded))
            {
                var nearest = rocks.LastOrDefault(r => r.Y < roundedRock.Y);
                roundedRock.Y = nearest == null ? 0 : nearest.Y + 1;
            }
        }
    }

    private static void TiltEast(Platform platform)
    {
        var sets = platform.Rocks.GroupBy(rock => rock.Y);

        foreach (var set in sets)
        {
            var rocks = set.OrderByDescending(rock => rock.X).ToList();
            foreach (var roundedRock in rocks.Where(x => x.Type == RockType.Rounded))
            {
                var nearest = rocks.LastOrDefault(r => r.X > roundedRock.X);
                roundedRock.X = nearest == null ? platform.Width - 1 : nearest.X - 1;
            }
        }
    }

    private static void TiltSouth(Platform platform)
    {
        var sets = platform.Rocks.GroupBy(rock => rock.X);

        foreach (var set in sets)
        {
            var rocks = set.OrderByDescending(rock => rock.Y).ToList();
            foreach (var roundedRock in rocks.Where(x => x.Type == RockType.Rounded))
            {
                var nearest = rocks.LastOrDefault(r => r.Y > roundedRock.Y);
                roundedRock.Y = nearest == null ? platform.Height -1 : nearest.Y - 1;
            }
        }
    }

    private static void TiltWest(Platform platform)
    {
        var sets = platform.Rocks.GroupBy(rock => rock.Y);

        foreach (var set in sets)
        {
            var rocks = set.OrderBy(rock => rock.X).ToList();
            foreach (var roundedRock in rocks.Where(x => x.Type == RockType.Rounded))
            {
                var nearest = rocks.LastOrDefault(r => r.X < roundedRock.X);
                roundedRock.X = nearest == null ? 0 : nearest.X + 1;
            }
        }
    }

    private class Platform(IList<Rock> rocks, int height, int width)
    {
        public int Height { get; } = height;
        public int Width { get; } = width;
        public IList<Rock> Rocks { get; } = rocks;

        public int LoadOnNorthBeams => Rocks.Where(rock => rock.Type == RockType.Rounded).Sum(rock => Height - rock.Y);

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var rock in Rocks.OrderBy(r => r.X).ThenBy(r => r.Y))
            {
                sb.Append(rock.X + "/" + rock.Y + "/" + rock.Type + "; ");
            }

            return sb.ToString();
        }
    }

    private class Rock(RockType type, int x, int y)
    {
        public RockType Type { get; set; } = type;

        public int X { get; set; } = x;

        public int Y { get; set; } = y;
    }

    private enum RockType
    {
        Rounded,
        Cube
    }
}