using Leetcode.Helpers;

namespace Leetcode.Solutions
{
    public class Lc_Studys
    {
        // 11. Container With Most Water
        // https://leetcode.com/problems/container-with-most-water/
        public int MaxArea(int[] height)
        {
            var left = 0;
            var right = height.Length - 1;
            var waterArea = 0;
            while (left < right)
            {
                var leftHeight = height[left];
                var rightHeight = height[right];
                var currentWidth = right - left;
                var tempArea = currentWidth * int.Min(leftHeight, rightHeight);
                waterArea = int.Max(waterArea, tempArea);
                if (leftHeight >= rightHeight)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return waterArea;
        }

        // https://neetcode.io/problems/top-k-elements-in-list

        public int[] TopKFrequent(int[] nums, int k)
        {
            var dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dic.ContainsKey(nums[i]))
                    dic.Add(nums[i], 0);
                dic[nums[i]] += 1;
            }

            // Linq Sort
            // var maxs = dic.OrderByDescending(e => e.Value).Take(k).Select(k => k.Key).OrderBy(e => e).ToArray();
            // return maxs;

            // Bucket Sort
            var bucketSort = new List<int>[nums.Length + 1];
            foreach (var keyAmount in dic)
            {
                var key = keyAmount.Key;
                var amount = keyAmount.Value;
                bucketSort[amount] ??= new List<int>();
                bucketSort[amount].Add(key);
            }

            var sortedBucket = new List<int>();
            for (var maxRight = bucketSort.Length - 1; maxRight >= 0 && k > 0; maxRight--)
            {
                if (bucketSort[maxRight] == null) continue;
                if (sortedBucket.Count == k) break;
                foreach (var num in bucketSort[maxRight])
                    sortedBucket.Add(num);
            }
            return sortedBucket.ToArray();
        }

        // Pacific Atlantic Water Flow
        // https://neetcode.io/problems/pacific-atlantic-water-flow

    }

    // https://neetcode.io/problems/time-based-key-value-store
    // Time Based Key Value Store
    public class TimeMap
    {
        private Dictionary<string, List<Tuple<int, string>>> store = new();

        public TimeMap()
        {

        }

        public void Set(string key, string value, int timestamp)
        {
            if (!store.ContainsKey(key))
                store.Add(key, new List<Tuple<int, string>>());
            store[key].Add(new Tuple<int, string>(timestamp, value));
        }

        public string Get(string key, int timestamp)
        {
            if (!store.ContainsKey(key))
                return "";
            var timeValues = store[key];

            // binary search
            int left = 0;
            int right = timeValues.Count - 1;
            Tuple<int, string> result = new Tuple<int, string>(0, "");
            while (left <= right)
            {
                var middle = left + (left - right) / 2;

                if (timeValues[middle].Item1 <= timestamp)
                {
                    result = timeValues[middle];
                    left = middle + 1;
                }
                else
                    right = middle - 1;
            }
            return result.Item2;
        }
    }

    // https://leetcode.com/problems/lru-cache
    // 146. LRU Cache
    public class LRUCache
    {
        public class CacheItem
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public CacheItem Prev { get; set; }
            public CacheItem Next { get; set; }

            public CacheItem(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly int _capacity;
        private readonly Dictionary<int, CacheItem> _map = new();

        // Dummy sentinels: head.Next = MRU, tail.Prev = LRU
        private readonly CacheItem _head = new CacheItem(0, 0);
        private readonly CacheItem _tail = new CacheItem(0, 0);

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _head.Next = _tail;
            _tail.Prev = _head;
        }

        public int Get(int key)
        {
            if (!_map.TryGetValue(key, out var node)) return -1;
            MoveToHead(node); // mark as most recently used
            return node.Value;
        }

        public void Put(int key, int value)
        {
            if (_capacity == 0) return;

            if (_map.TryGetValue(key, out var node))
            {
                node.Value = value;
                MoveToHead(node);
                return;
            }

            var newNode = new CacheItem(key, value);
            _map[key] = newNode;
            AddToHead(newNode);

            if (_map.Count > _capacity)
            {
                var lru = PopTail();
                _map.Remove(lru.Key);
            }
        }

        private void AddToHead(CacheItem node)
        {
            node.Prev = _head;
            node.Next = _head.Next;
            _head.Next.Prev = node;
            _head.Next = node;
        }

        private void RemoveNode(CacheItem node)
        {
            var prev = node.Prev;
            var next = node.Next;
            prev.Next = next;
            next.Prev = prev;
            node.Prev = node.Next = null;
        }

        private void MoveToHead(CacheItem node)
        {
            RemoveNode(node);
            AddToHead(node);
        }

        private CacheItem PopTail()
        {
            var node = _tail.Prev;
            RemoveNode(node);
            return node;
        }
    }

    public static class Lc_Study
    {
        public static void Execute()
        {
            Console.WriteLine("Leetcode: 11. Container With MostWater");
            var lc11code = new Lc_Studys();
            Console.WriteLine("Expected Output: 49 - " + lc11code.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
            Console.WriteLine("Expected Output: 1 - " + lc11code.MaxArea(new int[] { 1, 2 }));
            Console.WriteLine("");


            var neetcode115 = new Lc_Studys();
            Console.WriteLine("Expected [2,3]");
            Log.DebugPrintListInt(neetcode115.TopKFrequent(new int[] { 1, 2, 2, 3, 3, 3, 3 }, 3).ToList());
            Console.WriteLine("Expected [7]");
            Log.DebugPrintListInt(neetcode115.TopKFrequent(new int[] { 7 }, 1).ToList());

            
            TimeMap timeMap = new TimeMap();
            timeMap.Set("alice", "happy", 1); // store the key "alice" and value "happy" along with timestamp = 1.
            Console.WriteLine("Expected happy: " + timeMap.Get("alice", 1)); // return "happy"
            Console.WriteLine("Expected happy: " + timeMap.Get("alice", 2)); // return "happy", there is no value stored for timestamp 2, thus we return the value at timestamp 1.
            timeMap.Set("alice", "sad", 3); // store the key "alice" and value "sad" along with timestamp = 3.
            Console.WriteLine("Expected sad: " + timeMap.Get("alice", 3)); // return "sad"
            
            LRUCache lRUCache = new LRUCache(2);
            lRUCache.Put(1, 1); // cache is {1=1}
            lRUCache.Put(2, 2); // cache is {1=1, 2=2}
            Console.WriteLine("Expected 1: " + lRUCache.Get(1)); // return 1
            lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            Console.WriteLine("Expected -1: " + lRUCache.Get(2)); // returns -1 (not found)
            lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            Console.WriteLine("Expected -1: " + lRUCache.Get(1)); // return -1 (not found)
            Console.WriteLine("Expected 3: " + lRUCache.Get(3)); // return 3
            Console.WriteLine("Expected 4: " + lRUCache.Get(4)); // return 4
        }
    }
}