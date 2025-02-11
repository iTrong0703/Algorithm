/* Ý tưởng:
- Do mảng đã được sorted, nên ta có thể dùng tìm kiếm nhị phân
- Nếu nums[i] == target thì return vị trí đó luôn
- Nếu target không có trong mảng, ta cần tìm vị trí thích hợp của nó để chèn
thì ý tưởng sẽ là: chỉ cần nums[i] > target là ta lấy vị trí đó luôn
Vd: 2,4,5 -> nếu target = 3 thì nó sẽ nằm ở vị trí của số 4 trong mảng
          -> nên ta chỉ cần chèn nó sau vị trí mà nums[i] > target
- Trường hợp duyệt đến cuối mảng r mà vẫn chưa tìm được, thì nghĩa là target > tất cả các
số trong mảng, nên ta chỉ cần chèn nó vào vị trí cuối cùng
- Trường hợp target = 0, do ta gán result ban đầu là 0 nên nó cũng đúng với vị trí nums[0] luôn :D
*/
class Solution
{
    public int SearchInsert(int[] nums, int target) {
        int result = 0;
        int lastIndex = nums.Length - 1;
        int halfLength = (nums.Length-1)/2;
        if (nums[halfLength] < target)
        {
            for(int i = halfLength; i < nums.Length; i++)
            {
                if(nums[i] >= target)
                {
                    result = i;
                    break;
                }
                else if(nums[i] == nums[lastIndex] && nums[i] < target)
                {
                    result = i + 1;
                    break;
                }
            }
        } 
        else
        {
            for(int i = 0; i <= halfLength; i++)
            {
                if(nums[i] >= target)
                {
                    result = i;
                    break;
                }
            }
        }
        return result;
    }
    static void Main(string[] args)
    {
        try
        {
            int[] nums = [1,3,5,6];
            int target = 0;
            Solution s = new Solution();
            var result = s.SearchInsert(nums, target);
            System.Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
