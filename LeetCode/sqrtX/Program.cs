// Ý tưởng
// Cách 1:
// - Ta có thể duyệt từ đầu i = 2 đến if (i * i > x)
// -> return i - 1;
// Nhược điểm: nếu x quá lớn sẽ không tối ưu
// Cách 2: dùng Binary search
// - Ta sẽ + 2 đầu và lấy phân nửa -> m = (l + r)/2, sau đó check xem m*m == x -> return m
// - if (m*m > x) -> m vượt lấy nửa trái -> r = m - 1
// - if (m*m < x) -> m nhỏ lấy nửa phải -> l = m + 1 
// - Lặp lại đến khi l >= r thì return r do nếu r*r != x thì r là ptu lớn nhất thỏa "the nearest integer"
// Nhược điểm: nếu x là số cực lớn, thì m * m sẽ int overflow
// -> Vậy thay vì nhân, ta chuyển vế để ra chia
// -> m*m > x -> m > x/m -> r = m - 1
// -> m*m < x -> m < x/m -> l = m + 1
class Solution
{
    public int MySqrt(int x) 
    {
        if (x == 0 || x == 1) return x;
        int l = 0;
        int r = x;
        int m = 0;
        while (l <= r)
        {
            m = (l+r)/2;
            if (x / m > m)
            {
                l = m + 1;
            } else if (x / m < m)
            {
                r = m - 1;
            } else {
                return m;
            }
        }
        return r;
    }

    static void Main(string[] args)
    {
        try
        {
            Solution s = new Solution();
            System.Console.WriteLine(s.MySqrt(16));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
