// Ý tưởng
// Đề bài kêu tìm length của last word
// 1. Đầu tiên ta cần s.TrimEnd để loại bỏ ' ' ở cuối s
// 2. Bắt đầu chạy loop từ vị trí cuối của s đã trim đến khi tìm thấy ' ' thì return về


// Vấn đề
// Test case: "a"
// Nếu ta chạy loop vs if (s[i] != ' ') thì với test case trên nó vẫn thỏa dẫn đến i-- = 0;
// -> s.Length - i = 1 - 0 = 1
// => Vẫn đúng

// Nhưng với các test case như: "Hello world"
// Thì khi đến vị trí s[6] = 'w' -> if thỏa -> i--
// s[5] = ' ' -> if false -> i = 5
// -> s.Length - i = 11 - 5 = 6
// => Sai, trong khi "world" = 5

// Giải pháp
// Thay vì xét if(s[i] != ' ') thì ta xét if(s[i-1] != ' ')
// Như vậy
// Nếu s = "a" ->  i = sLength - 1 = 0 -> ko thỏa while(i!=0) -> return s.Length - i = 1 - 0 = 1 => đúng
// Nếu s = "Hello world"
// -> i = sLength - 1 = 10 -> khi while đến (s[6-1]) thì sẽ ko thỏa -> return s.Length - i = 11 - 6 = 5 => đúng



class Solution
{
    public int LengthOfLastWord(string s) {
        s = s.TrimEnd();
        int sLength = s.Length;
        if (sLength == 0) return 1;
        int i = sLength - 1;
        while (i != 0 && s[i-1] != ' ')
        {
            i--;
        }
        return s.Length - i;
    }
    static void Main(string[] args)
    {
        try
        {
            Solution s = new Solution();
            int result = s.LengthOfLastWord("   fly me   to   the moon  ");
            System.Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
