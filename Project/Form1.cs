using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NAudio.Wave;

namespace Project
{

    public partial class WaveAnalyzer : Form
    {
        public struct RecordData
        {
            public IntPtr data;
            public uint dataLength;
        }

        bool isTriangleWindow = false;
        bool isGaussianWindow = false;
        bool isSineWindow = false;

        string fileOpen;
        int N;
        int bitsPerSample;
        bool isStereo;
        int channel;
        double[][] storedData;
        const double MaxValue16Bit = 32767.0;
        double[] selectedSamples;
        bool threading = false;
        private List<DataPoint> selectedDataPoints = new List<DataPoint>();

        //Recorder settings
        bool recordingStatus = false;
        bool playStatus = false;
        int sampleSize = 8;
        int sampleRate = 11025;

        //Default menustrip selection flags
        bool sampleSizeFlag8 = true, sampleSizeFlag16 = false;
        bool sampleRateFlag11025 = true, sampleRateFlag22050 = false, sampleRateFlag44100 = false;

        double startX = 0.0;
        double endX = 0;
        double fEndX = 0;

        bool channel1AnalyzeBtnEnabled = false;
        bool channel2AnalyzeBtnEnabled = false;

        Chart sentFilterReq, selectedChart;

        public WaveAnalyzer()
        {
            InitializeComponent();
            InitRecorder();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            modifyChart();
            displayDefault();
            channel = 1;
            chart3.Visible = false;
            chart4.Visible = false;
            chart4.Series[0].Color = Color.Red;
        }


        /// <summary>
        /// Creates Time-Domain Chart
        /// </summary>
        /// <param name="s">samples to plot</param>
        /// <param name="chart">the chart to plot in</param>
        private void CreateAmplitudeChart(double[] s, Chart chart)
        {
            chart.Series[0].Points.Clear();
            for (int t = 0; t < s.Length; t++)
            {
                chart.Series[0].Points.AddXY(t, s[t]);
            }
            //Set x axis
            setXAxisLabels(chart, s.Length);
            //Set the chart to be visible
            chart.Visible = true;

        }

        /// <summary>
        /// Converting x-axis units to seconds
        /// </summary>
        /// <param name="chart">the chart of time domain</param>
        /// <param name="size">size of sample</param>
        private void setXAxisLabels(Chart chart, int size)
        {
            chart.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart.ChartAreas[0].AxisX.StripLines.Clear();
            for (int i = 0; i < size; i += N)
            {
                CustomLabel customLabel = new CustomLabel
                {
                    Text = ((i / N) + 1).ToString(),
                    ToPosition = (i + N) * 2
                };
                chart.ChartAreas[0].AxisX.CustomLabels.Add(customLabel);

                StripLine stripLine = new StripLine
                {
                    IntervalOffset = i,
                    StripWidth = 0.1,
                    BackColor = System.Drawing.Color.LawnGreen
                };
                chart.ChartAreas[0].AxisX.StripLines.Add(stripLine);
            }
        }

        /// <summary>
        /// Prints out dummy data
        /// </summary>
        private void UpdateChart()
        {
            {
                N = 100;
                int f = 1;
                storedData = new double[1][];
                storedData[0] = calculateSamples(f, N);

                CreateAmplitudeChart(storedData[0], chart1);
                int width = chart1.Width;
                int height = chart1.Height;
                chart1.Size = new Size(width++, height++);
            }


        }

        /// <summary>
        /// Resets the Chart to Zeros
        /// </summary>
        private void displayDefault()
        {
            chart1.Series[0].Points.AddXY(0, 0);
            chart3.Series[0].Points.AddXY(0, 0);
            chart2.Series[0].Points.AddXY(0, 0);
            chart4.Series[0].Points.AddXY(0, 0);

            //Menustrip default selections
            this.sampleSize8bitBtn.Checked = sampleSizeFlag8;
            this.sampleSize16bitBtn.Checked = sampleSizeFlag16;
            this.sampleRate11025Btn.Checked = sampleRateFlag11025;
            this.sampleRate22050Btn.Checked = sampleRateFlag22050;
            this.sampleRate44100Btn.Checked = sampleRateFlag44100;
        }

        /// <summary>
        /// Calculates Dummy Data
        /// </summary>
        /// <param name="f">freq</param>
        /// <param name="N">Sampling Rate</param>
        /// <returns>the dummy data samples</returns>
        private double[] calculateSamples(int f, int N)
        {
            double[] s = new double[2 * N];
            for (int t = 0; t < 2 * N; t++)
            {
                s[t] =   Math.Cos(2 * Math.PI * (t) * f / N + Math.PI / 2);
                s[t] += Math.Sin(2 * Math.PI * (t) * 25 / N + Math.PI / 2);
            }
            return s;
        }

