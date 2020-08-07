using System;
using System.Threading;

//1191100011 有友柚樹

class Shuffle
{
    //------------ランダムがおなじになるためここで回避----------------
    static Random rnd = new Random();
    //-----------dataをシャッフルしリターン----------
    public int[] Shuff()
    {
        const int SIZE = 100;
        int[] data = new int[SIZE] { 2070, 9360, 6868, 534, 9311, 9617, 1399, 9680, 5284, 6815, 6939, 5136, 5245, 172, 7814, 6389, 7049, 45, 9448, 4101, 8179, 4021, 4249, 8146, 4883, 1489, 2207, 1735, 5283, 1898, 8704, 431, 6373, 2849, 160, 2833, 8181, 9857, 6706, 2015, 1414, 7362, 8965, 1984, 7097, 2067, 6502, 9678, 2554, 9222, 1765, 5011, 6468, 5986, 9090, 6726, 3229, 1807, 1592, 2218, 4037, 306, 1632, 5364, 6453, 9649, 5595, 6413, 3257, 9898, 4100, 7573, 7791, 2030, 9953, 8345, 7788, 1286, 1942, 6626, 1854, 5189, 4737, 6527, 3781, 307, 7300, 9319, 3927, 6043, 9293, 5783, 9653, 1782, 2441, 9443, 6539, 5817, 8467, 7589 };

        for (int i = 0; i < 100; i++)
        {
            int random = rnd.Next(1, 100);
            int tmp = data[i];
            data[i] = data[random];
            data[random] = tmp;
        }
        return data;
    }

    internal int Next(int v1, int v2)
    {
        throw new NotImplementedException();
    }
}
class MainClass
{
    public static void Main()
    {
        const int TRIAL = 100000000;
        bool ABC = false;

        
        for (int k = 0; k < TRIAL; k++)
        {
            Random rnd = new Random();
            int array_num = rnd.Next(1, 100);
            int array_num_a = rnd.Next(1, 100);
            //Console.WriteLine(array_num);
            //Console.WriteLine(array_num_a);

            Shuffle ABB = new Shuffle();
            int[] data_abb = ABB.Shuff();

            int sum_1 = 0;
            for (int i = 0; i < array_num; i++)
            {
                sum_1 += data_abb[i];
            }

            Shuffle BCC = new Shuffle();
            int[] data_b = BCC.Shuff();

            int sum_2 = 0;
            for (int i = 0; i < array_num_a; i++)
            {
                sum_2 += data_b[i];
            }

            if (sum_1 == sum_2)
            {
                if (array_num != array_num_a)
                {
                    ABC = true;

                    for (int i = 0; i < array_num; i++)
                    {
                        Console.Write(data_abb[i] + ":");
                    }
                    Console.WriteLine();
                    for (int l = 0; l < array_num_a; l++)
                    {
                        Console.Write(data_b[l] + ":");

                    }

                    break;
                }
                int count = 0;
                for (int i = 0; i < array_num; i++)
                {
                    for(int l = 0; l < array_num_a; l++)
                    {
                        if (data_abb[i] == data_b[l])
                        {
                            count++;
                        }
                        
                    }
                }
                if (count == array_num)
                {
                    continue;
                }
                else
                {
                    ABC = true;
                    for (int i = 0; i < array_num; i++)
                    {
                        Console.Write(data_abb[i]+":");
                    }
                    Console.WriteLine();
                    for (int l = 0; l < array_num_a; l++)
                    {
                        Console.Write(data_b[l] + ":");

                    }
                    break;
                }
            }
        }

        if (ABC)
        {
            Console.WriteLine("部分和が存在します");
        }
        else
        {
            Console.WriteLine("部分和が存在しません");

        }

    }
}