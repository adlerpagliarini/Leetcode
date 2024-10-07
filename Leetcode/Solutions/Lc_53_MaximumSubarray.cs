namespace Leetcode.Solutions
{
    public class Lc_53_MaximumSubarray
    {
        // 53. Maximum Subarray
        // https://leetcode.com/problems/maximum-subarray/description/
        public int MaxSubArray(int[] nums)
        {
            var max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = Math.Max(nums[i] + nums[i - 1], nums[i]);
                max = Math.Max(max, nums[i]);
            }
            return max;
        }
    }

    public static class Lc_53_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 53 Maximum Subarray");
            var lc53code = new Lc_53_MaximumSubarray();
            Console.WriteLine("Expected Output: 6 - " + lc53code.MaxSubArray([-2, 1, -3, 4, -1, 2, 1, -5, 4]));
            Console.WriteLine("");
        }
    }
}