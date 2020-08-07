//1191100025 猪谷高匡

using System;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Text;

class Main2
{

    public char[,] map1;
    public int y1;
    public int x1;
    public int count;

    //インスタンス生成のコンストラクト
    public Main2(char[,] map, int y, int x)
    {
        map1 = map;
        y1 = y; // 12
        x1 = x; // 10
        count = 0;
    }
    public char[,] henkan(int y, int x)
    {
        if (map1[y, x] == 'W')
        {
            map1[y, x] = '.';
            if (x < x1 - 1) henkan(y, x + 1);
            if (y < y1 - 1) henkan(y + 1, x);
            if (x > 0) henkan(y, x - 1);
            if (y > 0) henkan(y - 1, x);
            if (y < y1 - 1 && x > 0) henkan(y + 1, x - 1);//右上
            if (y > 0 && x > 0) henkan(y - 1, x - 1);//左上
            if (y < y1 - 1 && x < x1 - 1) henkan(y + 1, x + 1);//右下
            if (y > 0 && x < x1 - 1) henkan(y - 1, x + 1);//左下
        }
        return map1;
    }
}

class FileMain
{
    public static void Main()
    {
        string text;
        //ファイルの読み込み
        using (StreamReader sr = new StreamReader(
        "view.txt", Encoding.GetEncoding("Shift_JIS")))
        {
            {
                text = sr.ReadToEnd(); //一気に読み込める
            }
            string[] line = text.Split('\n'); //行を配列に格納
            string[] yx = line[0].Split(' ');

            int y = int.Parse(yx[0]);// y 12
            int x = int.Parse(yx[1]);// x 10

            //Zahyo（二次元配列）に格納
            char[,] Zahyo = new char[y, x];
            for (int yy = 0; yy < y + 1; yy++)
            {
                if (yy == 0) continue;
                for (int xx = 0; xx < x; xx++)
                {
                    Zahyo[yy - 1, xx] = line[yy][xx];
                }
            }

            int count = 0;
            char[,] map = Zahyo;
            for (int i = 0; i < y; i++)
            {
                for (int k = 0; k < x; k++)
                {
                    if (Zahyo[i, k] == 'W')
                    {
                        count++;
                        Main2 A = new Main2(map, y, x);
                        //Console.WriteLine(i +":" +k);
                        A.henkan(i, k);

                    }

                }
            }


            Console.WriteLine(count);
        }
    }
}


