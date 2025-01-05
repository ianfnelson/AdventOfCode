using AdventOfCode.Events._2024.Days;

namespace AdventOfCodeTests.Events._2024.Days;

[TestFixture]
public class Day24Tests
{
    private readonly Day24 _systemUnderTest = new();

    [TestCase("24a.txt", "4")]
    [TestCase("24b.txt", "2024")]
    public void Part1Test(string filename, string expectedResult)
    {
        Assert.That(_systemUnderTest.Part1($"Events/2024/TestData/{filename}"), Is.EqualTo(expectedResult));
    }
    
    // [Test]
    // public void Part2Test()
    // {
    //     Assert.That(_systemUnderTest.Part2("TestData/23.txt"), Is.EqualTo("co,de,ka,ta"));
    // }
}