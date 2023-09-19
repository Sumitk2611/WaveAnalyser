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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           timer1.Interval = 1;
            timer1.Start();
            
            
        }


        private void CreateAmplitudeChart(double a, double t)
        {
            
            /*for(int i = 0; i < a.Length && i < t.Length; i++)
            {*/
                chart1.Series[0].Points.AddXY(t, a);
            /*}*/
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            /*if (count > 10)
            {
                timer1.Stop();
            }*/
            UpdateChart();
        }

        private void UpdateChart()
        {
            
            double newValue = calculateSamples(1, 10, t);
            
            a = newValue;
            CreateAmplitudeChart(a,t);
            t++;
        }

        private double calculateSamples(int f, int N, double t)
        {
            double a = Math.Cos(2 * Math.PI * f * t / ( N));
            return a;
        }


    }
}
