using AdventOfCode.Common;

namespace AdventOfCode.Events._2023.Days;

public class Day10 : DayBase
{
    private class Pipe(Coordinate coordinate, char pipeType)
    {
        public Coordinate Coordinate { get; } = coordinate;
        public char PipeType { get; } = pipeType;

        public IEnumerable<Coordinate> Connections
        {
            get
            {
                return PipeType switch
                {
                    '|' => new[] { Coordinate.Move(Direction.North), Coordinate.Move(Direction.South) },
                    '-' => new[] { Coordinate.Move(Direction.East), Coordinate.Move(Direction.West) },
                    'L' => new[] { Coordinate.Move(Direction.North), Coordinate.Move(Direction.East) },
                    'J' => new[] { Coordinate.Move(Direction.West), Coordinate.Move(Direction.North) },
                    '7' => new[] { Coordinate.Move(Direction.West), Coordinate.Move(Direction.South) },
                    'F' => new[] { Coordinate.Move(Direction.South), Coordinate.Move(Direction.East) },
                    '.' => Array.Empty<Coordinate>(),
                    _ => throw new InvalidDataException()
                };
            }
        }
    }

    private Dictionary<Coordinate, Pipe> _sketch;

    protected override string Part1(IEnumerable<string> inputData)
    {
        _sketch = ParseSketch(inputData);

        return CalculateLoopLength().ToString();
    }

    private static Dictionary<Coordinate, Pipe> ParseSketch(IEnumerable<string> inputData)
    {
        return ParseSketchPipes(inputData)
            .ToDictionary(x => x.Coordinate, x => x);
    }

    private static IEnumerable<Pipe> ParseSketchPipes(IEnumerable<string> inputData)
    {
        var yCoord = 0;
        foreach (var line in inputData)
        {
            var xCoord = 0;
            foreach (var pipeType in line.ToCharArray())
            {
                yield return new Pipe(new Coordinate(xCoord, yCoord), pipeType);
                xCoord++;
            }
            yCoord++;
        }
    }
    
    private int CalculateLoopLength()
    {
        var previousPipe = _sketch.Values.Single(x => x.PipeType == 'S');
        var currentPipe = PickAPipeConnectingToStartingPipe(previousPipe);
        var steps = 1;

        do
        {
            var nextPipe = FindNextPipeInLoop(currentPipe, previousPipe);
            previousPipe = currentPipe;
            currentPipe = nextPipe;
            steps++;
        } while (currentPipe.PipeType != 'S');

        return steps / 2;
    }

    private Pipe FindNextPipeInLoop(Pipe currentPipe, Pipe previousPipe)
    {
        var nextPipeCoordinates = currentPipe.Connections
            .First(x => !x.Equals(previousPipe.Coordinate));
        
        return _sketch[nextPipeCoordinates];
    }

    private Pipe PickAPipeConnectingToStartingPipe(Pipe startingPipe)
    {
        // Try pipe to the north
        if (startingPipe.Coordinate.Y > 0)
        {
            var northPipe = _sketch[startingPipe.Coordinate.Move(Direction.North)];
            if (new[] { '|', '7', 'F' }.Contains(northPipe.PipeType))
            {
                return northPipe;
            }
        }
        
        // Try pipe to the west
        if (startingPipe.Coordinate.X > 0)
        {
            var westPipe = _sketch[startingPipe.Coordinate.Move(Direction.West)];
            if (new[] { '-', 'L', 'F' }.Contains(westPipe.PipeType))
            {
                return westPipe;
            }
        }
        
        // Try pipe to the east
        if (startingPipe.Coordinate.X < _sketch.Keys.Select(x => x.X).Max())
        {
            var eastPipe = _sketch[startingPipe.Coordinate.Move(Direction.East)];
            if (new[] { '-', 'J', '7' }.Contains(eastPipe.PipeType))
            {
                return eastPipe;
            }
        }

        throw new InvalidDataException();
    }
    
    protected override string Part2(IEnumerable<string> inputData)
    {
        return "Pffft...";
    }

    public override int Day => 10;
}