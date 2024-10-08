using Leetcode.Helpers;

namespace Leetcode.Solutions
{
    public class Lc_130_SurroundedRegions
    {
        // 130. Surrounded Regions
        // https://leetcode.com/problems/surrounded-regions/description/
        public void Solve(char[][] board)
        {
            // When O on border change to Z    
            var m = board.Length;
            var n = board[0].Length;

            var positions = new List<(int x, int y)>() { (-1, 0), (0, -1), (1, 0), (0, 1) }; // top, right, down, left  
            var fullyFillBorders = new List<string>() { "top", "left", "right", "down" };

            foreach (var border in fullyFillBorders)
            {
                if (border == "top" || border == "down")
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (border == "top")
                            DfsPositions(0, j);
                        else
                            DfsPositions(m - 1, j);
                    }
                }
                else if (border == "left" || border == "right")
                {
                    for (int i = 0; i < m; i++)
                    {
                        if (border == "left")
                            DfsPositions(i, 0);
                        else
                            DfsPositions(i, n - 1);
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var value = board[i][j];
                    board[i][j] = value == 'Z' ? 'O' : 'X';
                }
            }

            void DfsPositions(int x, int y)
            {
                if (board[x][y] == 'X' || board[x][y] == 'Z') return;
                // else is 'O'        
                var anyIsOutBounded = false;
                foreach (var positions in positions)
                {
                    var xGoTo = positions.x + x;
                    var yGoTo = positions.y + y;
                    if (xGoTo < 0 || yGoTo < 0 || xGoTo > (m - 1) || yGoTo > (n - 1))
                        anyIsOutBounded = true;
                }
                if (anyIsOutBounded)
                    DfsChangeZBrothers(x, y);
            }

            void DfsChangeZBrothers(int x, int y)
            {
                if (board[x][y] == 'Z' || board[x][y] == 'X') return;
                // else is 'O'
                board[x][y] = 'Z';
                foreach (var positions in positions)
                {
                    var xGoTo = positions.x + x;
                    var yGoTo = positions.y + y;
                    // if (!((xGoTo >= 0 && yGoTo >= 0) && (xGoTo < m && yGoTo < n))) continue;
                    if (xGoTo < 0 || yGoTo < 0 || xGoTo > (m - 1) || yGoTo > (n - 1)) continue;
                    DfsChangeZBrothers(xGoTo, yGoTo);
                }
            }
        }
    }

    public static class Lc_130_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 130 Surrounded Regions");

            var lc130code = new Lc_130_SurroundedRegions();

            char[][] grid = new char[][]
            {
                ['O', 'X', 'X', 'X', 'X'],
                ['X', 'O', 'O', 'X', 'X'],
                ['X', 'X', 'X', 'O', 'X'],
                ['X', 'O', 'O', 'X', 'X'],
                ['X', 'X', 'O', 'X', 'X']
            };
            Console.WriteLine("Expected print only 4 -> O");
            lc130code.Solve(grid);
            Log.DebugPrint(grid);

            char[][] grid1 =
            [
                ['X', 'O', 'X', 'O', 'X', 'O'],
                ['O', 'X', 'O', 'X', 'O', 'X'],
                ['X', 'O', 'X', 'O', 'X', 'O'],
                ['O', 'X', 'O', 'X', 'O', 'X']
            ];

            Console.WriteLine("Expected print only 8 -> O");
            lc130code.Solve(grid1);
            Log.DebugPrint(grid1);

            Console.WriteLine("");
        }
    }
}