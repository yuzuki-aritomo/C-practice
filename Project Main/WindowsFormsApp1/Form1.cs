using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // /////////////////////////////////////////////////////
            // Chartコントロール内のグラフ、凡例、目盛り領域を削除
            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.ChartAreas.Clear();

            // /////////////////////////////////////////////////////
            // 目盛り領域の設定
            var ca = chart1.ChartAreas.Add("Histogram");

            // X軸
            ca.AxisX.Title = "Brightness";  // タイトル
            ca.AxisX.Minimum = 0;           // 最小値
            ca.AxisX.Maximum = 256;         // 最大値
            ca.AxisX.Interval = 64;         // 目盛りの間隔
                                            // Y軸
            ca.AxisY.Title = "Count";
            ca.AxisY.Minimum = 0;

            // /////////////////////////////////////////////////////
            // データの追加
            var hist = new Point[] {
            new Point(32, 10),
            new Point(96, 30),
            new Point(160, 50),
            new Point(224, 20)
                };

            // グラフの系列を追加
            var s = chart1.Series.Add("Histogram");
            // 棒グラフの隙間を無くす
            s.SetCustomProperty("PointWidth", "1.0");
            // データ設定
            for (int i = 0; i < hist.Length; i++)
            {
                s.Points.AddXY(hist[i].X, hist[i].Y);
            }
            InitializeComponent();
        }
    }
}
