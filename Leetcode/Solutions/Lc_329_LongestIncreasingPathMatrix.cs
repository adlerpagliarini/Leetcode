namespace Leetcode.Solutions
{
    public class Lc_329_LongestIncreasingPathMatrix
    {
        // 329. Longest Increasing Path in a Matrix
        // https://leetcode.com/problems/longest-increasing-path-in-a-matrix/description/
        public int LongestIncreasingPath(int[][] matrix)
        {
            var longestPath = 0;
            var m = matrix.Length;
            var n = matrix[0].Length;
            var memoization = new int[m, n];

            var positionsToMove = new List<(int x, int y)>() { (-1, 0), (1, 0), (0, -1), (0, 1) }; // up, down, left, right

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    var currentValue = matrix[i][j];
                    DfsPositions(i, j, currentValue);
                }
            }

            int DfsPositions(int i, int j, int refValue)
            {
                if (memoization[i, j] > 0)
                    return memoization[i, j];

                var sidesValues = new List<int>();
                foreach (var move in positionsToMove)
                {
                    var x = move.x + i;
                    var y = move.y + j;
                    if (x < 0 || y < 0 || x >= m || y >= n) continue;
                    var sideValue = matrix[x][y];
                    if (refValue < sideValue)
                    {
                        var result = DfsPositions(x, y, sideValue);
                        sidesValues.Add(result);
                    }
                }
                var maxSide = sidesValues.Count > 0 ? sidesValues.Max() + 1 : 1;
                if (maxSide > longestPath) longestPath = maxSide;
                memoization[i, j] = maxSide;
                return memoization[i, j];
            }
            return longestPath;
        }
        public static class Lc_329_Tests
        {
            public static void Execute()
            {
                Console.WriteLine("Leetcode: 329 Longest Increasing Path in a Matrix");

                var lc329code = new Lc_329_LongestIncreasingPathMatrix();
                Console.WriteLine("Expected Output: 4 - " + lc329code.LongestIncreasingPath([[9, 9, 4], [6, 6, 8], [2, 1, 1]]));
                Console.WriteLine("");
            }
        }
    }
}