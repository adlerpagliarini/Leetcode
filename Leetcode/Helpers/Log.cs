namespace Leetcode.Helpers
{
    public static class Log
    {
        public static void DebugPrint(char[][] grid)
        {
            foreach (char[] row in grid)
            {
                var str = "";
                str = string.Join("", row);
                Console.WriteLine(str);
            }
            Console.WriteLine($"**************************************************");
        }

        public static void DebugPrintListListInt(IList<IList<int>> grid)
        {
            foreach (var row in grid)
            {
                var str = "";
                str = string.Join(", ", row);
                Console.WriteLine(str);
            }
            Console.WriteLine($"**************************************************");
        }

        public static void DebugPrintListListString(IEnumerable<IEnumerable<string>> grid)
        {
            foreach (var row in grid)
            {
                var str = "";
                str = string.Join(", ", row);
                Console.WriteLine(str);
            }
            Console.WriteLine($"**************************************************");
        }

        public static void DebugPrintListInt(List<int> grid)
        {
            var str = string.Join(", ", grid);
            Console.WriteLine(str);
            Console.WriteLine($"**************************************************");
        }

        public static void DebugPrintListString(List<string> grid)
        {
            var str = string.Join(", ", grid);
            Console.WriteLine(str);
            Console.WriteLine($"**************************************************");
        }
    }
}
