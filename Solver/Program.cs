using Common;
using Solver;

internal class Program
{
    private static List<LogDto> _logDtos = [];

    private static async Task Main(string[] args)
    {
        List<DayPuzzle> puzzles =
    [
    new Day01.Puzzle(),
    //new Day02.Puzzle(),
    new Day03.Puzzle(),
    new Day04.Puzzle(),
    new Day05.Puzzle(),
    new Day06.Puzzle(),
    new Day07.Puzzle(),
    new Day08.Puzzle(),
    new Day09.Puzzle(),
    ];

        GenerateLogDtos(puzzles);
        List<Task> tasks = [];

        foreach (LogDto puzzle in _logDtos)
        {
            Task task = Task.Run(() =>
            {
                puzzle.Run1();
                puzzle.Run2();
            });
            tasks.Add(task);
        }

        await Task.WhenAll(tasks);

        Log();
        Console.ReadLine();
    }

    private static void GenerateLogDtos(List<DayPuzzle> puzzles)
    {
        foreach (var puzzle in puzzles)
        {
            _logDtos.Add(new LogDto(puzzle));
        }
    }

    static void Log()
    {
        Console.Clear();
        foreach (LogDto log in _logDtos)
        {
            Console.WriteLine($"== {log.Puzzle.GetType().FullName} ==");
            Console.WriteLine($"Part1 : {log.Result1}  (in {log.Ms1} ms)");
            Console.WriteLine($"Part2 : {log.Result2}  (in {log.Ms2} ms)");
            Console.WriteLine();
        }
    }
}