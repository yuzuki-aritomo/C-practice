//1191100011
using System;

class Code
{
    //最小公倍数を求める
    public static int Lcm(int a, int b)
    {
        return a * b / Gcd(a, b);
    }
    // ユークリッドの互除法 
    public static int Gcd(int a, int b)
    {
        if (a < b)
            // 引数を入替えて自分を呼び出す
            return Gcd(b, a);
        while (b != 0)
        {
            var remainder = a % b;
            a = b;
            b = remainder;
        }
        return a;
    }
    //落ちるポケットを求める
    public static string Hole(int w_sum, int h_sum)
    {
        string pocket;
        if (h_sum % 2 == 0)
        {
            if (w_sum % 2 == 0)
            {
                pocket = "A";
                return pocket;
            }
            else
            {
                pocket = "B";
                return pocket;
            }
        }
        else
        {
            if (w_sum % 2 == 0)
            {
                pocket = "C";
                return pocket;
            }
            else
            {
                pocket = "D";
                return pocket;
            }
        }
    }
    //----------------------------課題１------------------------------
    public void Code_1()
    {
        //前提条件
        int w = 6;
        int h = 3;
        //int theta = 45;

        //h,wの最小公倍数を求める
        int x = Lcm(w, h);
        
        //あたった回数を求める
        int w_sum = x / w - 1;
        int h_sum = x / h - 1;
        int sum = w_sum + h_sum;
        string pocket = Hole(w_sum+1,h_sum+1);

        Console.WriteLine("クッションにあたった回数：{0}",sum);
        Console.WriteLine("入ったポケット：{0}",pocket);
    }
    //----------------------------課題２------------------------------
    public void Code_2()
    {
        //theta = 45
        int w = 5;
        int h = 3;

        //h,wの最小公倍数を求める
        int x = Lcm(w, h);

        //あたった回数を求める
        int w_sum = x / w - 1;
        int h_sum = x / h - 1;
        int sum = w_sum + h_sum;
        string pocket = Hole(w_sum + 1, h_sum + 1);

        Console.WriteLine("クッションにあたった回数：{0}", sum);
        Console.WriteLine("入ったポケット：{0}", pocket);
    }
}
class CodeMain
{
    public static void Main()
    {
        Code A = new Code();
        Console.WriteLine("課題１");
        A.Code_1();
        Console.WriteLine("課題2");
        A.Code_2();
    }
}