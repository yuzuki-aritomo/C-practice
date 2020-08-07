using System;
using System.IO;
using System.Text;

class FileMain
{
    public static void Main()
    {
        string text = "";
        //ファイルの読み込み
        using (StreamReader sr = new StreamReader(
        "iris.csv", Encoding.GetEncoding("Shift_JIS")))
        {
            text = sr.ReadToEnd();
        }

        //Console.WriteLine(text);
        string[] str = text.Split('\n');

        
    }
}
