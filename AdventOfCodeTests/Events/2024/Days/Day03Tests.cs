using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day03Tests
{
    [Fact]
    public void Section_Parse_Part1ResultAsExpected()
    {
        var section = Day03.Memory.Parse(["xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"]);

        Assert.Equal(161, section.Part1Result);
    }

    [Fact]
    public void Section_Parse_Part2ResultAsExpected()
    {
        var section = Day03.Memory.Parse(["xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"]);

        Assert.Equal(48, section.Part2Result);
    }
}