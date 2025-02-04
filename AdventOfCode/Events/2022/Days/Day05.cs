using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Events._2022.Days;

public class Day05 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        var puzzle = Puzzle.Parse(inputData.ToList());
        
        puzzle.MoveCrates(1);

        return puzzle.TopCrates;
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        var puzzle = Puzzle.Parse(inputData.ToList());
        
        puzzle.MoveCrates(2);

        return puzzle.TopCrates;
    }

    public class Puzzle(Dictionary<int, Stack<char>> stacks, List<Puzzle.Instruction> instructions)
    {
        public static Puzzle Parse(List<string> inputData)
        {
            var separatorIndex = inputData.FindIndex(string.IsNullOrWhiteSpace);

            var stacks = ParseStacks(inputData, separatorIndex);
            var instructions = ParseInstructions(inputData, separatorIndex);

            return new Puzzle(stacks, instructions);
        }

        private static Dictionary<int, Stack<char>> ParseStacks(List<string> inputData, int separatorIndex)
        {
            var stackCount = (inputData[separatorIndex - 1].Length+1) / 4;
            var stacks = Enumerable
                .Range(1, stackCount)
                .ToDictionary(x => x, x => new Stack<char>());
            
            for (var line = separatorIndex-2; line >= 0; line--)
            {
                for (var stack = 1; stack <= stackCount; stack++)
                {
                    var character = inputData[line][stack * 4 - 3];
                    if (!char.IsWhiteSpace(character))
                    {
                        stacks[stack].Push(character);
                    }
                }
            }

            return stacks;
        }

        private static List<Instruction> ParseInstructions(List<string> inputData, int separatorIndex)
        {
            var instructions = new List<Instruction>();
            
            var regex = new Regex(@"\d+");

            for (var line = separatorIndex + 1; line < inputData.Count; line++)
            {
                var matches = regex.Matches(inputData[line]);

                var count = int.Parse(matches[0].Value);
                var from = int.Parse(matches[1].Value);
                var to = int.Parse(matches[2].Value);
                
                instructions.Add(new Instruction(count, from,to));
            }

            return instructions;
        }

        private Dictionary<int, Stack<char>> Stacks { get; } = stacks;

        private List<Instruction> Instructions { get;} = instructions;

        public class Instruction(int count, int from, int to)
        {
            public int Count { get; set; } = count;

            public int From { get; set; } = from;

            public int To { get; set; } = to;
        }

        public void MoveCrates(int part)
        {
            foreach (var instruction in Instructions)
            {
                if (part == 1)
                {
                    MoveCratesPart1(instruction);
                }
                else
                {
                    MoveCratesPart2(instruction);
                }
            }
        }

        private void MoveCratesPart1(Instruction instruction)
        {
            for (var i = 0; i < instruction.Count; i++)
            {
                Stacks[instruction.To].Push(Stacks[instruction.From].Pop());
            }
        }

        private void MoveCratesPart2(Instruction instruction)
        {
            var tempStack = new Stack<char>();

            for (var i = 0; i < instruction.Count; i++)
            {
                tempStack.Push(Stacks[instruction.From].Pop());
            }
            
            for (var i = 0; i < instruction.Count; i++)
            {
                Stacks[instruction.To].Push(tempStack.Pop());
            }
        }
        
        public string TopCrates
        {
            get
            {
                var sb = new StringBuilder();

                foreach (var stack in Stacks)
                {
                    if (stack.Value.Count > 0)
                    {
                        sb.Append(stack.Value.Peek());
                    }
                }

                return sb.ToString();
            }
        }
    }
    
    public override int Day => 5;
}