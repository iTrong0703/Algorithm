// Đề bài cũng yêu cầu tương tự bài Remove Duplicates from Sorted Array
// là ta không được tạo ra mảng mới, ta chỉ cần đưa val cần xóa về cuối mảng thôi.
// Các phần tử không bị xóa sẽ đưa lên đầu, và trả về "k" là số lượng các phần tử còn lại
// và nó cũng dùng con k đó để cắt cái mảng ban đầu ra và check xem đúng là các phần tử cần xóa bị đưa về cuối hết chưa
// Ví dụ: nums = [0,1,2,2,3,0,4,2], val = 2;
// thì return phải trả về k = 5 vì nó dùng k cắt nums ban đầu ra được = [0,1,4,0,3]

// Ý tưởng
// Đầu tiên cần check mảng truyền vào có = null hay không
// Do mảng không được sắp xếp và các số trong mảng có thể trùng lặp nhiều lần
// Ta sẽ sử dụng while và chạy từ 2 đầu vào để không bỏ sót số nào
// Trước hết, do ta sẽ đưa phần tử cần xóa về cuối mảng, nên phần tử cuối mảng phải khác val để ta có thể swap lên đầu
// -> nên nếu = val ta chỉ cần di chuyển right-- về
// Nếu phần tử cuối mảng đã != val, nghĩa là ta swap đc, ta check xem phần tử tại vị trí left có = val hay không rồi mới swap
// -> nếu != val nghĩa là k cần xóa, thì ta cứ tăng left++ lên
// Nếu thỏa 2 điều kiện:    + cuối mảng khác val
// ->                       + nums[left] == val
// -> Ta tiến hành swap nó, đưa phần tử cần xóa về cuối và đưa ptu k bị xóa lên
//    Sau đó left++; right--;

// Điều kiện lặp while phải là left <= right
// Vấn đề 1:
// Nếu ta để while (left < right)
// Nếu ta có mảng là nums = [3,2,2,3], val = 3 thì left sau khi lặp xong sẽ = 1, 
// nếu ta return left = 1 thì khi cắt mảng ra sẽ được mỗi [2] trong khi đáp án phải là [2,2] 
// -> return left + 1;
// Vấn đề 2:
// Nếu ta return left + 1; thì nếu input là nums = [1] và val = 1
// Khi đó left = 0 và right = 0 và nó return left + 1; thì 0 + 1 = 1 -> kết quả vẫn là [1] trong khi đáp án phải là []

// Do đó với left <= right, nếu left == right thì nó vẫn chạy đc thêm 1 lần nữa
// Vấn đề 1: do chạy thêm 1 lần nữa nên lúc này left sẽ +1;
// Vấn đề 2: nó sẽ vẫn chạy đc vào while, nhưng do ta check nums[right] == val thì right-- 
// và thoát vòng lặp return về left = 0; -> nums[] = null do 0 ptu còn lại

class Solution
{
    public int RemoveElement(int[] nums, int val) {
        if (nums == null || nums.Length==0) return 0;
        int left = 0;
        int right = nums.Length - 1; 
        while (left <= right)
        {
            if (nums[right] == val)
            {
                right--;
            }
            else if (nums[left] != val)
            {
                left++;
            } 
            else
            {
                nums[left] = nums[right];
                left++;
                right--;
            }
            
        }
        return left;
    }
    static void Main(string[] args)
    {
        try
        {
            Solution solution = new Solution();
            int[] nums = [3,2,2,3]; 
            int val = 3;
            int k = solution.RemoveElement(nums, val);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
