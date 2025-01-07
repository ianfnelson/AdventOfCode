namespace AdventOfCode.Events._2021.Days;

public class Day01 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        return CountIncreases(inputData, 1).ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return CountIncreases(inputData, 3).ToString();
    }

    private static int CountIncreases(IEnumerable<string> inputData, int windowSize)
    {
        var list = inputData.Select(int.Parse).ToList();

        var increases = 0;

        var pointer = 0;

        do
        {
            if (list[pointer + windowSize] > list[pointer])
            {
                increases++;
            }
        } while (++pointer + windowSize < list.Count);

        return increases;
    }

    public override int Day => 1;
}