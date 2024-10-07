using Leetcode.Helpers;

namespace Leetcode.Solutions
{
    public class Lc_797_AllPathsFromSourceTarget
    {
        // 797. All Paths From Source To Target
        // https://leetcode.com/problems/all-paths-from-source-to-target/description/
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            var last = graph.Length - 1;
            var paths = new List<IList<int>>();
            Dfs(graph[0], 0, new List<int>() { 0 });

            void Dfs(int[] directions, int node, List<int> path)
            {
                if (node == last)
                    paths.Add(path);

                foreach (int dic in directions)
                {
                    var temp = new List<int>();
                    temp.AddRange(path);
                    temp.Add(dic);
                    Dfs(graph[dic], dic, temp);
                }
            }

            return paths;
        }
    }

    public static class Lc_797_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 797 All Paths From Source To Target");

            var lc797code = new Lc_797_AllPathsFromSourceTarget();
            var graph = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 3 },
                new int[] { 3 },
                new int[] { }
            };
            Console.WriteLine("Expected Output: [[0,1,3],[0,2,3]]");
            Log.DebugPrintListListInt(lc797code.AllPathsSourceTarget(graph));

            var graph1 = new int[][]
           {
                new int[] { 4, 3, 1 },
                new int[] { 3, 2, 4 },
                new int[] { 3 },
                new int[] { 4 },
                new int[] { }
           };
            Console.WriteLine("Expected Output: [[0,4],[0,3,4],[0,1,3,4],[0,1,2,3,4],[0,1,4]]");
            Log.DebugPrintListListInt(lc797code.AllPathsSourceTarget(graph1));

            Console.WriteLine("");
        }
    }
}
