using System.Collections.Concurrent;

namespace AdventOfCode.Events._2023.Days;

public class Day16 : DayBase
{
    private Contraption _contraption;

    public override int Day => 16;

    protected override string Part1(IEnumerable<string> inputData)
    {
        _contraption = new Contraption(ParseTiles(inputData));

        var initialPosition = new PositionVector(new Coordinates(0, 0), Direction.East);
        Task.Run(async () => await TraceBeam(initialPosition)).Wait();

        return _contraption.EnergyCount.ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        _contraption = new Contraption(ParseTiles(inputData));
        var maximumEnergyCount = 0;

        foreach (var initialPosition in _contraption.InitialPositions)
        {
            _contraption.Reset();
            Task.Run(async () => await TraceBeam(initialPosition)).Wait();
            if (_contraption.EnergyCount > maximumEnergyCount) maximumEnergyCount = _contraption.EnergyCount;
        }

        return maximumEnergyCount.ToString();
    }

    private async Task TraceBeam(PositionVector positionVector)
    {
        if (_contraption.IncludesCoordinates(positionVector.Coordinates))
        {
            var currentTile = _contraption.Tiles[positionVector.Coordinates];

            if (!currentTile.Entries.Contains(positionVector.Direction))
            {
                currentTile.Enter(positionVector.Direction);

                var childTasks = currentTile.GetOutputBeams(positionVector.Direction)
                    .Select(outputBeam => Task.Run(async () => await TraceBeam(outputBeam))).ToList();

                await Task.WhenAll(childTasks);
            }
        }

        await Task.CompletedTask;
    }

    private static IEnumerable<Tile> ParseTiles(IEnumerable<string> inputData)
    {
        var yCoord = 0;
        foreach (var line in inputData)
        {
            var xCoord = 0;
            foreach (var tileType in line.ToCharArray())
            {
                yield return new Tile(new Coordinates(xCoord, yCoord), tileType);
                xCoord++;
            }

            yCoord++;
        }
    }

    private enum Direction
    {
        North,
        East,
        South,
        West
    }

    private readonly struct Coordinates(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;

        public PositionVector Travel(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return new PositionVector(new Coordinates(X, Y - 1), Direction.North);
                case Direction.East:
                    return new PositionVector(new Coordinates(X + 1, Y), Direction.East);
                case Direction.South:
                    return new PositionVector(new Coordinates(X, Y + 1), Direction.South);
                case Direction.West:
                    return new PositionVector(new Coordinates(X - 1, Y), Direction.West);
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }

    private class Contraption
    {
        private readonly int _maximumX;
        private readonly int _maximumY;

        public Contraption(IEnumerable<Tile> tiles)
        {
            Tiles = new ConcurrentDictionary<Coordinates, Tile>();
            foreach (var tile in tiles) Tiles.TryAdd(tile.Coordinates, tile);

            _maximumY = Tiles.Max(x => x.Key.Y);
            _maximumX = Tiles.Max(x => x.Key.X);
        }

        public ConcurrentDictionary<Coordinates, Tile> Tiles { get; }

        public int EnergyCount => Tiles.Count(x => x.Value.Energised);

        public IEnumerable<PositionVector> InitialPositions
        {
            get
            {
                foreach (var x in Enumerable.Range(0, _maximumX))
                {
                    yield return new PositionVector(new Coordinates(x, 0), Direction.South);
                    yield return new PositionVector(new Coordinates(x, _maximumY), Direction.North);
                }

                foreach (var y in Enumerable.Range(0, _maximumY))
                {
                    yield return new PositionVector(new Coordinates(y, 0), Direction.East);
                    yield return new PositionVector(new Coordinates(y, _maximumX), Direction.West);
                }
            }
        }

        public bool IncludesCoordinates(Coordinates coordinates)
        {
            return coordinates.X >= 0 &&
                   coordinates.Y >= 0 &&
                   coordinates.X <= _maximumX &&
                   coordinates.Y <= _maximumY;
        }

        public void Reset()
        {
            foreach (var tile in Tiles) tile.Value.Entries = new List<Direction>();
        }
    }

    private class Tile(Coordinates coordinates, char type)
    {
        public List<Direction> Entries { get; set; } = new();

        public Coordinates Coordinates { get; } = coordinates;

        public bool Energised => Entries.Count > 0;

        public void Enter(Direction direction)
        {
            Entries.Add(direction);
        }

        private IEnumerable<Direction> GetOutputBeamDirections(Direction entryDirection)
        {
            return type switch
            {
                '.' => new[] { entryDirection },
                '|' => entryDirection is Direction.North or Direction.South
                    ? new[] { entryDirection }
                    : new[] { Direction.North, Direction.South },
                '-' => entryDirection is Direction.East or Direction.West
                    ? new[] { entryDirection }
                    : new[] { Direction.East, Direction.West },
                '/' => entryDirection switch
                {
                    Direction.North => new[] { Direction.East },
                    Direction.East => new[] { Direction.North },
                    Direction.South => new[] { Direction.West },
                    Direction.West => new[] { Direction.South },
                    _ => throw new ArgumentOutOfRangeException(nameof(entryDirection), entryDirection, null)
                },
                '\\' => entryDirection switch
                {
                    Direction.North => new[] { Direction.West },
                    Direction.East => new[] { Direction.South },
                    Direction.South => new[] { Direction.East },
                    Direction.West => new[] { Direction.North },
                    _ => throw new ArgumentOutOfRangeException(nameof(entryDirection), entryDirection, null)
                },
                _ => throw new InvalidOperationException()
            };
        }

        public IEnumerable<PositionVector> GetOutputBeams(Direction entryDirection)
        {
            return GetOutputBeamDirections(entryDirection)
                .Select(outputDirection => Coordinates.Travel(outputDirection));
        }
    }

    private class PositionVector(Coordinates coordinates, Direction direction)
    {
        public Coordinates Coordinates { get; } = coordinates;
        public Direction Direction { get; } = direction;
    }
}