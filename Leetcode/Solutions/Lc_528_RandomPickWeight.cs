namespace Leetcode.Solutions
{
    public class Lc_528_RandomPickWeight
    {
        // 528. Random Pick with Weight
        // https://leetcode.com/problems/random-pick-with-weight/description/
        public class Solution
        {
            public int[] w;
            public List<double> probs = new List<double>();
            public List<double> percentProbs = new();

            public Solution(int[] w)
            {
                this.w = w;
                var sumW = w.Sum();
                for (int i = 0; i < w.Length; i++)
                    probs.Add((double)w[i] / (double)sumW);
                percentProbs.Add(probs[0]);
                for (int i = 1; i < w.Length; i++)
                {
                    percentProbs.Add(percentProbs[i - 1] + probs[i]);
                }
            }

            public int PickIndex()
            {
                var r = new Random().NextDouble();
                // loop works too, but binary search will be faster
                /*for (int i = 0; i < w.Length; i++)
                {
                    if (percentProbs[i] > r)
                        return i;
                }
                return -1;*/
                var left = 0;
                var right = w.Length - 1;
                var binarySearch = 0;
                while (left < right)
                {
                    binarySearch = left + (right - left) / 2;
                    if (percentProbs[binarySearch] < r)
                        left = binarySearch + 1;
                    else
                        right = binarySearch;
                }
                return left;
            }
        }
    }

    public static class Lc_528_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 528 Random Pick with Weight");
            var w = new int[] { 100, 9, 100 };
            var lc528code = new Lc_528_RandomPickWeight.Solution(w);
            Console.WriteLine("Expected: 0 || 2 - " + lc528code.PickIndex());            
            Console.WriteLine("");
        }
    }
}