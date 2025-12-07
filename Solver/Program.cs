using Common;
using Solver;
using System.Collections.Concurrent;

internal class Program
{
    private static List<LogDto> _logDtos = [];
    private static readonly BlockingCollection<Action> _logQueue = new();

    private static void Main(string[] args)
    {
        Task.Run(() =>
        {
            foreach (var action in _logQueue.GetConsumingEnumerable())
                action();
        });

        List<DayPuzzle> puzzles =
    [
    new Day01.Puzzle(),
    new Day02.Puzzle(),
    new Day03.Puzzle(),
    new Day04.Puzzle(),
    new Day05.Puzzle(),
    new Day06.Puzzle(),
    ];

        GenerateLogDtos(puzzles);

        foreach (LogDto puzzle in _logDtos)
        {
            _ = Task.Run(() =>
            {
                puzzle.Run1();
                _logQueue.Add(Log);
                puzzle.Run2();
                _logQueue.Add(Log);
            });

        }
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