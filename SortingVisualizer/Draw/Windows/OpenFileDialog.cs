using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.Draw.Windows
{
    public class OpenFileDialogForm : Form
    {
        private Button BtnChooseSummary;
        private readonly OpenFileDialog openFileDialog1;
        public OpenFileDialogForm()
        {
            InitializeComponent();

            Console.WriteLine("Opened file chooser!");
            openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "XML Files|*.xml",
                Title = "Open text file"
            };
        }
        private void BtnChooseSummary_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        Process.Start("notepad.exe", filePath);
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void InitializeComponent()
        {
            this.BtnChooseSummary = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnChooseSummary
            // 
            this.BtnChooseSummary.Location = new System.Drawing.Point(13, 13);
            this.BtnChooseSummary.Name = "BtnChooseSummary";
            this.BtnChooseSummary.Size = new System.Drawing.Size(209, 55);
            this.BtnChooseSummary.TabIndex = 0;
            this.BtnChooseSummary.Text = "Load";
            this.BtnChooseSummary.UseVisualStyleBackColor = true;
            this.BtnChooseSummary.Click += new System.EventHandler(this.BtnChooseSummary_Click);
            // 
            // OpenFileDialogForm
            // 
            this.ClientSize = new System.Drawing.Size(1189, 568);
            this.Controls.Add(this.BtnChooseSummary);
            this.Name = "OpenFileDialogForm";
            this.ResumeLayout(false);

        }

    }
}
