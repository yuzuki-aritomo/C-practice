//1191100011 有友柚樹

using System;
using System.IO;
using System.Linq;
using System.Text;

public class state
{
    public int row = 0; //行　横
    public int column = 0; //列　縦
    public int operation = 100000000;
}

class FileMain
{
    public static void Main()
    {
        string text;
        //ファイルの読み込み
        using (StreamReader sr = new StreamReader(
        "matrix.dat", Encoding.GetEncoding("Shift_JIS")))
        {
            text = sr.ReadToEnd();
        }
        //初期の値の整理
        string[] tmp = text.Split('\n');
        int num = int.Parse(tmp[0]); //num 6 行列の数
        int[,] value = new int[num,2]; //value[ 行列のi番目 , 0：行 1：列 ]
        for(int i = 0; i < num; i++)
        {
            string[] cash = tmp[i+1].Split(' ');
            value[i, 0] = int.Parse(cash[0]);
            value[i, 1] = int.Parse(cash[1]);
        }

        //テーブルの作成及び初期値の代入
        state[,] table = new state[num, num];
        for (int i = 0; i < num; i++)
        {
            for (int j = 0; j < num; j++)
            {
                table[i, j] = new state();
            }
            table[i, i].row = value[i, 0]; //初期の行
            table[i, i].column = value[i, 1]; //初期の列
            table[i, i].operation = 0; //初期の行列の積
        }

        //行列の積の計算
        for (int i = 1; i < num; i++)
        {
            for (int j = 0; j < num-i; j++)
            {
                //recordに代入して比較
                int[] record = new int[i + 1];
                for (int k = 1; k < i + 1; k++)
                {
                    record[k-1] = table[j, i + j - k].row * table[j, i + j - k].column * table[j + (1 + i - k), i + j].column + table[j, i + j - k].operation + table[j + (1 + i - k), i + j].operation;
                }
                //宣言時に0で初期化されてしまうため大きな数を代入
                for (int k = 0; k < i + 1; k++)
                {
                    if (record[k] == 0)
                    {
                        record[k] = 100000000;
                    }
                }
                //recordで最も小さかった物をtableに代入
                for (int k= 1; k < i + 1; k++)
                {
                    if(record[k-1] == record.Min())
                    {
                        table[j, i + j].operation = record[k-1];
                        table[j, i + j].row = table[j, i + j - k].row;
                        table[j, i + j].column = table[j + (1 + i - k), i + j].column;
                    }
                }
            }
        }

        Console.WriteLine(text);

        //結果の出力
        Console.WriteLine(table[0,num-1].operation);
    }
}