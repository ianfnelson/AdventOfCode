using System.Text.RegularExpressions;

namespace AdventOfCode2023.Days;

public class Day19 : DayBase
{
    private readonly Dictionary<string, Workflow> _workflows = new();
    private readonly List<Part> _parts = new();
    
    protected override string Part1(IEnumerable<string> inputData)
    {
        ParseInput(inputData.ToList());

        return _parts.Where(x => IsPartAccepted(x, "in"))
            .SelectMany(x => x.Ratings.Values)
            .Sum()
            .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        throw new NotImplementedException();
    }

    private bool IsPartAccepted(Part part, string nextWorkflow)
    {
        var outcome = _workflows[nextWorkflow].RunWorkflow(part);

        return outcome switch
        {
            "R" => false,
            "A" => true,
            _ => IsPartAccepted(part, outcome)
        };
    }

    public override int Day => 19;

    private void ParseInput(IList<string> inputData)
    {
        var lineCount = 0;

        do
        {
            var workflow = ParseWorkflow(inputData[lineCount]);
            _workflows.Add(workflow.Name, workflow);
            
            lineCount++;
        } while (!string.IsNullOrEmpty(inputData[lineCount]));

        lineCount++;

        do
        {
            var part = ParsePart(inputData[lineCount]);
            _parts.Add(part);
            lineCount++;
        } while (lineCount < inputData.Count);
    }

    private static Workflow ParseWorkflow(string input)
    {
        var match = Regex.Match(input, @"^([a-z]+)\{([a-zAR:<>\d,]+)\}$");
        var name = match.Groups[1].Value;
        var rules = match.Groups[2].Value.Split(",");

        return new Workflow(name, rules);
    }

    private static Part ParsePart(string input)
    {
        var ratings = input.Substring(1, input.Length - 2)
            .Split(',')
            .Select(x => x.Split("="))
            .ToDictionary(x => char.Parse(x[0]), x => int.Parse(x[1]));

        return new Part(ratings);
    }
    
    public class Part(Dictionary<char, int> ratings)
    {
        public Dictionary<char, int> Ratings { get; set; } = ratings;
    }

    private class Workflow
    {
        public Workflow(string name, IEnumerable<string> ruleDefinitions)
        {
            Name = name;
            foreach (var ruleDefinition in ruleDefinitions)
            {
                Rules.Add(Rule.Parse(ruleDefinition));
            }
        }
        
        public string Name { get; }

        public List<Rule> Rules { get; } = [];

        public string RunWorkflow(Part part)
        {
            return Rules.First(x => x.Evaluate(part)).Outcome;
        }
    }

    public abstract class Rule
    {
        public static Rule Parse(string definition)
        {
            return definition.Contains(':') ? new ConditionalRule(definition) : new UnconditionalRule(definition);
        }
        
        public abstract bool Evaluate(Part part);
        public string Outcome { get; set; }
    }

    private class ConditionalRule : Rule
    {
        public ConditionalRule(string definition)
        {
            var splitByColon = definition.Split(":");
            Category = splitByColon[0][0];
            Operator = splitByColon[0][1];
            Comparator = int.Parse(splitByColon[0][2..]);
            Outcome = splitByColon[1];
        }
        
        public char Category { get; set; }
        public char Operator { get; set; }
        public int Comparator { get; set; }

        public override bool Evaluate(Part part)
        {
            var partRating = part.Ratings[Category];
            return Operator == '>' ? partRating > Comparator : partRating < Comparator;
        }
    }

    private class UnconditionalRule : Rule
    {
        public UnconditionalRule(string outcome)
        {
            Outcome = outcome;
        }
        
        public override bool Evaluate(Part part)
        {
            return true;
        }
    }
}