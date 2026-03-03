using AdventOfCode.Events._2019.Days;

namespace AdventOfCodeTests.Events._2019.Days;

public class Day01Tests
{
    [Theory]
    [InlineData(12, 2)]
    [InlineData(14, 2)]
    [InlineData(1969, 654)]
    [InlineData(100756, 33583)]
    public void Module_FuelCalculation_Part1(int mass, int expectedFuel)
    {
        var sut = new Day01.Module(mass);

        Assert.Equal(expectedFuel, sut.FuelRequirement(false));
    }

    [Theory]
    [InlineData(12, 2)]
    [InlineData(14, 2)]
    [InlineData(1969, 966)]
    [InlineData(100756, 50346)]
    public void Module_FuelCalculation_Part2(int mass, int expectedFuel)
    {
        var sut = new Day01.Module(mass);

        Assert.Equal(expectedFuel, sut.FuelRequirement(true));
    }
}