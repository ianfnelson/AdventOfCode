using AdventOfCode.Events._2025.Days;

namespace AdventOfCodeTests.Events._2025.Days;

public class Day06Tests
{
    private readonly Day06 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("4277556", _systemUnderTest.Part1("Events/2025/TestData/6.txt"));
    }

    // [Fact]
    // public void Part2Test()
    // {
    //     Assert.Equal("14", _systemUnderTest.Part2("Events/2025/TestData/5.txt"));
    // }
}