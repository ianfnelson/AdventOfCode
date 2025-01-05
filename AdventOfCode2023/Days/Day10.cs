namespace AdventOfCode2023.Days;

public class Day10 : DayBase
{
    private class Pipe(Coordinates coordinates, char pipeType)
    {
        public Coordinates Coordinates { get; } = coordinates;
        public char PipeType { get; } = pipeType;

        public IEnumerable<Coordinates> Connections
        {
            get
            {
                switch (PipeType)
                {
                    case '|':
                        return new[] { coordinates.North, coordinates.South };
                    case '-':
                        return new[] { coordinates.East, coordinates.West };
                    case 'L':
                        return new[] { coordinates.North, coordinates.East };
                    case 'J':
                        return new[] { coordinates.West, coordinates.North };
                    case '7':
                        return new[] { coordinates.West, coordinates.South };
                    case 'F':
                        return new[] { coordinates.South, coordinates.East };
                    case '.':
                        return Array.Empty<Coordinates>();
                }

                throw new InvalidDataException();
            }
        }
    }

    private readonly struct Coordinates(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;

        public Coordinates North => new(X, Y - 1);
        public Coordinates East => new(X+1, Y);
        public Coordinates South => new(X, Y + 1);
        public Coordinates West => new(X-1, Y);
    }

    private Dictionary<Coordinates, Pipe> _sketch;

    protected override string Part1(IEnumerable<string> inputData)
    {
        _sketch = ParseSketch(inputData);

        return CalculateLoopLength().ToString();
    }

    private static Dictionary<Coordinates, Pipe> ParseSketch(IEnumerable<string> inputData)
    {
        return ParseSketchPipes(inputData)
            .ToDictionary(x => x.Coordinates, x => x);
    }

    private static IEnumerable<Pipe> ParseSketchPipes(IEnumerable<string> inputData)
    {
        var yCoord = 0;
        foreach (var line in inputData)
        {
            var xCoord = 0;
            foreach (var pipeType in line.ToCharArray())
            {
                yield return new Pipe(new Coordinates(xCoord, yCoord), pipeType);
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
            .First(x => !x.Equals(previousPipe.Coordinates));
        
        return _sketch[nextPipeCoordinates];
    }

    private Pipe PickAPipeConnectingToStartingPipe(Pipe startingPipe)
    {
        // Try pipe to the north
        if (startingPipe.Coordinates.Y > 0)
        {
            var northPipe = _sketch[startingPipe.Coordinates.North];
            if (new[] { '|', '7', 'F' }.Contains(northPipe.PipeType))
            {
                return northPipe;
            }
        }
        
        // Try pipe to the west
        if (startingPipe.Coordinates.X > 0)
        {
            var westPipe = _sketch[startingPipe.Coordinates.West];
            if (new[] { '-', 'L', 'F' }.Contains(westPipe.PipeType))
            {
                return westPipe;
            }
        }
        
        // Try pipe to the east
        if (startingPipe.Coordinates.X < _sketch.Keys.Select(x => x.X).Max())
        {
            var eastPipe = _sketch[startingPipe.Coordinates.East];
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