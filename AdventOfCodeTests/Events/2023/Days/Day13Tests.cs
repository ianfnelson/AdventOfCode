using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day13Tests
{
    private readonly Day13 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("405", _systemUnderTest.Part1("Events/2023/TestData/13.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("400", _systemUnderTest.Part2("Events/2023/TestData/13.txt"));
    }
}