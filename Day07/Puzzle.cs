using Common;

namespace Day07
{
    public class Puzzle : DayPuzzle
    {
        private char[,] _map = default!;
        private Tile[,] _tiles = default!;
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

        private void SplitLine2(int x, int y)
        {
            try
            {
                Tile topTile = _tiles[x, y - 1];
                long nb = topTile.Number;

                if (topTile.Char == '|')
                {
                    if (_tiles[x - 1, y].Char != '^')
                        _tiles[x - 1, y].FillLine(nb);

                    if (_tiles[x + 1, y].Char != '^')
                        _tiles[x + 1, y].FillLine(nb);
                }
            }
            catch { }
        }

        private void FillLine(int x, int y)
        {
            if (_map[x, y - 1] == '|')
                _map[x, y] = '|';
        }

        private void FillLine2(int x, int y)
        {
            Tile topTile = _tiles[x, y - 1];

            if (topTile.Char == '|')
                _tiles[x, y].FillLine(topTile.Number);
        }

        public override long SolvePart2()
        {
            _tiles = Helper.GetMap(_input, Instantiate);
            long result = 0;

            for (int x = 0; x < _tiles.GetLength(0); x++)
            {
                if (_tiles[x, 0].Char == 'S')
                {
                    _tiles[x, 1].Char = '|';
                    break;
                }
            }

            for (int y = 1; y < _tiles.GetLength(1); y++)
            {
                for (int x = 0; x < _tiles.GetLength(0); x++)
                {
                    char c = _tiles[x, y].Char;

                    switch (c)
                    {
                        case '.':
                            FillLine2(x, y);
                            break;

                        case '^':
                            SplitLine2(x, y);
                            break;

                        case '|':
                            FillLine2(x, y);
                            break;
                    }
                }
            }

            for (int x = 0; x < _tiles.GetLength(0); x++)
            {
                Tile tile = _tiles[x, _tiles.GetLength(1) - 1];

                if (tile.Char == '|')
                    result += tile.Number;
            }

            // low 16494603157
            // low 16494603157
            return result;
        }

        private Tile Instantiate(char c)
        {
            return new Tile(c);
        }
    }
}
