namespace Common
{
    public abstract class DayPuzzle
    {
        protected string[] _input;
        protected long _result = 0;

        protected DayPuzzle()
        {
            _input = GetInput();
        }

        protected string Day => GetType().Namespace ?? throw new Exception("no namespace");
        public abstract long SolvePart1();
        public abstract long SolvePart2();

        protected string[] GetInput()
        {
            var input = File.ReadAllText($"../../../../{Day}/input.txt");
            var lines = input.Split("\r\n");
            return [.. lines.SelectMany(l => l.Split(",")).Where(data => !string.IsNullOrEmpty(data))];
        }
    }
}
