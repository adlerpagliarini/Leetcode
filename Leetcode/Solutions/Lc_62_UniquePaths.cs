namespace Leetcode.Solutions
{
    public class Lc_62_UniquePaths
    {
        // 62. Unique Paths
        // https://leetcode.com/problems/unique-paths/description/
        public int UniquePaths(int m, int n)
        {
            int[,] camp = new int[m, n];
            var positionsToSum = new List<(int x, int y)>() { (-1, 0), (0, -1) }; // above, left
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                        camp[0, 0] = 1;
                    else
                    {
                        var neighbors = 0;
                        foreach (var moveTo in positionsToSum)
                        {
                            var x = moveTo.x + i;
                            var y = moveTo.y + j;
                            if (x < 0 || y < 0) continue;
                            neighbors += camp[x, y];
                        }
                        camp[i, j] = neighbors;
                    }
                }
            return camp[m - 1, n - 1];
        }
    }

    public static class Lc_62_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 62 Unique Paths");

            var lc62code = new Lc_62_UniquePaths();
            Console.WriteLine("Expected Output: 28 - " + lc62code.UniquePaths(3, 7));
            Console.WriteLine("");
        }
    }
}