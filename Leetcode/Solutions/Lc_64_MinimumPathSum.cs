namespace Leetcode.Solutions
{
    public class Lc_64_MinimumPathSum
    {
        // 64. Minimum Path Sum
        // https://leetcode.com/problems/minimum-path-sum/description/
        public int MinPathSum(int[][] grid)
        {
            var positionsToSum = new List<(int x, int y)>() { (-1, 0), (0, -1) }; // above, left
            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (i == 0 && j == 0)
                        grid[0][0] = grid[0][0];
                    else
                    {
                        var neighbors = new List<int>();
                        foreach (var moveTo in positionsToSum)
                        {
                            var x = moveTo.x + i;
                            var y = moveTo.y + j;
                            if (x < 0 || y < 0) continue;
                            neighbors.Add(grid[x][y]);
                        }
                        grid[i][j] = neighbors.Min() + grid[i][j];
                    }
                }
            return grid[grid.Length - 1][grid[0].Length - 1];
        }
        public static class Lc_64_Tests
        {
            public static void Execute()
            {
                Console.WriteLine("Leetcode: 64 Unique Paths");

                var lc64code = new Lc_64_MinimumPathSum();
                Console.WriteLine("Expected Output: 7 - " + lc64code.MinPathSum([[1, 3, 1], [1, 5, 1], [4, 2, 1]]));
                Console.WriteLine("");
            }
        }
    }
}