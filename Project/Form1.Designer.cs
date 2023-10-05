using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea17 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend17 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea18 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend18 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea19 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend19 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea20 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend20 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Start = new System.Windows.Forms.Button();
            this.new_window = new System.Windows.Forms.Button();
            this.read_file = new System.Windows.Forms.Button();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea17.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea17);
            legend17.Name = "Legend1";
            this.chart1.Legends.Add(legend17);
            this.chart1.Location = new System.Drawing.Point(130, 22);
            this.chart1.Name = "chart1";
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series17.IsVisibleInLegend = false;
            series17.Legend = "Legend1";
            series17.Name = "Series1";
            this.chart1.Series.Add(series17);
            this.chart1.Size = new System.Drawing.Size(1653, 304);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea18.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea18);
            legend18.Name = "Legend1";
            this.chart2.Legends.Add(legend18);
            this.chart2.Location = new System.Drawing.Point(130, 349);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series18.ChartArea = "ChartArea1";
            series18.IsVisibleInLegend = false;
            series18.Legend = "Legend1";
            series18.Name = "Sound Wave";
            this.chart2.Series.Add(series18);
            this.chart2.Size = new System.Drawing.Size(977, 267);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea19.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea19);
            legend19.Name = "Legend1";
            this.chart3.Legends.Add(legend19);
            this.chart3.Location = new System.Drawing.Point(130, 651);
            this.chart3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart3.Name = "chart3";
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series19.IsVisibleInLegend = false;
            series19.Legend = "Legend1";
            series19.Name = "Series1";
            this.chart3.Series.Add(series19);
            this.chart3.Size = new System.Drawing.Size(1659, 275);
            this.chart3.TabIndex = 3;
            this.chart3.Text = "chart3";
            // 
            // Start
            // 
            this.Start.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Start.Location = new System.Drawing.Point(-2, 50);
            this.Start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(113, 26);
            this.Start.TabIndex = 4;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.startbutton_click);
            // 
            // new_window
            // 
            this.new_window.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.new_window.Location = new System.Drawing.Point(-2, 22);
            this.new_window.Name = "new_window";
            this.new_window.Size = new System.Drawing.Size(113, 23);
            this.new_window.TabIndex = 5;
            this.new_window.Text = "New Window";
            this.new_window.UseVisualStyleBackColor = true;
            this.new_window.Click += new System.EventHandler(this.new_window_button_click);
            // 
            // read_file
            // 
            this.read_file.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.read_file.Location = new System.Drawing.Point(-2, 81);
            this.read_file.Name = "read_file";
            this.read_file.Size = new System.Drawing.Size(113, 23);
            this.read_file.TabIndex = 6;
            this.read_file.Text = "Read File";
            this.read_file.UseVisualStyleBackColor = true;
            this.read_file.Click += new System.EventHandler(this.read_file_click);
            // 
            // chart4
            // 
            chartArea20.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea20);
            legend20.Name = "Legend1";
            this.chart4.Legends.Add(legend20);
            this.chart4.Location = new System.Drawing.Point(130, 952);
            this.chart4.Name = "chart4";
            series20.ChartArea = "ChartArea1";
            series20.Legend = "Legend1";
            series20.Name = "Series1";
            this.chart4.Series.Add(series20);
            this.chart4.Size = new System.Drawing.Size(908, 267);
            this.chart4.TabIndex = 7;
            this.chart4.Text = "chart4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2061, 1181);
            this.Controls.Add(this.chart4);
            this.Controls.Add(this.read_file);
            this.Controls.Add(this.new_window);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.ResumeLayout(false);

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


                chartArea1.AxisX.ScaleView.Zoomable = true;
                chartArea1.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;

                chartArea1.AxisY.ScaleView.Zoomable = true;
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

            } else
            {
                chartArea1.AxisX.Title = "frequency";
                chartArea1.AxisY.Title = "Amplitude";
                chartArea1.AxisX.Minimum = 0;
                chart.Series[0].Color = Color.Blue;
            }
            chart.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.makeChartZoomable);
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
        private Button new_window;
        private Button read_file;
        private Chart chart4;
    }

    
}

