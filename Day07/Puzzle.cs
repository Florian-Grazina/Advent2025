using Common;

namespace Day07
{
    public class Puzzle : DayPuzzle
    {
        private char[,] _map = default!;
        private int _result = 0;

        public override long SolvePart1()
        {
            _map = Helper.GetMap(_input);

            for (int x = 0; x < _map.GetLength(1); x++)
            {
                if (_map[x, 0] == 'S')
                {
                    _map[x, 1] = '|';
                    break;
                }
            }

            for (int y = 1; y < _map.GetLength(1); y++)
            {
                for (int x = 0; x < _map.GetLength(0); x++)
                {
                    char c = _map[x, y];

                    switch (c)
                    {
                        case 'S':
                            _map[x, y] = '|';
                            break;

                        case '.':
                            FillLine(x, y);
                            break;

                        case '^':
                            SplitLine(x, y);
                            break;
                    }
                }
            }
            return _result;
        }

        private void SplitLine(int x, int y)
        {
            try
            {
                if (_map[x, y - 1] == '|')
                {
                    bool isSplitted = false;
                    if (_map[x - 1, y] == '.')
                    {
                        _map[x - 1, y] = '|';
                        isSplitted = true;
                    }
                    if (_map[x + 1, y] == '.')
                    {
                        _map[x + 1, y] = '|';
                        isSplitted |= true;
                    }

                    if (isSplitted)
                        _result++;
                }
            }
            catch { }
        }

        private void FillLine(int x, int y)
        {
            if (_map[x, y - 1] == '|')
                _map[x, y] = '|';
        }

        public override long SolvePart2()
        {
            return 0;
        }
    }
}
