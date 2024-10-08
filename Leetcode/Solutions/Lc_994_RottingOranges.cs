namespace Leetcode.Solutions
{
    public class Lc_994_RottingOranges
    {
        // 994. Rotting Oranges
        // https://leetcode.com/problems/rotting-oranges/submissions/
        public int OrangesRotting(int[][] grid)
        {
            var clock = 0;
            var positionsToMove = new List<(int x, int y)>() { (-1, 0), (0, -1), (1, 0), (0, 1) }; // top, right, bottom, right    
            Queue<(int xGoTo, int yGoTo)> bfsMinTime = new();

            // find roots
            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                    if (grid[i][j] == 2) bfsMinTime.Enqueue((i, j));

            while (bfsMinTime.Count > 0)
            {
                var amountOfNodesInTheDepth = bfsMinTime.Count;
                for (int nodeDepth = 0; nodeDepth < amountOfNodesInTheDepth; nodeDepth++)
                {
                    var node = bfsMinTime.Dequeue();

                    foreach (var move in positionsToMove)
                    {
                        var x = node.xGoTo + move.x;
                        var y = node.yGoTo + move.y;
                        if (x < 0 || y < 0) continue;
                        if (x >= grid.Length || y >= grid[x].Length) continue;
                        if (grid[x][y] == 1)
                        {
                            grid[x][y] = 2;
                            bfsMinTime.Enqueue((x, y));
                        }
                    }
                }
                if (bfsMinTime.Count > 0)
                    clock++;
            }

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                    if (grid[i][j] == 1) return -1;

            return clock;
        }
    }

    public static class Lc_994_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 994. Minimum Remove to Make Valid Parentheses");
            var lc994code = new Lc_994_RottingOranges();
            var gridOrange = new int[][] { [2, 1, 1], [1, 1, 0], [0, 1, 1] }; // 4
            var gridOrangeTwoTwo = new int[][] { [2, 1, 1], [1, 1, 1], [0, 1, 2] }; // 2 two roots
            var gridOrangeZero = new int[][] { [0, 2, 2] }; // 0
            Console.WriteLine("Expected: 4 - " + lc994code.OrangesRotting(gridOrange));
            Console.WriteLine("Expected: 2 - " + lc994code.OrangesRotting(gridOrangeTwoTwo));
            Console.WriteLine("Expected: 0 - " + lc994code.OrangesRotting(gridOrangeZero));
            Console.WriteLine("");
        }
    }
}