        /// <summary>
        /// Create a frequency Domain Chart
        /// </summary>
        /// <param name="s">Samples to convert to freq-domain</param>
        /// <param name="N">Sampling Rate</param>
        /// <param name="freqChart">Chart to plot on</param>
        private void CreateFreqChart(double[] s, int N, Chart freqChart)
        {
            freqChart.Series[0].Points.Clear();
            double[] A;

            //stopwatch to benchmark
            Stopwatch sw = new Stopwatch();

            //check if user wants threading or not
            if (!threading)
            {
                //threading not enabled
                sw.Start();
                A = DFT(s, N);
                sw.Stop();
            }
            else {
                //threading enabled
                sw.Start();
                A = DFTThreading(s, N);
                sw.Stop();
            }
            //display the timer for DFT
            this.timerDFT.Text = "DFT Timing: " + sw.ElapsedMilliseconds.ToString() + "ms";
            Series series = new Series("DFT");
            for (int i = 0; i < A.Length; i++)
            {
                freqChart.Series[0].Points.AddXY(i, A[i]); 

            }
            freqChart.Visible = true;

        }

        /// <summary>
        /// DFT Function
        /// </summary>
        /// <param name="s">samples to perform DFT on</param>
        /// <param name="N">sampling rate</param>
        /// <returns>Values after performing DFT on</returns>
        private double[] DFT(double[] s, int N)
        {

            Stopwatch timer = new Stopwatch();
            timer.Start();
            int n = s.Length < N ? s.Length : N;
            double[] A = new double[n];
            double real = 0;
            double imag = 0;

            for (int f = 0; f < n; f++)
            {
                real = 0; imag = 0;
                for (int t = 0; t < s.Length; t++)
                {
                    real += (s[t] * Math.Cos(2 * Math.PI * f * t * (N / n) / n));
                    imag += (-s[t] * Math.Sin(2 * Math.PI * f * t * (N / n) / n));
                }
                A[f] += Math.Sqrt((real*real) + (imag*imag)) / n;

            }
            timer.Stop();
            long elapsedTime = timer.ElapsedMilliseconds;
            
            return A;
        }
           
        /// <summary>
        /// Dummy Data Display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startbutton_click(object sender, EventArgs e)
        {
            ClearChart();
            UpdateChart();
            setStatusStrip();
        }

        /// <summary>
        /// Removes all data from the chart
        /// </summary>
        private void ClearChart()
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();

        }

        /// <summary>
        /// Makes chart Zoomable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void makeChartZoomable(object sender, MouseEventArgs e)
        {
            Chart chart = (Chart)sender;
            double xMin = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
            double xMax = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
            double mouseX = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X);
            double zoomFactor = 1.2; // Adjust the zoom factor as needed

