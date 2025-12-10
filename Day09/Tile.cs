namespace Day09
{
    internal class Tile
    {
        public Tile(string line)
        {
            string[] ok = line.Split(',');
            X = int.Parse(ok[0]);
            Y = int.Parse(ok[1]);
        }

        public int X { get; set; }
        public int Y { get; set; }

        public long GetHighestResult(Tile[] tilesCoords)
        {
            long highestResult = 0;
            foreach(Tile tile in tilesCoords)
            {
                long res = Compare(tile);
                if(res > highestResult)
                    highestResult = res;
            }

            return highestResult;
        }

        private long Compare(Tile tile)
        {
            long x = Math.Abs(tile.X - X) + 1;
            long y = Math.Abs(tile.Y - Y) + 1;

            return x * y;
        }
    }
}
