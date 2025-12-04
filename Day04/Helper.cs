using System.Runtime.Serialization;

namespace Day04
{
    internal static class Helper
    {
        internal static char[,] GetMap(string[] input)
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

        internal static void PrintMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                Console.WriteLine();
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x,y]);
                }
            }
        }
    }
}
