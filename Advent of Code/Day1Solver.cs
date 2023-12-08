namespace Advent_of_Code
{
    public class Day1Solver
    {
        public int Solve1(string input)
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
                if (char.IsDigit(input[i]) && string.IsNullOrEmpty(firstDigit))
                {
                    firstDigit = input[i].ToString();
                }

                if (char.IsDigit(input[input.Length - i - 1]) && string.IsNullOrEmpty(lastDigit))
                {
                    lastDigit = input[input.Length - i - 1].ToString();
                }

                if (!string.IsNullOrEmpty(firstDigit) && !string.IsNullOrEmpty(lastDigit))
                {
                    break;
                }
            }

            return int.Parse(firstDigit + lastDigit);
        }
    }
}