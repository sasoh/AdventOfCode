using Advent_of_Code;

namespace Advent_of_Code_Tests;

public class Day4Tests
{
    [TestCase("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53" +
              "\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19" +
              "\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1" +
              "\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83" +
              "\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36" +
              "\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
            13
        )
    ]
    public void SolvePart1_GivenTestData_ShouldProduceExpectedResult(string input, int expected)
    {
        var result = Day4Solver.SolvePart1(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Card 1: 41 42 43 44 45 | 83 86  6 31 16  9 48 53",
            1
        )
    ]
    [TestCase("Card 1: 41 42 43 44 45 | 83 86  6 31 17  9 48 41" +
              "\nCard 2: 12 13 14 15 16 | 61 30 68 82 17 32 24 19",
            3
        )
    ]
    [TestCase("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53" +
              "\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19" +
              "\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1" +
              "\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83" +
              "\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36" +
              "\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
            30
        )
    ]
    public void SolvePart2_GivenTestData_ShouldProduceExpectedResult(string input, int expected)
    {
        var result = Day4Solver.SolvePart2(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 4)]
    [TestCase("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
    public void GetWinningNumbersPerRow_GivenTestData_ShouldProduceExpectedResult(string input, int expected)
    {
        var result = Day4Solver.GetWinningNumbersPerRow(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}