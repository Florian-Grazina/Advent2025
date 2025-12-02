using Common;

namespace Day02
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
            var input = File.ReadAllText("../../../../Day02/input.txt");
            var lines = input.Split("\r\n");
            return lines.SelectMany(l => l.Split(",")).Where(data => !string.IsNullOrEmpty(data));
        }
    }
}
