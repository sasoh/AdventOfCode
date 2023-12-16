using Advent_of_Code;

namespace Advent_of_Code_Tests;

public class Day3Tests
{
    [TestCase("467..114.." +
              "\n...*......" +
              "\n..35..633.",
            502
        )
    ]
    [TestCase("467..114.." +
              "\n...*......" +
              "\n..35..633." +
              "\n......#..." +
              "\n617*......" +
              "\n.....+.58." +
              "\n..592....." +
              "\n......755." +
              "\n...$.*...." +
              "\n.664.598..",
            4361
        )
    ]
    [TestCase(
            ".....114.." +
              "\n...*35...." +
              "\n..35..633.",
            70
        )
    ]
    public void FindPartSum_GivenInput_ShouldProduceExpectedResult(string input, int expected)
    {
        var partSum = Day3Solver.FindPartSum(input);

        Assert.That(partSum, Is.EqualTo(expected));
    }
    
    [TestCase("467..114.." +
              "\n...*......" +
              "\n..35..633." +
              "\n......#..." +
              "\n617*......" +
              "\n.....+.58." +
              "\n..592....." +
              "\n......755." +
              "\n...$.*...." +
              "\n.664.598..",
            467835
        )
    ]
    public void FindGearRatioSum_GivenInput_ShouldProduceExpectedResult(string input, int expected)
    {
        var partSum = Day3Solver.FindGearRatioSum(input);

        Assert.That(partSum, Is.EqualTo(expected));
    }
}