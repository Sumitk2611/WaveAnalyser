using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NAudio.Wave;

namespace Project
{
    
    public partial class Form1 : Form
    {

        static string fileOpen;
        static int N;
        static int bitsPerSample;
        static bool isStereo;
        static int channel;
        static double[][] data;
        const double MaxValue16Bit = 32767.0;
        private List<DataPoint> selectedDataPoints = new List<DataPoint>();


        public Form1()
        {
            
            InitializeComponent();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            modifyChart();
            displayDefault();
            chart3.Visible = false;
            chart4.Visible = false;
            chart4.Series[0].Color = Color.Red;

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
                int N = 100;
                int f = 1;
                double[] s = calculateSamples(f, N);
                CreateAmplitudeChart(s);
                CreateFreqChart(s, N, chart2);
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
            chart4.Series[0].Points.AddXY(0, 0);


        }

        private double[] calculateSamples(int f, int N)
        {
            double[] s = new double[N];
            for (int t = 0; t < N; t++)
            {
                s[t] =10* Math.Sin(2 * Math.PI * (t) * f / N + Math.PI/2);
            }
            return s;
        }

        private void CreateFreqChart(double[] s, int N, Chart freqChart)
        {
            double[] A = DFT(s,N);
            for(int f = 0;f < N/2; f++)
            {
                freqChart.Series[0].Points.AddXY(f, Math.Abs(A[f]));
            }
            

        }

        private double[] DFT(double[] s, int N)
        {
            double[] A = new double[N/2];
            double real;
            double imag;

            for(int f = 0; f < N / 2; f++)
            {
                real = 0;
                imag = 0;
                for(int t = 0; t < N; t++)
                {
                    real += s[t] * Math.Cos(2 * Math.PI * t * f / N);
                    imag += -s[t] * Math.Sin(2 * Math.PI * t * f / N);
                    
                }
                A[f] += Math.Sqrt((real * real) + (imag * imag)) / (N/2);
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

        private void startbutton_click(object sender, EventArgs e)
        {
            ClearChart();
            UpdateChart(); 
        }

        private void ClearChart()
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();
            
        }
        private void makeChartZoomable(object sender, MouseEventArgs e)
        {
            Chart chart = (Chart)sender;
            if (e.Delta < 0)
            {
                chart.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
                chart.ChartAreas[0].AxisY.ScaleView.ZoomReset(1);
            }
            else
            {


                double xMin = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double yMin = chart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                double yMax = chart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                double posXStart = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                double posXFinish = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                double posYStart = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                double posYFinish = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                chart.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish,DateTimeIntervalType.Number, true);
                chart.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish, DateTimeIntervalType.Number, true);
            }
        }



        private void new_window_button_click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void readFile(string filename)
        {
            if (Path.GetExtension(filename).Equals(".wav", StringComparison.OrdinalIgnoreCase))
            {

                byte[] fileData = File.ReadAllBytes(filename);
                bitsPerSample = BitConverter.ToInt16(fileData, 34);
                N = BitConverter.ToInt16(fileData, 24);
                channel = BitConverter.ToInt16(fileData, 22);

                
                short[] audio16 = null;
                double[][]s = new double [2][];

                if (bitsPerSample == 8)
                {
                    audio16 = Convert8BitTo16Bit(fileData);
                    s[0] = new double[audio16.Length];
                    if (channel == 2)
                    {
                        
                        s = readstereo(audio16);
                        chart3.Visible = true;
                        chart4.Visible = true;
                    } else
                    {
                        chart3.Visible = false;
                        chart4.Visible = false;
                    }

                } else if (bitsPerSample == 16)
                {
                    s[0] = new double[fileData.Length / 2];
                    audio16 = new short[fileData.Length / 2];
                    Buffer.BlockCopy(fileData, 0, audio16, 0, fileData.Length);
                    if (channel == 2)
                    {
                        s = readstereo(audio16);
                        chart3.Visible = true;
                        chart4.Visible = true;
                    }
                    else
                    {
                        chart3.Visible = false;
                        chart3.Visible = false;
                    }
                    

                }

                if (channel == 1)
                {
                    for (int i = 0; i < audio16.Length; i++)
                    {
                        s[0][i] = audio16[i] / MaxValue16Bit;
                        chart1.Series[0].Points.AddY(s[0][i]);
                    }
                    
                    CreateFreqChart(s[0], N, chart2);
                    
                } else if(channel == 2) 
                {
                    for(int i = 0;i < audio16.Length/2 +1;i++)
                    {
                        s[0][i] /= MaxValue16Bit;
                        s[1][i] /= MaxValue16Bit;
                        chart1.Series[0].Points.AddY(s[0][i]);
                        chart3.Series[0].Points.AddY(s[1][i]);
                    }

                    CreateFreqChart(s[0],N, chart2);

                    CreateFreqChart(s[1], N, chart4);

                }
                data = s;
            }
            
           
        }

