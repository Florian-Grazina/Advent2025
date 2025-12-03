using System.Diagnostics;

namespace Day02
{
    internal class Part2Solver
    {
        private IEnumerable<string> _input;
        private long _result = 0;

        private IEnumerable<ProductRange> _productRanges;

        public Part2Solver(IEnumerable<string> input)
        {
            _input = input;
            _productRanges = _input.Select(line => new ProductRange(line));
        }

        internal long Solve()
        {
            long numOfChecks = _productRanges.Sum(p => p.IdEnd - p.IdStart);

            foreach (ProductRange productRange in _productRanges)
            {
                for (long i = productRange.IdStart; i <= productRange.IdEnd; i++)
                    CheckValidity(i);
            }
            return _result;
        }

        private void CheckValidity(long input)
        {
            string inputStr = input.ToString();
            int halfInputLength = inputStr.Length / 2;
            int strLength = inputStr.Length;

            if(strLength == 2 && inputStr[0] == inputStr[1])
            {
                _result += input;
                return;
            }


            for (int block = halfInputLength; block >= 1; block--)
            {
                try
                {
                    if (strLength % block != 0)
                        continue;

                    string[] splits = SplitByNum(inputStr, block);
                    string model = splits[0];

                    bool isInvalide = splits.All(s => s == model);
                    if (isInvalide)
                    {
                        _result += input;
                        break;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }


        private string[] SplitByNum(string str, int block)
        {
            List<string> toReturn = [];

            for (int i = 0; i < str.Length; i += block)
            {
                string toInput = string.Empty;

                for (int y = 0; y < block; y++)
                    toInput += str[i + y];

                toReturn.Add(toInput);
            }

            return [.. toReturn];
        }
    }
}