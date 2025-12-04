namespace Day04
{
    internal class PartSolver
    {
        public class Part1Solver
        {
            private IEnumerable<string> _input;
            private char[,] _map;
            private long _result = 0;

            public Part1Solver(IEnumerable<string> input)
            {
                _input = input;
                _map = Helper.GetMap(input.ToArray());
                Helper.PrintMap(_map);
            }

            internal long Solve()
            {
                return 0;
            }
        }

        public class Part2Solver
        {
            private IEnumerable<string> _input;
            private long _result = 0;

            public Part2Solver(IEnumerable<string> input)
            {
                _input = input;
            }

            internal long Solve()
            {
                return 0;
            }
        }
    }
}
