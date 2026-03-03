using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day16Tests
{
    private readonly Day16 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("46", _systemUnderTest.Part1("Events/2023/TestData/16.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("51", _systemUnderTest.Part2("Events/2023/TestData/16.txt"));
    }
}