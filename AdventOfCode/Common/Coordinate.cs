namespace AdventOfCode.Common;

public readonly record struct Coordinate(int X, int Y)
{
    public Coordinate Move(Direction direction)
    {
        return direction switch
        {
            Direction.North => this with { Y = Y - 1 },
            Direction.East => this with { X = X + 1 },
            Direction.South => this with { Y = Y + 1 },
            Direction.West => this with { X = X - 1 },
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
    
    public static Coordinate operator +(Coordinate a, Coordinate b) => new(a.X + b.X, a.Y + b.Y);
    public static Coordinate operator -(Coordinate a, Coordinate b) => new(a.X - b.X, a.Y - b.Y);

    /// <summary>
    /// Return the coordinates of the eight positions immediately surrounding this one.
    /// </summary>
    public IEnumerable<Coordinate> SurroundingCoordinates
    {
        get
        {
            for (var xdelta = -1; xdelta <=1 ; xdelta++)
            {
                for (var ydelta = -1; ydelta <=1; ydelta++)
                {
                    if (xdelta != 0 || ydelta != 0)
                    {
                        yield return new Coordinate(X + xdelta, Y + ydelta);
                    }
                }
            }
        }
    }
}