using System.Diagnostics;
using Advent_of_Code;

var stopwatch = Stopwatch.StartNew();

var result = Day3Solver.FindGearRatioSum(PuzzleData.Day3Data);
var expected = 79844424;

stopwatch.Stop();
Console.WriteLine($"Result = {result} expected {result == expected}");
Console.WriteLine($"Calculation took {stopwatch.ElapsedMilliseconds} ms");