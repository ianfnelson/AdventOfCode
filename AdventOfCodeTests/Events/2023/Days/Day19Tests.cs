using AdventOfCode.Events._2023.Days;

namespace AdventOfCodeTests.Events._2023.Days;

public class Day19Tests
{
    private readonly Day19 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("19114", _systemUnderTest.Part1("Events/2023/TestData/19.txt"));
    }

    // [Fact]
    // public void Part2Test()
    // {
    //     Assert.Equal("167409079868000", _systemUnderTest.Part2("TestData/19.txt"));
    // }
}