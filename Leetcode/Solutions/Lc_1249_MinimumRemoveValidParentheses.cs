using System.Text;

namespace Leetcode.Solutions
{
    public class Lc_1249_MinimumRemoveValidParentheses
    {
        // 1249. Minimum Remove to Make Valid Parentheses
        // https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/description/        
        public string MinRemoveToMakeValid(string s)
        {
            var dic = new Dictionary<char, List<int>>();
            Dictionary<char, Stack<int>> dicStake = new();
            var remove = new HashSet<int>();

            // get the positions of each parentheses
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    if (!dicStake.ContainsKey(s[i]))
                    {
                        dicStake[s[i]] = new Stack<int>();
                    }
                    dicStake[s[i]].Push(i);
                }
                else if (s[i] == ')')
                {
                    if (dicStake.TryGetValue('(', out Stack<int>? value) && value.Count > 0)
                        value.Pop();
                    else
                        remove.Add(i);
                }
            }

            foreach (var item in dicStake)
            {
                while (item.Value.Count > 0)
                {
                    remove.Add(item.Value.Pop());
                }
            }

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (remove.Contains(i)) continue;
                stringBuilder.Append(s[i]);
            }

            string str = stringBuilder.ToString();
            return str;
        }
    }

    public static class Lc_1249_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 1249. Minimum Remove to Make Valid Parentheses");
            var lc1249code = new Lc_1249_MinimumRemoveValidParentheses();
            Console.WriteLine("Expected lee(t(c)o)de || lee(t(c)ode): " + lc1249code.MinRemoveToMakeValid("lee(t(c)o)de)"));
            Console.WriteLine("Expected 'Empty' : " + lc1249code.MinRemoveToMakeValid("))(("));
            Console.WriteLine("Expected ab(c)d: " + lc1249code.MinRemoveToMakeValid("a)b(c)d"));
            Console.WriteLine("Expected (): " + lc1249code.MinRemoveToMakeValid("))()((("));
            Console.WriteLine("Expected ()(): " + lc1249code.MinRemoveToMakeValid("())()((("));
            Console.WriteLine("");
        }
    }
}