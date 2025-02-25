// Ý tưởng
// Sau một buổi tối sử dụng con trỏ để duyệt từng index nhưng vẫn k pass hết toàn bộ test case
// -> Tham khảo -> Sử dụng Stack -> Giải quyết nhanh gọn

// Các yêu cầu để pass:
// + Có ngoặc mở thì phải có ngoặc đóng "(), {}, []"
// + Nếu s.Length là lẻ hoặc < 2 -> False (do sẽ có 1 dấu ngoặc lẻ loi hoặc rỗng)

// Tận dụng cơ chế Stack, vào sau ra trước, ta cứ đưa các "ngoặc mở" vào, khi gặp "ngoặc đóng" thì
// Pop "ngoặc mở" trong Stack ra, nếu nó là 1 cặp đóng mở đúng thì OK, sai thì False luôn
// -> Dù có lồng nhau đến mấy, ví dụ ({[{([])}]}), thì với cơ chế Stack, nếu ta duyệt từ đầu mảng thì
// sau khi hết ngoặc mở, thì theo lẽ thường, tiếp theo nó sẽ phải bắt đầu đóng lại theo thứ tự trong cùng ra ngoài
// do đó ta Pop "ngoặc mở" ra và so sánh với ngoặc đóng có theo thứ tự hoặc đúng loại ngoặc không

class Solution
{
    Dictionary<char, char> parentheses;
    public Solution()
    {
        parentheses = new Dictionary<char, char>();
        parentheses.Add('(',')');
        parentheses.Add('{','}');
        parentheses.Add('[',']');
    }
    // Cách này nhanh hơn, do không cần phải khởi tạo Dictionary và duyệt tìm trong đó
    public bool IsValid2(string s)
    {
        if (s.Length < 2 || s.Length % 2 != 0) return false;
        Stack<char> stack = new Stack<char>();
        int Length = s.Length;
        for (int i = 0; i < s.Length; i++) 
        {
            if (s[i] == '(' || s[i] == '{' || s[i] == '[')
            {
                stack.Push(s[i]);
            } else 
            {
                if (stack.Count == 0) return false;
                char top = stack.Pop();
                if ((top != '(' && s[i] == ')') || (top != '{' && s[i] == '}') || (top != '[' && s[i] == ']'))
                {
                    return false;
                }
            }
        }
        if (stack.Count > 0) return false;
        return true;
    }
    public bool IsValid(string s) 
    {
        if (s.Length < 2 || s.Length % 2 != 0) return false;
        Stack<char> stack = new Stack<char>();
        int Length = s.Length;
        for (int i = 0; i < s.Length; i++) 
        {
            if (parentheses.ContainsKey(s[i]))
            {
                stack.Push(s[i]);
            } else if (stack.Count == 0 || parentheses[stack.Pop()] != s[i])
            {
                return false;
            }
        }
        if (stack.Count > 0) return false;
        return true;
    }
    static void Main(string[] args)
    {
        try
        {
            Solution solution = new Solution();
            string s = Console.ReadLine()!;
            System.Console.WriteLine(solution.IsValid2(s));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
