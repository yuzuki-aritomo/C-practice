using System;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Text;

class Main2
{
    public char[,] map;
    public int x_row;
    public int y_col;
    public int count;
    //インスタン生成のコンストラクト
    public Main2(char[,] _map,int x, int y)
    {
        map = _map;
        y_col = x; // 12
        x_row = y; // 10
        count = 0;
    }
    //池の確認、再帰、Wを"."に変更しmapをreturn
    public char[,] Check(int x, int y)
    {
        if (map[x, y] == 'W')
        {
            count++;
            map[x, y] = '.';
            if (y < y_col - 1) Check(x, y + 1);//下
            if (x < x_row - 1) Check(x + 1, y);//右
            if (y > 0) Check(x, y - 1);//上
            if (x > 0) Check(x - 1, y);//左
            if (x < x_row - 1 && y > 0) Check(x + 1, y - 1);//右上
            if (x > 0 && y > 0) Check(x - 1, y - 1);//左上
            if (x < x_row - 1 && y < y_col - 1) Check(x + 1, y + 1);//右下
            if (x > 0 && y < y_col - 1) Check(x - 1, y + 1);//左下
        }
        return map;
    }
    //池が連なっているかの確認
    public bool Count()
    {
        if(count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //マップの確認
    public void Test(char[,] map)
    {
        for (int i = 0; i < y_col; i++)
        {
            for (int k = 0; k < x_row; k++)
            {
                Console.Write(map[i, k]);
            }
            Console.WriteLine();
        }
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
            text = sr.ReadToEnd();
        }
        
        string[] values = text.Split('\n');
        string[] line = values[0].Split(' ');

        int y = int.Parse(line[0]);// x 12
        int x = int.Parse(line[1]);// y 10
        
        //配列に入れる
        char[,] map = new char[y,x];
        for(int i = 0; i < y+1; i++)
        {
            if (i == 0) continue;
            for (int k = 0; k < x; k++)
            {
                map[i-1, k] = values[i][k];
            }
        }

        int count = 0;
        char[,] B = map;
        for (int i = 0; i < y; i++)
        {
            for (int k = 0; k < x; k++)
            {
                Main2 A = new Main2(B, x, y);
                B = A.Check(i, k);
                if(A.Count()) count++;
            }
        }
        Console.WriteLine(count);
    }
}
