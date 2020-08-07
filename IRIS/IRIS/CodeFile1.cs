// 1191100011
using System;
using System.IO;
using System.Text;

class FileMain
{
    public static void Main()
    {
        string[] value;
        StreamReader sr = new StreamReader("iris.csv");
        {
            // 末尾まで繰り返す
            while (!sr.EndOfStream)
            {
                // CSVファイルの一行を読み込む
                string line = sr.ReadLine();
                // 読み込んだ一行をカンマ毎に分けて配列に格納する
                string[] values = line.Split(',');
                
            }
            Console.ReadKey();
        }
    }
}
