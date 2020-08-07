using System;
class Average
{
    //----------------kadai.dllの内容を表示-------------------
    public void Show()
    {
        double[][] data;
        data = Kadai.Sample.GetData();
        for(int i = 0; i < data.Length; i++)
        {
            Console.WriteLine(data[i][0]+ " : " + data[i][1]);
        }
    }

    //----------------移動平均を求める------------------------
    public double[] Ave(int width)
    {
        double[][] data;
        data = Kadai.Sample.GetData();
        double[] data_ave = new double[data.Length];
        
        //　i=width_half　から　i=data.Length - width_half　まで
        for (int i = 0; i < data.Length; i++)
        {
            //デバッグ用
            //if (i != 536) { continue; }
            int width_half = width / 2;
            int count = 0;
            double sum = 0;

            //最初と最後の部分
            if (i - width_half < 0)
            {
                width_half = i;
            }else if(i+width_half > data.Length -1)
            {
                width_half = data.Length - i - 1;
            }
            
            //widthが偶数の時
            if (width % 2 == 0)
            {
                for (int k = i- width_half + 1 ; k <= i + width_half - 1; k++)
                {
                    sum += data[k][1];
                    count++;
                }
                sum += data[i - width_half][1] / 2;
                sum += data[i + width_half][1] / 2;
                data_ave[i] = sum / (count+1);
            }
            //widthが奇数の時
            else
            {
                for (int k = i - width_half; k <= i+ width_half; k++)
                {
                    sum += data[k][1];
                    count++;
                }
                data_ave[i] = sum / count;
            }
        }
        return data_ave;
    }
    //-----------------信頼区間を超えるデータを除く-------------------
    public double[][] Filter(double[][] data)
    {
        double sum = 0;
        //平均
        for(int i=0; i<data.Length; i++)
        {
            sum += data[i][1];
        }
        double data_ave = sum / data.Length;
        //信頼係数
        double t = 1.96;
        double data_hensa = 0;
        for (int i = 0; i < data.Length; i++)
        {
            double tmp = data[i][1] - data_ave;
            data_hensa += tmp * tmp;

        }
        //不偏分散
        data_hensa = data_hensa / (data.Length - 1);

        //標本標準偏差
        data_hensa = Math.Sqrt(data_hensa);
        //信頼区間
        double data_max = data_ave + (t * data_hensa / Math.Sqrt(data.Length));
        double data_min = data_ave - (t * data_hensa / Math.Sqrt(data.Length));

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i][1] > data_max)
            {
                Array.Clear(data[i],0,2);
            }
            else if (data[i][1] < data_min)
            {

                Array.Clear(data[i], 0, 2);
            }

        }
        return data;
    }
}
public class Hello
{
    public static void Main()
    {
        double[][] data;
        data = Kadai.Sample.GetData();
        Average A = new Average();

        //----------------kadai.dllの内容を表示-------------------
        Console.WriteLine("---------宿題１－１---------");
        A.Show();

        //----------------移動平均を求める------------------------
        Console.WriteLine("---------宿題１－２---------");
        double[] a = A.Ave(5);
        for (int i = 0; i < a.Length; i++)
        {
            Console.WriteLine(a[i]);
        }
        

        //-----------------信頼区間を超えるデータを除く-------------------
        Console.WriteLine("---------宿題１－３---------");
        var test = A.Filter(data);
        for (int i = 0; i < test.Length; i++)
        {
            Console.WriteLine(test[i][1]);
        }
    }
}
