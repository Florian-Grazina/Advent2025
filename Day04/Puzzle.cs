using Common;

namespace Day04
{
    public class Puzzle : DayPuzzle
    {
        private char[,] _map;
        private long _newResult = 0;

        public override long SolvePart1()
        {
            _map = Helper.GetMapExtraLayer(_input.ToArray());

            for (int y = 0; y < _map.GetLength(1); y++)
            {
                for (int x = 0; x < _map.GetLength(0); x++)
                {
                    if (CanPickUp(x, y))
                    {
                        _map[x, y] = '.';
                        _result++;
                    }
                }
            }

            return _result;
        }

        public override long SolvePart2()
        {
            _map = Helper.GetMapExtraLayer(_input.ToArray());

            do
            {
                _result = _newResult;

                for (int y = 0; y < _map.GetLength(1); y++)
                {
                    for (int x = 0; x < _map.GetLength(0); x++)
                    {
                        if (CanPickUp(x, y))
                        {
                            _map[x, y] = '.';
                            _newResult++;
                        }
                    }
                }
            }
            while (_result != _newResult);

            return _result;
        }

        private bool CanPickUp(int x, int y)
        {
            if (IsNotStack(x, y))
                return false;

            if (x == 0 ||
                x == _map.GetLength(0) - 1 ||
                y == 0 ||
                y == _map.GetLength(1) - 1)
            {
                return false;
            }

            int stackNumber = 0;

            // left
            (int newX, int newY) = (x + -1, y + 0);
            if (IsNotStack(newX, newY))
                stackNumber++;

            // left top
            (newX, newY) = (x + -1, y + -1);
            if (IsNotStack(newX, newY))
                stackNumber++;

            // top
            (newX, newY) = (x + 0, y + -1);
            if (IsNotStack(newX, newY))
                stackNumber++;

            // top right
            (newX, newY) = (x + 1, y + -1);
            if (IsNotStack(newX, newY))
                stackNumber++;

            // right
            (newX, newY) = (x + 1, y + 0);
            if (IsNotStack(newX, newY))
                stackNumber++;

            if (stackNumber == 5)
                return true;

            // bottom right
            (newX, newY) = (x + 1, y + 1);
            if (IsNotStack(newX, newY))
                stackNumber++;

            if (stackNumber == 5)
                return true;

            // bottom
            (newX, newY) = (x + 0, y + 1);
            if (IsNotStack(newX, newY))
                stackNumber++;

            if (stackNumber == 5)
                return true;

            // bottom left
            (newX, newY) = (x + -1, y + 1);
            if (IsNotStack(newX, newY))
                stackNumber++;

            if (stackNumber == 5)
                return true;

            return false;
        }

        private bool IsNotStack(int x, int y)
        {
            var ok = _map[x, y];
            return ok == '.';
        }
    }
}
