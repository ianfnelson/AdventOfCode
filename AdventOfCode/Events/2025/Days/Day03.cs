namespace AdventOfCode.Events._2025.Days;

public class Day03 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        return
            ParseInputData(inputData)
                .Select(bank => bank.MaximumJoltage(2))
                .Sum()
                .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return
            ParseInputData(inputData)
                .Select(bank => bank.MaximumJoltage(12))
                .Sum()
                .ToString();
    }
    
    private static IEnumerable<Bank> ParseInputData(IEnumerable<string> inputData)
    {
        return inputData
            .Select(line => line.ToCharArray().Select(c => int.Parse(c.ToString())))
            .Select(digits => new Bank(digits));
    }

    private class Bank(IEnumerable<int> digits)
    {
        private List<int> Digits { get; } = digits.ToList();
        
        public long MaximumJoltage(int batteryCount) 
        {
            var rangeStart = 0;

            var batteries = new List<int>();

            for (var rangeEnd = Digits.Count - batteryCount; rangeEnd < Digits.Count; rangeEnd++)
            {
                var next = FindMaxInRange(Digits, rangeStart, rangeEnd);
                rangeStart = next.MaxIndex + 1;
                batteries.Add(next.MaxValue);
            }

            return long.Parse(string.Concat(batteries.Select(x => x.ToString())));
        }
        
        private static (int MaxValue, int MaxIndex) FindMaxInRange(
            List<int> numbers, 
            int start, 
            int endInclusive)
        {
            var maxValue = int.MinValue;
            var maxIndex = -1;

            for (var i = start; i <= endInclusive; i++)
            {
                var value = numbers[i];
                if (value > maxValue)
                {
                    maxValue = value;
                    maxIndex = i;
                }
            }

            return (maxValue, maxIndex);
        }
    }

    public override int Day => 3;
}