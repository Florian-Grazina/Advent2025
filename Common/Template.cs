namespace Common
{
    public abstract class Template
    {
        public class Solver
        {
            private IEnumerable<string> _input;
            private long _result = 0;

            public Solver(IEnumerable<string> input)
            {
                _input = input;
            }

            internal long Solve1()
            {
                return _result;
            }

            internal long Solve2()
            {
                return _result;
            }
        }
    }
}
