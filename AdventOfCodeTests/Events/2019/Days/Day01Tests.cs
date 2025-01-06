using AdventOfCode.Events._2019.Days;

namespace AdventOfCodeTests.Events._2019.Days;

[TestFixture]
public class Day01Tests
{
    [TestCase(12, 2)]
    [TestCase(14, 2)]
    [TestCase(1969, 654)]
    [TestCase(100756, 33583)]
    public void Module_FuelCalculation_Part1(int mass, int expectedFuel)
    {
        var sut = new Day01.Module(mass);
        
        Assert.That(sut.FuelRequirement(false), Is.EqualTo(expectedFuel));
    }
    
    [TestCase(12, 2)]
    [TestCase(14, 2)]
    [TestCase(1969, 966)]
    [TestCase(100756, 50346)]
    public void Module_FuelCalculation_Part2(int mass, int expectedFuel)
    {
        var sut = new Day01.Module(mass);
        
        Assert.That(sut.FuelRequirement(true), Is.EqualTo(expectedFuel));
    }
}