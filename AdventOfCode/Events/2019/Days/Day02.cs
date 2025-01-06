namespace AdventOfCode.Events._2019.Days;

public class Day02 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        var computer = new Computer();
        
        computer.Program(inputData.Single());

        return computer.Execute(12, 2).ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        var program = inputData.Single();
        var computer = new Computer();
        
        for (var noun = 0; noun <= 99; noun++)
        {
            for (var verb = 0; verb < 99; verb++)
            {
                computer.Program(program);
                if (computer.Execute(noun, verb) == 19690720)
                {
                    return (100 * noun + verb).ToString();
                }
            }
        }

        throw new InvalidOperationException();
    }

    public class Computer
    {
        public void Program(string input)
        {
            _memory = input
                .Split(',')
                .Select(int.Parse)
                .ToList();
        }

        public int Execute(int noun, int verb)
        {
            _memory[1] = noun;
            _memory[2] = verb;

            Run();

            return _memory[0];
        }

        private IList<int> _memory = new List<int>();

        public void Run()
        {
            var pointer = 0;

            while (pointer < _memory.Count)
            {
                switch (_memory[pointer])
                {
                    case 1:
                        _memory[_memory[pointer + 3]] = _memory[_memory[pointer + 1]] + _memory[_memory[pointer + 2]];
                        break;
                    case 2:
                        _memory[_memory[pointer + 3]] = _memory[_memory[pointer + 1]] * _memory[_memory[pointer + 2]];
                        break;
                    case 99:
                        return;
                }

                pointer += 4;
            }
        }

        public override string ToString()
        {
            return string.Join(',', _memory);
        }
    }

    public override int Day => 2;
}