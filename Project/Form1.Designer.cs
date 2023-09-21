using System.Drawing;
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(132, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1860, 380);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(132, 778);
            this.chart2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(1866, 334);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            this.chart2.Click += new System.EventHandler(this.chart2_Click);
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(132, 403);
            this.chart3.Name = "chart3";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart3.Series.Add(series3);
            this.chart3.Size = new System.Drawing.Size(1866, 344);
            this.chart3.TabIndex = 3;
            this.chart3.Text = "chart3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2244, 1160);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);

        }


        private void generateInfo()
        {

            
            //time-amplitude graph 1
            this.chart1.ChartAreas[0].AxisX.Title = "time";
            this.chart1.ChartAreas[0].AxisY.Title = "Amplitude";
            var chartArea1 = this.chart1.ChartAreas[0];
            chartArea1.AxisX.MinorGrid.Enabled = true;
            this.chart1.Series[0].BorderWidth = 3;
            
            this.chart1.Series[0].Color = Color.Yellow;
            

            //add color
            this.chart1.ChartAreas[0].BackColor = Color.Black;
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LawnGreen;
            this.chart1.ChartAreas[0].AxisX2.MajorGrid.LineColor = Color.LawnGreen;
            chartArea1.AxisX.LineWidth = 2;
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LawnGreen;
            

            // set view range to [0,max]
            chartArea1.AxisX.Minimum = 0;
            

            // enable autoscroll
            chartArea1.CursorX.AutoScroll = true;

            // let's zoom to [0,blockSize] (e.g. [0,100])
            chartArea1.AxisX.ScaleView.Zoomable = true;
            chartArea1.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            int position = 0;
            int size = 10;
            chartArea1.AxisX.ScaleView.Zoom(position, size);

            // disable zoom-reset button (only scrollbar's arrows are available)
            chartArea1.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

            // set scrollbar small change to blockSize (e.g. 100)
            chartArea1.AxisX.ScaleView.SmallScrollSize = 10;
            chartArea1.AxisX.ScrollBar.ButtonColor = Color.WhiteSmoke;
            chartArea1.AxisX.ScrollBar.LineColor = Color.White;
            chartArea1.AxisX.ScrollBar.IsPositionedInside = false;


            //time-amplitude graph 2
            this.chart3.ChartAreas[0].AxisX.Title = "time";
            this.chart3.ChartAreas[0].AxisY.Title = "Amplitude";
            var chartArea3 = this.chart3.ChartAreas[0];

            // set view range to [0,max]
            chartArea3.AxisX.Minimum = 0;
            

            // enable autoscroll
            chartArea3.CursorX.AutoScroll = true;

            // let's zoom to [0,blockSize] (e.g. [0,100])
            chartArea3.AxisX.ScaleView.Zoomable = true;
            chartArea3.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            
            chartArea3.AxisX.ScaleView.Zoom(position, size);

            // disable zoom-reset button (only scrollbar's arrows are available)
            chartArea3.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

            // set scrollbar small change to blockSize (e.g. 100)
            chartArea3.AxisX.ScaleView.SmallScrollSize = 10;



            //freq-amplitude graph
            this.chart2.ChartAreas[0].AxisX.Title = "frequency";
            this.chart2.ChartAreas[0].AxisY.Title = "Amplitude";
            this.chart2.ChartAreas[0].AxisX.Minimum = 0;
        }
        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Chart chart3;
        private System.Windows.Forms.Button button1;
    }

    
}

