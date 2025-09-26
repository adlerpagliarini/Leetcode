using Leetcode.Helpers;

namespace Leetcode.Solutions
{
    public class Lc_56_MergeIntervals
    {
        // 56. Merge Intervals
        // https://leetcode.com/problems/merge-intervals/description
        public int[][] Merge(int[][] intervals)
        {
            var numbers = new List<int>();
            var results = new List<Tuple<int, int>>();
            var orderedIntervals = intervals.OrderBy(e => e[0]).ToArray();
            for (int i = 0; i < orderedIntervals.Length; i++)
            {
                var min = orderedIntervals[i][0];
                var tempMin = min;
                var max = orderedIntervals[i][1];
                var newMax = int.MinValue;
                var newMin = int.MaxValue;
                var j = 0;
                for (j = i + 1; j < orderedIntervals.Length; j++)
                {
                    newMin = orderedIntervals[j][0];
                    newMax = orderedIntervals[j][1];

                    if (tempMin <= newMin && max >= newMin && (max <= newMax || newMax <= max))
                    {
                        max = Math.Max(max, newMax);
                        tempMin = newMin;
                    }
                    else
                    {
                        break;
                    }
                }
                i = j - 1;
                results.Add(new Tuple<int, int>(min, max));
            }
            return results.Select(e => new int[] { e.Item1, e.Item2 }).ToArray();
        }
    }
    public static class Lc_56_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 56. Merge Intervals");

            var lc156code = new Lc_56_MergeIntervals();
            int[][] intervals = new int[][]
                                {
                                        new int[] { 1, 3 },
                                        new int[] { 2, 6 },
                                        new int[] { 8, 10 },
                                        new int[] { 15, 18 }
                                };
            var result = lc156code.Merge(intervals);
            Console.WriteLine("Expected Output: [[1,6],[8,10],[15,18]]");
            Log.DebugPrintListListInt(result);

            int[][] intervals1 = new int[][]
                                {
                                        new int[] { 1, 4 },
                                        new int[] { 3, 6 },
                                        new int[] { 5, 7 },
                                        new int[] { 8, 10 },
                                        new int[] { 10, 18 },
                                        new int[] { 19, 21 }
                                };
            var result1 = lc156code.Merge(intervals1);
            Console.WriteLine("Expected Output: [[1,7],[8,18],[19,21]]");
            Log.DebugPrintListListInt(result1);

            int[][] intervals2 = new int[][]
                    {
                                        new int[] { 4, 7 },
                                        new int[] { 1, 4 },
                    };
            var result2 = lc156code.Merge(intervals2);
            Console.WriteLine("Expected Output: [[1,7]]");
            Log.DebugPrintListListInt(result2);

            int[][] intervals3 = new int[][]
                    {
                                        new int[] { 1, 4 },
                                        new int[] { 2, 3 },
                    };
            var result3 = lc156code.Merge(intervals3);
            Console.WriteLine("Expected Output: [[1,4]]");
            Log.DebugPrintListListInt(result3);

            Console.WriteLine("");
        }
    }
}
