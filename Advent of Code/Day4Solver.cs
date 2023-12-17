namespace Advent_of_Code;

public static class Day4Solver
{
    public static int Solve(string input)
    {
        var pointsSum = 0;
        var rows = input.Split("\n");
        foreach (var row in rows)
        {
            pointsSum += GetPointsPerRow(row);
        }

        return pointsSum;
    }

    public static int GetPointsPerRow(string input)
    {
        var cardAndData = input.Split(":");
        var data = cardAndData[1].Split("|");
        var winning =  data[0].Trim().Split(" ");
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

        return (int) Math.Pow(2, currentNumbers.Count - 1);
    }
}