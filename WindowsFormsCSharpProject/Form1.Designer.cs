namespace WindowsFormsCSharpProject
{
    partial class FormMain
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
            this.openFileDialogTicker = new System.Windows.Forms.OpenFileDialog();
            this.buttonFileSelect = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.candlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialogTicker
            // 
            this.openFileDialogTicker.Filter = "All Files|*.csv|Monthly|*-Month.csv|Weekly|*-Week.csv|Dailey|*-Day.csv";
            this.openFileDialogTicker.InitialDirectory = "\\\\Mac\\Home\\Documents\\Stock Folder";
            this.openFileDialogTicker.Multiselect = true;
            this.openFileDialogTicker.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_Stocks_FileOk);
            // 
            // buttonFileSelect
            // 
            this.buttonFileSelect.Location = new System.Drawing.Point(35, 220);
            this.buttonFileSelect.Name = "buttonFileSelect";
            this.buttonFileSelect.Size = new System.Drawing.Size(253, 54);
            this.buttonFileSelect.TabIndex = 0;
            this.buttonFileSelect.Text = "Open File(s)";
            this.buttonFileSelect.UseVisualStyleBackColor = true;
            this.buttonFileSelect.Click += new System.EventHandler(this.button_FileSelect_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(35, 62);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(425, 31);
            this.dateTimePickerStart.TabIndex = 1;
            this.dateTimePickerStart.Value = new System.DateTime(2022, 1, 1, 9, 37, 0, 0);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(35, 149);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(425, 31);
            this.dateTimePickerEnd.TabIndex = 2;
            this.dateTimePickerEnd.Value = new System.DateTime(2024, 2, 15, 10, 42, 46, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Period Start:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enter Period End:";
            // 
            // candlestickBindingSource
            // 
            this.candlestickBindingSource.DataSource = typeof(WindowsFormsCSharpProject.Candlestick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 332);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.buttonFileSelect);
            this.Name = "FormMain";
            this.Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogTicker;
        private System.Windows.Forms.Button buttonFileSelect;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource candlestickBindingSource;
    }
}

