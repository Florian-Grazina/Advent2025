using Common;

internal class Program
{
    private static void Main(string[] args)
    {
        List<IDayPuzzle> puzzles =
    [
    //new Day01.Puzzle(),
    //new Day02.Puzzle(),
    new Day03.Puzzle(),
    new Day04.Puzzle(),
    ];

        foreach (IDayPuzzle puzzle in puzzles)
        {
            Console.WriteLine($"== {puzzle.GetType().FullName} ==");

            LogPart("Part 1", puzzle.SolvePart1);
            LogPart("Part 2", puzzle.SolvePart2);

            Console.WriteLine();
        }

        static void LogPart(string label, Func<long> solve)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            long result = solve();
            sw.Stop();

            Console.WriteLine($"{label}: {result}  (in {sw.ElapsedMilliseconds} ms)");
        }
    }
}