using System.Text.RegularExpressions;

namespace AdventOfCode.Events._2023.Days;

public class Day08 : DayBase
{
    public override int Day => 8;

    protected override string Part1(IEnumerable<string> inputData)
    {
        var map = ParseMap(inputData);

        return CountStepsBetweenNodes(map, "AAA", "ZZZ").ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        var map = ParseMap(inputData);

        var stepCounts = map.Nodes
            .Where(x => x.Key.EndsWith("A"))
            .Select(x => CountStepsBetweenNodes(map, x.Value.Name, "Z"));

        return LowestCommonMultiple(stepCounts).ToString();
    }

    private static long GreatestCommonDivisor(long a, long b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    private static long LowestCommonMultiple(long a, long b)
    {
        return a * b / GreatestCommonDivisor(a, b);
    }

    private static long LowestCommonMultiple(IEnumerable<long> input)
    {
        var result = input.First();

        return input.Skip(1).Aggregate(result, LowestCommonMultiple);
    }

    private static long CountStepsBetweenNodes(Map map, string startingNode, string destinationNodeEndsWith)
    {
        var stepCounter = 0;
        var currentNode = map.Nodes[startingNode];

        do
        {
            foreach (var instruction in map.Instructions)
            {
                if (currentNode.Name.EndsWith(destinationNodeEndsWith)) return stepCounter;

                currentNode = map.Nodes[instruction == 'L' ? currentNode.Left : currentNode.Right];
                stepCounter++;
            }
        } while (true);
    }

    private static Map ParseMap(IEnumerable<string> inputData)
    {
        var lines = inputData.ToList();

        var instructions = lines[0].ToCharArray().ToList();

        var nodes = ParseNodes(lines.Skip(2)).ToDictionary(x => x.Name, x => x);

        return new Map(instructions, nodes);
    }

    private static IEnumerable<Node> ParseNodes(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            var match = Regex.Match(line, @"^([A-Z\d]+) = \(([A-Z\d]+), ([A-Z\d]+)\)$");

            yield return new Node(
                match.Groups[1].Value,
                match.Groups[2].Value,
                match.Groups[3].Value
            );
        }
    }

    private class Map(IList<char> instructions, IDictionary<string, Node> nodes)
    {
        public IList<char> Instructions { get; } = instructions;
        public IDictionary<string, Node> Nodes { get; } = nodes;
    }

    private class Node(string name, string left, string right)
    {
        public string Name { get; } = name;
        public string Left { get; } = left;
        public string Right { get; } = right;
    }
}