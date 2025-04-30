// Ý tưởng:
// - Cách cộng nhị phân:
// 1+1=0 nhớ 1
// 1+0=1
// 0+1=1
// 0+0=0
// - Tính từ phải sang trái
// - Nếu có nhớ 1, thì kết quả tiếp theo sẽ + 1
// + Ta sẽ duyệt 2 string
// + Dựa vào cách cộng nhị phân -> các điều kiện
// + Sử dụng Stack để thêm kết quả từng bước vào dễ dàng
// + Với trường hợp 1+1=0 nhớ 1 thì ta tạo thêm biến c để lưu giá trị nhớ
//   Sau khi sử dụng nhớ thì gán c về 0
// + Hết vòng lặp mà còn c = 1 -> ta thêm nó vào đầu

// Test case 1: a.Length > b.Length
// ->  Khi cộng hết số từ phải sang trái mà a.Length vẫn còn
//     Ta gán b = '0' và tiếp tục cộng a còn lại như bthng
//     Ví dụ: 11 + 1 ~ 11 + 01 = 100

// Test case 2: a.Length < b.Length
// -> Ta swap a và b để về Test case 1 :D

class Solution
{
    public string AddBinary(string a, string b) {
        if (b.Length > a.Length)
        {
            string z = a;
            a = b;
            b = z;
        }
        int lengthA = a.Length-1;
        int lengthB = b.Length-1;
        Stack<char> stack = new Stack<char>();
        int c = 0; 
        while (lengthA >= 0) 
        {
            char charA = a[lengthA];
            char charB = lengthB >= 0 ? b[lengthB] : '0';
            if (lengthB < 0) lengthB = 0;
            if (charA == '0' && charB == '1' || charA == '1' && charB == '0')
            {
                if (c == 1)
                {
                    stack.Push('0');
                } else {
                    stack.Push('1');
                }
            } else if (charA == '0' && charB == '0')
            {
                if (c == 1)
                {
                    stack.Push('1');
                    c = 0;
                } else {
                    stack.Push('0');
                }
            } else if (charA == '1' && charB == '1')
            {
                if (c == 1)
                {
                    stack.Push('1');
                } else {
                    stack.Push('0');
                    c = 1;
                }
            } 
            lengthA--;
            lengthB--;
        }
        string result = "";
        if (c == 1) 
        {
            result += '1';
        }
        while (stack.Count > 0)
        {
            result += stack.Pop().ToString(); 
        }
        
        return result;
    }
    static void Main(string[] args)
    {
        try
        {
            Solution s = new Solution();
            System.Console.WriteLine(s.AddBinary("1", "111"));

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
