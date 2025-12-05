namespace AdventOfCode.Events._2025.Days;

public class Day05 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        var puzzle = new Puzzle(inputData.ToList());
        
        return puzzle.CountAvailableFreshIngredients().ToString(); 
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        var puzzle = new Puzzle(inputData.ToList());
        
        return puzzle.CountAllFreshIngredients().ToString(); 
    }

    private class Puzzle
    {
        public Puzzle(IList<string> inputData)
        {
            var lineCounter = 0;

            do
            {
                var parts = inputData[lineCounter].Split('-');
                FreshRanges.Add(new Range(long.Parse(parts[0]), long.Parse(parts[1])));
                lineCounter++;
            } while (inputData[lineCounter].Length > 0);

            lineCounter++;

            do
            {
                AvailableIngredients.Add(long.Parse(inputData[lineCounter]));
                lineCounter++;
            } while (lineCounter < inputData.Count);
        }

        public List<Range> FreshRanges { get; } = [];
        public List<long> AvailableIngredients { get; } = [];

        public int CountAvailableFreshIngredients()
        {
            return AvailableIngredients.Count(i => FreshRanges.Any(r => i >= r.Start && i <= r.End));
        }

        public long CountAllFreshIngredients()
        {
            var combinedRanges = new List<Range>();

            foreach (var range in FreshRanges.OrderBy(r => r.Start).ThenBy(r => r.End))
            {
                var overlappingExistingRange = combinedRanges.FirstOrDefault(r => r.End >= range.Start);
                if (overlappingExistingRange != null)
                {
                    if (range.End > overlappingExistingRange.End)
                    {
                        overlappingExistingRange.End = range.End;
                    }
                }
                else
                {
                    combinedRanges.Add(range);
                }
            }
            
            return combinedRanges.Select(c => c.Length).Sum();
        }

        public class Range(long start, long end)
        {
            public long Start { get; set; } = start;
            public long End { get; set; } = end;

            public long Length => End - Start + 1;
        }
    }

    public override int Day => 5;
}