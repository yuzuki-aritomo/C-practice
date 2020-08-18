// 1191100011 有友柚樹
using System;

class QuickSort
{
    public static int check;
    public static void Sort(int[] data, int start, int end)
    {
        if (end - start <= 1 ) // 要素数が1以下なら終了
        {
            return;
        }
        //Console.WriteLine("----------");
        int p = data[start]; // 先頭要素をピボット p とする
        int i = start, j = end;
        while (true)
        {
            int tmp;
            if(p > data[i])
            {
                i++;
            }
            if(p <= data[j])
            {
                j--;
            }
            if(p <= data[i] && p > data[j])
            {
                
                tmp = data[i];
                data[i] = data[j];
                data[j] = tmp;
                for (int l = 0; l < data.Length; l++)
                {
                    Console.Write("{0} ", data[l]);
                }
                Console.WriteLine();
            }
            
            if (i >= j)
            {
                Console.WriteLine("----------");
                check = i;
                //Console.WriteLine(check);
                break;
            }
        }
        //Console.WriteLine(check);

        //Console.WriteLine("----------");
        Sort(data, start, check); // workのピボットの前後に対し、
        Sort(data, check + 1, end); // それぞれSortを再帰呼び出し
    }
}

class SortMain
{
    const int N_DATA = 20;
    public static void Main()
    {
        int[] data = new int[N_DATA];
        Random rand = new Random();
        Console.WriteLine("before sort");
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = rand.Next(N_DATA);
            Console.Write("{0} ", data[i]);
        }
        Console.WriteLine();
        QuickSort.Sort(data, 0, data.Length-1);
        Console.WriteLine("after sort");
        for (int i = 0; i < data.Length; i++)
        {
            Console.Write("{0} ", data[i]);
        }
        Console.WriteLine();
    }
}

//今回の課題を完成させることが出来ませんでした。
//なぜ思い通りに動かないのかデバックをしたのですがどれもうまくいきませんでした。
//