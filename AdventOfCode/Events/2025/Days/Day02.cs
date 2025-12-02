namespace AdventOfCode.Events._2025.Days;

public class Day02 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        var ranges = ParseInputData(inputData.Single());
        
        return ranges
            .SelectMany(InvalidIdsInRangePart1)
            .Sum()
            .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        var ranges = ParseInputData(inputData.Single());
        
        return ranges
            .SelectMany(InvalidIdsInRangePart2)
            .Distinct()
            .Sum()
            .ToString();
    }

    public override int Day => 2;

    private static List<Range> ParseInputData(string inputData)
    {
        return inputData
            .Split(',')
            .Select(line => line.Split('-'))
            .Select(split => new Range(long.Parse(split[0]), long.Parse(split[1])))
            .ToList();
    }

    private static IEnumerable<long> InvalidIdsInRangePart1(Range range)
    {
        var next = range.Start;
        
        do
        {
            var length = next.ToString().Length;
            if (length % 2 == 1)
            {
                // Odd number of digits, skip to next power of 10
                next = Pow10(length);
            }
            else
            {
                var half = next.ToString()[..(length/2)];
                var potential = long.Parse(half + half);

                if (potential >= range.Start && potential <= range.End && potential > 9)
                {
                    yield return potential;
                }
                
                var nextHalf = (long.Parse(half) + 1).ToString();
                next = long.Parse(nextHalf + nextHalf);
            }
        } while (next <= range.End);
    }

    private static IEnumerable<long> InvalidIdsInRangePart2(Range range)
    {
        var next = range.Start;
        var invalidIds = new HashSet<long>();

        do
        {
            var length = next.ToString().Length;
            var innerMax = Math.Min(Pow10(length)-1, range.End);

            var factors = LengthFactors[length];

            foreach (var factor in factors)
            {
                var innerNext = next;

                do
                {
                    var portion = innerNext.ToString()[..factor];
                    var potential = long.Parse(string.Join("", Enumerable.Repeat(portion, length / factor)));

                    if (potential >= range.Start && potential <= range.End && potential > 9)
                    {
                        invalidIds.Add(potential);
                    }
                    
                    var nextPortion = (long.Parse(portion)+1).ToString();
                    
                    try
                    {
                        innerNext = long.Parse(string.Join("",Enumerable.Repeat(nextPortion, length/factor)));
                    }
                    catch (OverflowException)
                    {
                        innerNext = long.MaxValue;
                    }
                } while (innerNext <= innerMax);
            }

            next = Pow10(length);

        } while (next <= range.End);
        
        return invalidIds;
    }

    private static readonly Dictionary<int, int[]> LengthFactors = new()
    {
        { 1, [1] },
        { 2, [1] },
        { 3, [1] },
        { 4, [1, 2] },
        { 5, [1] },
        { 6, [1, 2, 3] },
        { 7, [1] },
        { 8, [1, 4] },  // No need to do 2; 4 will catch those
        { 9, [1, 3] },
        { 10, [1, 2, 5] },
        { 11, [1] }
    };

    private static long Pow10(int n)
    {
        long result = 1;
        for (var i = 0; i < n; i++)
        {
            result *= 10;
        }
        return result;
    }
    
    private record Range(long Start, long End);
}