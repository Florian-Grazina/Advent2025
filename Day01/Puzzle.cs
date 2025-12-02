using Common;

namespace Day01
{
    public class Puzzle : IDayPuzzle
    {
        public int SolvePart1()
        {
            Part1Solver solver = new (GetInput());
            return solver.Solve();
        }

        public int SolvePart2()
        {
            Part2Solver solver = new (GetInput());
            return solver.Solve();
        }

        private static IEnumerable<string> GetInput()
        {
            var input = File.ReadAllText("../../../../Day01/input.txt");
            return input.Split("\r\n");
        }

    }
}
