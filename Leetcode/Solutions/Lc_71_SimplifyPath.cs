namespace Leetcode.Solutions
{
    public class Lc_71_SimplifyPath
    {
        // 71. Simplify Path
        // https://leetcode.com/problems/simplify-path/description/
        public string SimplifyPath(string path)
        {
            var paths = path.Split('/');
            Stack<string> stack = new Stack<string>();
            Stack<string> words = new Stack<string>();
            var result = "";

            for (int i = 0; i < paths.Length; i++)
                stack.Push(paths[i]);

            var ignore = 0;
            while (stack.Count > 0)
            {
                var value = stack.Pop();
                if (value == "") continue;
                if (value == ".") continue;
                if (value == "..") ignore += 1;
                else
                    if (ignore > 0) ignore--;
                else
                    words.Push(value);
            }

            while (words.Count > 0)
                result += "/" + words.Pop();
            if (result.Length == 0)
                return "/";
            return result;
        }
    }

    public static class Lc_71_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 71 Simplify Path");
            var lc71code = new Lc_71_SimplifyPath();            
            Console.WriteLine("Expected: /c/ - " + lc71code.SimplifyPath("/a/./b/../../c/"));
            Console.WriteLine("Expected: /for/bar/far - " + lc71code.SimplifyPath("/for//bar/./baz/../far/"));
            Console.WriteLine("Expected: /home/ - " + lc71code.SimplifyPath("/home/"));
            Console.WriteLine("Expected: /home/foo/ - " + lc71code.SimplifyPath("/home//foo/"));
            Console.WriteLine("");
        }
    }
}