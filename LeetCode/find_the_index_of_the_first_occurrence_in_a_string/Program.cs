// Ý tưởng
// - Duyệt haystack đến khi nào gặp haystack[i] == needle[0]
// - So sánh lần lượt từng kí tự của haystack và needle
// - Nếu so sánh tới vị trí j == needleLength -> có trong mảng, return vị trí i lúc bắt đầu so sánh
// - Nếu không trùng thì tiếp tục duyệt haystack tiếp đến cuối

// Vấn đề testcase
// 1. Nếu haystack = "", needle = "" Expected = 0
//        haystack = "abc", needle = "" Expected = 0
//    -> if (needleLength == 0) return 0
// 2. Nếu haystackLength < needleLength -> return -1 (do needle lớn hơn nên k thể nào nằm trong haystack)
// 3. Nếu haystack = "abcdef" và needle= "efgh" thì bị lỗi: "Index was outside the bounds of the array"
//    -> duyệt tới haystackLength - needleLength => nếu needle tồn tại trong haystack thì nếu nó có nằm ở cuối,
//       thì nó vẫn sẽ bắt đầu từ vị trí haystackLength - needleLength

class Solution
{
    public int StrStr2(string haystack, string needle) {
        return haystack.IndexOf(needle);
    }
    public int StrStr(string haystack, string needle) {
        int haystackLength = haystack.Length;
        int needleLength = needle.Length;
        if (needleLength == 0) return 0;
        if (haystackLength < needleLength) return -1;
        int loopLimit = haystackLength - needleLength;
        for (int i = 0; i <= loopLimit; i++)
        {
            if (haystack[i] == needle[0])
            {
                int j = 0;
                while (j < needleLength && haystack[i + j] == needle[j])
                {
                    j++;
                }
                if (j == needleLength) return i;
            }
        }
        return -1;
    }
    static void Main(string[] args)
    {
        try
        {
            Solution s = new Solution();
            string haystack = "a";
            string needle = "a";
            System.Console.WriteLine(s.StrStr(haystack, needle));

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
