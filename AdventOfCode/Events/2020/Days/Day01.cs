namespace AdventOfCode.Events._2020.Days;

public class Day01 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        return FindPair(inputData, 2020).ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return FindTriplet(inputData, 2020).ToString();
    }

    private static int FindPair(IEnumerable<string> inputData, int target)
    {
        var numbers = ParseInput(inputData);

        foreach (var integer in numbers)
        {
            if (numbers.Contains(target - integer))
            {
                return (target - integer) * integer;
            }
        }

        throw new InvalidDataException();
    }
    
    private static int FindTriplet(IEnumerable<string> inputData, int target)
    {
        var numbers = inputData.Select(int.Parse).ToList();
        numbers.Sort();
        
        for (var i = 0; i < numbers.Count - 2; i++)
        {
            var j = i + 1;
            var k = numbers.Count - 1;

            while (j < k)
            {
                var currentSum = numbers[i] + numbers[j] + numbers[k];

                if (currentSum == target)
                {
                    return numbers[i] * numbers[j] * numbers[k];
                }
                
                if (currentSum < target)
                {
                    j++; 
                }
                else
                {
                    k--;
                }
            }
        }

        throw new InvalidDataException();
    }

    private static HashSet<int> ParseInput(IEnumerable<string> inputData)
    {
        return inputData.Select(int.Parse)
            .ToHashSet();
    }

    public override int Day => 1;
}