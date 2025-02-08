class Solution
{
    public bool IsPalindrome(int x) 
    {
        List<int> lst = new List<int>();
        if (x < 0) {
            x = Math.Abs(x);
            while (x != 0) {
                lst.Add(x % 10);
                x /= 10;
            }
            lst[0] *= -1;
        }
        else {
            while (x != 0) {
                lst.Add(x % 10);
                x /= 10;
            }
        }
        
        if (lst.Count() > 1 && lst[0].Equals(lst.Last()))
        {
            return true;
        }
        return false;
    }
    static void Main(string[] args)
    {
        try
        {
            int x = int.Parse(Console.ReadLine());
            Solution s = new Solution();
            var result = s.IsPalindrome(x);
            System.Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
