namespace Leetcode.Solutions
{
    public class Lc_415_AddStrings
    {
        // 415. Add Strings
        // https://leetcode.com/problems/add-strings/description/
        public string AddStrings(string num1, string num2)
        {
            var n1Size = num1.Length - 1;
            var n2Size = num2.Length - 1;
            var rest = 0;
            var result = new List<int>();

            while (n1Size >= 0 && n2Size >= 0)
            {
                var n1 = num1[n1Size] - '0';
                var n2 = num2[n2Size] - '0';
                var sum = n1 + n2 + rest;
                if (sum >= 10)
                    rest = 1;
                else
                    rest = 0;
                result.Add(sum >= 10 ? sum % 10 : sum);
                n1Size--;
                n2Size--;
            }

            while (n1Size >= 0)
            {
                var n1 = num1[n1Size] - '0';
                var sum = n1 + rest;
                if (sum >= 10)
                    rest = 1;
                else
                    rest = 0;
                result.Add(sum >= 10 ? sum % 10 : sum);
                n1Size--;
            }

            while (n2Size >= 0)
            {
                var n2 = num2[n2Size] - '0';
                var sum = n2 + rest;
                if (sum >= 10)
                    rest = 1;
                else
                    rest = 0;
                result.Add(sum >= 10 ? sum % 10 : sum);
                n2Size--;
            }

            if (rest == 1)
                result.Add(1);

            var r = result.Select(e => e.ToString());
            return string.Join("", r.Reverse());
        }
    }

    public static class Lc_415_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 415 Add Strings");
            var lc415code = new Lc_415_AddStrings();
            Console.WriteLine("Expected Output: 134 - " + lc415code.AddStrings("11", "123"));
            Console.WriteLine("Expected Output: 0 - " + lc415code.AddStrings("0", "0"));
            Console.WriteLine("Expected Output: 533 - " + lc415code.AddStrings("456", "77"));
            Console.WriteLine("Expected Output: 100 - " + lc415code.AddStrings("99", "1"));
            Console.WriteLine("");
        }
    }
}
