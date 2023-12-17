using System.Diagnostics;
using Advent_of_Code;

var stopwatch = Stopwatch.StartNew();

var result = Day4Solver.Solve(PuzzleData.Day4Data);
var expected = 21213;

stopwatch.Stop();
Console.WriteLine($"Result = {result} expected {result == expected}");
Console.WriteLine($"Calculation took {stopwatch.ElapsedMilliseconds} ms");