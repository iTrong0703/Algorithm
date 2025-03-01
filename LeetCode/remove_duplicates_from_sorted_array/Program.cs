// Yêu cầu bài toán là không được remove những phần tử trùng lặp
// cũng không được tạo ra mảng mới
// chỉ sắp xếp những phần tử khác biệt lên đầu thôi
// sau đó return về số lượng phần tử khác biệt

// do nó sẽ lấy số lượng phần tử khác biệt return về (lấy k)
// và dùng con k ấy để cắt cái mảng ban đầu ra k phần tử và check xem nó có đc xếp đúng không

// -> Tóm lại chỉ cần, sử dụng chính mảng đc truyền vào và sắp xếp phần tử khác biệt lên đầu,
//    sau đó return về số phần tử khác biệt

// ý Tưởng:
// Ta sẽ thao tác trực tiếp trên mảng truyền vào
// Đặt một biến k làm biến flag ở đầu mảng
// Rồi cho vòng lặp i chạy từ ví trí tiếp theo tới cuối mảng
// Nếu nums[i] != nums[k] thì đó là số khác biệt, 
// Ta đưa lên đầu bằng cách gán nums[k+1] = nums[i], do nums[k] hiện đang ở đầu mảng, ta chỉ cần gán vào vị trí tiếp theo nó là nums[k+1]
// Sau đó di chuyển k lên vị trí vừa gán là k++;
// Hết vòng lặp, ta chỉ gần return k + 1 là ra số lượng phần tử khác biệt do k chạy từ 0
class Solution
{
    public int RemoveDuplicates(int[] nums) 
    {
        int k = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[k] != nums[i])
            {
                nums[k+1] = nums[i];
                k++;
            }
        }
        return k+1;
    }

    static void Main(string[] args)
    {
        try
        {
            Solution solution = new Solution();
            int[] nums = [0,0,1,1,1,2,2,3,3,4]; // Input array
            int[] expectedNums = [0,1,2,3,4]; // The expected answer with correct length

            int k = solution.RemoveDuplicates(nums); // Calls your implementation
            System.Console.WriteLine("k: " + k);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
