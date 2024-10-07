using static Leetcode.Solutions.Lc_380_InsertDeleteGetRandomO1;

namespace Leetcode.Solutions
{
    public class Lc_380_InsertDeleteGetRandomO1
    {
        // 380. Insert Delete GetRandom O(1)
        // https://leetcode.com/problems/insert-delete-getrandom-o1/description/
        public class RandomizedSet
        {
            public Dictionary<int, int> IntIndex = new Dictionary<int, int>();
            public List<int> Ints = new List<int>();
            public RandomizedSet()
            {

            }

            public bool Insert(int val)
            {
                if (IntIndex.ContainsKey(val))
                    return false;
                Ints.Add(val);
                IntIndex.Add(val, Ints.Count - 1);
                return true;
            }

            public bool Remove(int val)
            {
                if (IntIndex.TryGetValue(val, out int removeIndex))
                {
                    // get values
                    var removeValue = Ints[removeIndex];
                    var last = Ints[Ints.Count - 1];
                    // change itens on list
                    Ints[Ints.Count - 1] = removeValue;
                    Ints[removeIndex] = last;
                    // update last index
                    IntIndex[last] = removeIndex;
                    // remove
                    IntIndex.Remove(removeValue);
                    Ints.RemoveAt(Ints.Count - 1);
                    return true;
                }
                return false;
            }

            public int GetRandom()
            {
                var random = new Random();
                int i = random.Next(0, Ints.Count);
                return Ints[i];
            }
        }
    }
    public static class Lc_380_Tests
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 380 Insert Delete GetRandom O(1)");
            var lc380code = new RandomizedSet();
            Console.WriteLine("Expected Output: true - " + lc380code.Insert(1));
            Console.WriteLine("Expected Output: false - " + lc380code.Remove(2));
            Console.WriteLine("Expected Output: true - " + lc380code.Insert(2));
            Console.WriteLine("Expected Output: 1 || 2 - " + lc380code.GetRandom());
            Console.WriteLine("Expected Output: true - " + lc380code.Remove(1));
            Console.WriteLine("Expected Output: true - " + lc380code.Insert(2));
            Console.WriteLine("Expected Output: 2 - " + lc380code.GetRandom());
            Console.WriteLine("");
        }
    }
}