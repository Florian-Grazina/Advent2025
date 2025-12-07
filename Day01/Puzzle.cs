using Common;

namespace Day01
{
    public class Puzzle : DayPuzzle
    {
        public override long SolvePart1()
        {
            int position = 50;
            long result = 0;

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
                    result++;
            }

            //// 496 too low

            return result;
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

        public override long SolvePart2()
        {
            int position = 50;
            long result = 0;

            Queue<SafeCommand> commands = new(_input.Select(GetSafeCommand));

            foreach (SafeCommand command in commands)
            {
                switch (command.Direction)
                {
                    case Direction.Left:
                        for (int i = 0; i < command.Steps; i++)
                        {
                            position--;

                            if (position < 0)
                                position = 99;

                            if (position == 0)
                                result++;
                        }
                        break;

                    case Direction.Right:
                        for (int i = 0; i < command.Steps; i++)
                        {
                            position++;

                            if (position == 100)
                            {
                                position = 0;
                                result++;
                            }
                        }
                        break;
                }


                if (position < 0 || position >= 100)
                    throw new InvalidOperationException("Position out of bounds");
            }

            // 3815 too low
            // 6913 too high
            // 6907

            return result;
        }
    }
}
