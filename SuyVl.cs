using System.Collections.Specialized;
using static System.Console;


public class Program
{
    static void Main(string[] args)
    {
        //TimKiemNoiSuy();

        bai2.XuLy();
        
    }

    static void TimKiemNoiSuy()
    {
        Write("Hay nhap so phan tu cua mang: ");
        int n = Convert.ToInt32(ReadLine());

        int[] arr = new int[n];
        int tong = 0;
        int trungbinh = 0;

        /// chu y gia tri phan tu cua mang la tang dan

        for(int i=0; i<n; i++)
        {
            Write("Hay nhap gia tri cua phan tu thu {0}: ", i+1);
            arr[i] = Convert.ToInt32(ReadLine());
            tong += arr[i];
        }

        if(tong % n != 0)
        {
            WriteLine("khong co so nao bang trung binh cong");
            return;
        }

        trungbinh = tong / n;

        Write("in ra mang: ");
        foreach(var x in arr)
        {
            Write(x + " ");
        }
        WriteLine();

        WriteLine("vi tri cua so bang so trung binh la: " +  InterPolationSearch(arr, n, trungbinh) );
        
        ReadKey();
    }

    static int InterPolationSearch(int[] arr, int n, int x)
    {
        int left = 0;
        int right = n - 1;
        while (left <= right && x >= arr[left] && x <= arr[right])
        {
            double val1 = (double)(x - arr[left]) / (arr[right] - arr[left]);
            int val2 = (right - left);
            int Search = left + (int)val1 * val2;

            if (arr[Search] == x)
                return Search+1; /// nếu tìm thấy thì trả về luôn giá trị search+1

            if (arr[Search] < x)
                left = Search + 1;
            else
                right = Search - 1;
        }

        return -1; /// -1 nếu như không tìm thấy vị trí
    }
}
public class bai2
{
    struct HocSinh
    {
        public string HoTen;
        public double DiemToan;

    }

    public static void XuLy()
    {
        Write("Hay nhap so hoc sinh cua lop: ");
        int n = Convert.ToInt32(ReadLine());

        HocSinh[] hocSinh = new HocSinh[n];

        for (int i = 0; i < n; i++)
        {
            Write("Hay nhap ten cua hoc sinh thu {0}: ", i + 1);
            hocSinh[i].HoTen = ReadLine();
            Write("Hay nhap diem cua hoc sinh thu {0}: ", i + 1);
            hocSinh[i].DiemToan = Convert.ToDouble(ReadLine());
        }


        for(int i=0; i<n; i++)
            for(int j= i+1; j<n; j++)
                if (hocSinh[i].DiemToan > hocSinh[j].DiemToan)
                {
                    HocSinh temp = hocSinh[i];
                    hocSinh[i] = hocSinh[j];
                    hocSinh[j] = temp;
                }
        /// sap xe lai mang
        /// 

        InterPolationSearch(hocSinh, n, 8f);
        
    }

    static void InterPolationSearch(HocSinh[] arr, int n, float x)
    {
        int left = 0;
        int right = n - 1;
        while (left <= right && x >= arr[left].DiemToan && x <= arr[right].DiemToan)
        {
            double val1 = (double)(x - arr[left].DiemToan) / (arr[right].DiemToan - arr[left].DiemToan);
            int val2 = (right - left);
            int Search = left + (int)val1 * val2;

            if (arr[Search].DiemToan == x)
            {
                Write(arr[Search].HoTen + " co diem toan la 8");
                return; /// nếu tìm thấy thì trả về luôn giá trị search+1
            }

            if (arr[Search].DiemToan < x)
                left = Search + 1;
            else
                right = Search - 1;
        }
        WriteLine("khong co ai duoc 8 diem");
        return; /// -1 nếu như không tìm thấy vị trí
    }

}
