using Leetcode.Helpers;

namespace Leetcode.Solutions
{
    public class Lc_987_VerticalTraversal
    {
        // 987. Vertical Order Traversal of a Binary Tree
        // https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree/
        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            var verticalSorted = new SortedDictionary<int, SortedDictionary<int, List<int>>>();
            Stack<(TreeNode node, int leftRightIndex, int currentDepthRow)> stack = new();

            stack.Push((root, 0, 0));
            while (stack.Count > 0)
            {
                var stacked = stack.Pop();
                var node = stacked.node;
                var val = stacked.node.val;
                var index = stacked.leftRightIndex;
                var depth = stacked.currentDepthRow;

                if (!verticalSorted.ContainsKey(index))
                    verticalSorted.Add(index, new());

                if (!verticalSorted[index].ContainsKey(depth))
                    verticalSorted[index].Add(depth, new());

                verticalSorted[index][depth].Add(val);

                if (node.left is not null)
                    stack.Push((node.left, index - 1, depth + 1));

                if (node.right is not null)
                    stack.Push((node.right, index + 1, depth + 1));
            }

            var results = new List<IList<int>>();
            foreach (var indexSorted in verticalSorted)
            {
                var depths = indexSorted.Value;
                var temp = new List<int>();
                foreach (var depthToSort in depths.Values)
                {
                    temp.AddRange(depthToSort.OrderBy(e => e));
                }
                results.Add(temp);
            }
            return results;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public static TreeNode BuildTree(int?[] values)
        {
            if (values == null || values.Length == 0) return null;

            TreeNode root = new TreeNode(values[0] ?? 0);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int i = 1;
            while (i < values.Length)
            {
                TreeNode current = queue.Dequeue();

                // Assign left child
                if (i < values.Length && values[i] != -1)
                {
                    if (values[i] is not null)
                    {
                        current.left = new TreeNode(values[i] ?? 0);
                        queue.Enqueue(current.left);
                    }
                }
                i++;

                // Assign right child
                if (i < values.Length && values[i] != -1)
                {
                    if (values[i] is not null)
                    {
                        current.right = new TreeNode(values[i] ?? 0);
                        queue.Enqueue(current.right);
                    }
                }
                i++;
            }
            return root;
        }
    }

    public static class Lc_987_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 987 Vertical Order Traversal of a Binary Tree");

            var lc987code = new Lc_987_VerticalTraversal();
            int?[] values = { 1, 2, 3, 4, 6, 5, 7 };
            var resultVertical = lc987code.VerticalTraversal(TreeNode.BuildTree(values));
            Console.WriteLine("Expected Output: [[4],[2],[1,5,6],[3],[7]]");
            Log.DebugPrintListListInt(resultVertical);

            int?[] values1 = { 3, 9, 20, null, null, 15, 7 };
            var resultVertical1 = lc987code.VerticalTraversal(TreeNode.BuildTree(values1));
            Console.WriteLine("Expected Output: [[9],[3,15],[20],[7]]");
            Log.DebugPrintListListInt(resultVertical1);

            Console.WriteLine("");
        }
    }
}
