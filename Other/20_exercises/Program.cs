class Solution
{
    public void Ex1()
    {
        System.Console.Write("Nhập n: ");
        int n = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine($"Kết quả: {n*n}");
    }

    public void Ex2()
    {
        System.Console.Write("Nhập chuỗi: ");
        string s = Console.ReadLine()!;
        System.Console.WriteLine($"Kết quả: {s.Length}");
    }

    public void Ex3()
    {
        System.Console.Write("Nhập n: ");
        int n = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine($"Kết quả: {(n%2 == 0 ? "Chẵn" : "Lẻ")}");
    }

    public int Ex4(int n)
    {
        if (n < 1)
        {
            return 0;
        } else {
            return n + Ex4(n-1);
        }
    }

    public void Ex5()
    {
        string s = Console.ReadLine()!;
        string reverseString = "";
        int l = s.Length-1;
        while (l >= 0)
        {
            reverseString += s[l];
            l--;
        }
        System.Console.WriteLine(reverseString);
    }
    
    public void Ex6()
    {
        System.Console.Write("Nhập n: ");
        int n = int.Parse(Console.ReadLine()!);
        double sqrtN = Math.Sqrt(n);
        // chạy từ 2 vì tất cả mọi số đều chia hết cho 1
        // chạy tới sqrt(n) vì nếu n có 1 ước số a < sqrt(n) thì nó cũng sẽ có một ước số b = n/a > sqrt(n)
        // -> nếu có thì k phải là số nguyên tố
        // Lưu ý: <= vì n có thể là 1 số chính phương (số n có thể viết dưới dạng bình phương của 1 số nguyên. Ví dụ n = 4 = 2^2)  
        for (int i = 2; i <= sqrtN; i++)
        {
            if (n % i == 0)
            {
                System.Console.WriteLine("Không phải số nguyên tố");
                return;
            }
        }
        System.Console.WriteLine("Là số nguyên tố");
    }

    public void Ex7()
    {
        System.Console.Write("Nhập n: ");
        int n = int.Parse(Console.ReadLine()!);
        if (n < 0 || n > 9)
        {
            throw new Exception("Invalid number");
        }
        System.Console.WriteLine("Kết quả:");
        for (int i = 1; i <= 9; i++)
        {
            System.Console.WriteLine($"{n} x {i} = {n*i}");
        }
    }

    public void Ex8()
    { 
        // int min = 0;
        System.Console.Write("Nhập danh sách: ");
        string n = Console.ReadLine()!;
        List<int> lst = n.Split(' ').Select(Int32.Parse).ToList();
        int max = lst[0];
        int min = lst[0];
        foreach(int i in lst)
        {
            if (i < min) min = i;
            else if (i > max) max = i;
        }
        System.Console.WriteLine($"Max = {max}, Min = {min}");
    }

    public int Ex9(int n)
    {
        if (n == 1)
        {
            return 1;
        } else {
            return n * Ex9(n - 1);
        }
    }

    public void Ex10()
    {
        string s = Console.ReadLine()!;
        int left = 0;
        int right = s.Length-1;
        while (left <= right)
        {
            if (s[left] != s[right])
            {
                System.Console.WriteLine("Chuỗi không đối xứng");
                return;
            }
            left++;
            right--;
        }
        System.Console.WriteLine("Chuỗi đối xứng");
    }
    static void Main(string[] args)
    {
        try
        {
            Solution s = new Solution();
            // System.Console.WriteLine(s.Ex4(4));
            // System.Console.WriteLine(s.Ex9(5));
            s.Ex10();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
