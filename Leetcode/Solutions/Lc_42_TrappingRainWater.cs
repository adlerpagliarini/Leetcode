namespace Leetcode.Solutions
{
    public class Lc_42_TrappingRainWater
    {
        // 42. Trapping Rain Water
        // https://leetcode.com/problems/trapping-rain-water/description/        
        public int Trap(int[] height)
        {
            var maxLeft = 0;
            var leftMaxs = new int[height.Length];
            var maxRight = 0;
            var rightMaxs = new int[height.Length];
            var results = new int[height.Length];

            for (int x = 0; x < height.Length; x++)
            {
                leftMaxs[x] = maxLeft;
                maxLeft = Math.Max(maxLeft, height[x]);
            }

            for (int x = height.Length - 1; x >= 0; x--)
            {
                rightMaxs[x] = maxRight;
                maxRight = Math.Max(maxRight, height[x]);
            }

            for (int x = 0; x < height.Length; x++)
            {
                results[x] = Math.Min(leftMaxs[x], rightMaxs[x]) - height[x];
                if (results[x] < 0) results[x] = 0;
            }

            return results.Sum();
        }
    }

    public static class Lc_42_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 42 Trapping Rain Water");
            var lc42code = new Lc_42_TrappingRainWater();
            var blocks = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Console.WriteLine("Expected: 6 - " + lc42code.Trap(blocks));
            Console.WriteLine("");
        }
    }
}