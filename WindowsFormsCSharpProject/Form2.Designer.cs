namespace WindowsFormsCSharpProject
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileDialogTicker = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_Update = new System.Windows.Forms.Button();
            this.label_annotate = new System.Windows.Forms.Label();
            this.comboBox_annotate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Date:";
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Location = new System.Drawing.Point(23, 79);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(363, 31);
            this.dateTimePicker_Start.TabIndex = 2;
            this.dateTimePicker_Start.Value = new System.DateTime(2022, 1, 1, 9, 44, 0, 0);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(23, 164);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(363, 31);
            this.dateTimePicker_End.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "End Date:";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.Name = "ChartArea_Volume";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(409, 23);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Color = System.Drawing.Color.Lime;
            series1.CustomProperties = "PriceUpColor=Lime, PriceDownColor=Red";
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.Black;
            series1.MarkerColor = System.Drawing.SystemColors.ActiveCaptionText;
            series1.Name = "OHLC";
            series1.XValueMember = "date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueMembers = "high, low, open, close";
            series1.YValuesPerPoint = 4;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea_Volume";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.Name = "Volume";
            series2.XValueMember = "date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueMembers = "volume";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt64;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1602, 685);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // button_Update
            // 
            this.button_Update.Location = new System.Drawing.Point(23, 241);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(196, 113);
            this.button_Update.TabIndex = 6;
            this.button_Update.Text = "Update Period";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click_1);
            // 
            // label_annotate
            // 
            this.label_annotate.AutoSize = true;
            this.label_annotate.Location = new System.Drawing.Point(18, 447);
            this.label_annotate.Name = "label_annotate";
            this.label_annotate.Size = new System.Drawing.Size(371, 25);
            this.label_annotate.TabIndex = 7;
            this.label_annotate.Text = "Select a candlestick type to annotate:";
            // 
            // comboBox_annotate
            // 
            this.comboBox_annotate.FormattingEnabled = true;
            this.comboBox_annotate.Items.AddRange(new object[] {
            "No Annotation"});
            this.comboBox_annotate.Location = new System.Drawing.Point(23, 496);
            this.comboBox_annotate.Name = "comboBox_annotate";
            this.comboBox_annotate.Size = new System.Drawing.Size(363, 33);
            this.comboBox_annotate.TabIndex = 8;
            this.comboBox_annotate.SelectedIndexChanged += new System.EventHandler(this.comboBox_annotate_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2023, 734);
            this.Controls.Add(this.comboBox_annotate);
            this.Controls.Add(this.label_annotate);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker_End);
            this.Controls.Add(this.dateTimePicker_Start);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogTicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.Label label_annotate;
        private System.Windows.Forms.ComboBox comboBox_annotate;
    }
}