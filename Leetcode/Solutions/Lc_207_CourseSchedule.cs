namespace Leetcode.Solutions
{
    public class Lc_207_CourseSchedule
    {
        // 207. Course Schedule
        // https://leetcode.com/problems/course-schedule
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var UNVISITED = 0;
            var VISITING = 1;
            var VISITED = 2;

            var prereqs = new Dictionary<int, List<int>>();
            var courseState = new int[numCourses];

            foreach (var pair in prerequisites)
            {
                var current = pair[0];
                var prereq = pair[1];
                if (!prereqs.ContainsKey(current))
                    prereqs.Add(current, new List<int>());
                prereqs[current].Add(prereq);
            }

            for (int i = 0; i < numCourses; i++)
            {
                var continueSearch = DFS(i);
                if (!continueSearch) break;
            }


            bool DFS(int course)
            {
                if (courseState[course] == VISITING) // cycle
                    return false;
                if (courseState[course] == VISITED) // already searched
                    return true;

                courseState[course] = VISITING;

                if (prereqs.ContainsKey(course))
                    foreach (var prereq in prereqs[course])
                        if (!DFS(prereq)) return false;

                courseState[course] = VISITED;
                return true;
            }
            return courseState.All(e => e == VISITED);
        }
    }

    public static class Lc_207_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 210 Course Schedule II");

            var lc207code = new Lc_207_CourseSchedule();
            var result = lc207code.CanFinish(6, [[2, 0], [1, 0], [0, 3], [3, 4], [3, 5]]);
            Console.WriteLine("Expected Output: TRUE - " + result);
            var result1 = lc207code.CanFinish(6, [[2, 0], [1, 0], [0, 3], [3, 4], [3, 5], [5, 1]]);
            Console.WriteLine("Expected Output: FALSE - " + result1);
            var result2 = lc207code.CanFinish(4, [[1, 0], [2, 0], [3, 1], [3, 2]]);
            Console.WriteLine("Expected Output: TRUE - " + result2);
            Console.WriteLine("");
        }
    }
}
