namespace Day01
{
    internal class SafeCommand
    {
        public SafeCommand(Direction direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }

        public Direction Direction { get; set; }
        public int Steps { get; set; }
    }
}
