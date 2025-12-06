namespace AdventOfCode.Events._2025.Days;

public class Day06 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        var puzzle = new Puzzle(inputData.ToList());
        return puzzle.Problems.Sum(x => x.Result).ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        throw new NotImplementedException();
    }

    public class Puzzle
    {
        public Puzzle(IList<string> inputData)
        {
            var lineCounter = 0;

            do
            {
                var numbers = inputData[lineCounter]
                    .Split(default(char[]), StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToList();

                if (lineCounter == 0)
                {
                    Problems = Enumerable.Range(1, numbers.Count).Select(x => new Problem()).ToList();
                }

                for (var i = 0; i < numbers.Count; i++)
                {
                    Problems[i].Operands.Add(numbers[i]);
                }
                
                lineCounter++;
            } while (lineCounter< inputData.Count-1);
            
            var operators = inputData[lineCounter]
                .Split(default(char[]), StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x =="*" ? Operator.Multiplication : Operator.Addition)
                .ToList();

            for (var i = 0; i < operators.Count; i++)
            {
                Problems[i].Operator = operators[i];
            }
        }

        public List<Problem> Problems { get; set; } = [];
        
        public class Problem
        {
            public List<long> Operands { get; set; } = [];
            
            public Operator Operator { get; set; }

            public long Result
            {
                get
                {
                    return Operator == Operator.Addition ?
                        Operands.Sum() : Operands.Aggregate(1L, (acc, x) => acc * x);
                }
            }
        }

        public enum Operator
        {
            Addition,
            Multiplication
        }
    }
    
    public override int Day => 6;
}