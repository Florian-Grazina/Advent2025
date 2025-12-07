using Common;

namespace Day03
{
    public class Puzzle : DayPuzzle
    {
        public override long SolvePart1()
        {
            long result = 0;

            foreach (string line in _input)
            {
                result += GetResultPart1(line);
            }

            return result;
        }

        public override long SolvePart2()
        {
            long result = 0;

            foreach (string line in _input)
            {
                result += GetResultPart2(line);
            }

            return result;
            // low 17039474866
        }

        private int GetResultPart1(string line)
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

        private long GetResultPart2(string line)
        {
            int batteriesToTake = 12;

            List<int> shorts = [.. line.ToArray().Select(c => short.Parse(c.ToString()))];
            List<int> openedBatteries = [];

            while (batteriesToTake > 0)
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
