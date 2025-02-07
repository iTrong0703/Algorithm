class Solution
{
    public static int[] TwoSum(int[] nums, int target)
    {
        var length = nums.Length;
        Dictionary<int, int> keyValues = new Dictionary<int, int>();
        for (int i = 0; i < length; i++)
        {
            int x = target - nums[i];
            if (keyValues.ContainsKey(x)) // ~ if (nums[i] + x == target)
            {
                return [keyValues[x], i];
            }
            if (!keyValues.ContainsKey(nums[i])) // Tránh lỗi trùng lặp key
            {
                keyValues.Add(nums[i], i); // Lưu giá trị = key, vị trí = value
            }
            
        }
        throw new ArgumentException("Error");
    }
    static void Main(string[] args)
    {
        try
        {
            string input = Console.ReadLine();
            int target = int.Parse(Console.ReadLine());

            int[] nums = Array.ConvertAll(input.Split(' '), int.Parse);

            var result = TwoSum(nums, target);
            System.Console.WriteLine("{0} {1}", result[0], result[1]);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
