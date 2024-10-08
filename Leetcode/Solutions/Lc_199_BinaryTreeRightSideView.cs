using Leetcode.Helpers;

namespace Leetcode.Solutions
{
    public class Lc_199_BinaryTreeRightSideView
    {
        // 199. Binary Tree Right Side View
        // https://leetcode.com/problems/binary-tree-right-side-view/description/ 
        public IList<int> RightSideView(TreeNode root)
        {
            if (root == null) return [];
            var vals = new List<int>();
            var rightMax = -1;
            Dfs(root, 0);
            int Dfs(TreeNode node, int depth)
            {
                if (depth > rightMax)
                    vals.Add(node.val);

                if (node.right is not null)
                {
                    var result = Dfs(node.right, depth + 1);
                    rightMax = Math.Max(rightMax, result);
                }

                if (node.left is not null)
                {
                    var result = Dfs(node.left, depth + 1);
                    rightMax = Math.Max(rightMax, result);
                }
                return depth;
            }
            return vals;
        }
    }

    public static class Lc_199_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 199 Binary Tree Right Side View");

            var lc199code = new Lc_199_BinaryTreeRightSideView();
            int?[] values = { 1, 2, 3, null, 5, null, 4 };
            var result = lc199code.RightSideView(TreeNode.BuildTree(values));
            Console.WriteLine("Expected Output: [1, 3, 4]");
            Log.DebugPrintListInt([.. result]);

            int?[] values1 = { 1, 2, 3, null, 5, 4, null, 9 };
            var result1 = lc199code.RightSideView(TreeNode.BuildTree(values1));
            Console.WriteLine("Expected Output: [1, 3, 4, 9]");
            // folder TestCases -> 199-test.png
            Log.DebugPrintListInt([.. result1]);
            Console.WriteLine("");
        }
    }
}