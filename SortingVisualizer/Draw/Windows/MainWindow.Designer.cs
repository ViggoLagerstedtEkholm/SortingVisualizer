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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.XMLRadioBtn = new System.Windows.Forms.RadioButton();
            this.BINARYRadioBtn = new System.Windows.Forms.RadioButton();
            this.JSONRadioBtn = new System.Windows.Forms.RadioButton();
            this.FileChooseBtn = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.sleepTimeBar = new System.Windows.Forms.TrackBar();
            this.StopBtn = new System.Windows.Forms.Button();
            this.ResumeBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.fullscreenCheckbox = new System.Windows.Forms.CheckBox();
            this.regularArray = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.sineWave = new System.Windows.Forms.RadioButton();
            this.AlgorithmsList = new System.Windows.Forms.CheckedListBox();
            this.selectedAlgorithmListBox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MaxTxf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BarAmount = new System.Windows.Forms.Label();
            this.BarCountTxf = new System.Windows.Forms.TextBox();
            this.MinTxf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SortingPanel = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sleepTimeBar)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.sleepTimeBar);
            this.panel1.Controls.Add(this.StopBtn);
            this.panel1.Controls.Add(this.ResumeBtn);
            this.panel1.Controls.Add(this.PauseBtn);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(1412, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 894);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.XMLRadioBtn);
            this.panel5.Controls.Add(this.BINARYRadioBtn);
            this.panel5.Controls.Add(this.JSONRadioBtn);
            this.panel5.Controls.Add(this.FileChooseBtn);
            this.panel5.Location = new System.Drawing.Point(317, 300);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(166, 219);
            this.panel5.TabIndex = 17;
            // 
            // XMLRadioBtn
            // 
            this.XMLRadioBtn.AutoSize = true;
            this.XMLRadioBtn.Location = new System.Drawing.Point(12, 137);
            this.XMLRadioBtn.Name = "XMLRadioBtn";
            this.XMLRadioBtn.Size = new System.Drawing.Size(57, 21);
            this.XMLRadioBtn.TabIndex = 8;
            this.XMLRadioBtn.TabStop = true;
            this.XMLRadioBtn.Text = "XML";
            this.XMLRadioBtn.UseVisualStyleBackColor = true;
            this.XMLRadioBtn.Click += new System.EventHandler(this.XMLRadioBtn_Click);
            // 
            // BINARYRadioBtn
            // 
            this.BINARYRadioBtn.AutoSize = true;
            this.BINARYRadioBtn.Location = new System.Drawing.Point(12, 110);
            this.BINARYRadioBtn.Name = "BINARYRadioBtn";
            this.BINARYRadioBtn.Size = new System.Drawing.Size(69, 21);
            this.BINARYRadioBtn.TabIndex = 7;
            this.BINARYRadioBtn.TabStop = true;
            this.BINARYRadioBtn.Text = "Binary";
            this.BINARYRadioBtn.UseVisualStyleBackColor = true;
            this.BINARYRadioBtn.Click += new System.EventHandler(this.BINARYRadioBtn_Click);
            // 
            // JSONRadioBtn
            // 
            this.JSONRadioBtn.AutoSize = true;
            this.JSONRadioBtn.Location = new System.Drawing.Point(12, 83);
            this.JSONRadioBtn.Name = "JSONRadioBtn";
            this.JSONRadioBtn.Size = new System.Drawing.Size(66, 21);
            this.JSONRadioBtn.TabIndex = 6;
            this.JSONRadioBtn.TabStop = true;
            this.JSONRadioBtn.Text = "JSON";
            this.JSONRadioBtn.UseVisualStyleBackColor = true;
            this.JSONRadioBtn.Click += new System.EventHandler(this.JSONRadioBtn_Click);
            // 
            // FileChooseBtn
            // 
            this.FileChooseBtn.Location = new System.Drawing.Point(8, 18);
            this.FileChooseBtn.Name = "FileChooseBtn";
            this.FileChooseBtn.Size = new System.Drawing.Size(155, 59);
            this.FileChooseBtn.TabIndex = 5;
            this.FileChooseBtn.Text = "Choose output path";
            this.FileChooseBtn.UseVisualStyleBackColor = true;
            this.FileChooseBtn.Click += new System.EventHandler(this.FileChooseBtn_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(317, 244);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(166, 21);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "SAVE SOLVER DATA";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sleep time";
            // 
            // sleepTimeBar
            // 
            this.sleepTimeBar.Location = new System.Drawing.Point(328, 181);
            this.sleepTimeBar.Margin = new System.Windows.Forms.Padding(4);
            this.sleepTimeBar.Maximum = 100;
            this.sleepTimeBar.Minimum = 1;
            this.sleepTimeBar.Name = "sleepTimeBar";
            this.sleepTimeBar.Size = new System.Drawing.Size(155, 56);
            this.sleepTimeBar.TabIndex = 14;
            this.sleepTimeBar.Value = 1;
            this.sleepTimeBar.Scroll += new System.EventHandler(this.sleepTimeBar_Scroll);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(315, 96);
            this.StopBtn.Margin = new System.Windows.Forms.Padding(4);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(168, 28);
            this.StopBtn.TabIndex = 13;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // ResumeBtn
            // 
            this.ResumeBtn.Location = new System.Drawing.Point(315, 56);
            this.ResumeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ResumeBtn.Name = "ResumeBtn";
            this.ResumeBtn.Size = new System.Drawing.Size(168, 28);
            this.ResumeBtn.TabIndex = 12;
            this.ResumeBtn.Text = "Resume";
            this.ResumeBtn.UseVisualStyleBackColor = true;
            this.ResumeBtn.Click += new System.EventHandler(this.ResumeBtn_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.Location = new System.Drawing.Point(315, 20);
            this.PauseBtn.Margin = new System.Windows.Forms.Padding(4);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(168, 28);
            this.PauseBtn.TabIndex = 11;
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Location = new System.Drawing.Point(19, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(288, 871);
            this.panel4.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.fullscreenCheckbox);
            this.panel3.Controls.Add(this.regularArray);
            this.panel3.Controls.Add(this.btnStart);
            this.panel3.Controls.Add(this.sineWave);
            this.panel3.Controls.Add(this.AlgorithmsList);
            this.panel3.Controls.Add(this.selectedAlgorithmListBox);
            this.panel3.Location = new System.Drawing.Point(19, 226);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 631);
            this.panel3.TabIndex = 1;
            // 
            // fullscreenCheckbox
            // 
            this.fullscreenCheckbox.AutoSize = true;
            this.fullscreenCheckbox.Location = new System.Drawing.Point(20, 486);
            this.fullscreenCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.fullscreenCheckbox.Name = "fullscreenCheckbox";
            this.fullscreenCheckbox.Size = new System.Drawing.Size(95, 21);
            this.fullscreenCheckbox.TabIndex = 4;
            this.fullscreenCheckbox.Text = "Fullscreen";
            this.fullscreenCheckbox.UseVisualStyleBackColor = true;
            // 
            // regularArray
            // 
            this.regularArray.AutoSize = true;
            this.regularArray.Location = new System.Drawing.Point(20, 457);
            this.regularArray.Margin = new System.Windows.Forms.Padding(4);
            this.regularArray.Name = "regularArray";
            this.regularArray.Size = new System.Drawing.Size(79, 21);
            this.regularArray.TabIndex = 3;
            this.regularArray.TabStop = true;
            this.regularArray.Text = "Regular";
            this.regularArray.UseVisualStyleBackColor = true;
            this.regularArray.Click += new System.EventHandler(this.regularArray_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(20, 515);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(168, 31);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // sineWave
            // 
            this.sineWave.AutoSize = true;
            this.sineWave.Location = new System.Drawing.Point(20, 428);
            this.sineWave.Margin = new System.Windows.Forms.Padding(4);
            this.sineWave.Name = "sineWave";
            this.sineWave.Size = new System.Drawing.Size(93, 21);
            this.sineWave.TabIndex = 2;
            this.sineWave.TabStop = true;
            this.sineWave.Text = "Sine wave";
            this.sineWave.UseVisualStyleBackColor = true;
            this.sineWave.Click += new System.EventHandler(this.sineWave_Click);
            // 
            // AlgorithmsList
            // 
            this.AlgorithmsList.FormattingEnabled = true;
            this.AlgorithmsList.Location = new System.Drawing.Point(20, 23);
            this.AlgorithmsList.Margin = new System.Windows.Forms.Padding(4);
            this.AlgorithmsList.Name = "AlgorithmsList";
            this.AlgorithmsList.Size = new System.Drawing.Size(188, 225);
            this.AlgorithmsList.TabIndex = 1;
            this.AlgorithmsList.SelectedIndexChanged += new System.EventHandler(this.AlgorithmsList_SelectedIndexChanged);
            // 
            // selectedAlgorithmListBox
            // 
            this.selectedAlgorithmListBox.FormattingEnabled = true;
            this.selectedAlgorithmListBox.ItemHeight = 16;
            this.selectedAlgorithmListBox.Location = new System.Drawing.Point(20, 256);
            this.selectedAlgorithmListBox.Margin = new System.Windows.Forms.Padding(4);
            this.selectedAlgorithmListBox.Name = "selectedAlgorithmListBox";
            this.selectedAlgorithmListBox.Size = new System.Drawing.Size(188, 164);
            this.selectedAlgorithmListBox.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.MaxTxf);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BarAmount);
            this.panel2.Controls.Add(this.BarCountTxf);
            this.panel2.Controls.Add(this.MinTxf);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(19, 16);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 203);
            this.panel2.TabIndex = 8;
            // 
            // MaxTxf
            // 
            this.MaxTxf.Location = new System.Drawing.Point(8, 102);
            this.MaxTxf.Margin = new System.Windows.Forms.Padding(4);
            this.MaxTxf.Name = "MaxTxf";
            this.MaxTxf.Size = new System.Drawing.Size(200, 22);
            this.MaxTxf.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Min";
            // 
            // BarAmount
            // 
            this.BarAmount.AutoSize = true;
            this.BarAmount.Location = new System.Drawing.Point(4, 140);
            this.BarAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BarAmount.Name = "BarAmount";
            this.BarAmount.Size = new System.Drawing.Size(69, 17);
            this.BarAmount.TabIndex = 4;
            this.BarAmount.Text = "Bar count";
            // 
            // BarCountTxf
            // 
            this.BarCountTxf.Location = new System.Drawing.Point(8, 160);
            this.BarCountTxf.Margin = new System.Windows.Forms.Padding(4);
            this.BarCountTxf.Name = "BarCountTxf";
            this.BarCountTxf.Size = new System.Drawing.Size(200, 22);
            this.BarCountTxf.TabIndex = 2;
            // 
            // MinTxf
            // 
            this.MinTxf.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.MinTxf.Location = new System.Drawing.Point(8, 42);
            this.MinTxf.Margin = new System.Windows.Forms.Padding(4);
            this.MinTxf.Name = "MinTxf";
            this.MinTxf.Size = new System.Drawing.Size(200, 22);
            this.MinTxf.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Max";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // SortingPanel
            // 
            this.SortingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SortingPanel.Location = new System.Drawing.Point(16, 11);
            this.SortingPanel.Margin = new System.Windows.Forms.Padding(4);
            this.SortingPanel.Name = "SortingPanel";
            this.SortingPanel.Size = new System.Drawing.Size(1388, 898);
            this.SortingPanel.TabIndex = 1;
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
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 918);
            this.Controls.Add(this.SortingPanel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Start";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Start_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sleepTimeBar)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckedListBox AlgorithmsList;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox MaxTxf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BarAmount;
        private System.Windows.Forms.TextBox BarCountTxf;
        private System.Windows.Forms.TextBox MinTxf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox selectedAlgorithmListBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel SortingPanel;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button ResumeBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar sleepTimeBar;
        private System.Windows.Forms.RadioButton regularArray;
        private System.Windows.Forms.RadioButton sineWave;
        private System.Windows.Forms.CheckBox fullscreenCheckbox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button FileChooseBtn;
        private System.IO.FileSystemWatcher fileSystemWatcher2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton XMLRadioBtn;
        private System.Windows.Forms.RadioButton BINARYRadioBtn;
        private System.Windows.Forms.RadioButton JSONRadioBtn;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

