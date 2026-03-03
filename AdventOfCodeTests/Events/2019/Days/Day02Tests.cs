using AdventOfCode.Events._2019.Days;

namespace AdventOfCodeTests.Events._2019.Days;

public class Day02Tests
{
    [Theory]
    [InlineData("1,0,0,0,99","2,0,0,0,99")]
    [InlineData("2,3,0,3,99","2,3,0,6,99")]
    [InlineData("2,4,4,5,99,0","2,4,4,5,99,9801")]
    [InlineData("1,1,1,4,99,5,6,0,99","30,1,1,4,2,5,6,0,99")]
    public void Computer_Run_Part1(string input, string expectedOutput)
    {
        var sut = new Day02.Computer();

        sut.Program(input);

        sut.Run();

        Assert.Equal(expectedOutput, sut.ToString());
    }
}