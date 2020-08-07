using System;
using System.IO;
using System.Text;

class File
{
    public string[] data = { };
    public double lamda = 0.2;
    //データの数
    public int n = 0;
    //ファイルの読み込み
    public void file()
    {
        string text = "";

        //ファイルの読み込み
        using (StreamReader sr = new StreamReader(
        "longthrow.csv", Encoding.GetEncoding("Shift_JIS")))
        {
            text = sr.ReadToEnd();
        }
        data = text.Split('\n');
        n = data.Length-2;//data.Length 52
    }
    //a_0...を渡してy^を配列で返す
    public double[] y_hat(double a_0, double a_1, double a_2, double a_3)
    {
        double[] y_h = new double[n+1];
        for (int i = 1; i < n+1; i++)
        {
            string[] tmp = data[i].Split(',');
            y_h[i] = a_0 + a_1 * double.Parse(tmp[0])/50+ a_2 * double.Parse(tmp[1])/150+ a_3 * double.Parse(tmp[2])/50;
            //Console.WriteLine(y_h[i]);
        }
        return y_h;//y_h[1] ～ y_h[50] にデータを格納
    }
    //a0...の更新を行う
    public double[] update(double a_0, double a_1, double a_2,double a_3)
    {
        double[] a = new double[4];
        //sigma Σ(yi-y^i)
        double[] sigma = {0,0,0,0};
        double[] y_h = y_hat(a_0, a_1, a_2, a_3);
        for (int i= 1; i < n+1; i++)
        {
            string[] tmp = data[i].Split(',');
            sigma[0] += double.Parse(tmp[3]) - y_h[i];
            sigma[1] += (double.Parse(tmp[3]) - y_h[i]) * double.Parse(tmp[0]) / 50;
            sigma[2] += (double.Parse(tmp[3]) - y_h[i]) * double.Parse(tmp[1]) / 150;
            sigma[3] += (double.Parse(tmp[3]) - y_h[i]) * double.Parse(tmp[2]) / 50;
        }
        a[0] = a_0 + lamda * 2 / n * sigma[0];
        a[1] = a_1 + lamda * 2 / n * sigma[1];
        a[2] = a_2 + lamda * 2 / n * sigma[2];
        a[3] = a_3 + lamda * 2 / n * sigma[3];
        return a;
    }
    //a0...から２乗の平均を返す
    public double MSE(double a_0, double a_1, double a_2, double a_3)
    {
        double sum = 0;
        double[] y_h = y_hat(a_0, a_1, a_2, a_3);
        for (int i = 1; i < n + 1; i++)
        {
            string[] tmp = data[i].Split(',');
            sum += (double.Parse(tmp[3]) - y_h[i])*(double.Parse(tmp[3]) - y_h[i]);
        }
        return sum/n;
    }
}
class FileMain
{
    public static void Main()
    {
        File A = new File();
        A.file();
        Random rand = new Random();
        double a_0 = rand.NextDouble();
        double a_1 = rand.NextDouble();
        double a_2 = rand.NextDouble();
        double a_3 = rand.NextDouble();

        for(int i = 0; i < 100000; i++)
        {
            double mse = A.MSE(a_0, a_1, a_2, a_3);
            double[] a = A.update(a_0, a_1, a_2, a_3);
            a_0 = a[0];
            a_1 = a[1];
            a_2 = a[2];
            a_3 = a[3];
            Console.WriteLine("a0 = {0:F3} a1 = {1:F3} a2 = {2:F3} a3 = {3:F3} MSE = {4:F3}", a_0, a_1 / 50, a_2 / 150, a_3 / 50, mse);
        }

    }
}
