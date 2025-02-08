class Solution
{
    public bool IsPalindrome2(int x)
    {
        if (x < 0)
        {
            return false;
        }
        int defaultX = x;
        int reverseX = 0;
        while (x != 0)
        {
            reverseX = reverseX * 10 + (x % 10);
            x /= 10;
        }
        if (reverseX == defaultX)
        {
            return true;
        }
        return false;
    }
    public bool IsPalindrome1(int x) 
    {
        if (x < 0)
        {
            return false;
        }
        if (x >= 0 && x < 10) {
            return true;
        }
        List<int> lst = new List<int>();
        while (x != 0) {
            lst.Add(x % 10);
            x /= 10;
        }
        int left = 0;
        int right = lst.Count - 1;
        while (left < right) 
        {
            if (!lst[left].Equals(lst[right]))
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
    static void Main(string[] args)
    {
        try
        {
            int x = int.Parse(Console.ReadLine());
            Solution s = new Solution();
            var result = s.IsPalindrome2(x);
            System.Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
