using Common;
using static Day04.PartSolver;

namespace Day04
{
    public class Puzzle : IDayPuzzle
    {
        public long SolvePart1()
        {
            Part1Solver solver = new(GetInput());
            return solver.Solve();
        }

        public long SolvePart2()
        {
            Part2Solver solver = new(GetInput());
            return solver.Solve();
        }

        private static IEnumerable<string> GetInput()
        {
            var input = File.ReadAllText("../../../../Day04/input.txt");
            var lines = input.Split("\r\n");
            return lines;
        }
    }
}
