namespace Advent_of_Code;

public static class Day3Solver
{
    public static int FindPartSum(string input)
    {
        var rows = input.Split("\n");
        var schematicArray = new string[rows.Length, rows[0].Length];
        CopyRowsToArray(rows, schematicArray);

        var parts = new List<int>();
        for (var row = 0; row < rows.Length; row++)
        {
            var currentRow = rows[row];
            for (var column = 0; column < currentRow.Length; column++)
            {
                var currentCharacter = currentRow[column];
                if (char.IsDigit(currentCharacter) || char.IsLetter(currentCharacter) || currentCharacter == '.') continue;
                var adjacentPartsSum = GetAdjacentPartsSum(schematicArray, row, column);
                parts.Add(adjacentPartsSum);
            }
        }
        
        return parts.Sum();
    }

    public static int FindGearRatioSum(string input)
    {        
        var rows = input.Split("\n");
        var schematicArray = new string[rows.Length, rows[0].Length];
        CopyRowsToArray(rows, schematicArray);
        
        var gearRatios = new List<int>();
        for (var row = 0; row < rows.Length; row++)
        {
            var currentRow = rows[row];
            for (var column = 0; column < currentRow.Length; column++)
            {
                var currentCharacter = currentRow[column];
                if (char.IsDigit(currentCharacter) || char.IsLetter(currentCharacter) || currentCharacter == '.') continue;
                gearRatios.Add(GetGearRatio(schematicArray, row, column));
            }
        }
        
        return gearRatios.Sum();
    }

    private static int GetGearRatio(string[,] array, int row, int column)
    {
        var neighbourCoordinateOffset = new[]
        {
            new []{-1, -1},
            new []{0, -1},
            new []{1, -1},
            new []{-1, 0},
            new []{1, 0},
            new []{-1, 1},
            new []{0, 1},
            new []{1, 1},
        };
        
        // Get unique number ranges.
        var rangesWithRows = new HashSet<(Range, int)>();
        foreach (var coordinateOffset in neighbourCoordinateOffset)
        {
            var adjacentRow = row + coordinateOffset[0];
            var adjacentColumn = column + coordinateOffset[1];

            var adjacentCharacter = array[adjacentRow, adjacentColumn];
            if (!char.IsDigit(adjacentCharacter[0])) continue;
            
            var numberRange = NumberRangeFromDigit(array, adjacentRow, adjacentColumn);
            var rangeWithRow = (Range: numberRange, Row: adjacentRow);
            rangesWithRows.Add(rangeWithRow);
        }

        if (rangesWithRows.Count != 2 || array[row, column][0] != '*') return 0;
        return rangesWithRows.Select(rangeWithRow => NumberFromRange(rangeWithRow.Item1, array, rangeWithRow.Item2)).Aggregate(1, (current, number) => current * number);
    }

    private static int GetAdjacentPartsSum(string[,] array, int row, int column)
    {
        var neighbourCoordinateOffset = new[]
        {
            new []{-1, -1},
            new []{0, -1},
            new []{1, -1},
            new []{-1, 0},
            new []{1, 0},
            new []{-1, 1},
            new []{0, 1},
            new []{1, 1},
        };
        
        // Get unique number ranges.
        var rangesWithRows = new HashSet<(Range, int)>();
        foreach (var coordinateOffset in neighbourCoordinateOffset)
        {
            var adjacentRow = row + coordinateOffset[0];
            var adjacentColumn = column + coordinateOffset[1];

            var adjacentCharacter = array[adjacentRow, adjacentColumn];
            if (!char.IsDigit(adjacentCharacter[0])) continue;
            
            var numberRange = NumberRangeFromDigit(array, adjacentRow, adjacentColumn);
            var rangeWithRow = (Range: numberRange, Row: adjacentRow);
            rangesWithRows.Add(rangeWithRow);
        }

        return rangesWithRows.Sum(rangeWithRow => NumberFromRange(rangeWithRow.Item1, array, rangeWithRow.Item2));
    }

    private static int NumberFromRange(Range numberRange, string[,] array, int row)
    {
        var numberAsString = "";
        for (var i = numberRange.Start.Value; i <= numberRange.End.Value; i++)
        {
            numberAsString += array[row, i];
        }

        return int.Parse(numberAsString);
    }

    private static Range NumberRangeFromDigit(string[,] array, int row, int column)
    {
        var start = new Index(column);
        var end = new Index(column);

        // look for digits in left & right from starting point
        if (column > 0)
        {
            for (var i = column - 1; i >= 0; i--)
            {
                var previousCharacter = array[row, i];
                if (!char.IsDigit(previousCharacter[0])) break;
                start = new Index(i);
            }
        }
        
        if (column < array.GetLength(1) - 1)
        {
            for (var i = column + 1; i < array.GetLength(1); i++)
            {
                var nextCharacter = array[row, i];
                if (!char.IsDigit(nextCharacter[0])) break;
                end = new Index(i);
            }
        }

        return new Range(start, end);
    }

    private static void CopyRowsToArray(IReadOnlyList<string> rows, string[,] array)
    {
        for (var row = 0; row < rows.Count; row++)
        {
            var currentRow = rows[row];
            for (var column = 0; column < currentRow.Length; column++)
            {
                array[row, column] = currentRow[column].ToString();
            }
        }
    }
}