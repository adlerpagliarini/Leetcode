using Leetcode.Helpers;

namespace Leetcode.Solutions
{
    public class Lc_210_CourseScheduleII
    {
        // 210. Course Schedule II
        // https://leetcode.com/problems/course-schedule-ii/description/
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            int UNVISITED = 0;
            int VISITING = 1;
            int VISITED = 2;

            var status = new int[numCourses];
            status = Enumerable.Repeat(UNVISITED, numCourses).ToArray();
            var orderResult = new List<int>();

            var requisites = new Dictionary<int, List<int>>();

            for (int i = 0; i < prerequisites.Length; i++)
            {
                var course = prerequisites[i][0];
                var dependency = prerequisites[i][1];

                if (!requisites.ContainsKey(course))
                    requisites[course] = new List<int>();

                requisites[course].Add(dependency);
            }

            bool Dfs(int nodexIndex, int depth)
            {
                if (status[nodexIndex] == VISITING)
                    return false; // cycle detected

                if (status[nodexIndex] == VISITED)
                    return true;

                status[nodexIndex] = VISITING;

                if (requisites.ContainsKey(nodexIndex))
                    foreach (var dependency in requisites[nodexIndex])
                        if (!Dfs(dependency, depth++))
                            return false;

                status[nodexIndex] = VISITED;
                orderResult.Add(nodexIndex);
                return true;
            }

            for (int i = 0; i < numCourses; i++)
                if (!Dfs(i, 0))
                    return [];

            return orderResult.ToArray();
        }
    }

    public static class Lc_210_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 210 Course Schedule II");

            var lc210code = new Lc_210_CourseScheduleII();
            var result = lc210code.FindOrder(6, [[2, 0], [1, 0], [0, 3], [3, 4], [3, 5]]);
            Console.WriteLine("Expected Output: [4, 5, 3, 0, 1, 2]");
            Log.DebugPrintListInt([.. result]);
            var result1 = lc210code.FindOrder(4, [[1, 0], [2, 0], [3, 1], [3, 2]]);
            Console.WriteLine("Expected Output: [0, 2, 1, 3] || [0, 1, 2, 3]");
            Log.DebugPrintListInt([.. result1]);
            Console.WriteLine("");
        }
    }
}