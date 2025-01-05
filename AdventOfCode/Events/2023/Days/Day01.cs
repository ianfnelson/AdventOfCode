using System.Text.RegularExpressions;

namespace AdventOfCode.Events._2023.Days;

public class Day01 : DayBase
{
    private static readonly Dictionary<string, string> Part2WordTranslations = new()
    {
        { "one", "1" }, { "two", "2" }, { "three", "3" }, { "four", "4" }, { "five", "5" },
        { "six", "6" }, { "seven", "7" }, { "eight", "8" }, { "nine", "9" }
    };

    public override int Day => 1;

    protected override string Part1(IEnumerable<string> inputData)
    {
        return inputData
            .Select(GetPart1CalibrationValue)
            .Sum(x => x)
            .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return inputData
            .Select(GetPart2CalibrationValue)
            .Sum(x => x)
            .ToString();
    }

    public static int GetPart1CalibrationValue(string inputLine)
    {
        var matches = Regex.Matches(inputLine, @"\d");

        var firstDigit = matches[0].Value;
        var lastDigit = matches[^1].Value;

        return int.Parse(firstDigit + lastDigit);
    }

    public static int GetPart2CalibrationValue(string inputLine)
    {
        const string pattern = @"(?=(\d|one|two|three|four|five|six|seven|eight|nine))";
        var matches = Regex.Matches(inputLine, pattern);

        var firstDigit = TranslatePart2MatchToDigit(matches[0].Groups[1].Value);
        var lastDigit = TranslatePart2MatchToDigit(matches[^1].Groups[1].Value);

        return int.Parse(firstDigit + lastDigit);
    }

    private static string TranslatePart2MatchToDigit(string match)
    {
        return Part2WordTranslations.GetValueOrDefault(match, match);
    }
}