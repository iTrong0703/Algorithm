// Ý tưởng
// Leetcode kêu sài ListNode thì ta sài
// Để merge 2 lists bằng ListNode thì ta nên tạo thêm 1 ListNode thứ 3 để dễ thao tác hơn
// (Do ListNode trỏ next tới vùng nhớ của ListNode tiếp theo, nên để tránh lỗi mất kết nối thì nên dùng thêm ListNode thứ 3)

// + Đầu tiên cần check nếu list1 hoặc list2 bằng null thì trả về thằng còn lại luôn
// + Tạo node giả là "nodeFake" với val là -1 (do là node giả nên nó phải nằm đầu tiên nên ta cho nó giá trị nhỏ nhất để nó luôn đứng đầu)
//   Node giả cũng đóng vai trò quan trọng trong việc giữ liên kết của list mà ta sẽ merge 2 list kia vào
// + Tạo thêm một node là "listMerge" và gán nó bằng node giả trên, để nó di chuyển và gán các node từ 2 list kia vào để merge
// * Như vậy, "nodeFake" đóng vai trò là giữ liên kết nên nó sẽ đứng yên đó, còn "listMerge" ta sẽ di chuyển nó để gắn các node kia vào

// Tiếp theo, ta cần vòng lặp chạy từ node đầu đến node cuối của cả 2 list. Khi 1 trong 2 list đã duyệt hết, ta gán phần còn lại vào listMerge luôn
// + Tạo vòng lặp while chạy đến khi nào 1 trong 2 list == null
// + So sánh giá trị node hiện tại cùng từng list, nếu nhỏ hơn thì đưa vào listMerge
// + Nếu list1.val nhỏ hơn, thì gán nó vô listMerge, xong di chuyển đến node tiếp theo của list1 và gán listMerge = node vừa gắn vào
//   Làm tương tự với list2
// + Cuối mỗi vòng lặp, ta sẽ di chuyển listMerge lên node mới vừa gắn vô
// + Sau khi đã lặp xong, nếu 1 trong 2 list vẫn còn giá trị, thì gán phần còn lại vào listMerge luôn 

// Cuối cùng trả về "nodeFake.next", nghĩa là bỏ qua node giả -1 ban đầu và trả về dãy mà ta đã dùng listMerge gắn từng node vô

// ban đầu ta gán "listMerge" = "nodeFake", như vậy cả 2 thằng .next đều sẽ trỏ đến cùng vùng nhớ của node kế tiếp, mà hiện tại đang = null
// sau vòng lặp đầu tiên, thì nodeFake.next sẽ trỏ tới node mới được gán vào, còn "listMerge" sẽ di chuyển lên vị trí node mới đó

// node sau khi gán k mất liền mà chỉ là k ai trỏ tới nó, sau đó sẽ bị GC dọn
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null!) 
    {
        this.val = val;
        this.next = next;
    }
}
class Solution
{
    public ListNode MergeTwoLists (ListNode list1, ListNode list2) 
    {
        if ( list1 == null ) return list2;
        if ( list2 == null ) return list1;
        ListNode nodeFake = new ListNode(-1);
        ListNode listMerge = nodeFake; // nodeFake.next ~ listMerge.next do hiện tại đang cùng trỏ đến 1 vị trí trong bộ nhớ
        
        while (list1 != null && list2 != null)
        {
            if (list1.val >= list2.val)
            {
                listMerge.next = list2;
                list2 = list2.next;
            } else
            {
                listMerge.next = list1;
                list1 = list1.next;
            }
            listMerge = listMerge.next;
        }
        listMerge.next = list1 != null ? list1 : list2!; 
        return nodeFake.next;
    }
    static void Main(string[] args)
    {
        try
        {
            Solution solution = new Solution();
            ListNode list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            ListNode list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

            ListNode result = solution.MergeTwoLists(list1, list2);
            while (result != null)
            {
                System.Console.Write($"{result.val}, ");
                result = result.next;
            }

            // 1, 1, 2, 3, 4, 4
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
