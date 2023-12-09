using Advent_of_Code;

namespace Advent_of_Code_Tests;

public class Day1Tests
{
    [TestCase("1a2", 12)]
    [TestCase("treb7uchet", 77)]
    [TestCase("a1b2c3d4e5f", 15)]
    [TestCase("793", 73)]
    [TestCase("1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet", 142)]
    [TestCase("two1nine", 29)]
    [TestCase("eightwothree", 83)]
    [TestCase("zoneight234", 14)]
    [TestCase("two1nine\neightwothree\nabcone2threexyz\nxtwone3four\n4nineeightseven2\nzoneight234\n7pqrstsixteen", 281)]
    public void Day1Solve_GivenString_ShouldReturnExpectedSum(string input, int expected)
    {
        var sut = new Day1Solver();

        var result = sut.Solve(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}