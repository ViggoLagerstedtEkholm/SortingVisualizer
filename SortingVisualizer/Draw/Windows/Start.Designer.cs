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
            this.label3 = new System.Windows.Forms.Label();
            this.sleepTimeBar = new System.Windows.Forms.TrackBar();
            this.StopBtn = new System.Windows.Forms.Button();
            this.ResumeBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.AlgorithmsList = new System.Windows.Forms.CheckedListBox();
            this.selectedAlgorithmListBox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MaxTxf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BarAmount = new System.Windows.Forms.Label();
            this.BarCountTxf = new System.Windows.Forms.TextBox();
            this.MinTxf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SortingPanel = new System.Windows.Forms.Panel();
            this.sineWave = new System.Windows.Forms.RadioButton();
            this.regularArray = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sleepTimeBar)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.sleepTimeBar);
            this.panel1.Controls.Add(this.StopBtn);
            this.panel1.Controls.Add(this.ResumeBtn);
            this.panel1.Controls.Add(this.PauseBtn);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(1277, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 937);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sleep time";
            // 
            // sleepTimeBar
            // 
            this.sleepTimeBar.Location = new System.Drawing.Point(255, 147);
            this.sleepTimeBar.Maximum = 100;
            this.sleepTimeBar.Minimum = 1;
            this.sleepTimeBar.Name = "sleepTimeBar";
            this.sleepTimeBar.Size = new System.Drawing.Size(116, 45);
            this.sleepTimeBar.TabIndex = 14;
            this.sleepTimeBar.Value = 1;
            this.sleepTimeBar.Scroll += new System.EventHandler(this.sleepTimeBar_Scroll);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(255, 78);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(126, 23);
            this.StopBtn.TabIndex = 13;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // ResumeBtn
            // 
            this.ResumeBtn.Location = new System.Drawing.Point(255, 45);
            this.ResumeBtn.Name = "ResumeBtn";
            this.ResumeBtn.Size = new System.Drawing.Size(126, 23);
            this.ResumeBtn.TabIndex = 12;
            this.ResumeBtn.Text = "Resume";
            this.ResumeBtn.UseVisualStyleBackColor = true;
            this.ResumeBtn.Click += new System.EventHandler(this.ResumeBtn_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.Location = new System.Drawing.Point(255, 16);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(126, 23);
            this.PauseBtn.TabIndex = 11;
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.btnStart);
            this.panel4.Location = new System.Drawing.Point(14, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(235, 929);
            this.panel4.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.regularArray);
            this.panel3.Controls.Add(this.sineWave);
            this.panel3.Controls.Add(this.AlgorithmsList);
            this.panel3.Controls.Add(this.selectedAlgorithmListBox);
            this.panel3.Location = new System.Drawing.Point(14, 184);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(208, 674);
            this.panel3.TabIndex = 1;
            // 
            // AlgorithmsList
            // 
            this.AlgorithmsList.FormattingEnabled = true;
            this.AlgorithmsList.Location = new System.Drawing.Point(15, 19);
            this.AlgorithmsList.Name = "AlgorithmsList";
            this.AlgorithmsList.Size = new System.Drawing.Size(173, 274);
            this.AlgorithmsList.TabIndex = 1;
            this.AlgorithmsList.SelectedIndexChanged += new System.EventHandler(this.AlgorithmsList_SelectedIndexChanged);
            // 
            // selectedAlgorithmListBox
            // 
            this.selectedAlgorithmListBox.FormattingEnabled = true;
            this.selectedAlgorithmListBox.Location = new System.Drawing.Point(15, 314);
            this.selectedAlgorithmListBox.Name = "selectedAlgorithmListBox";
            this.selectedAlgorithmListBox.Size = new System.Drawing.Size(173, 225);
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
            this.panel2.Location = new System.Drawing.Point(14, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 165);
            this.panel2.TabIndex = 8;
            // 
            // MaxTxf
            // 
            this.MaxTxf.Location = new System.Drawing.Point(6, 83);
            this.MaxTxf.Name = "MaxTxf";
            this.MaxTxf.Size = new System.Drawing.Size(193, 20);
            this.MaxTxf.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Min";
            // 
            // BarAmount
            // 
            this.BarAmount.AutoSize = true;
            this.BarAmount.Location = new System.Drawing.Point(3, 114);
            this.BarAmount.Name = "BarAmount";
            this.BarAmount.Size = new System.Drawing.Size(53, 13);
            this.BarAmount.TabIndex = 4;
            this.BarAmount.Text = "Bar count";
            // 
            // BarCountTxf
            // 
            this.BarCountTxf.Location = new System.Drawing.Point(6, 130);
            this.BarCountTxf.Name = "BarCountTxf";
            this.BarCountTxf.Size = new System.Drawing.Size(193, 20);
            this.BarCountTxf.TabIndex = 2;
            // 
            // MinTxf
            // 
            this.MinTxf.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.MinTxf.Location = new System.Drawing.Point(6, 34);
            this.MinTxf.Name = "MinTxf";
            this.MinTxf.Size = new System.Drawing.Size(193, 20);
            this.MinTxf.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Max";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(14, 864);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(202, 62);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // SortingPanel
            // 
            this.SortingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SortingPanel.Location = new System.Drawing.Point(12, 12);
            this.SortingPanel.Name = "SortingPanel";
            this.SortingPanel.Size = new System.Drawing.Size(1259, 937);
            this.SortingPanel.TabIndex = 1;
            // 
            // sineWave
            // 
            this.sineWave.AutoSize = true;
            this.sineWave.Location = new System.Drawing.Point(15, 545);
            this.sineWave.Name = "sineWave";
            this.sineWave.Size = new System.Drawing.Size(75, 17);
            this.sineWave.TabIndex = 2;
            this.sineWave.TabStop = true;
            this.sineWave.Text = "Sine wave";
            this.sineWave.UseVisualStyleBackColor = true;
            this.sineWave.CheckedChanged += new System.EventHandler(this.sineWave_CheckedChanged);
            // 
            // regularArray
            // 
            this.regularArray.AutoSize = true;
            this.regularArray.Location = new System.Drawing.Point(103, 545);
            this.regularArray.Name = "regularArray";
            this.regularArray.Size = new System.Drawing.Size(62, 17);
            this.regularArray.TabIndex = 3;
            this.regularArray.TabStop = true;
            this.regularArray.Text = "Regular";
            this.regularArray.UseVisualStyleBackColor = true;
            this.regularArray.CheckedChanged += new System.EventHandler(this.regularArray_CheckedChanged);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1675, 961);
            this.Controls.Add(this.SortingPanel);
            this.Controls.Add(this.panel1);
            this.Name = "Start";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Start_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sleepTimeBar)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
    }
}

