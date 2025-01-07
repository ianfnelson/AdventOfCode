namespace AdventOfCode.Events._2022.Days;

public class Day01 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        return Parse(inputData)
            .Max()
            .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return Parse(inputData)
            .OrderByDescending(x => x)
            .Take(3)
            .Sum()
            .ToString();
    }

    private static IEnumerable<int> Parse(IEnumerable<string> inputData)
    {
        var calories = 0;
        
        foreach (var line in inputData)
        {
            if (line.Length == 0)
            {
                yield return calories;
                calories = 0;
            }
            else
            {
                calories += int.Parse(line);
            }
        }

        yield return calories;
    }

    public override int Day => 1;
}