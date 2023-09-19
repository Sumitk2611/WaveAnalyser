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

namespace Project
{
    public partial class Form1 : Form
    {
        double t;
        double a;
        int count = 0;
        int N = 10;
        int f = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           timer1.Interval = 1;
            timer1.Start();
            
            
        }


        private void CreateAmplitudeChart(double[] s)
        {

            for (int t = 0; t <s.Length; t++)
            {
                chart1.Series[0].Points.AddXY(t+count, s[t]);
            }
            count += s.Length;
    }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count > 10)
            {
                timer1.Stop();
            }
            UpdateChart();
        }

        private void UpdateChart()
        {
            double[] s = calculateSamples(f, N);
            CreateAmplitudeChart(s);
            CreateFreqChart(s, N);
            t++;
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
        


    }
}
