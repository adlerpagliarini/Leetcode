using Leetcode.Helpers;
using Microsoft.VisualBasic;
using static Leetcode.Solutions.Lc_211_AddSearchWords;

namespace Leetcode.Solutions
{
    public class Lc_211_AddSearchWords
    {
        // 211. Design Add and Search Words Data Structure
        // https://leetcode.com/problems/design-add-and-search-words-data-structure/description/
        public class PrefixWord
        {
            public Dictionary<char, PrefixWord> Children = new();
            public bool IsEnd = false;
            public string Word = null;
        }

        public class WordDictionary
        {
            public PrefixWord Tree = new();

            public WordDictionary()
            {

            }

            public void AddWord(string word)
            {
                var temp = Tree;
                foreach (var c in word)
                {
                    if (!temp.Children.ContainsKey(c))
                        temp.Children[c] = new PrefixWord();
                    temp = temp.Children[c];
                }
                temp.IsEnd = true;
                temp.Word = word;
            }

            private bool DfsSearch(PrefixWord prefix, string lookFor, int depth)
            {
                if (prefix == null) return false;
                if (lookFor.Length == depth) return prefix.IsEnd;

                var ch = lookFor[depth];
                if (ch == '.')
                    foreach (var prefixWord in prefix.Children.Values)
                    {
                        var result = DfsSearch(prefixWord, lookFor, depth + 1);
                        if (result) return true;
                    }
                else if (prefix.Children.TryGetValue(ch, out var prefixWord))
                {
                    var result = DfsSearch(prefixWord, lookFor, depth + 1);
                    if (result) return true;
                }
                return false;
            }

            public bool Search(string word)
            {
                var result = DfsSearch(Tree, word, 0);
                return result;
            }
        }
    }

    public static class Lc_211_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 211 Design Add and Search Words Data Structure");
            var strings = new string[] { "bad", "dad", "mad" };
            var searchStrings = new string[] { "pad", "bad", ".ad", "b..", "b.", "...", "....", "m.d" };
            var lc211code = new WordDictionary();
            foreach (var str in strings)
                lc211code.AddWord(str);
            Console.WriteLine("Expected Output: false,true,true,true,false,true,false,true");
            foreach (var str in searchStrings)
                Console.WriteLine(lc211code.Search(str));
            Console.WriteLine("");
        }
    }
}
