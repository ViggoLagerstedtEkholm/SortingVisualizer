using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.Draw.Windows
{
    public class Controls : Form
    {
        private Button PauseBtn;
        private Label label3;
        private Button ResumeBtn;
        private TrackBar sleepTimeBar;
        private Button StopBtn;
        private CheckBox FullscreenCheckBox;
        private CheckBox InfoCheckBox;
        private readonly Window window;
        public Controls(Window window)
        {
            InitializeComponent();

            this.window = window;
        }

        private void InitializeComponent()
        {
            this.PauseBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ResumeBtn = new System.Windows.Forms.Button();
            this.sleepTimeBar = new System.Windows.Forms.TrackBar();
            this.StopBtn = new System.Windows.Forms.Button();
            this.FullscreenCheckBox = new System.Windows.Forms.CheckBox();
            this.InfoCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.sleepTimeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // PauseBtn
            // 
            this.PauseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PauseBtn.Location = new System.Drawing.Point(12, 12);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(180, 60);
            this.PauseBtn.TabIndex = 11;
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.UseVisualStyleBackColor = false;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 29);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sleep time";
            // 
            // ResumeBtn
            // 
            this.ResumeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ResumeBtn.Location = new System.Drawing.Point(198, 12);
            this.ResumeBtn.Name = "ResumeBtn";
            this.ResumeBtn.Size = new System.Drawing.Size(180, 60);
            this.ResumeBtn.TabIndex = 12;
            this.ResumeBtn.Text = "Resume";
            this.ResumeBtn.UseVisualStyleBackColor = false;
            this.ResumeBtn.Click += new System.EventHandler(this.ResumeBtn_Click);
            // 
            // sleepTimeBar
            // 
            this.sleepTimeBar.Location = new System.Drawing.Point(12, 185);
            this.sleepTimeBar.Maximum = 100;
            this.sleepTimeBar.Minimum = 1;
            this.sleepTimeBar.Name = "sleepTimeBar";
            this.sleepTimeBar.Size = new System.Drawing.Size(925, 45);
            this.sleepTimeBar.TabIndex = 14;
            this.sleepTimeBar.Value = 1;
            this.sleepTimeBar.Scroll += new System.EventHandler(this.SleepTimeBar_Scroll);
            // 
            // StopBtn
            // 
            this.StopBtn.BackColor = System.Drawing.Color.Silver;
            this.StopBtn.Location = new System.Drawing.Point(12, 78);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(187, 60);
            this.StopBtn.TabIndex = 13;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = false;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // FullscreenCheckBox
            // 
            this.FullscreenCheckBox.AutoSize = true;
            this.FullscreenCheckBox.Checked = true;
            this.FullscreenCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FullscreenCheckBox.Location = new System.Drawing.Point(418, 12);
            this.FullscreenCheckBox.Name = "FullscreenCheckBox";
            this.FullscreenCheckBox.Size = new System.Drawing.Size(74, 17);
            this.FullscreenCheckBox.TabIndex = 17;
            this.FullscreenCheckBox.Text = "Fullscreen";
            this.FullscreenCheckBox.UseVisualStyleBackColor = true;
            this.FullscreenCheckBox.CheckedChanged += new System.EventHandler(this.FullscreenCheckBox_CheckedChanged);
            // 
            // InfoCheckBox
            // 
            this.InfoCheckBox.AutoSize = true;
            this.InfoCheckBox.Checked = true;
            this.InfoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InfoCheckBox.Location = new System.Drawing.Point(418, 35);
            this.InfoCheckBox.Name = "InfoCheckBox";
            this.InfoCheckBox.Size = new System.Drawing.Size(44, 17);
            this.InfoCheckBox.TabIndex = 18;
            this.InfoCheckBox.Text = "Info";
            this.InfoCheckBox.UseVisualStyleBackColor = true;
            this.InfoCheckBox.CheckedChanged += new System.EventHandler(this.InfoCheckBox_CheckedChanged);
            // 
            // Controls
            // 
            this.ClientSize = new System.Drawing.Size(950, 280);
            this.Controls.Add(this.InfoCheckBox);
            this.Controls.Add(this.FullscreenCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sleepTimeBar);
            this.Controls.Add(this.PauseBtn);
            this.Controls.Add(this.ResumeBtn);
            this.Controls.Add(this.StopBtn);
            this.Name = "Controls";
            this.Text = "Control panel";
            ((System.ComponentModel.ISupportInitialize)(this.sleepTimeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            PauseBtn.Enabled = false;
            ResumeBtn.Enabled = true;
            window.SetPause();
        }
        private void ResumeBtn_Click(object sender, EventArgs e)
        {
            ResumeBtn.Enabled = false;
            PauseBtn.Enabled = true;
            window.SetResume();
        }
        private void StopBtn_Click(object sender, EventArgs e)
        {
            window.StopSorting();
        }

        private void SleepTimeBar_Scroll(object sender, EventArgs e)
        {
            int t = sleepTimeBar.Value;

            window.GetCurrentAlgorithm().SleepTime = t;
        }

        private void FullscreenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            window.Toggle_FULLSCREEN();
            BringToFront();
        }

        private void InfoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            window.Toggle_Info();
        }
    }
}
