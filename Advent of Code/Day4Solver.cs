namespace Advent_of_Code;

public static class Day4Solver
{
    public static int SolvePart1(string input)
    {
        var pointsSum = 0;
        var rows = input.Split("\n");
        foreach (var row in rows)
        {
            pointsSum += (int) Math.Pow(2, GetWinningNumbersPerRow(row) - 1);
        }

        return pointsSum;
    }

    public static int SolvePart2(string input)
    {
        var rows = input.Split("\n");
        var cards = new int[rows.Length];
        for (var i = 0; i < rows.Length; i++)
        {
            cards[i] += 1;
            var pointsPerRow = GetWinningNumbersPerRow(rows[i]);
            if (pointsPerRow == 0) continue;

            for (var j = 0; j < cards[i]; j++)
            {
                for (var k = 1; k <= pointsPerRow; k++)
                {
                    cards[i + k] += 1;
                }
            }
        }

        return cards.Sum();
    }

    public static int GetWinningNumbersPerRow(string input)
    {
        var cardAndData = input.Split(":");
        var data = cardAndData[1].Split("|");
        var winning = data[0].Trim().Split(" ");
        var current = data[1].Trim().Split(" ");

        var winningNumbers = new HashSet<int>();
        foreach (var number in winning)
        {
            if (string.IsNullOrEmpty(number)) continue;
            winningNumbers.Add(int.Parse(number));
        }

        var currentNumbers = new HashSet<int>();
        foreach (var number in current)
        {
            if (string.IsNullOrEmpty(number)) continue;
            currentNumbers.Add(int.Parse(number));
        }

        currentNumbers.IntersectWith(winningNumbers);

        return currentNumbers.Count;
    }
}