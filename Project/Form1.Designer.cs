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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Start = new System.Windows.Forms.Button();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.waveAnalyzerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.channel1AnalyzeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.channel2AnalyzeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToChart1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToChart2 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.recordBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(3, 4);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.IsVisibleInLegend = false;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(1507, 327);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.chart2.Legends.Add(legend6);
            this.chart2.Location = new System.Drawing.Point(3, 4);
            this.chart2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series6.ChartArea = "ChartArea1";
            series6.IsVisibleInLegend = false;
            series6.Legend = "Legend1";
            series6.Name = "Sound Wave";
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(748, 323);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea7.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea7);
            this.chart3.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Name = "Legend1";
            this.chart3.Legends.Add(legend7);
            this.chart3.Location = new System.Drawing.Point(3, 672);
            this.chart3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart3.Name = "chart3";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.IsVisibleInLegend = false;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart3.Series.Add(series7);
            this.chart3.Size = new System.Drawing.Size(1507, 332);
            this.chart3.TabIndex = 3;
            this.chart3.Text = "chart3";
            // 
            // Start
            // 
            this.Start.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Start.Location = new System.Drawing.Point(3, 2);
            this.Start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(120, 32);
            this.Start.TabIndex = 4;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.startbutton_click);
            // 
            // chart4
            // 
            chartArea8.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea8);
            this.chart4.Dock = System.Windows.Forms.DockStyle.Fill;
            legend8.Name = "Legend1";
            this.chart4.Legends.Add(legend8);
            this.chart4.Location = new System.Drawing.Point(757, 4);
            this.chart4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart4.Name = "chart4";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chart4.Series.Add(series8);
            this.chart4.Size = new System.Drawing.Size(749, 323);
            this.chart4.TabIndex = 7;
            this.chart4.Text = "chart4";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.Controls.Add(this.chart1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chart3, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 42);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1513, 1006);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.chart2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chart4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 337);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 331F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1509, 331);
            this.tableLayoutPanel3.TabIndex = 1;
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1517, 33);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // waveAnalyzerToolStripMenuItem
            // 
            this.waveAnalyzerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowBtn,
            this.exitToolStripMenuItem});
            this.waveAnalyzerToolStripMenuItem.Name = "waveAnalyzerToolStripMenuItem";
            this.waveAnalyzerToolStripMenuItem.Size = new System.Drawing.Size(138, 29);
            this.waveAnalyzerToolStripMenuItem.Text = "WaveAnalyzer";
            // 
            // newWindowBtn
            // 
            this.newWindowBtn.Name = "newWindowBtn";
            this.newWindowBtn.Size = new System.Drawing.Size(220, 34);
            this.newWindowBtn.Text = "New Window";
            this.newWindowBtn.Click += new System.EventHandler(this.newWindowBtn_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(220, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileBtn,
            this.saveFileBtn});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileBtn
            // 
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(158, 34);
            this.openFileBtn.Text = "Open";
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // saveFileBtn
            // 
            this.saveFileBtn.Name = "saveFileBtn";
            this.saveFileBtn.Size = new System.Drawing.Size(158, 34);
            this.saveFileBtn.Text = "Save";
            this.saveFileBtn.Click += new System.EventHandler(this.saveFileBtn_Click);
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.recordToolStripMenuItem.Text = "Recorder";
            // 
            // analyseToolStripMenuItem
            // 
            this.analyseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analyseToolStripMenuItem1});
            this.analyseToolStripMenuItem.Name = "analyseToolStripMenuItem";
            this.analyseToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.analyseToolStripMenuItem.Text = "Analyse";
            // 
            // analyseToolStripMenuItem1
            // 
            this.analyseToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channel1AnalyzeBtn,
            this.channel2AnalyzeBtn});
            this.analyseToolStripMenuItem1.Name = "analyseToolStripMenuItem1";
            this.analyseToolStripMenuItem1.Size = new System.Drawing.Size(145, 34);
            this.analyseToolStripMenuItem1.Text = "DFT";
            // 
            // channel1AnalyzeBtn
            // 
            this.channel1AnalyzeBtn.Enabled = false;
            this.channel1AnalyzeBtn.Name = "channel1AnalyzeBtn";
            this.channel1AnalyzeBtn.Size = new System.Drawing.Size(192, 34);
            this.channel1AnalyzeBtn.Text = "Channel 1";
            this.channel1AnalyzeBtn.Click += new System.EventHandler(this.channel1AnalyzeBtn_Click);
            // 
            // channel2AnalyzeBtn
            // 
            this.channel2AnalyzeBtn.Enabled = false;
            this.channel2AnalyzeBtn.Name = "channel2AnalyzeBtn";
            this.channel2AnalyzeBtn.Size = new System.Drawing.Size(192, 34);
            this.channel2AnalyzeBtn.Text = "Channel 2";
            this.channel2AnalyzeBtn.Click += new System.EventHandler(this.channel2AnalyzeBtn_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToChart1,
            this.pasteToChart2});
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // pasteToChart1
            // 
            this.pasteToChart1.Name = "pasteToChart1";
            this.pasteToChart1.Size = new System.Drawing.Size(171, 34);
            this.pasteToChart1.Text = "Chart 1";
            this.pasteToChart1.Click += new System.EventHandler(this.pasteToChart1_Click);
            // 
            // pasteToChart2
            // 
            this.pasteToChart2.Name = "pasteToChart2";
            this.pasteToChart2.Size = new System.Drawing.Size(171, 34);
            this.pasteToChart2.Text = "Chart 2";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(70, 29);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 33);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1517, 1049);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Start);
            this.flowLayoutPanel1.Controls.Add(this.recordBtn);
            this.flowLayoutPanel1.Controls.Add(this.playBtn);
            this.flowLayoutPanel1.Controls.Add(this.pauseBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1513, 36);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // recordBtn
            // 
            this.recordBtn.Location = new System.Drawing.Point(128, 2);
            this.recordBtn.Margin = new System.Windows.Forms.Padding(2);
            this.recordBtn.Name = "recordBtn";
            this.recordBtn.Size = new System.Drawing.Size(120, 32);
            this.recordBtn.TabIndex = 5;
            this.recordBtn.Text = "Record";
            this.recordBtn.UseVisualStyleBackColor = true;
            this.recordBtn.Click += new System.EventHandler(this.recordBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(252, 2);
            this.playBtn.Margin = new System.Windows.Forms.Padding(2);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(120, 32);
            this.playBtn.TabIndex = 6;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Location = new System.Drawing.Point(376, 2);
            this.pauseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(120, 32);
            this.pauseBtn.TabIndex = 7;
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // WaveAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1517, 1082);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1356, 1051);
            this.Name = "WaveAnalyzer";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFileBtn;
        private ToolStripMenuItem saveFileBtn;
        private ToolStripMenuItem waveAnalyzerToolStripMenuItem;
        private ToolStripMenuItem newWindowBtn;
        private ToolStripMenuItem recordToolStripMenuItem;
        private ToolStripMenuItem analyseToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem analyseToolStripMenuItem1;
        private ToolStripMenuItem channel1AnalyzeBtn;
        private ToolStripMenuItem channel2AnalyzeBtn;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button recordBtn;
        private Button playBtn;
        private Button pauseBtn;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem pasteToChart1;
        private ToolStripMenuItem pasteToChart2;
        private ToolStripMenuItem copyToolStripMenuItem;
    }

    
}

