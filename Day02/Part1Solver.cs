
namespace Day02
{
    internal class Part1Solver
    {
        private IEnumerable<string> _input;
        private long _result = 0;

        private IEnumerable<ProductRange> _productRanges;

        public Part1Solver(IEnumerable<string> input)
        {
            _input = input;
            _productRanges = _input.Select(line => new ProductRange(line));
        }

        internal long Solve()
        {
            foreach(ProductRange productRange in _productRanges)
            {
                for(long i = productRange.IdStart; i <= productRange.IdEnd; i++)
                {
                    if(!IsValide(i))
                        _result += i;
                }
            }
            return _result;
        }

        private bool IsValide(long number)
        {
            string stringNumber = number.ToString();
            int stringLength = stringNumber.Length;

            if (stringLength % 2 == 1)
                return true;

            var start = stringNumber[(stringLength / 2)..];
            var end = stringNumber[..(stringLength / 2)];

            if (start == end)
                return false;

            return true;
        }
    }
}