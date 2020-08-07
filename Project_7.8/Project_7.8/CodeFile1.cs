//1191100011 有友柚樹

using System;
using System.Collections.Generic;
using System.Linq;

class FileMain
{
    public static void Main()
    {
        //リストにデータを格納
        List<int> data = new List<int>();
        while (true)
        {
            int tmp = int.Parse(Console.ReadLine());
            if (tmp == -1)
            {
                break;
            }
            data.Add(tmp);
        }

        //最大値の計算
        int max = 0;
        foreach (int value in data)
        {
            max += value;
        }

        //最小値の計算
        int min;
        int data_max = data.Max();
        if( max - data_max - data_max > 0)
        {
            min = 0;
        }
        else
        {
            min = max - data_max - data_max;
        }


        Console.WriteLine(max);
        Console.WriteLine(min);
    }
}


