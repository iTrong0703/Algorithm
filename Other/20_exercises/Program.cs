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
    public int Ex11(int a, int b)
    {
        if (a == 0 || b == 0) return a + b;
        // Euclid
        while (a != b)
        {
            if (a > b)
            {
                a -= b;
            } else {
                b -= a;
            }
        }
        return a;
    }
    public void Ex12()
    { 
        System.Console.Write("Nhập danh sách: ");
        string n = Console.ReadLine()!;
        List<int> lst = n.Split(' ').Select(Int32.Parse).ToList();
        lst.Sort();
        lst.ForEach(c => System.Console.WriteLine(c));
    }
    public void Ex13()
    { 
        int count = 0;
        string s = Console.ReadLine()!;
        int l = s.Length;
        for (int i = 0; i < l; i++)
        {
            if (s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u')
            {
                count++;
            }
        }
        System.Console.WriteLine(count);
    }
    public void Ex14()
    {
        System.Console.Write("Nhập n: ");
        int n = int.Parse(Console.ReadLine()!);
        int halfN = n/2;
        int total = 0;
        for (int i = 1; i <= halfN; i++)
        {
            if (n % i == 0)
            {
                total += i;
            }
        }
        if (total == n)
        {
            System.Console.WriteLine("Là số hoàn hảo");
        } else {
            System.Console.WriteLine("Không là số hoàn hảo");
        }
    }
    public void Ex15()
    {
        System.Console.Write("Nhập danh sách: ");
        string s = Console.ReadLine()!;
        int total = 0;
        List<int> lst = s.Split(' ').Select(Int32.Parse).ToList();
        foreach (var i in lst)
        {
            if (i % 2 == 0)
            {
                total += i;
            }
        }
        System.Console.WriteLine($"Kết quả: {total}");
    }
    public void Ex16()
    {
        System.Console.Write("Nhập danh sách: ");
        string n = Console.ReadLine()!;
        Dictionary<int, int> dic = new Dictionary<int, int>();
        List<int> lst = n.Split(' ').Select(Int32.Parse).ToList();
        foreach (var i in lst)
        {
            if (dic.ContainsKey(i))
            {
                dic[i]++;
            } else {
                dic.Add(i, 1);
            }
        }
        int max = 0;
        int result = 0;
        foreach(var i in dic)
        {
            if (i.Value > max)
            {
                max = i.Value;
                result = i.Key;
            }
        }
        System.Console.WriteLine($"Kết quả: {result} (xuất hiện {max} lần)");
    }
    public void Ex17()
    {
        System.Console.Write("Nhập n: ");
        string s = Console.ReadLine()!;
        List<int> lst = s.Select(i => int.Parse(i.ToString())).ToList();
        int total = 0;
        foreach (var i in lst)
        {
            total += i;
        }
        System.Console.WriteLine("Kết quả: " + total);
    }
    public int Ex18(int n)
    {
        int b;
        if (n == 0)
        {
            return 0;
        } else {
            b = n%2;
            return Ex18(n/2)*10 + b;
        }
    }
    public void Ex19()
    {
        System.Console.Write("Nhập a: ");
        int a = int.Parse(Console.ReadLine()!);
        System.Console.Write("Nhập b: ");
        int b = int.Parse(Console.ReadLine()!);
        if (a * b > 0)
        {
            System.Console.WriteLine("Cùng dấu");
        } else {
            System.Console.WriteLine("Khác dấu");
        }
    }
    public void Ex20()
    {
        System.Console.Write("Nhập danh sách: ");
        string s = Console.ReadLine()!;
        List<int> lst = s.Split(' ').Select(Int32.Parse).ToList();
        int max = 1;
        foreach(var i in lst)
        {
            if (i % 2 != 0 && i >= max)
            {
                max = i;
            }
        }
        System.Console.WriteLine($"Số lẻ lớn nhất là: {max}");
    }
    static void Main(string[] args)
    {
        try
        {
            Solution s = new Solution();
            // System.Console.WriteLine(s.Ex4(4));
            // System.Console.WriteLine(s.Ex9(5));
            // System.Console.WriteLine(s.Ex11(16, 10));
            // System.Console.WriteLine(s.Ex18(10));
            s.Ex20();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
        }
    }
}
