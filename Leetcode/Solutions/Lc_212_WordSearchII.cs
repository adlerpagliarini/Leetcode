using Leetcode.Helpers;

namespace Leetcode.Solutions
{
    public class Lc_212_WordSearchII
    {
        // 212. Word Search II
        // https://leetcode.com/problems/word-search-ii/description/
        public class PrefixTree
        {
            public Dictionary<char, PrefixTree> Children = new();
            public bool IsEnd = false;
            public string Word = "";

            public bool Search(char ch, out PrefixTree children) => Children.TryGetValue(ch, out children);
        }

        public class PrefixRoot
        {
            public PrefixTree Root = new();

            public void AddWord(string word)
            {
                var temp = Root;
                foreach (var ch in word)
                {
                    if (temp.Children.TryGetValue(ch, out var child))
                        temp = child;
                    else
                    {
                        temp.Children[ch] = new PrefixTree();
                        temp = temp.Children[ch];
                    }
                }
                temp.IsEnd = true;
                temp.Word = word;
            }
        }

        public class Solution
        {
            public IList<string> FindWords(char[][] board, string[] words)
            {
                var inits = new HashSet<char>();
                var prefixTree = new PrefixRoot();
                var positionsToMove = new List<(int x, int y)>() { (-1, 0), (0, -1), (1, 0), (0, 1) };
                var results = new List<string>();

                foreach (var word in words)
                {
                    inits.Add(word[0]);
                    prefixTree.AddWord(word);
                }

                for (int i = 0; i < board.Length; i++)
                {
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        if (!inits.Contains(board[i][j])) continue;
                        var visited = new bool[board.Length, board[0].Length];
                        DfsSearch(i, j, prefixTree.Root, visited);
                    }
                }

                void DfsSearch(int x, int y, PrefixTree node, bool[,] visited)
                {
                    if (visited[x, y]) return;
                    visited[x, y] = true;
                    var ch = board[x][y];
                    if (node.Search(ch, out var children))
                    {
                        if (children.IsEnd) results.Add(children.Word);
                        foreach (var moveTo in positionsToMove)
                        {
                            var goToX = moveTo.x + x;
                            var goToY = moveTo.y + y;

                            if (goToX < 0 || goToY < 0) continue;
                            if (goToX >= board.Length || goToY >= board[0].Length) continue;
                            if (visited[goToX, goToY]) continue;
                            DfsSearch(goToX, goToY, children, visited);
                        }
                    }
                    visited[x, y] = false;
                    return;
                }
                return results.Distinct().ToList();
            }
        }
    }

    public static class Lc_212_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 212 Word Search II");
            var lc212code = new Lc_212_WordSearchII.Solution();
            var boards = new char[][] { new char[] { 'o', 'a', 'a', 'n' }, new char[] { 'e', 't', 'a', 'e' }, new char[] { 'i', 'h', 'k', 'r' }, new char[] { 'i', 'f', 'l', 'v' } };
            var words = new string[] { "eat", "oath", "ant" };
            Console.WriteLine("Expected: [eat, oath]");
            Log.DebugPrintListString([.. lc212code.FindWords(boards, words)]);
            Console.WriteLine("");
        }
    }
}