            if (e.Delta < 0)
            {
                // Zoom out
                double newPosXStart = mouseX - (mouseX - xMin) * zoomFactor;
                double newPosXFinish = mouseX + (xMax - mouseX) * zoomFactor;
                chart.ChartAreas[0].AxisX.ScaleView.Zoom(newPosXStart, newPosXFinish);
            }
            else
            {
                // Zoom in
                double newPosXStart = mouseX - (mouseX - xMin) / zoomFactor;
                double newPosXFinish = mouseX + (xMax - mouseX) / zoomFactor;
                chart.ChartAreas[0].AxisX.ScaleView.Zoom(newPosXStart, newPosXFinish);
            }
        }


        /// <summary>
        /// Opens a new window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newWindowBtn_Click(object sender, EventArgs e)
        {
            WaveAnalyzer form1 = new WaveAnalyzer();
            form1.Show();
        }

        /// <summary>
        /// Function to read an wav file
        /// </summary>
        /// <param name="filename">file to read</param>
        private void readFile(string filename)
        {

            byte[] headerBytes = new byte[12];
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                fs.Read(headerBytes, 0, headerBytes.Length);
            }
            string waveFormat = Encoding.ASCII.GetString(headerBytes, 8, 4);
            if (waveFormat == "WAVE")
            {

                byte[] fileData = File.ReadAllBytes(filename);
                bitsPerSample = BitConverter.ToInt16(fileData, 34);
                N = BitConverter.ToInt16(fileData, 24);
                channel = BitConverter.ToInt16(fileData, 22);


                short[] audio16 = null;
                double[][] s = new double[2][];

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
                        chart4.Visible = false;
                    }

                }

                if (channel == 1)
                {
                    for (int i = 0; i < audio16.Length; i++)
                    {
                        s[0][i] = audio16[i] / MaxValue16Bit;
                        
                    }
                    CreateAmplitudeChart(s[0], chart1);


                } else if (channel == 2)
                {
                    for (int i = 0; i < audio16.Length / 2 + 1; i++)
                    {
                        s[0][i] /= MaxValue16Bit;
                        s[1][i] /= MaxValue16Bit;
                    }
                    CreateAmplitudeChart(s[0], chart1);
                    CreateAmplitudeChart(s[1], chart3);

                }
                storedData = s;
                setStatusStrip();
            }


        }

        /// <summary>
        /// Reads a stereo file
        /// </summary>
        /// <param name="audio16">the audio read from</param>
        /// <returns>demuxed stereo</returns>
        double[][] readstereo(short[] audio16)
        {
            int leftCounter = 0;
            int rightCounter = 0;
            int size = audio16.Length + 2;
            double[][] s = new double[2][];
            s[0] = new double[size / 2];
            s[1] = new double[size / 2];

            for (int i = 0; i < audio16.Length; i++)
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

        /// <summary>
        /// Convert 8 bit data to 16 bit
        /// </summary>
        /// <param name="data">data to convert</param>
        /// <returns>converted array</returns>
        short[] Convert8BitTo16Bit(byte[] data)
        {
            int max8BitValue = 255; // Maximum value for 8-bit audio
                                    // Maximum value for 16-bit audio

            int factor = (int)MaxValue16Bit / max8BitValue;


            short[] output = new short[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                short sample16Bit = (short)((data[i]-128) * 256);
                output[i] = sample16Bit;
            }
            return output;
        }

        /// <summary>
        /// Opens file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileBtn_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Function to write the headers of the file
        /// and the contents
        /// </summary>
        /// <param name="filePath">path of file to write in</param>
        /// <param name="audio">data to write</param>
        private void writeFile(string filePath, double[][] audio)
        {
            byte[] audioData;
            if (channel == 1)
            {
                if (bitsPerSample == 8)
                    audioData = ConvertDoubleArrayToByteArray8bit(audio[0]);
                else audioData = ConvertDoubleArrayToByteArray(audio[0]);
            } else
            {
                double[] samples = InterleaveStereoAudio(audio[0], audio[1]);
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

        /// <summary>
        /// Function to convert Double array to Byte array (8-bit)
        /// </summary>
        /// <param name="doubleSamples">array to convert</param>
        /// <returns>byte array</returns>
        static byte[] ConvertDoubleArrayToByteArray8bit(double[] doubleSamples)
        {
            // Create a byte array with enough capacity to store all the double values
            // Assuming 16-bit (2 bytes) per sample
            short[] shortSamples = new short[doubleSamples.Length];
            // Convert each double sample to a 16-bit signed integer and store it in the byte array
            for (int i = 0; i < doubleSamples.Length; i++)
            {
                shortSamples[i] = (short)(doubleSamples[i] * short.MaxValue);
            }

            byte[] byteArray = new byte[shortSamples.Length];
            for (int j = 0; j < shortSamples.Length; j++)
            {
                byte to8Bit = (byte)Math.Min(((shortSamples[j]) / 256 + 128), 255);
                byteArray[j] = to8Bit;

            }
            return byteArray;
        }

        /// <summary>
        /// Convert Double array to byte array (16-bit)
        /// </summary>
        /// <param name="doubleSamples">samples to convert</param>
        /// <returns>byte array</returns>
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

        /// <summary>
        /// Function to multiplex a stereo file
        /// </summary>
        /// <param name="leftChannel">channel to multiplex</param>
        /// <param name="rightChannel">channel to multiplex with</param>
        /// <returns>multiplexed values</returns>
        static double[] InterleaveStereoAudio(double[] leftChannel, double[] rightChannel)
        {
            int numSamples = Math.Max(leftChannel.Length, rightChannel.Length) / 2;
            double[] interleavedSamples = new double[numSamples * 2]; // Interleaved stereo data

            for (int i = 0; i < numSamples; i++)
            {
                //leftChannel
                if (leftChannel.Length - 1 >= i)
                {
                    interleavedSamples[i * 2] = leftChannel[i];
                } else
                {
                    interleavedSamples[i * 2] = 0;

                }

                // Right channel
                if (rightChannel.Length - 1 >= i)
                {
                    interleavedSamples[i * 2 + 1] = rightChannel[i];
                } else
                {
                    interleavedSamples[i * 2 + 1] = 0;
                }

            }

            return interleavedSamples;
        }

        private void saveFileBtn_Click(object sender, EventArgs e)
        {
            SaveFile();

        }
        /// <summary>
        /// Opens the dialog box
        /// </summary>
        private void SaveFile()
        {
            if (storedData != null && storedData.Length != 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Select a File";
                saveFileDialog.DefaultExt = ".wav";
                saveFileDialog.Filter = "Wav Files (*.wav)|*.wav|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    fileOpen = saveFileDialog.FileName;
                    writeFile(fileOpen, storedData);

                }
            } else
            {
                MessageBox.Show("No data stored", "Error");
            }
        }

        private void Chart_SelectionRangeChanging(object sender, CursorEventArgs e)
        {
            // Clear the previously selected data points
            if (selectedSamples == null) return;
            for (int i = 0; i < selectedSamples.Length; ++i)
            {
                selectedSamples[i] = 0;
            }
        }

        private void Chart_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            Chart chart = (Chart)sender;
            ChartArea chartArea = chart.ChartAreas["ChartArea1"];
            Series series = chart.Series[0];
            selectedChart = chart;

            // Determine the X-values of the selection range
            startX = chartArea.CursorX.SelectionStart;
            endX = chartArea.CursorX.SelectionEnd;

            List<DataPoint> selectedDataPoints = new List<DataPoint>();

            if (startX > endX)
            {
                double temp = startX;
                startX = endX;
                endX = temp;

            }

            // Iterate through data points to find selected points
            foreach (DataPoint point in series.Points)
            {
                if (point.XValue >= startX && point.XValue <= endX)
                {
                    selectedDataPoints.Add(point);
                }
            }
            
            selectedSamples = new double[selectedDataPoints.Count];
            int i = 0;
            foreach(DataPoint points in selectedDataPoints)
            {
                selectedSamples[i] = points.YValues[0];
                i++;
            }
            

            //Enable analyze buttons
            this.channel1AnalyzeBtn.Enabled = sender == chart1 && this.chart1.Series[0].Points.Count > 0 && this.selectedSamples.Length > 0;
            this.channel2AnalyzeBtn.Enabled = sender == chart3 && this.chart3.Series[0].Points.Count > 0 && this.selectedSamples.Length > 0;
        }

        private void channel1AnalyzeBtn_Click(object sender, EventArgs e)
        {
            chart2.Series[0].Points.Clear();
            double[] window;
            //If triangle Window active
            if (isTriangleWindow)
            {
                window = CreateTriangleWindow(selectedSamples.Length);
                
            }
            else if (isGaussianWindow)
            {
                //Gaussian Window active
                window = CreateGaussianWindow(selectedSamples.Length,10);
            }
            else if (isSineWindow)
            {
                //Sine window active
                window = CreateSineWindow(selectedSamples.Length);
            }
            else
            {
                //Default - Rectangle Window
                window = CreateRectangleWindow(selectedSamples.Length);
            }
            double[] windowedSamples = ApplyWindow(selectedSamples, window);
            CreateFreqChart(windowedSamples, N, chart2);

        }

        private void channel2AnalyzeBtn_Click(object sender, EventArgs e)
        {
            chart4.Series[0].Points.Clear();

            double[] window;
            if (isTriangleWindow)
            {
                window = CreateTriangleWindow(selectedSamples.Length);

            }
            else if (isGaussianWindow)
            {
                window = CreateGaussianWindow(selectedSamples.Length, 10);
            }
            else if (isSineWindow)
            {

                window = CreateSineWindow(selectedSamples.Length);
            }
            else
            {
                window = CreateRectangleWindow(selectedSamples.Length);
            }
            double[] windowedSamples = ApplyWindow(selectedSamples, window);
            CreateFreqChart(windowedSamples, N, chart4);

        }


        /*
         * Recorder
         */

        [DllImport("..\\..\\..\\Recorder_DLL\\recorder_dll.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool InitRecorder();
        [DllImport("..\\..\\..\\Recorder_DLL\\recorder_dll.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StartRec();
        [DllImport("..\\..\\..\\Recorder_DLL\\recorder_dll.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern RecordData StopRec();
        [DllImport("..\\..\\..\\Recorder_DLL\\recorder_dll.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PlayRec();
        [DllImport("..\\..\\..\\Recorder_DLL\\recorder_dll.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void PauseRec();
        [DllImport("..\\..\\..\\Recorder_DLL\\recorder_dll.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetData(RecordData data);
        [DllImport("..\\..\\..\\Recorder_DLL\\recorder_dll.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetRecorderSpecs(int sampleSize, int sampleRate, int channels);



        private void recordBtn_Click(object sender, EventArgs e)
        {
            if (recordingStatus)
            {
                RecordData record = StopRec();
                recordingStatus = false;
                recordBtn.Text = "Start";

                N = sampleRate;
                bitsPerSample = sampleSize;
                channel = 1;

                //Display sound wave
                ClearChart();
                unsafe
                {
                    if (record.data != IntPtr.Zero && record.dataLength != 0)
                    {
                        //Initialize variables
                        byte* buffer = (byte*)record.data;
                        byte[] byteData = new byte[record.dataLength];
                        short[] audio16 = new short[record.dataLength];
                        storedData = new double[2][];
                        storedData[0] = new double[record.dataLength];

                        //Get data in byte
                        for (int i = 0; i < record.dataLength; i++)
                        {
                            byteData[i] = (byte)buffer[i];
                        }

                        //Convert data to 16-bit
                        if (sampleSize == 8)
                        {
                            audio16 = Convert8BitTo16Bit(byteData);
                        } else if (sampleSize == 16)
                        {
                            storedData[0] = new double[byteData.Length / 2];
                            audio16 = new short[byteData.Length / 2];
                            Buffer.BlockCopy(byteData, 0, audio16, 0, byteData.Length);
                        }

                        //Plot the graph
                        for (int i = 0; i < audio16.Length; i++)
                        {
                            storedData[0][i] = audio16[i] / MaxValue16Bit;
                        }
                        CreateAmplitudeChart(storedData[0], chart1);
                    }

                }
                setStatusStrip();
            }
            else
            {
                SetRecorderSpecs(sampleSize, sampleRate, 1);
                StartRec();
                recordingStatus = true;
                recordBtn.Text = "Stop";
            }
        }

        unsafe private void setPlayData(short[] samples)
        {
            RecordData recordData = new RecordData();
            byte[] b = samples.SelectMany(x => BitConverter.GetBytes(x)).ToArray();
            IntPtr iptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(byte)) * b.Length);
            Marshal.Copy(b, 0, iptr, b.Length);
            recordData.data = iptr;
            recordData.dataLength = (uint)b.Length;
            SetData(recordData);
        }

        private short[] convertStoredDataToShort()
        {
            if (channel == 1)
            {
                short[] shortSamples = new short[storedData[0].Length];
                for (int i = 0; i < storedData[0].Length; i++)
                {
                    shortSamples[i] = (short)(storedData[0][i] * MaxValue16Bit);
                }
                return shortSamples;
            }
            else
            {
                int size = 2 * storedData[0].Length - 2;
                short[] shortSamples = new short[size];
                for (int i = 0; i < storedData[0].Length; i += 2)
                {
                    shortSamples[i] = (short)(storedData[0][i] * MaxValue16Bit);
                    shortSamples[i + 1] = (short)(storedData[1][i] * MaxValue16Bit);
                }
                return shortSamples;
            }
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            setPlayData(convertStoredDataToShort());
            SetRecorderSpecs(16, N, channel);
            PlayRec();
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            PauseRec();
        }

        private void SetSampleSize(object sender, EventArgs e)
        {

            if (sender.Equals(sampleSize8bitBtn))
            {
                sampleSizeFlag8 = true;
                sampleSizeFlag16 = false;
                sampleSize = 8;
            }
            else if (sender.Equals(sampleSize16bitBtn))
            {
                sampleSizeFlag8 = false;
                sampleSizeFlag16 = true;
                sampleSize = 16;
            }
            this.sampleSize8bitBtn.Checked = sampleSizeFlag8;
            this.sampleSize16bitBtn.Checked = sampleSizeFlag16;
        }

        private void SetSampleRate(object sender, EventArgs e)
        {
            if (sender.Equals(sampleRate11025Btn))
            {
                sampleRateFlag11025 = true;
                sampleRateFlag22050 = false;
                sampleRateFlag44100 = false;
                sampleRate = 11025;
            }
            else if (sender.Equals(sampleRate22050Btn))
            {
                sampleRateFlag11025 = false;
                sampleRateFlag22050 = true;
                sampleRateFlag44100 = false;
                sampleRate = 22050;
            }
            else if (sender.Equals(sampleRate44100Btn))
            {
                sampleRateFlag11025 = false;
                sampleRateFlag22050 = false;
                sampleRateFlag44100 = true;
                sampleRate = 44100;
            }
            this.sampleRate11025Btn.Checked = sampleRateFlag11025;
            this.sampleRate22050Btn.Checked = sampleRateFlag22050;
            this.sampleRate44100Btn.Checked = sampleRateFlag44100;
        }

        /// <summary>
        /// This function updates the values of the Status
        /// strip.(Present at the bottom of the window)
        /// </summary>
        private void setStatusStrip()
        {
            this.statusStripSampleRateLabel.Text = "Sample Rate: " + N.ToString() + "Hz";
            this.statusStripSampleSizeLabel.Text = "Sample Size: " + bitsPerSample.ToString() + "-bit";
            this.statusStripChannels.Text = "Channels: " + channel.ToString();
        }

        /*
         * End of recorder
         */


        private void pasteToChart1_Click(object sender, EventArgs e)
        {
            if (storedData == null) storedData = new double[2][];
            storedData[0] = pasteToChart(chart1);
        }

        /// <summary>
        /// This function handles the pasting 
        /// selected samples to a chart
        /// </summary>
        /// <param name="chart">chart to paste too</param>
        /// <returns>new samples</returns>
        private double[] pasteToChart(Chart chart)
        {
            string doubleArrayAsString = Clipboard.GetText();
            string[] stringValues = doubleArrayAsString.Split(',');
            double[] samplesPlusSampleRate = Array.ConvertAll(stringValues, double.Parse);

            //Extract origin sample rate from the clipboard
            double[] originSamples = new double[samplesPlusSampleRate.Length - 1];
            Array.Copy(samplesPlusSampleRate, originSamples, originSamples.Length);
            int originSampleRate = (int)samplesPlusSampleRate[samplesPlusSampleRate.Length - 1];

            //Check if up/down sampling needed
            double[] s = checkSampleRate(originSamples, originSampleRate);

            double[] samples = new double[s.Length + chart.Series[0].Points.Count - selectedSamples.Length];
            double lastXvalue = chart.Series[0].Points.Count - 1;
            int counter = 0;

            Series chartsamples = chart.Series[0];
            int pointsRemoved = (int)(endX - startX);
            double[] newSamples = new double[chartsamples.Points.Count - pointsRemoved + 1];

            //remove the other samples
            if(chartsamples.Points.Count == 1)
            {
                CreateAmplitudeChart(s, chart);
                return samples;
            }
            int cutCounter = 0;
            for (int t = 0; t < chartsamples.Points.Count; ++t)
            {
                if (t > startX && t < endX)
                {
                    cutCounter++;
                    continue;
                }

                newSamples[t - cutCounter] = chartsamples.Points[t].YValues[0];
            }

            for (int t = 0; t < samples.Length; t++)
            {
                if (t == startX)
                {
                    for (int i = 0; i < s.Length; ++i, ++t)
                    {
                        samples[t] = s[i];
                    }
                }
                samples[t] = newSamples[counter];
                counter++;
            }
            CreateAmplitudeChart(samples, chart);
            return samples;
        }

        //Copys the points from the charts
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedSamples == null) {
                MessageBox.Show("Nothing Selected", "Error");

                return;
            }
            string doubleArrayAsString = string.Join(",", selectedSamples);

            //Attach sample rate to the end of the string
            doubleArrayAsString = doubleArrayAsString + "," + N.ToString();

            Clipboard.SetText(doubleArrayAsString);
        }

        private void pasteToChart2_Click_1(object sender, EventArgs e)
        {
            if (storedData == null) storedData = new double[2][];
            storedData[1] = pasteToChart(chart3);
        }



        private void cutchart1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            storedData[0] = cut(chart1);
        }

        /// <summary>
        /// This function handles the cut i.e.
        /// removal of selected points from the array
        /// </summary>
        /// <param name="chart">the chart to cut from</param>
        /// <returns>new Samples without the selectedsamples</returns>
        private double[] cut(Chart chart)
        {
            if (selectedSamples == null)
            {
                MessageBox.Show("Nothing Selected", "Error");

                return null;
            }

            string doubleArrayAsString = string.Join(",", selectedSamples);

            //Attach sample rate to the end of the string
            doubleArrayAsString = doubleArrayAsString + "," + N.ToString();

            Series samples = chart.Series[0];
            int pointsRemoved = (int)(endX - startX);
            double[] newSamples = new double[samples.Points.Count - pointsRemoved];
            int counter = 0;
            for (int t = 0; t < samples.Points.Count; ++t)
            {
                if (t >= startX && t <= endX)
                {
                    counter++;
                    continue;
                }

                newSamples[t - counter] = samples.Points[t].YValues[0];
            }


            CreateAmplitudeChart(newSamples, chart);

            Clipboard.SetText(doubleArrayAsString);
            return newSamples;
        }

        /// <summary>
        /// Check if the samples need to be resampled to the sample rate of the target signla
        /// </summary>
        /// <param name="originSamples"></param>
        /// <param name="originSampleRate"></param>
        /// <returns></returns>
        private double[] checkSampleRate(double[] originSamples, int originSampleRate)
        {
            if (N == 0) {
                N = originSampleRate;
                return originSamples; 
            }
            if (originSampleRate > N)
            {
                //Down sampling
                return downSampleSignal(originSamples, originSampleRate, N);
            } else if (originSampleRate < N)
            {
                //Up sampling
                return upSampleSignal(originSamples, originSampleRate, N);
            } else
            {
                return originSamples;
            }
        }

        /// <summary>
        /// Up sample the signal by inserting zeroes
        /// </summary>
        /// <param name="signal"></param>
        /// <param name="originalSampleRate"></param>
        /// <param name="targetSampleRate"></param>
        /// <returns></returns>
        private double[] upSampleSignal(double[] signal, int originalSampleRate, int targetSampleRate)
        {
            //Upsample by inserting zero-valued samples
            int upsampleFactor = targetSampleRate / originalSampleRate;
            double[] upsampledSignal = new double[signal.Length * upsampleFactor];

            for (int i = 0; i < signal.Length; i++)
            {
                upsampledSignal[i * upsampleFactor] = signal[i];
            }

            return upsampledSignal;
        }

        /// <summary>
        /// Down sample the signal by discard every other sample
        /// </summary>
        /// <param name="signal"></param>
        /// <param name="originalSampleRate"></param>
        /// <param name="targetSampleRate"></param>
        /// <returns></returns>
        private double[] downSampleSignal(double[] signal, int originalSampleRate, int targetSampleRate)
        {
            //Discard every other sample
            int decimationFactor = originalSampleRate / targetSampleRate;
            double[] downsampledSignal = new double[signal.Length / decimationFactor];

            for (int i = 0; i < downsampledSignal.Length; i++)
            {
                downsampledSignal[i] = signal[i * decimationFactor];
            }

            return downsampledSignal;
        }

        private void cutchart2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            storedData[1] = cut(chart3);
        }

        private void rightClickonChart1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //  
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// When user wants to filter from frequency chart
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">event arguements</param>
        private void filter_Click(object sender, EventArgs e)
        {
            if (fEndX == 0)
            {
                MessageBox.Show("Nothing Selected", "Error");
                return;
            }

            double[] filter = createFilter(fEndX, chart2.Series[0].Points.Count);
            double[] filterInTimeDomain = InvDFT(filter, N);

            storedData[0] = convolution(storedData[0], filterInTimeDomain);
            if (channel == 2)
                storedData[1] = convolution(storedData[1], filterInTimeDomain);

            for (int i = 0; i < selectedSamples.Length; ++i)
            {
                selectedSamples[i] = storedData[0][i + (int)startX];
            }
            CreateAmplitudeChart(storedData[0], chart1);
            if(channel == 2)
            CreateAmplitudeChart(storedData[1], chart3);
            if (sentFilterReq == chart2)
            {
                CreateFreqChart(selectedSamples, N, chart2);
            }
            else
            {
                CreateFreqChart(selectedSamples, N, chart4);
            }

        }

        private void FreqChart_SelectionRangeChanging(object sender, CursorEventArgs e)
        {
            // Clear the previously selected data points
            fEndX = 0;
        }

        // Handles Selection
        private void FreqChart_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            Chart chart = (Chart)sender;
            sentFilterReq = chart;
            ChartArea chartArea = chart.ChartAreas["ChartArea1"];
            Series series = chart.Series[0];

            // Determine the X-values of the selection range
            double fStartX = chartArea.CursorX.SelectionStart;
            fEndX = chartArea.CursorX.SelectionEnd;



            if (fStartX > fEndX)
            {
                double temp = fStartX;
                fStartX = fEndX;
                fEndX = temp;

            }


        }

        /// <summary>
        /// Functionn to create the filter
        /// from the selected samples
        /// </summary>
        /// <param name="fbin">Highest Frequency bin to build lowpass filter upto</param>
        /// <param name="sizeOfFilter">how big the filter should be</param>
        /// <returns>newly created filter</returns>
        private double[] createFilter(double fbin, int sizeOfFilter)
        {
            double[] filter = new double[sizeOfFilter];
            for (int i = 0; i < sizeOfFilter; ++i)
            {
                if (i <= fbin || i > (sizeOfFilter - fbin))
                    filter[i] = 1;
                else filter[i] = 0;
            }
            return filter;
        }

        private void WindowOnToggle_Click(object sender, EventArgs e)
        {
            if (!isTriangleWindow)
            {
                isGaussianWindow = false;
                isSineWindow = false;
                this.WindowOnToggle.Text = "Off";
                this.GaussianToolStrip.Text = "On";
                this.sinWaveOn.Text = "On";
                isTriangleWindow = true;
                this.windowingStatus.Text = "Windowing:Triangle";
            }
            else
            {
                this.WindowOnToggle.Text = "On";
                isTriangleWindow = false;
                this.windowingStatus.Text = "Windowing: OFF";
            }

        }


        private void threadingToggle_Click(object sender, EventArgs e)
        {
            if (!threading)
            {
                this.threadingToggle.Text = "Threading: ON";
                threading = true;

            } else
            {
                this.threadingToggle.Text = "Threading: OFF";
                threading = false;
            }
        }

        /// <summary>
        /// Inverse DFT for filter
        /// Only need the real part
        /// </summary>
        /// <param name="A">Array to pass through InverseDFT</param>
        /// <param name="N">Sampling Rate</param>
        /// <returns></returns>
        private double[] InvDFT(double[] A, int N)
        {

            double real;
            double imag;
            int n = A.Length;
            double[] s = new double[n];

            for (int t = 0; t < n; t++)
            {
                real = 0;
                for (int f = 0; f < n; f++)
                {
                    real += (A[f] * Math.Cos(2 * Math.PI * t * f * (N / n) / N)) / N;
                }
                s[t] = real;
            }
            return s;
        }

        /// <summary>
        /// Performs convolution on the samples
        /// </summary>
        /// <param name="s">samples </param>
        /// <param name="filter">filter that has been passed through Inverse DFT</param>
        /// <returns>cnvolved samples</returns>
        private double[] convolution(double[] s, double[] filter)
        {
            double[] newSamples = new double[s.Length];
            for (int t = 0; t < s.Length; t++)
            {
                newSamples[t] = 0;
                for (int i = 0; i < filter.Length; i++)
                {

                    if (t + i < s.Length)
                    {
                        newSamples[t] += (s[t + i] * filter[i]);
                    }
                    else
                    {
                        int circularIndex = (t + i) - s.Length;
                        newSamples[t] += s[circularIndex] * filter[i];

                    }

                }
            }
            return newSamples;
        }

        /// <summary>
        /// Applys Triangle Windowing 
        /// </summary>
        /// <param name="samples">samples to apply windowing too</param>
        /// <returns>windowed samples</returns>
        static double[] CreateTriangleWindow(int size)
        {
            int N = size;
            double[] windowed = new double[N];

            for (int n = 0; n < N; n++)
            {
                windowed[n] =(1.0 - Math.Abs((n - (N / 2.0)) / (N / 2.0)));
            }

            return windowed;
        }

        /// <summary>
        /// Function to call if threading is enabled
        /// </summary>
        /// <param name="s">samples</param>
        /// <param name="N">sampling Rate</param>
        /// <returns>double array A which contains values of Amplitude of each Frequency Bin</returns>
        private double[] DFTThreading(double[] s, int N)
        {

            int numThreads = 4;
            
            Thread[] threads = new Thread[numThreads];
            double[][] chunks = new double[numThreads][];

            Mutex mutex = new Mutex();

            for (int i = 0; i < numThreads; ++i)
            {
                int curIndx = i;
                int chunkSize = i == numThreads - 1 ? s.Length - (s.Length / numThreads * curIndx) : s.Length / numThreads;
                //creates the chunks
                chunkSize = chunkSize < N / numThreads ? chunkSize : N / numThreads;
                if (i == (numThreads - 1))
                {
                    if (s.Length < N)
                    {
                        chunkSize = s.Length - chunkSize * (numThreads - 1);
                    }
                    else
                    {
                        chunkSize = N - chunkSize * (numThreads - 1);
                    }
                }
                chunks[i] = new double[chunkSize];

                threads[i] = new Thread(() =>
                {
                    double[] result = DFTforThreads(s, N, chunkSize, curIndx);

                    // Use mutex to safely update the chunks array
                    mutex.WaitOne();
                    try
                    {
                        Array.Copy(result, 0, chunks[curIndx], 0, result.Length);
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                    }
                });
                threads[i].Name = i.ToString();
            }

            foreach (Thread thread in threads) thread.Start();
            foreach (Thread thread in threads) thread.Join();

            int totalLength = chunks.Sum(chunk => chunk.Length);
            double[] A = new double[totalLength];
            int currentIndex = 0;
            for (int i = 0; i < numThreads; i++)
            {
                Array.Copy(chunks[i], 0, A, currentIndex, chunks[i].Length);
                currentIndex += chunks[i].Length;
            }

            return A;
        }

        /// <summary>
        /// Gaussian Window Toggle Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isGaussianWindow)
            {
                isTriangleWindow = false;
                isSineWindow = false;
                this.WindowOnToggle.Text = "On";
                this.GaussianToolStrip.Text = "Off";
                this.sinWaveOn.Text = "On";
                isGaussianWindow = true;
                this.windowingStatus.Text = "Windowing:Gaussian";
            }
            else
            {
                this.GaussianToolStrip.Text = "On";
                isTriangleWindow = false;
                this.windowingStatus.Text = "Windowing: Rectangle";
            }

        }

        /// <summary>
        /// Sine Window Toggle Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isSineWindow)
            {
                isTriangleWindow = false;
                isGaussianWindow = false;
                this.sinWaveOn.Text = "Off";
                this.GaussianToolStrip.Text = "On";
                this.WindowOnToggle.Text = "On";
                isSineWindow = true;
                this.windowingStatus.Text = "Windowing: Sine";
            }
            else
            {
                this.sinWaveOn.Text = "On";
                isSineWindow = false;
                this.windowingStatus.Text = "Windowing: Rectangle";
            }
        }

        /// <summary>
        /// Thread Proc for DFT
        /// </summary>
        /// <param name="s"> samples </param>
        /// <param name="N">Sampling Rate</param>
        /// <param name="chunkSize">Size of the array to return as well frequencies to calculate up to</param>
        /// <param name="chunkIndex">The starting index from where to start calculating values for frequencies</param>
        /// <returns></returns>
        private double[] DFTforThreads(double[] s, int N, int chunkSize, int chunkIndex)
        {
            double real;
            double imag;
            int n = s.Length < N ? s.Length : N;
            double[] A = new double[chunkSize];


            for (int f = 0; f < chunkSize; f++)
            {
                real = 0;
                imag = 0;
                for (int t = 0; t < s.Length; t++)
                {
                    int newF = f + (chunkSize * chunkIndex);
                    real += (s[t] * Math.Cos(2 * Math.PI * t * newF * (N / n) / n)) / s.Length;
                    imag += (-s[t] * Math.Sin(2 * Math.PI * t * newF * (N / n) / n)) / s.Length;

                }
                A[f] = 0;
                A[f] = Math.Sqrt((real * real) + (imag * imag));
            }
            return A;
        }

        /// <summary>
        /// Shortcuts from Keyboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (e.Handled) return;
                SaveFile();
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.X)
            {
                if (e.Handled) return;
                if (selectedChart == chart1)
                {
                    
                    cutchart1ToolStripMenuItem_Click(null, null);
                    e.Handled = true;
                    return;
                }
                else
                {

                    cutchart2ToolStripMenuItem_Click(null, null);
                    e.Handled = true;
                    return;
                }

            }

            if (e.Control && e.KeyCode == Keys.C) {
                if (e.Handled) return;
                copyToolStripMenuItem_Click(null, null);
                e.Handled = true;
                return;
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                if (e.Handled) return;
                if (selectedChart == chart1)
                {
                    pasteToChart1_Click(null, null);
                    e.Handled = true;

                }
                if (selectedChart == chart3)
                {
                    pasteToChart2_Click_1(null, null);
                    e.Handled = true;
                }
                

            }

            // Prevent further processing of the Ctrl+S key combination
            e.Handled = true;
        
        }

        /// <summary>
        /// Create the Gaussian Window
        /// </summary>
        /// <param name="size">size of the window</param>
        /// <param name="sigma">sigma val</param>
        /// <returns></returns>
        static double[] CreateGaussianWindow(int size, double sigma)
        {
            double[] window = new double[size];
            double sum = 0.0;

            int halfSize = size / 2;
            for (int i = -halfSize; i < halfSize; i++)
            {
                double x = i / sigma;
                double value = Math.Exp(-0.5 * (x * x));
                window[i + halfSize] = value;
                sum += value;
            }

            // Normalize the window to make sure the sum is 1
            for (int i = 0; i < size; i++)
            {
                window[i] /= sum;
            }

            return window;
        }

        /// <summary>
        /// Create The sine Window
        /// </summary>
        /// <param name="size">size of the window</param>
        /// <returns></returns>
        static double[] CreateSineWindow(int size)
        {
            double[] window = new double[size];

            for (int i = 0; i < size; i++)
            {
                window[i] = Math.Sin(Math.PI * i / (size - 1));
            }

            return window;
        }

        /// <summary>
        /// Create the default Window
        /// </summary>
        /// <param name="size">size of the window</param>
        /// <returns></returns>
        static double[] CreateRectangleWindow(int size)
        {
            double[] window = new double[size];
            for (int i = 0; i < size; i++)
            {
                window[i] = 1;
            }
            return window;
        }
        
        /// <summary>
        /// Converts the samples using the right window
        /// </summary>
        /// <param name="samples">samples to convert</param>
        /// <param name="window">Window to apply it to</param>
        /// <returns>windowed samples</returns>
        static double[] ApplyWindow(double[]samples,  double[] window)
        {
            
            int length = Math.Min(samples.Length, window.Length);
            double[] result = new double[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = samples[i] * window[i];
            }

            return result;
        }


    }
}
