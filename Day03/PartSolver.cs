
namespace Day03
{
    internal class PartSolver
    {
        public class Part1Solver
        {
            private IEnumerable<string> _input;
            private long _result = 0;

            public Part1Solver(IEnumerable<string> input)
            {
                _input = input;
            }

            internal long Solve()
            {
                foreach (string line in _input)
                {
                    int result = GetResult(line);
                    _result += result;
                }

                return _result;
            }

            private int GetResult(string line)
            {
                List<short> shorts = [.. line.ToArray().Select(c => short.Parse(c.ToString()))];

                short highest = shorts.GetRange(0, shorts.Count - 1).Max();
                int higestIndex = shorts.IndexOf(highest);

                short secondHigest = 0;

                for (int i = higestIndex + 1; i < shorts.Count; i++)
                {
                    if (shorts[i] > secondHigest)
                        secondHigest = shorts[i];
                }

                return highest * 10 + secondHigest;
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
                foreach (string line in _input)
                {
                    long result = GetResult(line);
                    Console.WriteLine(result);
                    _result += result;
                }

                return _result;
                // low 17039474866
            }

            private long GetResult(string line)
            {
                int batteriesToTake = 12;

                List<int> shorts = [.. line.ToArray().Select(c => short.Parse(c.ToString()))];
                List<int> openedBatteries = [];

                while(batteriesToTake > 0)
                {
                    List<int> subShorts = shorts.GetRange(0, shorts.Count - batteriesToTake + 1);

                    int highest = subShorts.Max();
                    int highestIndex = subShorts.IndexOf(highest);

                    openedBatteries.Add(highest);
                    batteriesToTake--;

                    shorts.RemoveRange(0, highestIndex + 1);
                }

                string result = string.Join("", openedBatteries);
                return long.Parse(result);
            }
        }
    }
}
