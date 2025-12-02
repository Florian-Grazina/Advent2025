
namespace Day01
{
    internal class Part2Solver(IEnumerable<string> input)
    {
        private IEnumerable<string> _input = input;
        private int _result = 0;

        public int Solve()
        {
            int position = 50;

            Queue<SafeCommand> commands = new(_input.Select(GetSafeCommand));

            foreach (SafeCommand command in commands)
            {
                switch (command.Direction)
                {
                    case Direction.Left:
                        for(int i = 0; i < command.Steps; i++)
                        {
                            position--;

                            if (position < 0)
                                position = 99;

                            if(position == 0)
                                _result++;
                        }
                        break;

                    case Direction.Right:
                        for (int i = 0; i < command.Steps; i++)
                        {
                            position++;

                            if (position == 100)
                            {
                                position = 0;
                                _result++;
                            }
                        }
                        break;
                }


                if (position < 0 || position >= 100)
                    throw new InvalidOperationException("Position out of bounds");
            }

            // 3815 too low
            // 6913 too high

            return _result;
        }

        private SafeCommand GetSafeCommand(string line)
        {
            int steps = int.Parse(line[1..]);

            Direction direction = line.First() switch
            {
                'L' => Direction.Left,
                'R' => Direction.Right,
                _ => throw new InvalidOperationException("Invalid direction"),
            };

            return new SafeCommand(direction, steps);
        }
    }
}
