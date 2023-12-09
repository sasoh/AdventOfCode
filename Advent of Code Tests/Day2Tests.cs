using Advent_of_Code;

namespace Advent_of_Code_Tests;

public class Day2Tests
{
    private const int MaxRed = 12;
    private const int MaxGreen = 13;
    private const int MaxBlue = 14;

    [TestCase("3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
    [TestCase("1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
    [TestCase("8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false)]
    [TestCase("1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", false)]
    [TestCase("6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", true)]
    [TestCase("2 green, 3 blue, 5 red; 9 green, 4 red, 2 blue; 4 green, 3 blue; 2 blue, 3 red; 5 red, 3 blue, 9 green; 9 green, 5 red, 2 blue", true)]
    public void IsGamePossible_GivenString_ShouldReturnExpectedValue(string input, bool expected)
    {
        var sut = new Day2Solver();

        var result = sut.IsGamePossible(input, MaxRed, MaxGreen, MaxBlue);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day2Solve_GivenString_ShouldReturnExpectedSum()
    {
        const string input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
        const int expectedSum = 8;
        var sut = new Day2Solver();

        var result = sut.SumPossibleGameIds(input, MaxRed, MaxGreen, MaxBlue);

        Assert.That(result, Is.EqualTo(expectedSum));
    }
}