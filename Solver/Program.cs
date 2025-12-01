
using Common;

List<IDayPuzzle> puzzles =
    [
    new Day01.Puzzle(),
    ];

foreach (IDayPuzzle puzzle in puzzles)
{
    Console.WriteLine($"== {puzzle.GetType().Name} ==");

    LogPart("Part 1", puzzle.SolvePart1);
    LogPart("Part 2", puzzle.SolvePart2);

    Console.WriteLine();
}

static void LogPart(string label, Func<int> solve)
{
    var sw = System.Diagnostics.Stopwatch.StartNew();
    int result = solve();
    sw.Stop();

    Console.WriteLine($"{label}: {result}  (in {sw.ElapsedMilliseconds} ms)");
}