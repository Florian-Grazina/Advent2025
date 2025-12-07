using Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day06
{
    public class Puzzle : DayPuzzle
    {
        private readonly List<List<string>> _parsedInput = [];
        private readonly List<string> _parsedInput2 = [];

        public override long SolvePart1()
        {
            long result = 0;
            ParseInput();

            foreach (var input in _parsedInput)
                result += GetCollectionResut(input);

            return result;
        }

        public override long SolvePart2()
        {
            long result = 0;
            ParseInput2();

            char? activeOp = null;
            long runningResult = 0;

            foreach (string inp in _parsedInput2)
            {
                string input = inp.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    activeOp = null;
                    result += runningResult;
                    runningResult = 0;
                    continue;
                }

                if (activeOp == null)
                {
                    if (input.Last() == '*')
                        activeOp = '*';
                    else
                        activeOp = '+';

                    input = input[..^1];

                    runningResult = long.Parse(input);
                    continue;
                }

                long number = long.Parse(input);

                switch (activeOp)
                {
                    case '+':
                        runningResult += number;
                        break;
                    case '*':
                        runningResult *= number;
                        break;
                }
            }

            // low 12841225016822
            return result + runningResult;
        }

        private long GetCollectionResut(List<string> input)
        {
            long result = int.Parse(input.First());
            string operation = input.Last();

            input.RemoveAt(input.Count - 1);
            input.RemoveAt(0);

            IEnumerable<long> numbers = input.Select(long.Parse);

            foreach (long number in numbers)
            {
                switch (operation)
                {
                    case "+":
                        result += number;
                        break;
                    case "*":
                        result *= number;
                        break;
                }
            }

            return result;
        }

        private void ParseInput2()
        {
            foreach (char c in _input.First())
                _parsedInput2.Add(string.Empty);

            for (int i = 0; i < _input.Length; i++)
            {
                string line = _input[i];

                for (int c = 0; c < _input[i].Length; c++)
                {
                    _parsedInput2[c] += line[c];
                }
            }
        }

        private void ParseInput()
        {
            for (int i = 0; i < _input.Length; i++)
            {
                var trimmed = _input[i].Split(" ").Where(s => !string.IsNullOrEmpty(s)).ToArray();

                if (i == 0)
                    for (int y = 0; y < trimmed.Length; y++)
                        _parsedInput.Add([]);

                for (int y = 0; y < trimmed.Length; y++)
                {
                    _parsedInput[y].Add(trimmed[y]);
                }
            }
        }
    }
}
