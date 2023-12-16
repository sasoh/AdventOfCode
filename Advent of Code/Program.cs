using System.Diagnostics;
using Advent_of_Code;

var stopwatch = Stopwatch.StartNew();

var result = Day3Solver.FindPartSum(PuzzleData.Day3Data);

stopwatch.Stop();
Console.WriteLine($"Result = {result}");
Console.WriteLine($"Calculation took {stopwatch.ElapsedMilliseconds} ms");