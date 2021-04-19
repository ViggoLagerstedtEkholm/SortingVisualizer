namespace SortingVisualizer.Draw
{
    partial class Start
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.XMLRadioBtn = new System.Windows.Forms.RadioButton();
            this.BINARYRadioBtn = new System.Windows.Forms.RadioButton();
            this.JSONRadioBtn = new System.Windows.Forms.RadioButton();
            this.FileChooseBtn = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.regularArray = new System.Windows.Forms.RadioButton();
            this.sineWave = new System.Windows.Forms.RadioButton();
            this.AlgorithmsList = new System.Windows.Forms.CheckedListBox();
            this.selectedAlgorithmListBox = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BarAmount = new System.Windows.Forms.Label();
            this.BarCountTxf = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.radioButton4);
            this.panel5.Controls.Add(this.radioButton3);
            this.panel5.Controls.Add(this.radioButton2);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Location = new System.Drawing.Point(13, 109);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(242, 305);
            this.panel5.TabIndex = 2;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(8, 156);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(53, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "JSON";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.JSONRadioBtn_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(9, 133);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "XML";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.XMLRadioBtn_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 110);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(54, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Binary";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.BINARYRadioBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save path";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.FileChooseBtn_Click);
            // 
            // XMLRadioBtn
            // 
            this.XMLRadioBtn.AutoSize = true;
            this.XMLRadioBtn.Location = new System.Drawing.Point(9, 147);
            this.XMLRadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.XMLRadioBtn.Name = "XMLRadioBtn";
            this.XMLRadioBtn.Size = new System.Drawing.Size(47, 17);
            this.XMLRadioBtn.TabIndex = 8;
            this.XMLRadioBtn.TabStop = true;
            this.XMLRadioBtn.Text = "XML";
            this.XMLRadioBtn.UseVisualStyleBackColor = true;
            this.XMLRadioBtn.Click += new System.EventHandler(this.XMLRadioBtn_Click);
            // 
            // BINARYRadioBtn
            // 
            this.BINARYRadioBtn.AutoSize = true;
            this.BINARYRadioBtn.Location = new System.Drawing.Point(9, 125);
            this.BINARYRadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.BINARYRadioBtn.Name = "BINARYRadioBtn";
            this.BINARYRadioBtn.Size = new System.Drawing.Size(54, 17);
            this.BINARYRadioBtn.TabIndex = 7;
            this.BINARYRadioBtn.TabStop = true;
            this.BINARYRadioBtn.Text = "Binary";
            this.BINARYRadioBtn.UseVisualStyleBackColor = true;
            this.BINARYRadioBtn.Click += new System.EventHandler(this.BINARYRadioBtn_Click);
            // 
            // JSONRadioBtn
            // 
            this.JSONRadioBtn.AutoSize = true;
            this.JSONRadioBtn.Location = new System.Drawing.Point(9, 103);
            this.JSONRadioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.JSONRadioBtn.Name = "JSONRadioBtn";
            this.JSONRadioBtn.Size = new System.Drawing.Size(53, 17);
            this.JSONRadioBtn.TabIndex = 6;
            this.JSONRadioBtn.TabStop = true;
            this.JSONRadioBtn.Text = "JSON";
            this.JSONRadioBtn.UseVisualStyleBackColor = true;
            this.JSONRadioBtn.Click += new System.EventHandler(this.JSONRadioBtn_Click);
            // 
            // FileChooseBtn
            // 
            this.FileChooseBtn.Location = new System.Drawing.Point(6, 51);
            this.FileChooseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.FileChooseBtn.Name = "FileChooseBtn";
            this.FileChooseBtn.Size = new System.Drawing.Size(116, 48);
            this.FileChooseBtn.TabIndex = 5;
            this.FileChooseBtn.Text = "Choose output path";
            this.FileChooseBtn.UseVisualStyleBackColor = true;
            this.FileChooseBtn.Click += new System.EventHandler(this.FileChooseBtn_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 168);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(131, 17);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "SAVE SOLVER DATA";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.RadioButton1_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.regularArray);
            this.panel3.Controls.Add(this.sineWave);
            this.panel3.Controls.Add(this.AlgorithmsList);
            this.panel3.Controls.Add(this.selectedAlgorithmListBox);
            this.panel3.Location = new System.Drawing.Point(260, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(481, 402);
            this.panel3.TabIndex = 1;
            // 
            // regularArray
            // 
            this.regularArray.AutoSize = true;
            this.regularArray.Location = new System.Drawing.Point(15, 356);
            this.regularArray.Name = "regularArray";
            this.regularArray.Size = new System.Drawing.Size(62, 17);
            this.regularArray.TabIndex = 3;
            this.regularArray.TabStop = true;
            this.regularArray.Text = "Regular";
            this.regularArray.UseVisualStyleBackColor = true;
            this.regularArray.Click += new System.EventHandler(this.RegularArray_Click);
            // 
            // sineWave
            // 
            this.sineWave.AutoSize = true;
            this.sineWave.Location = new System.Drawing.Point(15, 333);
            this.sineWave.Name = "sineWave";
            this.sineWave.Size = new System.Drawing.Size(75, 17);
            this.sineWave.TabIndex = 2;
            this.sineWave.TabStop = true;
            this.sineWave.Text = "Sine wave";
            this.sineWave.UseVisualStyleBackColor = true;
            this.sineWave.Click += new System.EventHandler(this.SineWave_Click);
            // 
            // AlgorithmsList
            // 
            this.AlgorithmsList.FormattingEnabled = true;
            this.AlgorithmsList.Location = new System.Drawing.Point(9, 18);
            this.AlgorithmsList.Name = "AlgorithmsList";
            this.AlgorithmsList.Size = new System.Drawing.Size(458, 169);
            this.AlgorithmsList.TabIndex = 1;
            this.AlgorithmsList.SelectedIndexChanged += new System.EventHandler(this.AlgorithmsList_SelectedIndexChanged);
            // 
            // selectedAlgorithmListBox
            // 
            this.selectedAlgorithmListBox.FormattingEnabled = true;
            this.selectedAlgorithmListBox.Location = new System.Drawing.Point(9, 193);
            this.selectedAlgorithmListBox.Name = "selectedAlgorithmListBox";
            this.selectedAlgorithmListBox.Size = new System.Drawing.Size(458, 134);
            this.selectedAlgorithmListBox.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 420);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(729, 81);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BarAmount);
            this.panel2.Controls.Add(this.BarCountTxf);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 91);
            this.panel2.TabIndex = 8;
            // 
            // BarAmount
            // 
            this.BarAmount.AutoSize = true;
            this.BarAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarAmount.Location = new System.Drawing.Point(4, 18);
            this.BarAmount.Name = "BarAmount";
            this.BarAmount.Size = new System.Drawing.Size(104, 25);
            this.BarAmount.TabIndex = 4;
            this.BarAmount.Text = "Bar count";
            // 
            // BarCountTxf
            // 
            this.BarCountTxf.Location = new System.Drawing.Point(8, 51);
            this.BarCountTxf.Name = "BarCountTxf";
            this.BarCountTxf.Size = new System.Drawing.Size(226, 20);
            this.BarCountTxf.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // fileSystemWatcher2
            // 
            this.fileSystemWatcher2.EnableRaisingEvents = true;
            this.fileSystemWatcher2.SynchronizingObject = this;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "No path detected";
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 514);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnStart);
            this.Name = "Start";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Start_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckedListBox AlgorithmsList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label BarAmount;
        private System.Windows.Forms.TextBox BarCountTxf;
        private System.Windows.Forms.ListBox selectedAlgorithmListBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton regularArray;
        private System.Windows.Forms.RadioButton sineWave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button FileChooseBtn;
        private System.IO.FileSystemWatcher fileSystemWatcher2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton XMLRadioBtn;
        private System.Windows.Forms.RadioButton BINARYRadioBtn;
        private System.Windows.Forms.RadioButton JSONRadioBtn;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label1;
    }
}

