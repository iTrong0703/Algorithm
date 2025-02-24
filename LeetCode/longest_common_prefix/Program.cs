// Ý tưởng
// Đề bài yêu cầu tìm số lượng chữ cái giống nhau nhiều nhất của mảng chuỗi truyền vào
// Do vậy nên những chữ cái đó đều phải nằm ở tất cả các phần tử trong mảng mới thỏa điều kiện
// Ví dụ: ["abcd", "abcmmm", "xyz"] -> không thỏa -> return ""

// Như vậy thay vì lặp từng kí tự của mảng[0] rồi so sánh với từng kí tự ở mảng[1],...mảng[n]
// -> k nên, quá mất thời gian

// Do đó, ta sẽ cầm chuỗi đầu tiên của mảng
// So sánh nó lần lượt với các chuỗi còn lại trong mảng
// Dùng Substring để cắt từ từ từ phải qua cho đến khi 
// mảng[0] nằm trong mảng[2] với IndexOf = 0 (là vị trí đầu tiên ở mảng[2])
// lặp lại với các mảng còn lại

// Trường hợp: ["abcde", "xyzabc"] thì có "abc" thỏa, nếu làm theo cách trên sẽ trả về null,
// nhưng các test case trong leetcode lại pass hết kể cả hidden 🤔🤔
// Còn nếu có, thì chắc có lẻ dùng StartsWith() để tìm vị trí của mảng[0] trong mảng[2] 

class Solution
{
    public string LongestCommonPrefix(string[] strs) {
        string result = "";
        string firstString = strs[0];
        int arrayStringLength = strs.Length; 
        if (strs == null)
        {
            return result;
        }
        if (arrayStringLength >= 1)
        {
            for (int i = 1; i < arrayStringLength; i++)
            {
                {
                    while (strs[i].IndexOf(firstString) != 0)
                    {
                        firstString = firstString.Substring(0, firstString.Length - 1);
                    }
                }
            }
            result = firstString;
        }
        return result;
    }
    static void Main(string[] args)
    {
        
        try
        {
            Solution solution = new Solution();
            string input = Console.ReadLine()!;
            string[] s = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string result = solution.LongestCommonPrefix(s);
            System.Console.WriteLine(result);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
