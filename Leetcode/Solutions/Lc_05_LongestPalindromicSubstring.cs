namespace Leetcode.Solutions
{
    public class Lc_05_LongestPalindromicSubstring
    {
        // 5. Longest Palindromic Substring
        // https://leetcode.com/problems/longest-palindromic-substring/description
        public string LongestPalindrome(string s)
        {
            // Find the middle of the string
            // If is even (par) have middle
            // If is odd (impar) dont have middle

            // abba
            // abcba
            var longestWord = "";
            var maxLegthWord = 0;
            var startMaxFrom = 0;

            if (string.IsNullOrEmpty(s)) return s;
            if (s.Length < 2) return s[0].ToString();

            for (var i = 0; i < s.Length; i++) // foreach char try to find the longest word
            {
                var len1 = subGroupExpandWord(i, i, s); // odd
                var len2 = subGroupExpandWord(i, i + 1, s); // even
                var maxLength = Math.Max(len1, len2);
                if (maxLength > maxLegthWord)
                {
                    startMaxFrom = i - ((maxLength - 1) / 2);
                    maxLegthWord = maxLength;
                }
            }
            int subGroupExpandWord(int start, int end, string word)
            {
                while (start >= 0 && end < s.Length && s[start] == s[end])
                {
                    start--;
                    end++;
                }
                var length = (end - 1) - (start + 1) + 1;
                return length;
            }

            longestWord = s.Substring(startMaxFrom, maxLegthWord);
            return longestWord;
        }
    }

    public static class Lc_05_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 5 Longest Palindromic Substring");

            var lc118code = new Lc_05_LongestPalindromicSubstring();
            Console.WriteLine("Expected Output: a - " + lc118code.LongestPalindrome("a"));
            Console.WriteLine("Expected Output: a - " + lc118code.LongestPalindrome("ac"));
            Console.WriteLine("Expected Output: bb - " + lc118code.LongestPalindrome("bb"));
            Console.WriteLine("Expected Output: bab - " + lc118code.LongestPalindrome("babad"));
            Console.WriteLine("Expected Output: bb - " + lc118code.LongestPalindrome("cbbd"));
            Console.WriteLine("Expected Output: cbbc - " + lc118code.LongestPalindrome("cbbc"));
            Console.WriteLine("");
        }
    }
}
