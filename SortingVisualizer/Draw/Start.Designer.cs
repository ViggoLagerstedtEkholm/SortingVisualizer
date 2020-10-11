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
            this.panel4 = new System.Windows.Forms.Panel();
            this.AlgorithmsList = new System.Windows.Forms.CheckedListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.MinTxf = new System.Windows.Forms.TextBox();
            this.BarCountTxf = new System.Windows.Forms.TextBox();
            this.BarAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MaxTxf = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 488);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.AlgorithmsList);
            this.panel4.Location = new System.Drawing.Point(242, 14);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 377);
            this.panel4.TabIndex = 10;
            // 
            // AlgorithmsList
            // 
            this.AlgorithmsList.FormattingEnabled = true;
            this.AlgorithmsList.Items.AddRange(new object[] {
            "Bubble sort",
            "Selection sort",
            "Heap sort",
            "Merge sort",
            "Quick sort",
            "Insertion sort",
            "Cocktail sort",
            "Shell sort",
            "Comb sort",
            "Cycle sort",
            "Pigeonhole sort",
            "Stooge sort"});
            this.AlgorithmsList.Location = new System.Drawing.Point(14, 16);
            this.AlgorithmsList.Name = "AlgorithmsList";
            this.AlgorithmsList.Size = new System.Drawing.Size(168, 349);
            this.AlgorithmsList.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(274, 397);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(168, 67);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(11, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 377);
            this.panel3.TabIndex = 9;
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
            // MinTxf
            // 
            this.MinTxf.Location = new System.Drawing.Point(6, 34);
            this.MinTxf.Name = "MinTxf";
            this.MinTxf.Size = new System.Drawing.Size(177, 20);
            this.MinTxf.TabIndex = 3;
            // 
            // BarCountTxf
            // 
            this.BarCountTxf.Location = new System.Drawing.Point(6, 130);
            this.BarCountTxf.Name = "BarCountTxf";
            this.BarCountTxf.Size = new System.Drawing.Size(177, 20);
            this.BarCountTxf.TabIndex = 2;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Min";
            // 
            // MaxTxf
            // 
            this.MaxTxf.Location = new System.Drawing.Point(6, 83);
            this.MaxTxf.Name = "MaxTxf";
            this.MaxTxf.Size = new System.Drawing.Size(177, 20);
            this.MaxTxf.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MaxTxf);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BarAmount);
            this.panel2.Controls.Add(this.BarCountTxf);
            this.panel2.Controls.Add(this.MinTxf);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 165);
            this.panel2.TabIndex = 8;
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 512);
            this.Controls.Add(this.panel1);
            this.Name = "Start";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Start_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox MaxTxf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BarAmount;
        private System.Windows.Forms.TextBox BarCountTxf;
        private System.Windows.Forms.TextBox MinTxf;
        private System.Windows.Forms.Label label2;
    }
}

