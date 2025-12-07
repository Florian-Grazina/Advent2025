namespace Common
{
    public abstract class DayPuzzle
    {
        protected string[] _input;

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
            return input.Split("\r\n");
        }
    }
}
