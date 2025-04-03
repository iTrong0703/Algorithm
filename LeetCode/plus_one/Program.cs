// Ý tưởng ban đầu là convert mảng sang số, sau đó +1 và convert ngược lại thành mảng
// Nhưng có test case k pass do nó > int và long

// Ý tưởng 2: duyệt mảng từ cuối lên
// + Nếu số cuối < 9 thì ta +1 và return kết quả luôn
// + Nếu số cuối = 9 thì có nghĩa nếu +1 nó sẽ thành 0 -> gán = 0 -> i-- -> tới số tiếp theo
//     + Nếu số tiếp < 9 thì ta +1 (nhớ 1) và return kết quả luôn
// + Nếu chạy tới cuối vòng lặp mà vẫn chưa return -> số đó có thể là các số như 999, 9999, 99999,...
//     + Ví dụ 999+1 = 1000 -> Length của nó sẽ +1
//     -> Ta chỉ cần tạo mảng mới có Length của số cũ +1 và đặt array[0] = 1, các array[i] còn lại sẽ nhận
//        giá trị mặc định là 0

class Solution
{
    public int[] PlusOne(int[] digits) {
        int digitsLength = digits.Length - 1;
        for (int i = digitsLength; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                digits[i] += 1;
                return digits;
            }
            digits[i] = 0;
        }
        
        int[] result = new int[digitsLength + 2]; 
        result[0] = 1;
        return result;
    }
    // Cách này lỗi, do convert test case sang number > long & int
    public int[] PlusOne2(int[] digits) {
        long number = 0;
        int digitsLength = digits.Length;
        for (int i = 0; i < digitsLength; i++)
        {
            number = number * 10 + digits[i];
        }
        number += 1;
        int[] result = number.ToString().Select(i => i - '0').ToArray();   
        // trừ đi char '0' có ASCII = 48 để convert char thành int
        // ví dụ char '9' có có ASCII = 57
        // -> '9' - '0' = 57 - 48 = 9     
        return result;
    }
    static void Main(string[] args)
    {
        try
        {
            Solution s = new Solution();
            s.PlusOne([9,8,7,6,5,4,3,2,1,0]).ToList().ForEach(i => System.Console.Write(i));

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
