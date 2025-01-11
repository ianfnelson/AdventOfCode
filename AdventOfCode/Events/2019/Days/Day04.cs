namespace AdventOfCode.Events._2019.Days;

public class Day04 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        return DoPuzzle(inputData, 1);
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return DoPuzzle(inputData, 2);
    }

    private static string DoPuzzle(IEnumerable<string> inputData, int part)
    {
        var parts = inputData.Single().Split('-');
        var start = int.Parse(parts[0]);
        var end = int.Parse(parts[1]);

        return Enumerable
            .Range(start, end - start + 1)
            .Count(x => MeetsCriteria(x, part))
            .ToString();
    }

    public static bool MeetsCriteria(int value, int part)
    {
        var digits = value
            .ToString()
            .Select(c => c - '0')
            .ToList();

        return NeverDecreases(digits) &&
               (part == 1 ? HasEqualSuccessiveDigits(digits) : HasExactlyTwoEqualSuccessiveDigits(digits));
    }

    private static bool NeverDecreases(List<int> digits)
    {
        return digits
            .Zip(digits.Skip(1), (a, b) => a <= b)
            .All(x => x);
    }

    private static bool HasEqualSuccessiveDigits(List<int> digits)
    {
        return digits
            .Zip(digits.Skip(1), (a, b) => a == b)
            .Any(x => x);
    }

    private static bool HasExactlyTwoEqualSuccessiveDigits(List<int> digits)
    {
        return digits
            .Select((digit, index) => 
                index > 0 && digit == digits[index - 1] && 
                (index == 1 || digits[index - 2] != digit) && 
                (index == digits.Count - 1 || digits[index + 1] != digit))
            .Any(x => x);
    }

    public override int Day => 4;
}