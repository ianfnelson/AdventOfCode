using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day17Tests
{
    [Fact]
    public void Test1()
    {
        var computer = new Day17.Computer(0, 0, 9);

        computer.Run("2,6");

        Assert.Equal(1, computer.Register.B);
    }

    [Fact]
    public void Test2()
    {
        var computer = new Day17.Computer(10, 0, 0);

        computer.Run("5,0,5,1,5,4");

        Assert.Equal("0,1,2", computer.Output);
    }

    [Fact]
    public void Test3()
    {
        var computer = new Day17.Computer(2024, 0, 0);

        computer.Run("0,1,5,4,3,0");

        Assert.Equal("4,2,5,6,7,7,7,7,3,1,0", computer.Output);
        Assert.Equal(0, computer.Register.A);
    }

    [Fact]
    public void Test4()
    {
        var computer = new Day17.Computer(0, 29, 0);

        computer.Run("1,7");

        Assert.Equal(26, computer.Register.B);
    }

    [Fact]
    public void Test5()
    {
        var computer = new Day17.Computer(0, 2024, 43690);

        computer.Run("4,0");

        Assert.Equal(44354, computer.Register.B);
    }

    [Fact]
    public void Part1Test()
    {
        var sut = new Day17();

        Assert.Equal("4,6,3,5,6,3,5,2,1,0", sut.Part1("Events/2024/TestData/17a.txt"));
    }

    [Fact]
    public void Part2Test()
    {
        var sut = new Day17();

        Assert.Equal("117440", sut.Part2("Events/2024/TestData/17b.txt"));
    }
}