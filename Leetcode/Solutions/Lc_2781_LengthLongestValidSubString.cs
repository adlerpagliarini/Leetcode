namespace Leetcode.Solutions
{
    public class Lc_2781_LengthLongestValidSubString
    {
        // 2781. Length of the Longest Valid SubString
        // https://leetcode.com/problems/length-of-the-longest-valid-substring/description/
        public int LongestValidSubstring(string word, IList<string> forbidden)
        {
            var leftIndex = word.Length - 1;
            var rightIndex = word.Length - 1;
            var invalidWords = new HashSet<string>(forbidden);
            var maxInvalidWordSize = forbidden.Max(f => f.Length);
            var maxSize = 0;

            (int lastIndex, int validWordSize, bool hasInvalid) SlideLeft(int startFrom)
            {
                var str = "";
                var start = 0;
                for (start = startFrom; start <= Math.Min(rightIndex, startFrom + maxInvalidWordSize); start++)
                {
                    str += word[start];
                    if (invalidWords.Contains(str))
                        return (start - 1, rightIndex - start, true);

                }
                return (startFrom, rightIndex - startFrom + 1, false);
            }
            while (rightIndex >= 0 && leftIndex >= 0)
            {
                var result = SlideLeft(leftIndex);
                if (result.hasInvalid)
                {
                    rightIndex = result.lastIndex;
                    leftIndex = rightIndex;
                }
                else
                {
                    leftIndex--;
                }
                maxSize = Math.Max(maxSize, result.validWordSize);
            }
            return maxSize;
        }
    }

    public static class Lc_2781_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 2781 Length of the Longest Valid SubString");
            var lc2781code = new Lc_2781_LengthLongestValidSubString();
            Console.WriteLine("Expected Output: 4 - " + lc2781code.LongestValidSubstring("leetcode", new List<string>() { "de", "le", "e" })); // tcod            
            Console.WriteLine("Expected Output: 6 - " + lc2781code.LongestValidSubstring("eabtcodele", new List<string>() { "de", "le", "e" })); // abtcod
            Console.WriteLine("");
        }
    }
}