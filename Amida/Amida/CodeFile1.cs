using System;
using System.IO;
using System.Text;

class FileMain
{
    public static void Main()
    {
        string[] player = { };
        //ファイルの読み込み
        using (StreamReader sr = new StreamReader(
        "amida.txt", Encoding.GetEncoding("Shift_JIS")))
        {
            int i = 0;
            while (!sr.EndOfStream)
            {
                var record = sr.ReadLine();
                Console.WriteLine(record);
                if (i == 0)
                {
                    player = record.Split(' ');
                }
                for (int k = 0; k < player.Length-1; k++)
                {
                    string line = record.Replace("|", "");
                    if(line[k] == '-')
                    {
                        string tmp = player[k];
                        player[k] = player[k + 1];
                        player[k + 1] = tmp;
                    }
                    int n = line.IndexOf('-');
                    if (n == -1)
                    {
                        break;
                    }
                }
                
                i++;
            }
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} ", player[0], player[1], player[2], player[3], player[4], player[5], player[6], player[7], player[8], player[9]);
        }
    }
}
