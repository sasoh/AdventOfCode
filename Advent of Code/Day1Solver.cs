namespace Advent_of_Code;

public class Day1Solver
{
    private static readonly Dictionary<string, string> TextToDigitDictionary = new()
    {
        {"one", "1"},
        {"two", "2"},
        {"three", "3"},
        {"four", "4"},
        {"five", "5"},
        {"six", "6"},
        {"seven", "7"},
        {"eight", "8"},
        {"nine", "9"}
    };

    public int Solve(string input)
    {
        var splitByNewline = input.Split("\n");
        return splitByNewline.Sum(ParseLine);
    }

    private static int ParseLine(string input)
    {
        var firstDigit = "";
        var lastDigit = "";
        for (var i = 0; i < input.Length; i++)
        {
            if (string.IsNullOrEmpty(firstDigit) && TryGetDigit(input, i, out var digitFromStart))
            {
                firstDigit = digitFromStart;
            }

            if (string.IsNullOrEmpty(lastDigit) && TryGetDigit(input, input.Length - i - 1, out var digitFromEnd))
            {
                lastDigit = digitFromEnd;
            }

            if (!string.IsNullOrEmpty(firstDigit) && !string.IsNullOrEmpty(lastDigit))
            {
                break;
            }
        }

        return int.Parse(firstDigit + lastDigit);
    }

    private static bool TryGetDigit(string input, int index, out string digit)
    {
        digit = "";

        if (char.IsDigit(input[index]))
        {
            digit = input[index].ToString();
            return true;
        }

        var substring = input[index..];
        foreach (var (digitKey, digitValue) in TextToDigitDictionary)
        {
            if (!substring.StartsWith(digitKey)) continue;
            digit = digitValue;
            return true;
        }

        return false;
    }
}