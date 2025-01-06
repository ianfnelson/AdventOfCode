namespace AdventOfCode.Events._2018.Days;

public class Day01 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        return Part1Impl(inputData);
    }
    
    protected override string Part2(IEnumerable<string> inputData)
    {
        return Part2Impl(inputData);
    }

    public static string Part1Impl(IEnumerable<string> inputData)
    {
        return inputData
            .Select(int.Parse)
            .Sum()
            .ToString();
    }

    public static string Part2Impl(IEnumerable<string> inputData)
    {
        var changes = inputData.Select(int.Parse).ToList();

        var frequency = 0;
        var frequencies = new HashSet<int> { frequency };

        do
        {
            foreach (var change in changes)
            {
                frequency += change;
                if (!frequencies.Add(frequency))
                {
                    return frequency.ToString();
                }
            }
        } while (true);
    }
    
    public override int Day => 1;
}