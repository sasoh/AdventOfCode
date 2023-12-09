namespace Advent_of_Code;

public class Day2Solver
{
    public bool IsGamePossible(
        string samples,
        int maxRed,
        int maxGreen,
        int maxBlue,
        out int minRed,
        out int minGreen,
        out int minBlue
    )
    {
        var samplesList = samples.Split(";");

        minRed = 0;
        minGreen = 0;
        minBlue = 0;
        
        foreach (var sample in samplesList)
        {
            var redCount = 0;
            var greenCount = 0;
            var blueCount = 0;

            var sampleElementsList = sample.Split(",");
            foreach (var sampleElement in sampleElementsList)
            {
                var trimmedSampleElement = sampleElement.Trim();
                var countAndColor = trimmedSampleElement.Split(" ");
                if (!int.TryParse(countAndColor[0], out var count)) continue;
                if (countAndColor[1] == "red")
                {
                    redCount += count;
                }
                else if (countAndColor[1] == "green")
                {
                    greenCount += count;
                }
                else if (countAndColor[1] == "blue")
                {
                    blueCount += count;
                }

                if (redCount > minRed)
                {
                    minRed = redCount;
                }
                if (greenCount > minGreen)
                {
                    minGreen = greenCount;
                }
                if (blueCount > minBlue)
                {
                    minBlue = blueCount;
                }

                if (redCount > maxRed || greenCount > maxGreen || blueCount > maxBlue)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public int SumPossibleGameIds(string input, int maxRed, int maxGreen, int maxBlue)
    {
        var sum = 0;
        var lines = input.Split("\n");
        foreach (var line in lines)
        {
            var gameAndData = line.Split(":");
            var samples = gameAndData[1].Trim();
            if (!IsGamePossible(samples, maxRed, maxGreen, maxBlue, out _, out _, out _)) continue;
            
            var game = gameAndData[0];
            var gameAndId = game.Split(" ");
            if (!int.TryParse(gameAndId[1], out var id)) continue;
            sum += id;
        }

        return sum;
    }

    public int Power(string input)
    {
        var power = 0;
        var lines = input.Split("\n");
        foreach (var line in lines)
        {
            var gameAndData = line.Split(":");
            var samples = gameAndData[1].Trim();
            if (!IsGamePossible(
                    samples,
                    int.MaxValue,
                    int.MaxValue,
                    int.MaxValue,
                    out var minRed,
                    out var minGreen,
                    out var minBlue
                )) continue;

            power += Math.Max(1, minRed) * Math.Max(1, minGreen) * Math.Max(1, minBlue);
        }

        return power;
    }
}