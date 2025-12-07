using Common;

namespace Day02
{
    public class Puzzle : DayPuzzle
    {
        private IEnumerable<ProductRange> _productRanges = [];
        public override long SolvePart1()
        {
            _input = [.. _input.SelectMany(l => l.Split(","))];
            _productRanges = _input.Select(line => new ProductRange(line));
            
            long result = 0;
            
            foreach (ProductRange productRange in _productRanges)
            {
                for (long i = productRange.IdStart; i <= productRange.IdEnd; i++)
                {
                    if (!IsValide(i))
                        result += i;
                }
            }
            return result;
        }

        public override long SolvePart2()
        {
            _input = [.. _input.SelectMany(l => l.Split(","))];
            _productRanges = _input.Select(line => new ProductRange(line));

            long result = 0;

            foreach (ProductRange productRange in _productRanges)
            {
                for (long i = productRange.IdStart; i <= productRange.IdEnd; i++)
                    result += CheckValidity(i);
            }
            return result;
        }

        private long CheckValidity(long input)
        {
            string inputStr = input.ToString();
            int halfInputLength = inputStr.Length / 2;
            int strLength = inputStr.Length;

            if (strLength == 2 && inputStr[0] == inputStr[1])
            {
                return input;
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
                        return input;
                    }
                }
                catch
                {
                    continue;
                }
            }
            return 0;
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
