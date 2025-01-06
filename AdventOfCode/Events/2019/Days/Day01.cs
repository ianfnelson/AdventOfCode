namespace AdventOfCode.Events._2019.Days;

public class Day01 : DayBase
{
    protected override string Part1(IEnumerable<string> inputData)
    {
        return inputData
            .Select(x => new Module(int.Parse(x)))
            .Sum(x => x.FuelRequirement(false))
            .ToString();
    }

    protected override string Part2(IEnumerable<string> inputData)
    {
        return inputData
            .Select(x => new Module(int.Parse(x)))
            .Sum(x => x.FuelRequirement(true))
            .ToString();
    }

    public class Module(int mass)
    {
        public int Mass { get; } = mass;

        public int FuelRequirement(bool fuelRequiresFuel)
        {
            var totalFuel = FuelCalculation(Mass);
            var nextFuel = totalFuel;
            
            while (fuelRequiresFuel && nextFuel > 0)
            {
                nextFuel = FuelCalculation(nextFuel);
                totalFuel += nextFuel;
            }

            return totalFuel;
        }

        private static int FuelCalculation(int mass)
        {
            var calc = mass / 3 - 2;
            return calc <= 0 ? 0 : calc;
        }
    }

    public override int Day => 1;
}