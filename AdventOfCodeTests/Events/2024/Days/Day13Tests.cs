using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day13Tests
{
    private readonly Day13 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("480", _systemUnderTest.Part1("Events/2024/TestData/13.txt"));
    }
}