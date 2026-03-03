using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day02Tests
{
    private readonly Day02 _systemUnderTest = new();

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("2", _systemUnderTest.Part1("Events/2024/TestData/2.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        Assert.Equal("4", _systemUnderTest.Part2("Events/2024/TestData/2.txt"));
    }

    [Fact]
    public void Report_IsSafe_LevelsAreSteadilyIncreasing_Safe()
    {
        var sut = Day02.Report.Parse("1 3 6 7 9");

        Assert.True(sut.IsSafe);
    }

    [Fact]
    public void Report_IsSafe_LevelsAreSteadilyDecreasing_Safe()
    {
        var sut = Day02.Report.Parse("7 6 4 2 1");

        Assert.True(sut.IsSafe);
    }

    [Fact]
    public void Report_IsSafe_LevelsIncreaseByMoreThanThree_Unsafe()
    {
        var sut = Day02.Report.Parse("1 5 6 7 9");

        Assert.False(sut.IsSafe);
    }

    [Fact]
    public void Report_IsSafe_LevelsDecreaseByMoreThanThree_Unsafe()
    {
        var sut = Day02.Report.Parse("9 7 6 5 1");

        Assert.False(sut.IsSafe);
    }

    [Fact]
    public void Report_IsSafe_LevelsIncreaseAndDecrease_Unsafe()
    {
        var sut = Day02.Report.Parse("1 3 6 4 5");

        Assert.False(sut.IsSafe);
    }

    [Fact]
    public void Report_IsSafe_LevelsRemainTheSame_Unsafe()
    {
        var sut = Day02.Report.Parse("1 3 3 4 5");

        Assert.False(sut.IsSafe);
    }

    [Fact]
    public void Report_IsSafeWithDampener_WasSafe_Safe()
    {
        var sut = Day02.Report.Parse("7 6 4 2 1");

        Assert.True(sut.IsSafeWithDampener);
    }


    [Fact]
    public void Report_IsSafeWithDampener_LevelsIncreaseByMoreThanThree_Unsafe()
    {
        var sut = Day02.Report.Parse("1 2 7 8 9");

        Assert.False(sut.IsSafeWithDampener);
    }

    [Fact]
    public void Report_IsSafeWithDampener_LevelsDecreaseByMoreThanThree_Unsafe()
    {
        var sut = Day02.Report.Parse("9 7 6 2 1");

        Assert.False(sut.IsSafeWithDampener);
    }

    [Fact]
    public void Report_IsSafeWithDampener_OneDeltaOfZero_Safe()
    {
        var sut = Day02.Report.Parse("8 6 4 4 1");

        Assert.True(sut.IsSafeWithDampener);
    }

    [Fact]
    public void Report_IsSafeWithDampener_OneAnomalousDirection_Safe()
    {
        var sut = Day02.Report.Parse("1 3 4 2 5");

        Assert.True(sut.IsSafeWithDampener);
    }
}