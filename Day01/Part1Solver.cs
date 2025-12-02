namespace Day01
{
    internal class Part1Solver(IEnumerable<string> input)
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
                        position -= command.Steps;
                        int turn = command.Steps / 100;

                        position += turn * 100;
                        if (position < 0)
                            position += 100;
                        break;

                    case Direction.Right:
                        position += command.Steps;
                        turn = command.Steps / 100;

                        position -= turn * 100;
                        if (position >= 100)
                            position -= 100;
                        break;
                }
                if (position == 0)
                    _result++;
            }

            // 496 too low

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
