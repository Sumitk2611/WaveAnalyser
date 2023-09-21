using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project
{
    public partial class Form1 : Form
    {
        bool flag = false;
        int count = 0;
        int N = 10;
        int f = 3;
        int numberOfSamples = 100;

        public Form1()
        {
            
            InitializeComponent();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            generateInfo();
            timer1.Interval = 1;
            timer1.Start();

        }


        private void CreateAmplitudeChart(double[] s)
        {
            
            for (int t = 0; t <s.Length; t++)
            {
                chart1.Series[0].Points.AddXY(t+count, s[t]);
                chart3.Series[0].Points.AddXY(t + count, s[t]);
            }
            count += s.Length;
    }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count > numberOfSamples)
            {
                timer1.Stop();
            }
            UpdateChart();
        }

        private void UpdateChart()
        {
            if (flag)
            {
                double[] s = calculateSamples(f, N);
                CreateAmplitudeChart(s);
                CreateFreqChart(s, N);
                int width = chart1.Width;
                int height = chart1.Height;
                chart1.Size = new Size(width++, height++);
            } else
            {
                displayDefault();
            }
            



        }

        private void displayDefault()
        {
            timer1.Stop();
                chart1.Series[0].Points.AddXY(0, 0);
                chart3.Series[0].Points.AddXY(0 , 0);
                chart2.Series[0].Points.AddXY (0 , 0);
            

        }

        private double[] calculateSamples(int f, int N)
        {
            double[] s = new double[N];
            for (int t = 0; t < N; t++)
            {
                s[t] = Math.Cos(2 * Math.PI * (t+count) * f / N);
            }
            return s;
        }

        private void CreateFreqChart(double[] s, int N)
        {
            double[] A = DFT(s,N);
            for(int f = 0;f < N; f++)
            {
                chart2.Series[0].Points.AddXY(f, Math.Abs(A[f]));
            }
            

        }

        private double[] DFT(double[] s, int N)
        {
            double[] A = new double[N];

            for(int f = 0; f < N; f++)
            {
                for(int t = 0; t < N; t++)
                {
                    A[f] += s[t] * Math.Cos(2 * Math.PI * t * f / N);
                }
            }
            return A;
        }

    

        private void ChartArea1_AxisViewChanged(object sender, ViewEventArgs e)
        {
            // Handle the zooming event here
            // You can update your chart's data based on the new view range
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            
            timer1.Start();
            
            
        }
    }
}
