using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day23Tests
{
    private readonly Day23 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("7", _systemUnderTest.Part1("Events/2024/TestData/23.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("co,de,ka,ta", _systemUnderTest.Part2("Events/2024/TestData/23.txt"));
    }
}