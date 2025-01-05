using AdventOfCode.Common;

namespace AdventOfCode.Events._2023.Days;

public class Day09 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        return inputData
            .Select(NextValueInSequence)
            .Sum()
            .ToString();
    }
    
    protected override string Part2(IEnumerable<string> inputData)
    {
        return inputData
            .Select(PreviousValueInSequence)
            .Sum()
            .ToString();
    }

    private static long NextValueInSequence(string sequence)
    {
        return NextValueInSequence(sequence.Split(" ").Select(long.Parse).ToList());
    }
    
    private static long PreviousValueInSequence(string sequence)
    {
        return NextValueInSequence(sequence.Split(" ").Select(long.Parse).Reverse().ToList());
    }
    
    private static long NextValueInSequence(List<long> sequence)
    {
        var sequences = new List<List<long>> { sequence };
        
        while (sequence.Any(x => x != 0))
        {
            var nextSequence = new List<long>();
            for (var i = 0; i < sequence.Count - 1; i++)
            {
                nextSequence.Add(sequence[i+1] - sequence[i]);
            }
            sequences.Add(nextSequence);
            sequence = nextSequence;
        }

        for (var i = sequences.Count - 2; i >= 0; i--)
        {
            sequences[i].Add(sequences[i].Last()+sequences[i+1].Last());
        }

        return sequences.First().Last();
    }
    
    public override int Day => 9;
}