        double[][]readstereo(short[] audio16)
        {
            int leftCounter = 0;
            int rightCounter = 0;
            int size = audio16.Length + 1;
            double[][] s = new double[2][];
            s[0] = new double[size];
            s[1] = new double[size];
            
            for (int i = 0; i < audio16.Length ; i++)
            {

                if (i % 2 == 0)
                {
                    s[0][leftCounter] = audio16[i];
                    leftCounter++;
                }
                else
                {
                    s[1][rightCounter] = audio16[i];
                    rightCounter++;
                }
            }
            return s;
        }
        

        short[] Convert8BitTo16Bit(byte[] data)
        {
            int max8BitValue = 255; // Maximum value for 8-bit audio
             // Maximum value for 16-bit audio
            
            int factor = (int)MaxValue16Bit / max8BitValue;

            
            short[] output = new short[data.Length];

            for(int i = 0; i < data.Length; i++)
            {
                short sample16Bit = (short)(factor * data[i]);
                output[i] = sample16Bit;
            }
            return output;
        }

        private void read_file_click(object sender, EventArgs e)
        {
            string selectedFilePath = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a File";
            openFileDialog.Filter = "All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                ClearChart();
                readFile(selectedFilePath);

            }
            fileOpen = selectedFilePath;

        }

        private void writeFile(string filePath, double[][] audio)
        {
            byte[] audioData;
            if (channel == 1)
            {
                audioData = ConvertDoubleArrayToByteArray(audio[0]);
            } else
            {
                double[]samples = InterleaveStereoAudio(audio[0], audio[1]);
                audioData = ConvertDoubleArrayToByteArray(samples);
            }
            
            try
            {
                // Create a BinaryWriter to write binary data to the file
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    // Write the RIFF header
                    writer.Write(Encoding.ASCII.GetBytes("RIFF"));
                    writer.Write(36 + audioData.Length); // File size - 36 bytes for the rest of the headers
                    writer.Write(Encoding.ASCII.GetBytes("WAVE"));

                    // Write the format chunk
                    writer.Write(Encoding.ASCII.GetBytes("fmt "));
                    writer.Write(16); // Subchunk1 size (16 bytes for PCM)
                    writer.Write((short)1); // Audio format (PCM = 1)
                    writer.Write((short)channel); // Number of channels
                    writer.Write(N); // Sample rate
                    writer.Write(N * channel * bitsPerSample / 8); // Byte rate
                    writer.Write((short)(channel * bitsPerSample / 8)); // Block align
                    writer.Write((short)bitsPerSample); // Bits per sample

                    // Write the data chunk header
                    writer.Write(Encoding.ASCII.GetBytes("data"));
                    writer.Write(audioData.Length); // Data chunk size

                    // Write the audio data
                    writer.Write(audioData);

                    MessageBox.Show("File was Successfully saved", "File Saved");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating WAV audio file: {ex.Message}");
            }
        }

        static byte[] ConvertDoubleArrayToByteArray(double[] doubleSamples)
        {
            // Create a byte array with enough capacity to store all the double values
            byte[] byteSamples = new byte[doubleSamples.Length * 2]; // Assuming 16-bit (2 bytes) per sample

            // Convert each double sample to a 16-bit signed integer and store it in the byte array
            for (int i = 0; i < doubleSamples.Length; i++)
            {
                short sampleValue = (short)(doubleSamples[i] * short.MaxValue);
                byteSamples[i * 2] = (byte)(sampleValue & 0xFF);
                byteSamples[i * 2 + 1] = (byte)((sampleValue >> 8) & 0xFF);
            }

            return byteSamples;
        }

        static double[] InterleaveStereoAudio(double[] leftChannel, double[] rightChannel)
        {
            int numSamples = Math.Min(leftChannel.Length, rightChannel.Length) /2;
            double[] interleavedSamples = new double[numSamples * 2]; // Interleaved stereo data

            for (int i = 0; i < numSamples; i++)
            {
                interleavedSamples[i * 2] = leftChannel[i];     // Left channel
                interleavedSamples[i * 2 + 1] = rightChannel[i]; // Right channel
            }

            return interleavedSamples;
        }

        private void save_Click(object sender, EventArgs e)
        {
           if(fileOpen == null)
            {
                MessageBox.Show("Could not save file\n There was no file open", "Error");
            } 
            else
            {
                writeFile(fileOpen, data);
            }
        }



        /* private void Chart_SelectionRangeChanging(object sender, CursorEventArgs e)
         {
             // Clear the previously selected data points
             selectedDataPoints.Clear();
         }

         private void Chart_SelectionRangeChanged(object sender, CursorEventArgs e)
         {
             Chart chart = (Chart)sender;
             ChartArea chartArea = chart.ChartAreas["ChartArea1"];
             Series series = chart.Series[0];

             // Determine the X-values of the selection range
             double startX = chartArea.CursorX.SelectionStart;
             double endX = chartArea.CursorX.SelectionEnd;

             // Iterate through data points to find selected points
             foreach (DataPoint point in series.Points)
             {
                 if (point.XValue >= startX && point.XValue <= endX)
                 {
                     selectedDataPoints.Add(point);
                 }
             }

         }*/
    }
}
