using Common;

namespace Solver
{
    internal class LogDto (DayPuzzle puzzle)
    {
        public DayPuzzle Puzzle { get; set; } = puzzle;
        public long? Result1 { get; set; }
        public long? Ms1 { get; set; }

        public long? Result2 { get; set; }
        public long? Ms2 { get; set; }

        public void Run1()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            Result1 = Puzzle.SolvePart1();
            sw.Stop();
            Ms1 = sw.ElapsedMilliseconds;
        }

        public void Run2()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            Result2 = Puzzle.SolvePart2();
            sw.Stop();
            Ms2 = sw.ElapsedMilliseconds;
        }
    }
}
