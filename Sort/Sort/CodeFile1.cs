// 1191100011 有友柚樹
using System;

class Score
{
    public string name;
    public int point;

    public Score(string n, int p)
    {
        name = n;
        point = p;
    }
}
class SelectionSort
{
    public static void Sort(Score[] score)
    {
        for (int i = 0; i < score.Length - 1; i++)
        {
            int max = score[i].point;
            int k = i;
            for (int j = i + 1; j < score.Length; j++)
            {
                if (score[j].point > max)
                {
                    max = score[j].point;
                    k = j;
                }
            }
            if (k != i)
            {
                (score[i], score[k]) = (score[k], score[i]);
            }
        }

        for (int i = 0; i < score.Length ; i++)
        {
            Console.WriteLine("name:{0} , point:{1}",score[i].name,score[i].point);
        }
    }
}
class SortMain
{
    public static void Main()
    {
        Score[] scores = {
            new Score("Alice", 2520),
            new Score("Bob", 1219),
            new Score("Charlie", 1005),
            new Score("Dave", 2117),
            new Score("Ellen", 1095),
            new Score("Frank", 1033),
            new Score("Grace", 993),
            new Score("Hugo", 1120),
            new Score("Ivan", 2755),
            new Score("Justin", 1750),
            new Score("Kevin", 1137),
            new Score("Lewis", 993),
            new Score("Mallory", 1470),
            new Score("Oscar", 1352),
            new Score("Pat", 1750),
            new Score("Roy", 1582),
            new Score("Steve", 1005),
            new Score("Trent", 1120),
            new Score("Victor", 993),
            new Score("Walter", 1338)
        };
        SelectionSort.Sort(scores);
    }
}

//課題コメント　コードの安定性
//選択ソートでは安定性が保たれている