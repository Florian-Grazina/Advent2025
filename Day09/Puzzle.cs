using Common;

namespace Day09
{
    public class Puzzle : DayPuzzle
    {
        public override long SolvePart1()
        {

            IEnumerable<Tile> tilesCoords = _input.Select(line => new Tile(line));
            IEnumerable<long> results = GetResults(tilesCoords.ToArray());

            return results.Max();

            // low 2147410078
            // low 448678192
            // low 4743645488
        }

        public override long SolvePart2()
        {
            return 0;
        }

        private IEnumerable<KeyValuePair<(Tile, Tile), long>> GetResultDico(Tile[] tilesCoords)
        {
            for (int i = 0; i < tilesCoords.Length; i++)
            {
                for (int y = i + 1; y < tilesCoords.Length; y++)
                {
                    Tile tile1 = tilesCoords[i];
                    Tile tile2 = tilesCoords[y];

                    long result = GetResult(tile1, tile2);
                    yield return new((tile1, tile2), result);
                }
            }
        }

        private IEnumerable<long> GetResults(Tile[] tilesCoords)
        {
            foreach(Tile tile in tilesCoords)
                yield return tile.GetHighestResult(tilesCoords);
        }

        private long GetResult(Tile tile1, Tile tile2)
        {
            long x = Math.Abs(tile1.X - tile2.X) + 1;
            long y = Math.Abs(tile1.Y - tile2.Y) + 1;

            return x * y;
        }
    }
}
