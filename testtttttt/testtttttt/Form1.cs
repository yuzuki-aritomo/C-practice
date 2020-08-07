using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testtttttt
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            string legend = "グラフ１";

            chart1.Series.Clear();  //グラフ初期化

            chart1.Series.Add(legend);  //グラフ追加
                                        //グラフの種類を指定（Columnは棒グラフ）
            chart1.Series[legend].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[legend].LegendText = legend;  //凡例に表示するテキストを指定

            string[] xValues = new string[] { "A", "B", "C", "D", "E" };
            int[] yValues = new int[] { 10, 20, 30, 40, 50 };

            for (int i = 0; i < xValues.Length; i++)
            {
                //グラフに追加するデータクラスを生成
                System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
                dp.SetValueXY(xValues[i], yValues[i]);  //XとYの値を設定
                dp.IsValueShownAsLabel = true;  //グラフに値を表示するように指定
                chart1.Series[legend].Points.Add(dp);   //グラフにデータ追加
            }
        }
    }
}
