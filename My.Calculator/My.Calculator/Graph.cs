﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.mariuszgromada.math.mxparser;
using System.Windows.Forms.DataVisualization.Charting;

namespace My.Calculator
{
    public partial class Graph : UserControl
    {
       
        public Graph()
        {
            InitializeComponent();
            
        }

        float xmax = 12;
        float xmin = -12;
        float ymax = 24;
        float ymin = -24;
        float xint = 1;
        float yint = 4;
        float xplus = 5;
        float yplus = 5;

        private void button1_Click(object sender, EventArgs e)
        {
            var chart = chart1.ChartAreas[0];

            chart.AxisX.IntervalType = DateTimeIntervalType.Number;

            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.IsEndLabelVisible = true;
            chart.AxisX.Maximum = xmax;
            chart.AxisX.Minimum = xmin;
            chart.AxisY.Maximum = ymax;
            chart.AxisY.Minimum = ymin;
            chart.AxisX.Interval = xint;
            chart.AxisY.Interval = yint;

            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            chart1.Series.Clear();
            chart1.Series.Add("Hallo");
            chart1.Series["Hallo"].ChartType = SeriesChartType.Line;
            chart1.Series["Hallo"].Color = Color.Blue;


            chart1.Series.Add("AxisX");
            chart1.Series["AxisX"].ChartType = SeriesChartType.Line;
            chart1.Series["AxisX"].Color = Color.Black;
            chart1.Series["AxisX"].Points.AddXY(0, ymax);
            chart1.Series["AxisX"].Points.AddXY(0, ymin);

            chart1.Series.Add("AxisY");
            chart1.Series["AxisY"].ChartType = SeriesChartType.Line;
            chart1.Series["AxisY"].Color = Color.Black;
            chart1.Series["AxisY"].Points.AddXY(xmin, 0);
            chart1.Series["AxisY"].Points.AddXY(xmax, 0);
            chart1.Legends.Clear();
            ChartArea CA = chart1.ChartAreas[0];  // quick reference
            CA.AxisX.ScaleView.Zoomable = true;
            CA.CursorX.AutoScroll = true;
            CA.CursorX.IsUserSelectionEnabled = true;

            try
            {
                Argument x = new Argument("x");
                Expression g = new Expression(textBox1.Text, x);

                for (double i = xmin; i <= xmax; i += 0.1F)
                {

                    x.setArgumentValue(i);
                    double y = g.calculate();
                    if (Math.Abs(y) > 99999 || Math.Abs(y) < -99999)
                    { }
                    else
                        chart1.Series["Hallo"].Points.AddXY(i, y);

                }
                textBox1.BackColor = Color.White;
            }
            catch
            {
                textBox2.BackColor = Color.Red;
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xmax = xmax / 2;
            xmin = xmin / 2;
            ymax = ymax / 2;
            ymin = ymin / 2;
            xint = xint / 2;
            yint = yint / 2;
            xplus = xplus / 2;
            yplus = yplus / 2;
            button1.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xmax = xmax * 2;
            xmin = xmin * 2;
            ymax = ymax * 2;
            ymin = ymin * 2;
            xint = xint * 2;
            yint = yint * 2;
            xplus = xplus * 2;
            yplus = yplus * 2;
            button1.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            xmin = xmin - xplus;
            xmax = xmax - xplus;
            button1.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            xmin = xmin + xplus;
            xmax = xmax + xplus;
            button1.PerformClick();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            xmax = xmax / 2;
            xmin = xmin / 2;
            xint = xint / 2;
            xplus = xplus / 2;
            button1.PerformClick();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            xmax = xmax * 2;
            xmin = xmin * 2;
            xint = xint * 2;
            xplus = xplus * 2;
            button1.PerformClick();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ymax = ymax / 2;
            ymin = ymin / 2;
            yint = yint / 2;
            yplus = yplus / 2;
            button1.PerformClick();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ymax = ymax * 2;
            ymin = ymin * 2;
            yint = yint * 2;
            yplus = yplus * 2;
            button1.PerformClick();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Argument x = new Argument("x");
                Expression g = new Expression(textBox1.Text, x);
                string str = textBox2.Text;
                x.setArgumentValue(Convert.ToDouble(str));
                labelResult.Text = g.calculate().ToString();
            }
            catch { }

            
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button12.PerformClick();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SendToBack();
        }
    }
}