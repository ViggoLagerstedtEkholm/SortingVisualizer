using System.Windows.Forms;

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
            this.LblHasBeenUsed = new System.Windows.Forms.Label();
            this.checkBoxSerialize = new System.Windows.Forms.CheckBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.XMLRadioBtn = new System.Windows.Forms.RadioButton();
            this.BINARYRadioBtn = new System.Windows.Forms.RadioButton();
            this.JSONRadioBtn = new System.Windows.Forms.RadioButton();
            this.FileChooseBtn = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AlgorithmsList = new System.Windows.Forms.CheckedListBox();
            this.selectedAlgorithmListBox = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxShuffleSpeed = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSleepStart = new System.Windows.Forms.TextBox();
            this.BarAmount = new System.Windows.Forms.Label();
            this.BarCountTxf = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.shuffleSleepTimeBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.sleepTimeBar = new System.Windows.Forms.TrackBar();
            this.InfoCheckBox = new System.Windows.Forms.CheckBox();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.ResumeBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxAlgorithmName = new System.Windows.Forms.TextBox();
            this.textBoxAmountOfBars = new System.Windows.Forms.TextBox();
            this.textBoxVisualize = new System.Windows.Forms.TextBox();
            this.textBoxSleep = new System.Windows.Forms.TextBox();
            this.textBoxShuffleSp = new System.Windows.Forms.TextBox();
            this.textBoxSwaps = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SHOWCASE_PANEL = new System.Windows.Forms.Panel();
            this.checkBoxBlack = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBoxGray = new System.Windows.Forms.CheckBox();
            this.checkBoxDarkBlue = new System.Windows.Forms.CheckBox();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shuffleSleepTimeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleepTimeBar)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.LblHasBeenUsed);
            this.panel5.Controls.Add(this.checkBoxSerialize);
            this.panel5.Controls.Add(this.tbPath);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.textBoxFileName);
            this.panel5.Controls.Add(this.lblFileName);
            this.panel5.Location = new System.Drawing.Point(13, 90);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(242, 135);
            this.panel5.TabIndex = 2;
            // 
            // LblHasBeenUsed
            // 
            this.LblHasBeenUsed.AutoSize = true;
            this.LblHasBeenUsed.Location = new System.Drawing.Point(139, 86);
            this.LblHasBeenUsed.Name = "LblHasBeenUsed";
            this.LblHasBeenUsed.Size = new System.Drawing.Size(61, 13);
            this.LblHasBeenUsed.TabIndex = 9;
            this.LblHasBeenUsed.Text = "Enter name";
            // 
            // checkBoxSerialize
            // 
            this.checkBoxSerialize.AutoSize = true;
            this.checkBoxSerialize.Location = new System.Drawing.Point(8, 14);
            this.checkBoxSerialize.Name = "checkBoxSerialize";
            this.checkBoxSerialize.Size = new System.Drawing.Size(65, 17);
            this.checkBoxSerialize.TabIndex = 8;
            this.checkBoxSerialize.Text = "Serialize";
            this.checkBoxSerialize.UseVisualStyleBackColor = true;
            this.checkBoxSerialize.CheckedChanged += new System.EventHandler(this.CheckBoxSerialize_CheckedChanged);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(8, 63);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(224, 20);
            this.tbPath.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "File name";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(9, 102);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(225, 20);
            this.textBoxFileName.TabIndex = 5;
            this.textBoxFileName.TextChanged += new System.EventHandler(this.TextBoxFileName_TextChanged);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(5, 47);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(56, 13);
            this.lblFileName.TabIndex = 4;
            this.lblFileName.Text = "Save path";
            // 
            // XMLRadioBtn
            // 
            this.XMLRadioBtn.Location = new System.Drawing.Point(0, 0);
            this.XMLRadioBtn.Name = "XMLRadioBtn";
            this.XMLRadioBtn.Size = new System.Drawing.Size(104, 24);
            this.XMLRadioBtn.TabIndex = 0;
            // 
            // BINARYRadioBtn
            // 
            this.BINARYRadioBtn.Location = new System.Drawing.Point(0, 0);
            this.BINARYRadioBtn.Name = "BINARYRadioBtn";
            this.BINARYRadioBtn.Size = new System.Drawing.Size(104, 24);
            this.BINARYRadioBtn.TabIndex = 0;
            // 
            // JSONRadioBtn
            // 
            this.JSONRadioBtn.Location = new System.Drawing.Point(0, 0);
            this.JSONRadioBtn.Name = "JSONRadioBtn";
            this.JSONRadioBtn.Size = new System.Drawing.Size(104, 24);
            this.JSONRadioBtn.TabIndex = 0;
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
            this.panel3.Controls.Add(this.checkBoxSelectAll);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.AlgorithmsList);
            this.panel3.Controls.Add(this.selectedAlgorithmListBox);
            this.panel3.Location = new System.Drawing.Point(13, 231);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 451);
            this.panel3.TabIndex = 1;
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(9, 32);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(69, 17);
            this.checkBoxSelectAll.TabIndex = 3;
            this.checkBoxSelectAll.Text = "Select all";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.CheckBoxSelectAll_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Algorithms";
            // 
            // AlgorithmsList
            // 
            this.AlgorithmsList.FormattingEnabled = true;
            this.AlgorithmsList.Location = new System.Drawing.Point(8, 55);
            this.AlgorithmsList.Name = "AlgorithmsList";
            this.AlgorithmsList.Size = new System.Drawing.Size(224, 199);
            this.AlgorithmsList.TabIndex = 1;
            this.AlgorithmsList.SelectedIndexChanged += new System.EventHandler(this.AlgorithmsList_SelectedIndexChanged);
            // 
            // selectedAlgorithmListBox
            // 
            this.selectedAlgorithmListBox.FormattingEnabled = true;
            this.selectedAlgorithmListBox.Location = new System.Drawing.Point(9, 260);
            this.selectedAlgorithmListBox.Name = "selectedAlgorithmListBox";
            this.selectedAlgorithmListBox.Size = new System.Drawing.Size(225, 186);
            this.selectedAlgorithmListBox.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 688);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(242, 43);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBoxShuffleSpeed);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBoxSleepStart);
            this.panel2.Controls.Add(this.BarAmount);
            this.panel2.Controls.Add(this.BarCountTxf);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 72);
            this.panel2.TabIndex = 8;
            // 
            // textBoxShuffleSpeed
            // 
            this.textBoxShuffleSpeed.Location = new System.Drawing.Point(168, 38);
            this.textBoxShuffleSpeed.Name = "textBoxShuffleSpeed";
            this.textBoxShuffleSpeed.Size = new System.Drawing.Size(66, 20);
            this.textBoxShuffleSpeed.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(165, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Shuffle speed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Start sleep";
            // 
            // textBoxSleepStart
            // 
            this.textBoxSleepStart.Location = new System.Drawing.Point(85, 38);
            this.textBoxSleepStart.Name = "textBoxSleepStart";
            this.textBoxSleepStart.Size = new System.Drawing.Size(76, 20);
            this.textBoxSleepStart.TabIndex = 5;
            // 
            // BarAmount
            // 
            this.BarAmount.AutoSize = true;
            this.BarAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarAmount.Location = new System.Drawing.Point(7, 18);
            this.BarAmount.Name = "BarAmount";
            this.BarAmount.Size = new System.Drawing.Size(53, 13);
            this.BarAmount.TabIndex = 4;
            this.BarAmount.Text = "Bar count";
            // 
            // BarCountTxf
            // 
            this.BarCountTxf.Location = new System.Drawing.Point(9, 38);
            this.BarCountTxf.Name = "BarCountTxf";
            this.BarCountTxf.Size = new System.Drawing.Size(70, 20);
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.shuffleSleepTimeBar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.sleepTimeBar);
            this.panel1.Controls.Add(this.InfoCheckBox);
            this.panel1.Controls.Add(this.PauseBtn);
            this.panel1.Controls.Add(this.ResumeBtn);
            this.panel1.Location = new System.Drawing.Point(262, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 72);
            this.panel1.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(844, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Shuffle time";
            // 
            // shuffleSleepTimeBar
            // 
            this.shuffleSleepTimeBar.Location = new System.Drawing.Point(847, 22);
            this.shuffleSleepTimeBar.Maximum = 100;
            this.shuffleSleepTimeBar.Minimum = 1;
            this.shuffleSleepTimeBar.Name = "shuffleSleepTimeBar";
            this.shuffleSleepTimeBar.Size = new System.Drawing.Size(333, 45);
            this.shuffleSleepTimeBar.TabIndex = 25;
            this.shuffleSleepTimeBar.Value = 1;
            this.shuffleSleepTimeBar.Scroll += new System.EventHandler(this.ShuffleSleepTimeBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(516, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Sleep time";
            // 
            // sleepTimeBar
            // 
            this.sleepTimeBar.Location = new System.Drawing.Point(509, 26);
            this.sleepTimeBar.Maximum = 100;
            this.sleepTimeBar.Minimum = 1;
            this.sleepTimeBar.Name = "sleepTimeBar";
            this.sleepTimeBar.Size = new System.Drawing.Size(329, 45);
            this.sleepTimeBar.TabIndex = 23;
            this.sleepTimeBar.Value = 1;
            this.sleepTimeBar.Scroll += new System.EventHandler(this.SleepTimeBar_Scroll);
            // 
            // InfoCheckBox
            // 
            this.InfoCheckBox.AutoSize = true;
            this.InfoCheckBox.Checked = true;
            this.InfoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InfoCheckBox.Location = new System.Drawing.Point(375, 7);
            this.InfoCheckBox.Name = "InfoCheckBox";
            this.InfoCheckBox.Size = new System.Drawing.Size(115, 17);
            this.InfoCheckBox.TabIndex = 22;
            this.InfoCheckBox.Text = "Show elapsed time";
            this.InfoCheckBox.UseVisualStyleBackColor = true;
            this.InfoCheckBox.CheckedChanged += new System.EventHandler(this.InfoCheckBox_CheckedChanged);
            // 
            // PauseBtn
            // 
            this.PauseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PauseBtn.Location = new System.Drawing.Point(3, 7);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(180, 60);
            this.PauseBtn.TabIndex = 19;
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.UseVisualStyleBackColor = false;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // ResumeBtn
            // 
            this.ResumeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ResumeBtn.Location = new System.Drawing.Point(189, 7);
            this.ResumeBtn.Name = "ResumeBtn";
            this.ResumeBtn.Size = new System.Drawing.Size(180, 60);
            this.ResumeBtn.TabIndex = 20;
            this.ResumeBtn.Text = "Resume";
            this.ResumeBtn.UseVisualStyleBackColor = false;
            this.ResumeBtn.Click += new System.EventHandler(this.ResumeBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Algorithm";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.textBoxAlgorithmName);
            this.panel4.Controls.Add(this.textBoxAmountOfBars);
            this.panel4.Controls.Add(this.textBoxVisualize);
            this.panel4.Controls.Add(this.textBoxSleep);
            this.panel4.Controls.Add(this.textBoxShuffleSp);
            this.panel4.Controls.Add(this.textBoxSwaps);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(262, 688);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1244, 43);
            this.panel4.TabIndex = 13;
            // 
            // textBoxAlgorithmName
            // 
            this.textBoxAlgorithmName.Enabled = false;
            this.textBoxAlgorithmName.Location = new System.Drawing.Point(79, 10);
            this.textBoxAlgorithmName.Name = "textBoxAlgorithmName";
            this.textBoxAlgorithmName.Size = new System.Drawing.Size(100, 20);
            this.textBoxAlgorithmName.TabIndex = 33;
            // 
            // textBoxAmountOfBars
            // 
            this.textBoxAmountOfBars.Enabled = false;
            this.textBoxAmountOfBars.Location = new System.Drawing.Point(235, 10);
            this.textBoxAmountOfBars.Name = "textBoxAmountOfBars";
            this.textBoxAmountOfBars.Size = new System.Drawing.Size(65, 20);
            this.textBoxAmountOfBars.TabIndex = 32;
            // 
            // textBoxVisualize
            // 
            this.textBoxVisualize.Enabled = false;
            this.textBoxVisualize.Location = new System.Drawing.Point(481, 10);
            this.textBoxVisualize.Name = "textBoxVisualize";
            this.textBoxVisualize.Size = new System.Drawing.Size(79, 20);
            this.textBoxVisualize.TabIndex = 31;
            // 
            // textBoxSleep
            // 
            this.textBoxSleep.Enabled = false;
            this.textBoxSleep.Location = new System.Drawing.Point(647, 10);
            this.textBoxSleep.Name = "textBoxSleep";
            this.textBoxSleep.Size = new System.Drawing.Size(59, 20);
            this.textBoxSleep.TabIndex = 30;
            // 
            // textBoxShuffleSp
            // 
            this.textBoxShuffleSp.Enabled = false;
            this.textBoxShuffleSp.Location = new System.Drawing.Point(847, 10);
            this.textBoxShuffleSp.Name = "textBoxShuffleSp";
            this.textBoxShuffleSp.Size = new System.Drawing.Size(50, 20);
            this.textBoxShuffleSp.TabIndex = 29;
            // 
            // textBoxSwaps
            // 
            this.textBoxSwaps.Enabled = false;
            this.textBoxSwaps.Location = new System.Drawing.Point(1011, 11);
            this.textBoxSwaps.Name = "textBoxSwaps";
            this.textBoxSwaps.Size = new System.Drawing.Size(83, 20);
            this.textBoxSwaps.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(906, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 18);
            this.label15.TabIndex = 26;
            this.label15.Text = "ms";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(747, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 18);
            this.label14.TabIndex = 25;
            this.label14.Text = "Shuffle speed";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(712, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 18);
            this.label13.TabIndex = 24;
            this.label13.Text = "ms";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(952, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 18);
            this.label8.TabIndex = 22;
            this.label8.Text = "Swaps";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(566, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "Sort sleep";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(320, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "Algorithms to visualize";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(190, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "Bars";
            // 
            // SHOWCASE_PANEL
            // 
            this.SHOWCASE_PANEL.Location = new System.Drawing.Point(262, 91);
            this.SHOWCASE_PANEL.Name = "SHOWCASE_PANEL";
            this.SHOWCASE_PANEL.Size = new System.Drawing.Size(1244, 591);
            this.SHOWCASE_PANEL.TabIndex = 14;
            // 
            // checkBoxBlack
            // 
            this.checkBoxBlack.AutoSize = true;
            this.checkBoxBlack.Location = new System.Drawing.Point(109, 739);
            this.checkBoxBlack.Name = "checkBoxBlack";
            this.checkBoxBlack.Size = new System.Drawing.Size(53, 17);
            this.checkBoxBlack.TabIndex = 15;
            this.checkBoxBlack.Text = "Black";
            this.checkBoxBlack.UseVisualStyleBackColor = true;
            this.checkBoxBlack.CheckedChanged += new System.EventHandler(this.CheckBoxBlack_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 740);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 13);
            this.label16.TabIndex = 16;
            this.label16.Text = "Background color";
            // 
            // checkBoxGray
            // 
            this.checkBoxGray.AutoSize = true;
            this.checkBoxGray.Location = new System.Drawing.Point(166, 739);
            this.checkBoxGray.Name = "checkBoxGray";
            this.checkBoxGray.Size = new System.Drawing.Size(48, 17);
            this.checkBoxGray.TabIndex = 17;
            this.checkBoxGray.Text = "Gray";
            this.checkBoxGray.UseVisualStyleBackColor = true;
            this.checkBoxGray.CheckedChanged += new System.EventHandler(this.CheckBoxGray_CheckedChanged);
            // 
            // checkBoxDarkBlue
            // 
            this.checkBoxDarkBlue.AutoSize = true;
            this.checkBoxDarkBlue.Location = new System.Drawing.Point(220, 739);
            this.checkBoxDarkBlue.Name = "checkBoxDarkBlue";
            this.checkBoxDarkBlue.Size = new System.Drawing.Size(72, 17);
            this.checkBoxDarkBlue.TabIndex = 18;
            this.checkBoxDarkBlue.Text = "Dark blue";
            this.checkBoxDarkBlue.UseVisualStyleBackColor = true;
            this.checkBoxDarkBlue.CheckedChanged += new System.EventHandler(this.CheckBoxDarkBlue_CheckedChanged);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 762);
            this.Controls.Add(this.checkBoxDarkBlue);
            this.Controls.Add(this.checkBoxGray);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.checkBoxBlack);
            this.Controls.Add(this.SHOWCASE_PANEL);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnStart);
            this.Name = "Start";
            this.Text = "SortingVisualizer";
            this.Load += new System.EventHandler(this.Start_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shuffleSleepTimeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleepTimeBar)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label lblFileName;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox InfoCheckBox;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button ResumeBtn;
        private System.Windows.Forms.TrackBar sleepTimeBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSleepStart;
        private System.Windows.Forms.TextBox textBoxShuffleSpeed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar shuffleSleepTimeBar;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBoxSerialize;
        private System.Windows.Forms.TextBox textBoxSwaps;
        private System.Windows.Forms.TextBox textBoxShuffleSp;
        private System.Windows.Forms.TextBox textBoxSleep;
        private System.Windows.Forms.TextBox textBoxVisualize;
        private System.Windows.Forms.TextBox textBoxAmountOfBars;
        private System.Windows.Forms.TextBox textBoxAlgorithmName;
        private System.Windows.Forms.Label LblHasBeenUsed;
        private System.Windows.Forms.Panel SHOWCASE_PANEL;
        private CheckBox checkBoxDarkBlue;
        private CheckBox checkBoxGray;
        private Label label16;
        private CheckBox checkBoxBlack;
    }
}

