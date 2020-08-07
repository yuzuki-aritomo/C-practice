using System;
using System.IO;
using System.Text;

class File
{
    public string Move(string text)
    {
        string text_after = "";
        for (int i = 0; i < text.Length; i++)
        {
            int tmp;
            //大文字をずらす
            if (64 < (int)text[i] && (int)text[i] < 91)
            {
                tmp = (int)text[i] + 13;
                if (tmp > 90)
                {
                    tmp -= 26;
                }
                text_after += (char)tmp;
            }
            //小文字をずらす
            else if (96 < (int)text[i] && (int)text[i] < 123)
            {
                tmp = (int)text[i] + 13;
                if (tmp > 122)
                {
                    tmp -= 26;
                }
                text_after += (char)tmp;
            }
            else
            {
                text_after += text[i];
            }
        }
        return text_after;
    }
}
class FileMain
{
    
    public static void Main()
    {
        Console.Write("入力ファイル名：");
        string file_in = Console.ReadLine();
        Console.Write("出力ファイル名：");
        string file_out = Console.ReadLine();
        string text = "";
        string text_after;

        //ファイルの読み込み
        using (StreamReader sr = new StreamReader(
        file_in, Encoding.GetEncoding("Shift_JIS")))
        {
            text = sr.ReadToEnd();
        }

        //文字を１６個ずらす
        File A = new File();
        text_after = A.Move(text);

        //ファイルの書き込み
        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
        using (StreamWriter writer = new StreamWriter(file_out, false, sjisEnc))
        {
            writer.WriteLine(text_after);

        }
        Console.WriteLine(text_after);
    }
}
