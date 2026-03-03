using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

public class Day22Tests
{
    private readonly Day22 _systemUnderTest = new();

    [Theory]
    [InlineData(123, 15887950)]
    [InlineData(15887950, 16495136)]
    [InlineData(16495136, 527345)]
    [InlineData(527345, 704524)]
    [InlineData(704524, 1553684)]
    [InlineData(1553684, 12683156)]
    [InlineData(12683156, 11100544)]
    [InlineData(11100544, 12249484)]
    [InlineData(12249484, 7753432)]
    [InlineData(7753432, 5908254)]
    public void SecretNumberGenerator_GenerateNext(long input, long expected)
    {
        var generator = new Day22.SecretNumberGenerator();

        var next = Day22.SecretNumberGenerator.GenerateNext(input);

        Assert.Equal(expected, next);
    }

    [Theory]
    [InlineData(1, 8685429)]
    [InlineData(10, 4700978)]
    [InlineData(100, 15273692)]
    [InlineData(2024, 8667524)]
    public void SecretNumberGenerator_GenerateNth(long input, long expected)
    {
        var generator = new Day22.SecretNumberGenerator();

        var nth = Day22.SecretNumberGenerator.GenerateNth(input, 2000);

        Assert.Equal(expected, nth);
    }

    [Fact]
    public void Part1Test()
    {
        Assert.Equal("37327623", _systemUnderTest.Part1("Events/2024/TestData/22.txt"));
    }
}