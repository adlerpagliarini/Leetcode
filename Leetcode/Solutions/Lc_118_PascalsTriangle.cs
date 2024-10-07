using Leetcode.Helpers;

namespace Leetcode.Solutions
{
    public class Lc_118_PascalsTriangle
    {
        // 118. Pascal's Triangle
        // https://leetcode.com/problems/pascals-triangle/description/
        public IList<IList<int>> Generate(int numRows)
        {
            var result = new List<IList<int>>();
            result.Add(new List<int>() { 1 });
            var row = 1;
            while (row < numRows)
            {
                result.Add(new List<int>() { 1 });
                var prevRow = result[row - 1];
                for (int i = 1; i < row; i++)
                {
                    result[row].Add(prevRow[i - 1] + prevRow[i]);
                }
                result[row].Add(1);
                row++;
            }
            return result;
        }
    }

    public static class Lc_118_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 118 Pascal's Triangle");

            var lc118code = new Lc_118_PascalsTriangle();
            var result = lc118code.Generate(5);
            Console.WriteLine("Expected Output: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]");
            Log.DebugPrintListListInt(result);

            Console.WriteLine("");
        }
    }
}
