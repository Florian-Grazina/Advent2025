
namespace Common
{
    public static class Helper
    {
        public static char[,] GetMap(string[] input)
        {
            int xSize = input.First().Length;
            int ySize = input.Length;

            char[,] map = new char[xSize, ySize];

            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    char c = input[y][x];
                    map[x, y] = c;
                }
            }

            return map;
        }

        public static IEnumerable<char> IterateMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    yield return map[x, y];
                }
            }
        }

        public static char[,] GetMapExtraLayer(string[] input)
        {
            int xSize = input.First().Length + 2;
            int ySize = input.Length + 2;

            char[,] map = new char[xSize, ySize];

            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    if (x == 0 ||
                        x == xSize - 1 ||
                        y == 0 ||
                        y == ySize - 1)
                    {
                        map[x, y] = '.';
                        continue;
                    }

                    char c = input[y - 1][x - 1];
                    map[x, y] = c;
                }
            }

            return map;
        }

        public static void PrintMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                Console.WriteLine();
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
            }
        }
    }
}
