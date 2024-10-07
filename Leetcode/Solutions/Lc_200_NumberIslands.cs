using Leetcode.Helpers;

namespace Leetcode.Solutions
{
    // https://leetcode.com/problems/number-of-islands/description/
    public class Lc_200_NumberIslands
    {
        static void ChangeConnectedPiecesOfEarth(int row, int column, char[][] grid, List<(int row, int column)> positions, int rows, int columns)
        {
            foreach (var pos in positions)
            {
                var posX = pos.row + row;
                var posY = pos.column + column;
                if ((posX >= rows || posX < 0) || (posY >= columns || posY < 0)) continue;
                if (grid[posX][posY] == '0') continue;
                grid[posX][posY] = '0';
                // Log.DebugPrint(grid);
                ChangeConnectedPiecesOfEarth(posX, posY, grid, positions, rows, columns);
            }
        }

        public int NumIslands(char[][] grid)
        {
            // Log.DebugPrint(grid);
            var islandsCounter = 0;
            List<(int row, int column)> positions = new List<(int, int)> { (0, 1), (1, 0), (0, -1), (-1, 0) }; // right, down, left, top
            if (grid.Length == 0 || grid[0].Length == 0) return 0;
            var rows = grid.Length;
            var columns = grid[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (grid[i][c] == '0') continue;
                    if (grid[i][c] == '1')
                    {
                        islandsCounter += 1;
                        ChangeConnectedPiecesOfEarth(i, c, grid, positions, rows, columns);
                        // Log.DebugPrint(grid);
                    }
                }
            }
            return islandsCounter;
        }
    }

    public static class Lc_200_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 200 Number of Islands");

            var lc200code = new Lc_200_NumberIslands();

            char[][] grid = new char[][]
            {
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '0', '0', '1', '0', '0' },
                new char[] { '0', '0', '0', '1', '1' }
            };

            Console.WriteLine("Expected 3: " + lc200code.NumIslands(grid));

            char[][] grid1 = new char[][]
            {
                new char[] { '1', '1', '1', '1', '0' },
                new char[] { '1', '1', '0', '1', '0' },
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '0', '0', '0', '0', '0' }
            };

            Console.WriteLine("Expected 1: " + lc200code.NumIslands(grid1));

            char[][] grid2 = new char[][]
            {
                new char[] { '1', '1', '1' },
                new char[] { '0', '1', '0' },
                new char[] { '1', '1', '1' }
            };

            Console.WriteLine("Expected 1: " + lc200code.NumIslands(grid2));

            char[][] grid4 = new char[][]
            {
                new char[] { '1', '0', '1', '1', '1' },
                new char[] { '1', '0', '1', '0', '1' },
                new char[] { '1', '1', '1', '0', '1' }
            };

            Console.WriteLine("Expected 1: " + lc200code.NumIslands(grid4));

            char[][] grid5 = new char[][]
            {
                new char[] { '1', '0', '1', '1', '1' },
                new char[] { '1', '0', '0', '0', '1' },
                new char[] { '1', '0', '1', '1', '1' }
            };

            Console.WriteLine("Expected 2: " + lc200code.NumIslands(grid5));

            Console.WriteLine("");            
        }
    }
}
