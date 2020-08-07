using System;

class BingoCard
{
    public int[][] card;
    //--------------ビンゴカードの作成------------------
    public void CreateCard(int n, int m)
    {
        int[] bingo = new int[n * m];
        for (int i = 0; i < n * m; i++)
        {
            bingo[i] = i + 1;
        }
        int length = bingo.Length;
        for (int i = length - 1; i > 0; i--)
        {
            Random rnd = new Random();
            int k = rnd.Next(i + 1);
            int tmp = bingo[i];
            bingo[i] = bingo[k];
            bingo[k] = tmp;
        }
        card = new int[n][];
        for (int i = 0; i < n; i++)
        {
            card[i] = new int[n];
            for (int k = 0; k < n; k++)
            {
                card[i][k] = bingo[i * n + k];
            }
        }
    }
    public int[][] ReturnCard(int n,int m)
    {
        CreateCard(n,m);
        return card;
    }
    //--------------カードに数字があるかの判定------------------
    public bool PushNumber(int x,int[][] card)
    {
        bool aa = false;
        for (int i = 0; i < card.Length; i++)
        {
            for (int l = 0; l < card[i].Length; l++)
            {
                //Console.WriteLine(i + ":" + card[i][l]);
                if (card[i][l] == x)
                {
                    aa = true;
                    //Console.WriteLine("-------" + card[i][l]);
                    card[i][l] = 0;
                    //カードに数字があった場合０を代入
                    return aa;
                }
            }
        }
        return aa;
    }
    //--------------ビンゴになっているかの判定------------------
    public bool IsBingo(int x, int[][] card)
    {
        bool aa = false;
        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;
        for (int i = 0; i < card.Length; i++)
        {
            for (int k = 0; k < card.Length; k++)
            {
                //縦
                a += card[i][k];
                //横
                b += card[k][i];
                //斜め
                c += card[i][i];
                d += card[i][card.Length - 1 - i];
            }
            if (a == 0 || b == 0)
            {
                aa = true;
            }
        }
        if (c == 0 || d == 0)
        {
            aa = true;
        }

        return aa;
    }
    //------------ランダムがおなじになるためここで回避----------------
    static Random random = new Random();

    //------------n,mでのビンゴになるまでの回数----------------
    public int BingoNum(int n,int m)
    {
        CreateCard(n, m);
        //ビンゴの正解のランダムの数
        int[] bingo_ran = new int[n * m];
        for (int i = 0; i < n * m; i++)
        {
            bingo_ran[i] = i + 1;
        }
        int length = bingo_ran.Length;
        for (int i = length - 1; i > 0; i--)
        {
            int k = random.Next(i + 1);
            int tmp = bingo_ran[i];
            bingo_ran[i] = bingo_ran[k];
            bingo_ran[k] = tmp;
        }
        int bingo_num = 0;
        for (int i = 0; i < bingo_ran.Length; i++)
        {
            //Console.WriteLine(i);
            if (PushNumber(bingo_ran[i], card)) 
            {
                if (IsBingo(bingo_ran[i], card))
                {
                    //Console.WriteLine("####"+i);
                    bingo_num = i;
                    break;
                }
            }
        }
        return bingo_num;
    }
    //------------n，mでビンゴをX回繰り返したときのBの平均値----------------
    public double BingoAve(int n,int m,int x)
    {
        double sum = 0;
        for (int i = 0; i < x; i++)
        {
            sum += BingoNum(n, m);
        }
        double ave = sum / x;
        return ave;

    }
    //------------10000回でのヒストグラムを表示----------------
    public void Graph()
    {
        int[] x = new int[100];

        for (int i = 0; i < 100; i++)
        {
            x[i] = 0;
        }
        for(int i = 0; i < 10000; i++)
        {
            int num = BingoNum(5, 20);
            //Console.WriteLine(num);
            x[num-1]++;
        }
        for(int i = 4; i < 100; i++)
        {
            Console.Write("{0}回目：", i+1);
            string repeat = new string('*', x[i]);
            Console.Write(x[i]);
            Console.WriteLine(repeat);
        }
    }
}
public class Hello
{
    public static void Main()
    {
        // Your code here!
        Console.Write("nを代入してください");
        int n = int.Parse(Console.ReadLine());
        Console.Write("mを代入してください");
        int m = int.Parse(Console.ReadLine());

        BingoCard A = new BingoCard();
        Console.WriteLine("---------宿題２－1---------");
        var bingo = A.ReturnCard(n,m);
        for (int i = 0; i < bingo.Length; i++)
        {
            for (int j = 0; j < bingo[i].Length; j++)
            {
                Console.Write("|" + bingo[i][j]);
            }
            Console.WriteLine("|");
        }
        Console.WriteLine("---------宿題２－4---------");
        Console.WriteLine(A.BingoAve(3,5,10000));
        Console.WriteLine("---------宿題２－５---------");
        A.Graph();
        

    }
}
