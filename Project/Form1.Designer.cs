using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project
{
    partial class WaveAnalyzer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Start = new System.Windows.Forms.Button();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.waveAnalyzerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.exitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleSizeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleSize8bitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleSize16bitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleRateMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleRate11025Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleRate22050Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleRate44100Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.channel1AnalyzeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.channel2AnalyzeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToChart1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToChart2 = new System.Windows.Forms.ToolStripMenuItem();
            this.recordBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusStripSampleSizeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripSampleRateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripChannels = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(4, 5);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1560, 317);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(4, 5);
            this.chart2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series2.ChartArea = "ChartArea1";
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Sound Wave";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(773, 311);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            this.chart3.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(4, 656);
            this.chart3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.chart3.Name = "chart3";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart3.Series.Add(series3);
            this.chart3.Size = new System.Drawing.Size(1560, 325);
            this.chart3.TabIndex = 3;
            this.chart3.Text = "chart3";
            // 
            // Start
            // 
            this.Start.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Start.Location = new System.Drawing.Point(4, 2);
            this.Start.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(160, 40);
            this.Start.TabIndex = 4;
            this.Start.Text = "Start";
            this.Start.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.startbutton_click);
            // 
            // chart4
            // 
            chartArea4.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea4);
            this.chart4.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chart4.Legends.Add(legend4);
            this.chart4.Location = new System.Drawing.Point(785, 5);
            this.chart4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart4.Name = "chart4";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart4.Series.Add(series4);
            this.chart4.Size = new System.Drawing.Size(773, 311);
            this.chart4.TabIndex = 7;
            this.chart4.Text = "chart4";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.waveAnalyzerToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.recordToolStripMenuItem,
            this.analyseToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1574, 40);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // waveAnalyzerToolStripMenuItem
            // 
            this.waveAnalyzerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowBtn,
            this.exitBtn});
            this.waveAnalyzerToolStripMenuItem.Name = "waveAnalyzerToolStripMenuItem";
            this.waveAnalyzerToolStripMenuItem.Size = new System.Drawing.Size(183, 36);
            this.waveAnalyzerToolStripMenuItem.Text = "WaveAnalyzer";
            // 
            // newWindowBtn
            // 
            this.newWindowBtn.Name = "newWindowBtn";
            this.newWindowBtn.Size = new System.Drawing.Size(289, 44);
            this.newWindowBtn.Text = "New Window";
            this.newWindowBtn.Click += new System.EventHandler(this.newWindowBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(289, 44);
            this.exitBtn.Text = "Exit";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileBtn,
            this.saveFileBtn});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(71, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileBtn
            // 
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(206, 44);
            this.openFileBtn.Text = "Open";
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // saveFileBtn
            // 
            this.saveFileBtn.Name = "saveFileBtn";
            this.saveFileBtn.Size = new System.Drawing.Size(206, 44);
            this.saveFileBtn.Text = "Save";
            this.saveFileBtn.Click += new System.EventHandler(this.saveFileBtn_Click);
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sampleSizeMenu,
            this.sampleRateMenu});
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(128, 36);
            this.recordToolStripMenuItem.Text = "Recorder";
            // 
            // sampleSizeMenu
            // 
            this.sampleSizeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sampleSize8bitBtn,
            this.sampleSize16bitBtn});
            this.sampleSizeMenu.Name = "sampleSizeMenu";
            this.sampleSizeMenu.Size = new System.Drawing.Size(280, 44);
            this.sampleSizeMenu.Text = "Sample Size";
            // 
            // sampleSize8bitBtn
            // 
            this.sampleSize8bitBtn.Name = "sampleSize8bitBtn";
            this.sampleSize8bitBtn.Size = new System.Drawing.Size(211, 44);
            this.sampleSize8bitBtn.Text = "8-bit";
            this.sampleSize8bitBtn.Click += new System.EventHandler(this.SetSampleSize);
            // 
            // sampleSize16bitBtn
            // 
            this.sampleSize16bitBtn.Name = "sampleSize16bitBtn";
            this.sampleSize16bitBtn.Size = new System.Drawing.Size(211, 44);
            this.sampleSize16bitBtn.Text = "16-bit";
            this.sampleSize16bitBtn.Click += new System.EventHandler(this.SetSampleSize);
            // 
            // sampleRateMenu
            // 
            this.sampleRateMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sampleRate11025Btn,
            this.sampleRate22050Btn,
            this.sampleRate44100Btn});
            this.sampleRateMenu.Name = "sampleRateMenu";
            this.sampleRateMenu.Size = new System.Drawing.Size(280, 44);
            this.sampleRateMenu.Text = "Sample Rate";
            // 
            // sampleRate11025Btn
            // 
            this.sampleRate11025Btn.CheckOnClick = true;
            this.sampleRate11025Btn.Name = "sampleRate11025Btn";
            this.sampleRate11025Btn.Size = new System.Drawing.Size(254, 44);
            this.sampleRate11025Btn.Text = "11025KHz";
            this.sampleRate11025Btn.Click += new System.EventHandler(this.SetSampleRate);
            // 
            // sampleRate22050Btn
            // 
            this.sampleRate22050Btn.CheckOnClick = true;
            this.sampleRate22050Btn.Name = "sampleRate22050Btn";
            this.sampleRate22050Btn.Size = new System.Drawing.Size(254, 44);
            this.sampleRate22050Btn.Text = "22050KHz";
            this.sampleRate22050Btn.Click += new System.EventHandler(this.SetSampleRate);
            // 
            // sampleRate44100Btn
            // 
            this.sampleRate44100Btn.CheckOnClick = true;
            this.sampleRate44100Btn.Name = "sampleRate44100Btn";
            this.sampleRate44100Btn.Size = new System.Drawing.Size(254, 44);
            this.sampleRate44100Btn.Text = "44100KHz";
            this.sampleRate44100Btn.Click += new System.EventHandler(this.SetSampleRate);
            // 
            // analyseToolStripMenuItem
            // 
            this.analyseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analyseToolStripMenuItem1});
            this.analyseToolStripMenuItem.Name = "analyseToolStripMenuItem";
            this.analyseToolStripMenuItem.Size = new System.Drawing.Size(116, 36);
            this.analyseToolStripMenuItem.Text = "Analyse";
            // 
            // analyseToolStripMenuItem1
            // 
            this.analyseToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channel1AnalyzeBtn,
            this.channel2AnalyzeBtn});
            this.analyseToolStripMenuItem1.Name = "analyseToolStripMenuItem1";
            this.analyseToolStripMenuItem1.Size = new System.Drawing.Size(189, 44);
            this.analyseToolStripMenuItem1.Text = "DFT";
            // 
            // channel1AnalyzeBtn
            // 
            this.channel1AnalyzeBtn.Enabled = false;
            this.channel1AnalyzeBtn.Name = "channel1AnalyzeBtn";
            this.channel1AnalyzeBtn.Size = new System.Drawing.Size(255, 44);
            this.channel1AnalyzeBtn.Text = "Channel 1";
            this.channel1AnalyzeBtn.Click += new System.EventHandler(this.channel1AnalyzeBtn_Click);
            // 
            // channel2AnalyzeBtn
            // 
            this.channel2AnalyzeBtn.Enabled = false;
            this.channel2AnalyzeBtn.Name = "channel2AnalyzeBtn";
            this.channel2AnalyzeBtn.Size = new System.Drawing.Size(255, 44);
            this.channel2AnalyzeBtn.Text = "Channel 2";
            this.channel2AnalyzeBtn.Click += new System.EventHandler(this.channel2AnalyzeBtn_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(89, 36);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToChart1,
            this.pasteToChart2});
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(89, 36);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // pasteToChart1
            // 
            this.pasteToChart1.Name = "pasteToChart1";
            this.pasteToChart1.Size = new System.Drawing.Size(224, 44);
            this.pasteToChart1.Text = "Chart 1";
            this.pasteToChart1.Click += new System.EventHandler(this.pasteToChart1_Click);
            // 
            // pasteToChart2
            // 
            this.pasteToChart2.Name = "pasteToChart2";
            this.pasteToChart2.Size = new System.Drawing.Size(224, 44);
            this.pasteToChart2.Text = "Chart 2";
            // 
            // recordBtn
            // 
            this.recordBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.recordBtn.Location = new System.Drawing.Point(171, 3);
            this.recordBtn.Name = "recordBtn";
            this.recordBtn.Size = new System.Drawing.Size(160, 40);
            this.recordBtn.TabIndex = 5;
            this.recordBtn.Text = "Record";
            this.recordBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.recordBtn.UseVisualStyleBackColor = true;
            this.recordBtn.Click += new System.EventHandler(this.recordBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.playBtn.Location = new System.Drawing.Point(337, 3);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(160, 40);
            this.playBtn.TabIndex = 6;
            this.playBtn.Text = "Play";
            this.playBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Location = new System.Drawing.Point(503, 3);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(160, 40);
            this.pauseBtn.TabIndex = 7;
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Start);
            this.flowLayoutPanel1.Controls.Add(this.recordBtn);
            this.flowLayoutPanel1.Controls.Add(this.playBtn);
            this.flowLayoutPanel1.Controls.Add(this.pauseBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1568, 44);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripSampleSizeLabel,
            this.statusStripSampleRateLabel,
            this.statusStripChannels});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1039);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(1574, 50);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusStripSampleSizeLabel
            // 
            this.statusStripSampleSizeLabel.Name = "statusStripSampleSizeLabel";
            this.statusStripSampleSizeLabel.Size = new System.Drawing.Size(206, 40);
            this.statusStripSampleSizeLabel.Text = "Sample Size: 0-bit";
            // 
            // statusStripSampleRateLabel
            // 
            this.statusStripSampleRateLabel.Name = "statusStripSampleRateLabel";
            this.statusStripSampleRateLabel.Size = new System.Drawing.Size(200, 40);
            this.statusStripSampleRateLabel.Text = "Sample Rate: 0Hz";
            // 
            // statusStripChannels
            // 
            this.statusStripChannels.Name = "statusStripChannels";
            this.statusStripChannels.Size = new System.Drawing.Size(137, 40);
            this.statusStripChannels.Text = "Channels: 0";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1574, 1089);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.chart1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.chart3, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 53);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1568, 983);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.chart4, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.chart2, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 330);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1562, 321);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // WaveAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1574, 1129);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1600, 1200);
            this.Name = "WaveAnalyzer";
            this.Text = "WaveAnalyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void defineChartInfo(Chart chart, int flag)
        {
            var chartArea1 = chart.ChartAreas[0];
            if (flag == 1)
            {
                int position = 0;
                int size = 10;
                
                var series = chart.Series[0];
                chartArea1.AxisX.Title = "time";
                chartArea1.AxisY.Title = "Amplitude";
                series.BorderWidth = 3;
                series.Color = Color.Yellow;
                chartArea1.BackColor = Color.Black;
                chartArea1.AxisX.MajorGrid.LineColor = Color.LawnGreen;
                chartArea1.AxisX2.MajorGrid.LineColor = Color.LawnGreen;
                chartArea1.AxisX.LineWidth = 2;
                chartArea1.AxisY.MajorGrid.LineColor = Color.LawnGreen;
                chartArea1.AxisY2.MajorGrid.LineColor = Color.LawnGreen;  

                chartArea1.AxisX.Minimum = 0;
                chartArea1.CursorX.AutoScroll = true;
                chartArea1.CursorY.AutoScroll = true; 


                chartArea1.AxisX.ScaleView.Zoomable = false;
                chartArea1.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;

                chartArea1.AxisY.ScaleView.Zoomable = false;
                chartArea1.AxisY.ScaleView.SizeType = DateTimeIntervalType.Number;

                /*chartArea1.AxisX.ScaleView.Zoom(position, size);*/
                /*chartArea1.AxisY.ScaleView.Zoom(-5, 5);*/

                chartArea1.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
                chartArea1.AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

                chartArea1.AxisX.ScaleView.SmallScrollSize = 10;
                chartArea1.AxisX.ScrollBar.ButtonColor = Color.WhiteSmoke;
                chartArea1.AxisX.ScrollBar.LineColor = Color.White;
                chartArea1.AxisX.ScrollBar.IsPositionedInside = true;
                chartArea1.CursorX.AutoScroll = true;
                chartArea1.CursorX.IsUserSelectionEnabled = true;
                chartArea1.AxisX.LabelStyle.Format = "0";

                chartArea1.AxisY.ScaleView.SmallScrollSize = 1;
                chartArea1.AxisY.ScrollBar.ButtonColor = Color.WhiteSmoke;
                chartArea1.AxisY.ScrollBar.LineColor = Color.White;
                chartArea1.AxisY.ScrollBar.IsPositionedInside = true;
                chartArea1.CursorX.AutoScroll = true;
                chartArea1.CursorX.IsUserSelectionEnabled = true;
                chartArea1.AxisY.LabelStyle.Format = "0.00";
                chart.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.makeChartZoomable);
                chart.SelectionRangeChanging += Chart_SelectionRangeChanging;
                chart.SelectionRangeChanged += Chart_SelectionRangeChanged;


            }
            else
            {
                chartArea1.AxisX.Title = "frequency";
                chartArea1.AxisY.Title = "Amplitude";
                chartArea1.AxisX.Minimum = 0;
                chartArea1.AxisX.ScaleView.Zoomable = false;
                chartArea1.AxisY.ScaleView.Zoomable = false;
                chartArea1.CursorX.IsUserSelectionEnabled = true;

                chart.Series[0].Color = Color.Blue;
            }
        }
        
        

        private void modifyChart()
        {
            defineChartInfo(chart1, 1);
            defineChartInfo(chart2, 2);
            defineChartInfo(chart3, 1);
            defineChartInfo(chart4, 2);
            
        }
        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private Chart chart3;
        private System.Windows.Forms.Button Start;
        private Chart chart4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFileBtn;
        private ToolStripMenuItem saveFileBtn;
        private ToolStripMenuItem waveAnalyzerToolStripMenuItem;
        private ToolStripMenuItem newWindowBtn;
        private ToolStripMenuItem recordToolStripMenuItem;
        private ToolStripMenuItem analyseToolStripMenuItem;
        private ToolStripMenuItem exitBtn;
        private ToolStripMenuItem analyseToolStripMenuItem1;
        private ToolStripMenuItem channel1AnalyzeBtn;
        private ToolStripMenuItem channel2AnalyzeBtn;
        private Button recordBtn;
        private Button playBtn;
        private Button pauseBtn;
        private ToolStripMenuItem sampleSizeMenu;
        private ToolStripMenuItem sampleSize8bitBtn;
        private ToolStripMenuItem sampleSize16bitBtn;
        private ToolStripMenuItem sampleRateMenu;
        private ToolStripMenuItem sampleRate11025Btn;
        private ToolStripMenuItem sampleRate22050Btn;
        private ToolStripMenuItem sampleRate44100Btn;
        private FlowLayoutPanel flowLayoutPanel1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusStripSampleSizeLabel;
        private ToolStripStatusLabel statusStripSampleRateLabel;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private ToolStripStatusLabel statusStripChannels;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem pasteToChart1;
        private ToolStripMenuItem pasteToChart2;
    }

    
}

