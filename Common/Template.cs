using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public abstract class Template
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
                return 0;
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
                return 0;
            }
        }
    }
}
