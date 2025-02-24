// Ý tưởng
// Các số la mã được tính bằng cách cộng từng kí tự từ trái qua phải
// Ví dụ XVII = 10 + 5 + 1 + 1 = 17
// -> Ta sẽ tách chuỗi ra và cộng từng kí tự từ trái qua phải
// Các trường hợp đặc biệt
// Các số như IV sẽ tương đương với 4, IX tương đương vs 9, XL ~ 40
// Ta có thể thấy rằng 4 = V - I = 5 - 1
// Mà các số la mã thường xếp theo thứ tự giảm dần trái qua phải
// Nên các trường hợp đặc biệt thì số bé sẽ nằm bên trái số lớn
// Do đó ta chỉ cần check số phía trước mà < số hiện tại -> + số hiện tại - số trước * 2  (*2 là do lần lặp trước ta đã lỡ + nó vô)
class Solution
{
    Dictionary<char, int> romanNum;
    public Solution()
    {
        romanNum = new Dictionary<char, int>();
        romanNum.Add('I', 1);
        romanNum.Add('V', 5);
        romanNum.Add('X', 10);
        romanNum.Add('L', 50);
        romanNum.Add('C', 100);
        romanNum.Add('D', 500);
        romanNum.Add('M', 1000);
    }

    public int RomanToInt(string s) {
        int num = 0;
        int preNum = romanNum[s[0]];
        foreach (var i in s)
        {
            if (romanNum[i] > preNum)
            {
                num += romanNum[i] - preNum * 2;
            } else {
                num += romanNum[i];
            }
            preNum = romanNum[i];
        }
        return num;
    }
    static void Main(string[] args)
    {
        
        try
        {
            Solution solution = new Solution();
            string s = Console.ReadLine()!;
            int result = solution.RomanToInt(s);
            System.Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
