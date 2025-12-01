
using Common;

List<DayPuzzle> puzzles =
    [
    null
    ];

foreach (DayPuzzle puzzle in puzzles)
{
    puzzle?.SolvePart1();
    puzzle?.SolvePart2();

}

void Log(string message)
{
    Console.WriteLine(message);
}