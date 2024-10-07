namespace Leetcode.Solutions
{
    public class Lc_124_BinaryTreeMaximumPathSum
    {
        // 124. Binary Tree Maximum Path Sum
        // https://leetcode.com/problems/binary-tree-maximum-path-sum/description/
        public int MaxPathSum(TreeNode root)
        {
            int max = int.MinValue;
            var nodeLeafsSums = new List<int>();
            var value = BfsNodeLeafsSum(root);
            nodeLeafsSums.Add(value);

            int BfsNodeLeafsSum(TreeNode node)
            {

                if (node is null) return 0;
                var left = Math.Max(0, BfsNodeLeafsSum(node.left));
                var right = Math.Max(0, BfsNodeLeafsSum(node.right));
                var maxSum = left + right + node.val;
                max = Math.Max(max, maxSum);
                return node.val + Math.Max(left, right);
            }
            return max;
        }
    }

    public static class Lc_124_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 124 Binary Tree Maximum Path Sum");

            var lc124code = new Lc_124_BinaryTreeMaximumPathSum();
            int?[] treeValues = { -10, 9, 20, null, null, 15, 7 };
            var treeNodes = TreeNode.BuildTree(treeValues);
            Console.WriteLine("Expected Output: 42 - " + lc124code.MaxPathSum(treeNodes));
            int?[] treeValues2 = { 10, 5, -10, -5, 1, 50, 20 };
            var treeNodes2 = TreeNode.BuildTree(treeValues2);
            Console.WriteLine("Expected Output: 60 - " + lc124code.MaxPathSum(treeNodes2));            
            Console.WriteLine("");
        }
    }
}