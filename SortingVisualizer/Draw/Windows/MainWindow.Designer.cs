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
            this.label1 = new System.Windows.Forms.Label();
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
            this.SHOWCASE_PANEL = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.sleepTimeBar = new System.Windows.Forms.TrackBar();
            this.InfoCheckBox = new System.Windows.Forms.CheckBox();
            this.FullscreenCheckBox = new System.Windows.Forms.CheckBox();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.ResumeBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LblAlgorithmName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblElapsedTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblAmountOfBars = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblVisualize = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LblSleep = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblSwaps = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sleepTimeBar)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.radioButton4);
            this.panel5.Controls.Add(this.radioButton3);
            this.panel5.Controls.Add(this.radioButton2);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Location = new System.Drawing.Point(13, 109);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(242, 194);
            this.panel5.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "No path detected";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(9, 158);
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
            this.radioButton3.Location = new System.Drawing.Point(9, 135);
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
            this.radioButton2.Location = new System.Drawing.Point(8, 112);
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
            this.button1.Location = new System.Drawing.Point(5, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 34);
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
            this.panel3.Location = new System.Drawing.Point(13, 309);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 392);
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
            this.AlgorithmsList.Size = new System.Drawing.Size(224, 169);
            this.AlgorithmsList.TabIndex = 1;
            this.AlgorithmsList.SelectedIndexChanged += new System.EventHandler(this.AlgorithmsList_SelectedIndexChanged);
            // 
            // selectedAlgorithmListBox
            // 
            this.selectedAlgorithmListBox.FormattingEnabled = true;
            this.selectedAlgorithmListBox.Location = new System.Drawing.Point(8, 193);
            this.selectedAlgorithmListBox.Name = "selectedAlgorithmListBox";
            this.selectedAlgorithmListBox.Size = new System.Drawing.Size(225, 134);
            this.selectedAlgorithmListBox.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 707);
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
            this.panel2.Controls.Add(this.BarAmount);
            this.panel2.Controls.Add(this.BarCountTxf);
            this.panel2.Location = new System.Drawing.Point(12, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 72);
            this.panel2.TabIndex = 8;
            // 
            // BarAmount
            // 
            this.BarAmount.AutoSize = true;
            this.BarAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarAmount.Location = new System.Drawing.Point(3, 10);
            this.BarAmount.Name = "BarAmount";
            this.BarAmount.Size = new System.Drawing.Size(104, 25);
            this.BarAmount.TabIndex = 4;
            this.BarAmount.Text = "Bar count";
            // 
            // BarCountTxf
            // 
            this.BarCountTxf.Location = new System.Drawing.Point(9, 38);
            this.BarCountTxf.Name = "BarCountTxf";
            this.BarCountTxf.Size = new System.Drawing.Size(220, 20);
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
            // SHOWCASE_PANEL
            // 
            this.SHOWCASE_PANEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SHOWCASE_PANEL.Location = new System.Drawing.Point(262, 109);
            this.SHOWCASE_PANEL.Name = "SHOWCASE_PANEL";
            this.SHOWCASE_PANEL.Size = new System.Drawing.Size(1244, 592);
            this.SHOWCASE_PANEL.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1518, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.sleepTimeBar);
            this.panel1.Controls.Add(this.InfoCheckBox);
            this.panel1.Controls.Add(this.FullscreenCheckBox);
            this.panel1.Controls.Add(this.PauseBtn);
            this.panel1.Controls.Add(this.ResumeBtn);
            this.panel1.Location = new System.Drawing.Point(262, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 72);
            this.panel1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(565, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Sleep time";
            // 
            // sleepTimeBar
            // 
            this.sleepTimeBar.Location = new System.Drawing.Point(655, 10);
            this.sleepTimeBar.Maximum = 100;
            this.sleepTimeBar.Minimum = 1;
            this.sleepTimeBar.Name = "sleepTimeBar";
            this.sleepTimeBar.Size = new System.Drawing.Size(584, 45);
            this.sleepTimeBar.TabIndex = 23;
            this.sleepTimeBar.Value = 1;
            this.sleepTimeBar.Scroll += new System.EventHandler(this.SleepTimeBar_Scroll);
            // 
            // InfoCheckBox
            // 
            this.InfoCheckBox.AutoSize = true;
            this.InfoCheckBox.Checked = true;
            this.InfoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InfoCheckBox.Location = new System.Drawing.Point(375, 18);
            this.InfoCheckBox.Name = "InfoCheckBox";
            this.InfoCheckBox.Size = new System.Drawing.Size(44, 17);
            this.InfoCheckBox.TabIndex = 22;
            this.InfoCheckBox.Text = "Info";
            this.InfoCheckBox.UseVisualStyleBackColor = true;
            this.InfoCheckBox.CheckedChanged += new System.EventHandler(this.InfoCheckBox_CheckedChanged);
            // 
            // FullscreenCheckBox
            // 
            this.FullscreenCheckBox.AutoSize = true;
            this.FullscreenCheckBox.Location = new System.Drawing.Point(375, 41);
            this.FullscreenCheckBox.Name = "FullscreenCheckBox";
            this.FullscreenCheckBox.Size = new System.Drawing.Size(74, 17);
            this.FullscreenCheckBox.TabIndex = 21;
            this.FullscreenCheckBox.Text = "Fullscreen";
            this.FullscreenCheckBox.UseVisualStyleBackColor = true;
            this.FullscreenCheckBox.CheckedChanged += new System.EventHandler(this.FullscreenCheckBox_CheckedChanged);
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
            this.panel4.Controls.Add(this.LblSwaps);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.LblSleep);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.LblVisualize);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.LblAmountOfBars);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.LblElapsedTime);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.LblAlgorithmName);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(262, 707);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1244, 43);
            this.panel4.TabIndex = 13;
            // 
            // LblAlgorithmName
            // 
            this.LblAlgorithmName.AutoSize = true;
            this.LblAlgorithmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAlgorithmName.Location = new System.Drawing.Point(79, 10);
            this.LblAlgorithmName.Name = "LblAlgorithmName";
            this.LblAlgorithmName.Size = new System.Drawing.Size(161, 18);
            this.LblAlgorithmName.TabIndex = 13;
            this.LblAlgorithmName.Text = "ALGORITHM_NAME";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(246, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Elapsed time";
            // 
            // LblElapsedTime
            // 
            this.LblElapsedTime.AutoSize = true;
            this.LblElapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblElapsedTime.Location = new System.Drawing.Point(345, 10);
            this.LblElapsedTime.Name = "LblElapsedTime";
            this.LblElapsedTime.Size = new System.Drawing.Size(131, 18);
            this.LblElapsedTime.TabIndex = 15;
            this.LblElapsedTime.Text = "ELAPSED_TIME";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(482, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "Bars";
            // 
            // LblAmountOfBars
            // 
            this.LblAmountOfBars.AutoSize = true;
            this.LblAmountOfBars.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAmountOfBars.Location = new System.Drawing.Point(527, 10);
            this.LblAmountOfBars.Name = "LblAmountOfBars";
            this.LblAmountOfBars.Size = new System.Drawing.Size(164, 18);
            this.LblAmountOfBars.TabIndex = 17;
            this.LblAmountOfBars.Text = "AMOUNT_OF_BARS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(697, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "Algorithms to visualize";
            // 
            // LblVisualize
            // 
            this.LblVisualize.AutoSize = true;
            this.LblVisualize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVisualize.Location = new System.Drawing.Point(858, 10);
            this.LblVisualize.Name = "LblVisualize";
            this.LblVisualize.Size = new System.Drawing.Size(121, 18);
            this.LblVisualize.TabIndex = 19;
            this.LblVisualize.Text = "TO_VISUALIZE";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(985, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "Sleep";
            // 
            // LblSleep
            // 
            this.LblSleep.AutoSize = true;
            this.LblSleep.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSleep.Location = new System.Drawing.Point(1036, 10);
            this.LblSleep.Name = "LblSleep";
            this.LblSleep.Size = new System.Drawing.Size(61, 18);
            this.LblSleep.TabIndex = 21;
            this.LblSleep.Text = "SLEEP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1103, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 18);
            this.label8.TabIndex = 22;
            this.label8.Text = "Swaps";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // LblSwaps
            // 
            this.LblSwaps.AutoSize = true;
            this.LblSwaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSwaps.Location = new System.Drawing.Point(1162, 9);
            this.LblSwaps.Name = "LblSwaps";
            this.LblSwaps.Size = new System.Drawing.Size(67, 18);
            this.LblSwaps.TabIndex = 23;
            this.LblSwaps.Text = "SWAPS";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "File name";
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 762);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SHOWCASE_PANEL);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnStart);
            this.MainMenuStrip = this.menuStrip1;
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel SHOWCASE_PANEL;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox InfoCheckBox;
        private System.Windows.Forms.CheckBox FullscreenCheckBox;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button ResumeBtn;
        private System.Windows.Forms.TrackBar sleepTimeBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LblSleep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblVisualize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblAmountOfBars;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblElapsedTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblAlgorithmName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblSwaps;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
    }
}

