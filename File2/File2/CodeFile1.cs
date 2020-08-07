using System;
using System.IO;
using System.Text;

class FileMain
{
    public static void Main()
    {

        Console.Write("検索文字列：");
        string word = Console.ReadLine();

        string text = "";
        string text_after = "";

        //ファイルの読み込み
        using (StreamReader sr = new StreamReader(
        "iris.csv", Encoding.GetEncoding("Shift_JIS")))
        {
            text = sr.ReadToEnd();
        }

        //Console.WriteLine(text);
        string[] str = text.Split('\n');

        int m = 1;
        foreach(string record in str)
        {
            int n = record.IndexOf(word);
            string tmp = record.Replace(word,"["+ word + "]");
            if(n != -1)
            {

                Console.WriteLine("({0}):{1}",m,tmp);
            }
            m++;
        }
    }
}
