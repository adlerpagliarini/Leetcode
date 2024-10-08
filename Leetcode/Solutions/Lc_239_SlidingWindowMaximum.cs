using Leetcode.Helpers;

namespace Leetcode.Solutions
{
    public class Lc_239_SlidingWindowMaximum
    {
        // 239. Sliding Window Maximum
        // https://leetcode.com/problems/sliding-window-maximum/description/
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length <= 1) return nums;
            var maxLeftIndex = -1;
            var maxLeftValue = -1;
            var sortedMax = new SortedList<int, int>(); // valueKey, valueIndex
            var result = new List<int>();
            var ki = 0;
            while (ki < k)
            {
                if (nums[ki] >= maxLeftValue)
                {
                    maxLeftValue = nums[ki];
                    maxLeftIndex = ki;
                }
                if (sortedMax.ContainsKey(nums[ki]))
                    sortedMax[nums[ki]] = ki;
                else
                    sortedMax.Add(nums[ki], ki);
                ki++;
            }
            result.Add(maxLeftValue);
            if (maxLeftIndex == 0)
            {
                var next = false;
                while (!next && sortedMax.Count > 0)
                {
                    var sortedValue = sortedMax.Keys[sortedMax.Count - 1];
                    var sortedValueIndex = sortedMax.Values[sortedMax.Count - 1];
                    if (sortedValueIndex > maxLeftIndex)
                    {
                        next = true;
                        maxLeftValue = sortedValue;
                        maxLeftIndex = sortedValueIndex;
                    }
                    sortedMax.RemoveAt(sortedMax.Count - 1);
                }
            }

            for (int i = k; i < nums.Length; i++)
            {
                if (sortedMax.ContainsKey(nums[i]))
                    sortedMax[nums[i]] = i;
                else
                    sortedMax.Add(nums[i], i);

                if (nums[i] >= maxLeftValue || k == 1)
                {
                    maxLeftValue = nums[i];
                    maxLeftIndex = i;
                }
                result.Add(maxLeftValue);
                var nextRangeGreaterThanMax = (i + 1) - maxLeftIndex;
                if (nextRangeGreaterThanMax >= k)
                {
                    var next = false;
                    while (!next && sortedMax.Count > 0)
                    {
                        var sortedValue = sortedMax.Keys[sortedMax.Count - 1];
                        var sortedValueIndex = sortedMax.Values[sortedMax.Count - 1];
                        if (sortedValueIndex > maxLeftIndex)
                        {
                            next = true;
                            maxLeftValue = sortedValue;
                            maxLeftIndex = sortedValueIndex;
                        }
                        sortedMax.RemoveAt(sortedMax.Count - 1);
                    }
                }
            }
            return result.ToArray();
        }
    }

    public static class Lc_239_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 239 Sliding Window Maximum");
            var lc239code = new Lc_239_SlidingWindowMaximum();
            var kMax = lc239code.MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
            Console.WriteLine("Expected: [3,3,5,5,6,7]");
            Log.DebugPrintListInt([.. kMax]);
            Console.WriteLine("");
        }
    }
}