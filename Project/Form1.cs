using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NAudio.Wave;

namespace Project
{
    public partial class Form1 : Form
    {
        
       
        int N = 100;
        int f = 1;
        

        public Form1()
        {
            
            InitializeComponent();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            modifyChart();
            displayDefault();

        }


        private void CreateAmplitudeChart(double[] s)
        {
            
            for (int t = 0; t <s.Length; t++)
            {
                chart1.Series[0].Points.AddXY(t, s[t]);
                chart3.Series[0].Points.AddXY(t, s[t]);
            }
            
    }



        private void UpdateChart()
        {
            
            {
                double[] s = calculateSamples(f, N);
                CreateAmplitudeChart(s);
                CreateFreqChart(s, N);
                int width = chart1.Width;
                int height = chart1.Height;
                chart1.Size = new Size(width++, height++);
            } 
            
            
        }

        private void displayDefault()
        {
                chart1.Series[0].Points.AddXY(0, 0);
                chart3.Series[0].Points.AddXY(0 , 0);
                chart2.Series[0].Points.AddXY (0 , 0);
            
        }

        private double[] calculateSamples(int f, int N)
        {
            double[] s = new double[N];
            for (int t = 0; t < N; t++)
            {
                s[t] =10* Math.Cos(2 * Math.PI * (t) * f / N);
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
            double real;
            double imag;

            for(int f = 0; f < N; f++)
            {
                real = 0;
                imag = 0;
                for(int t = 0; t < N; t++)
                {
                    real += s[t] * Math.Cos(2 * Math.PI * t * f / N);
                    imag += -s[t] * Math.Sin(2 * Math.PI * t * f / N);
                    
                }
                A[f] += Math.Sqrt((real * real) + (imag * imag));
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
            ClearChart();
            UpdateChart(); 
        }

        private void ClearChart()
        {
            chart1.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();
            
        }
        private void makeChart1Zoomable(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
                chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(1);
            }
            else
            {


                double xMin = chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = chart1.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double yMin = chart1.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                double yMax = chart1.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                double posXStart = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                double posXFinish = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                double posYStart = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                double posYFinish = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                chart1.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish,DateTimeIntervalType.Number, true);
                chart1.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish, DateTimeIntervalType.Number, true);
            }
        }

        private void makeChart3Zoomable(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                chart3.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
                chart3.ChartAreas[0].AxisY.ScaleView.ZoomReset(1);
            }
            else
            {


                double xMin = chart3    .ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = chart3.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double yMin = chart3.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                double yMax = chart3.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                double posXStart = chart3.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                double posXFinish = chart3.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                double posYStart = chart3.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                double posYFinish = chart3.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                chart3.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish, DateTimeIntervalType.Number, true);
                chart3.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish, DateTimeIntervalType.Number, true);
            }
        }

        private void makeChart2Zoomable(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                chart2.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
                chart2.ChartAreas[0].AxisY.ScaleView.ZoomReset(1);
            }
            else
            {


                double xMin = chart2.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = chart2.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double yMin = chart2.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                double yMax = chart2.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                double posXStart = chart2.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                double posXFinish = chart2.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                double posYStart = chart2.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                double posYFinish = chart2.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                chart2.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish, DateTimeIntervalType.Number, true);
                chart2.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish, DateTimeIntervalType.Number, true);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void readFile(string filename)
        {
            int count = 0;
            string audioFilePath = filename;
            var audioFile = new AudioFileReader(audioFilePath);
            byte[] buffer = new byte[1024]; // Adjust the buffer size as needed
            int bytesRead;
            double[] audioSamples = new double[audioFile.WaveFormat.SampleRate];
            
            double sample;
            double maxAmplitude = 0;
            while ((bytesRead = audioFile.Read(buffer, 0, buffer.Length)) > 0)
            {
                // Process each audio sample in the 'buffer'
                for (int i = 0; i < bytesRead; i++)
                {
                    sample = buffer[i];
                    audioSamples[i] = (sample);
                    if (sample > maxAmplitude)
                        maxAmplitude = sample;

                    // You can perform further processing on each sample if needed
                    // For example, you might want to analyze or manipulate the audio data here
                }
            }

            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(-maxAmplitude, maxAmplitude);
            for (int i = 0;i < audioSamples.Length;i++)
            {
                chart1.Series[0].Points.Add(audioSamples[i]);
            }
            CreateFreqChart(audioSamples, audioFile.WaveFormat.SampleRate);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string selectedFilePath = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a File";
            openFileDialog.Filter = "All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                readFile(selectedFilePath);

            } 
            
            
            
        }
    }
}
