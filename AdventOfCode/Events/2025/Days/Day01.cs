namespace AdventOfCode.Events._2025.Days;

public class Day01 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        var rotations = ParseInputData(inputData);

        var dial = new Dial(50);

        foreach (var rotation in rotations)
        {
            dial.Rotate(rotation);
        }
        
        return dial
            .PositionHistory
            .Count(x => x==0)
            .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        var rotations = ParseInputData(inputData);

        var dial = new Dial(50);

        foreach (var rotation in rotations)
        {
            dial.Rotate(rotation);
        }

        return dial.PassZeroCount.ToString();
    }

    private class Dial(int position)
    {
        public int Position { get; private set; } = position;
        public List<int> PositionHistory { get; } = [position];
        public int PassZeroCount { get; private set; }

        public void Rotate(Rotation rotation)
        {
            var sign = rotation.Direction == Direction.Left ? -1 : 1;
            var newPositionRaw = Position + sign * rotation.Clicks;

            PassZeroCount += sign * (newPositionRaw / 100);
            if (newPositionRaw <= 0 && Position > 0 || newPositionRaw >= 0 && Position < 0)
            {
                PassZeroCount++;
            }
            
            Position = newPositionRaw % 100;
            PositionHistory.Add(Position);
        }
    }

    private static IEnumerable<Rotation> ParseInputData(IEnumerable<string> inputData)
    {
        foreach (var line in inputData)
        {
            var direction = line[0]=='L' ?  Direction.Left : Direction.Right;
            var clicks = int.Parse(line.Substring(1));
            
            yield return new Rotation(direction, clicks);
        }
    }

    private record Rotation(Direction Direction, int Clicks);

    private enum Direction
    {
        Left,
        Right
    }

    public override int Day => 1;
}