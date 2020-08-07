using System;
using System.IO;
using System.Text;

class FileMain
{
    public static void Main()
    {
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


        int a = str.Length;
        for(int i = 0; i < a; i++)
        {
            if (i == 0)
            {
                text_after = str[i];
                continue;
            }
            string[] record = str[i].Split(',');
            double b = double.Parse(record[2]);
            b = b * 10;
            record[2] = b.ToString();
            str[i] = record[0] + "," + record[1] + "," + record[2] + "," + record[3] + "," + record[4];
            text_after += '\n' + str[i];
        }
        Console.WriteLine(text_after);

        //ファイルの書き込み
        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
        using (StreamWriter writer = new StreamWriter("iris_10times.csv", false, sjisEnc))
        {
            writer.WriteLine(text_after);
        }

        
    }
}
