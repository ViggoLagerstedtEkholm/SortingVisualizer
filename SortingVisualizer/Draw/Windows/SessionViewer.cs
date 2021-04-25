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
using WindowsFormsApp2.IO;

namespace WindowsFormsApp2.Draw.Windows
{
    public class SessionViewer : Form
    {
        private DataGridView dataGridSessions;
        private Label label1;
        private readonly BindingSource sessionsBindingSource = new BindingSource();
        private readonly List<string> files = new List<string>();
        private readonly Serialize Serialier;
        public SessionViewer(Serialize serializer)
        {
            InitializeComponent();
            Serialier = serializer;
            UpdateSessions();
        }

        public void UpdateSessions()
        {
            Clear();

            foreach (Session session in GetSessions())
            {
                sessionsBindingSource.Add(session);
            }
            dataGridSessions.DataSource = sessionsBindingSource;
            files.Clear();
        }

        public List<Session> GetSessions()
        {
            foreach (string f in Directory.GetFiles(Serialier.DirectoryPath))
            {
                files.Add(f);
            }

            List<Session> sessions = Serialier.DeSerializeObjects(files);
            return sessions;
        }

        public void Clear()
        {
            dataGridSessions.Rows.Clear();
            dataGridSessions.Refresh();
            sessionsBindingSource.Clear();
        }

        private void DataGridSessions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Session session = (Session)dataGridSessions.CurrentRow.DataBoundItem;

            new Summaries(session).Show();
        }

        private void InitializeComponent()
        {
            this.dataGridSessions = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSessions)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridSessions
            // 
            this.dataGridSessions.AllowUserToAddRows = false;
            this.dataGridSessions.AllowUserToResizeColumns = false;
            this.dataGridSessions.AllowUserToResizeRows = false;
            this.dataGridSessions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridSessions.BackgroundColor = System.Drawing.Color.White;
            this.dataGridSessions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridSessions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridSessions.ColumnHeadersHeight = 50;
            this.dataGridSessions.GridColor = System.Drawing.Color.White;
            this.dataGridSessions.Location = new System.Drawing.Point(11, 37);
            this.dataGridSessions.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridSessions.Name = "dataGridSessions";
            this.dataGridSessions.ReadOnly = true;
            this.dataGridSessions.RowHeadersVisible = false;
            this.dataGridSessions.RowHeadersWidth = 250;
            this.dataGridSessions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridSessions.RowTemplate.Height = 24;
            this.dataGridSessions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridSessions.Size = new System.Drawing.Size(1167, 510);
            this.dataGridSessions.TabIndex = 5;
            this.dataGridSessions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridSessions_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Saved sessions";
            // 
            // SessionViewer
            // 
            this.ClientSize = new System.Drawing.Size(1189, 568);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridSessions);
            this.Name = "SessionViewer";
            this.Text = "SessionViewer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSessions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
