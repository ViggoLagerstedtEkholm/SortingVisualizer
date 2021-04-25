
namespace WindowsFormsApp2.Draw.Windows
{
    partial class Summaries
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
            this.dataGridSummary = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxUnsorted = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxSorted = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.textBoxSwap = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAlgorithmName = new System.Windows.Forms.TextBox();
            this.textBoxSession = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridSummary
            // 
            this.dataGridSummary.AllowUserToAddRows = false;
            this.dataGridSummary.AllowUserToResizeColumns = false;
            this.dataGridSummary.AllowUserToResizeRows = false;
            this.dataGridSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridSummary.BackgroundColor = System.Drawing.Color.White;
            this.dataGridSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridSummary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridSummary.ColumnHeadersHeight = 50;
            this.dataGridSummary.GridColor = System.Drawing.Color.White;
            this.dataGridSummary.Location = new System.Drawing.Point(11, 28);
            this.dataGridSummary.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridSummary.Name = "dataGridSummary";
            this.dataGridSummary.ReadOnly = true;
            this.dataGridSummary.RowHeadersVisible = false;
            this.dataGridSummary.RowHeadersWidth = 250;
            this.dataGridSummary.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridSummary.RowTemplate.Height = 24;
            this.dataGridSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridSummary.Size = new System.Drawing.Size(728, 170);
            this.dataGridSummary.TabIndex = 6;
            this.dataGridSummary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridSummary_CellClick_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Summaries";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Session";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Date";
            // 
            // listBoxUnsorted
            // 
            this.listBoxUnsorted.FormattingEnabled = true;
            this.listBoxUnsorted.Location = new System.Drawing.Point(11, 312);
            this.listBoxUnsorted.Name = "listBoxUnsorted";
            this.listBoxUnsorted.Size = new System.Drawing.Size(727, 82);
            this.listBoxUnsorted.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Unsorted array";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sorted array";
            // 
            // listBoxSorted
            // 
            this.listBoxSorted.FormattingEnabled = true;
            this.listBoxSorted.Location = new System.Drawing.Point(11, 424);
            this.listBoxSorted.Name = "listBoxSorted";
            this.listBoxSorted.Size = new System.Drawing.Size(727, 95);
            this.listBoxSorted.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 535);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Swaps";
            // 
            // textBoxDate
            // 
            this.textBoxDate.Enabled = false;
            this.textBoxDate.Location = new System.Drawing.Point(44, 235);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(100, 20);
            this.textBoxDate.TabIndex = 15;
            // 
            // textBoxSwap
            // 
            this.textBoxSwap.Enabled = false;
            this.textBoxSwap.Location = new System.Drawing.Point(53, 532);
            this.textBoxSwap.Name = "textBoxSwap";
            this.textBoxSwap.Size = new System.Drawing.Size(100, 20);
            this.textBoxSwap.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Algorithm name";
            // 
            // textBoxAlgorithmName
            // 
            this.textBoxAlgorithmName.Enabled = false;
            this.textBoxAlgorithmName.Location = new System.Drawing.Point(93, 267);
            this.textBoxAlgorithmName.Name = "textBoxAlgorithmName";
            this.textBoxAlgorithmName.Size = new System.Drawing.Size(100, 20);
            this.textBoxAlgorithmName.TabIndex = 18;
            // 
            // textBoxSession
            // 
            this.textBoxSession.Enabled = false;
            this.textBoxSession.Location = new System.Drawing.Point(53, 203);
            this.textBoxSession.Name = "textBoxSession";
            this.textBoxSession.Size = new System.Drawing.Size(100, 20);
            this.textBoxSession.TabIndex = 19;
            // 
            // Summaries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 586);
            this.Controls.Add(this.textBoxSession);
            this.Controls.Add(this.textBoxAlgorithmName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxSwap);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBoxSorted);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxUnsorted);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridSummary);
            this.Name = "Summaries";
            this.Text = "Summaries";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridSummary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxUnsorted;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxSorted;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.TextBox textBoxSwap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAlgorithmName;
        private System.Windows.Forms.TextBox textBoxSession;
    }
}