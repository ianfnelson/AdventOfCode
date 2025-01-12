namespace AdventOfCode.Events._2022.Days;

public class Day03 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        return inputData
            .Select(x => new Rucksack(x))
            .Sum(x => x.Priority)
            .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return inputData
            .Select(x => new Rucksack(x))
            .Select((rucksack, index) => new { rucksack, index })
            .GroupBy(x => x.index / 3)
            .Select(x => CommonCharacter(x.Select(y => y.rucksack.Contents)))
            .Sum(GetPriority)
            .ToString();
    }

    private class Rucksack
    {
        public Rucksack(string contents)
        {
            Contents = contents;
            
            var mid = contents.Length / 2;
            _compartment1 = contents[..mid];
            _compartment2 = contents[mid..];
        }
        
        public string Contents { get; init; }

        private readonly string _compartment1;
        private readonly string _compartment2;

        public int Priority => GetPriority(_compartment1.Intersect(_compartment2).Single());
    }

    private static char CommonCharacter(IEnumerable<string> inputs)
    {
        return inputs
            .Select(str => str.ToHashSet()) // Convert each string to a HashSet<char> for efficient intersection
            .Aggregate((set1, set2) =>
            {
                set1.IntersectWith(set2); // Retain only the characters present in both sets
                return set1;
            })
            .Single();
    }
    
    private static int GetPriority(char item)
    {
        return char.IsLower(item) ? item - 'a' + 1 : item - 'A' + 27;
    }

    public override int Day => 3;
}