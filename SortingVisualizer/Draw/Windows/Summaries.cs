using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.Draw.Windows
{
    public partial class Summaries : Form
    {
        private readonly BindingSource summariesBindingSource = new BindingSource();
        private readonly Session Session;
        public Summaries(Session session)
        {
            InitializeComponent();
            Session = session;
            UpdateSummaries();
        }
        public void UpdateSummaries()
        {
            Clear();

            foreach (SortSummary session in Session.SortSummaries)
            {
                summariesBindingSource.Add(session);
            }

            dataGridSummary.DataSource = summariesBindingSource;
        }
        public void Clear()
        {
            dataGridSummary.Rows.Clear();
            dataGridSummary.Refresh();
            summariesBindingSource.Clear();
        }

        private void DataGridSummary_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            SortSummary summary = (SortSummary)dataGridSummary.CurrentRow.DataBoundItem;

            textBoxAlgorithmName.Text = summary.Name;
            textBoxDate.Text = Session.Date.ToString();

            for(int i = 0; i < summary.UnsortedArray.Length; i++)
            {
                listBoxUnsorted.Items.Add(summary.UnsortedArray[i].ToString());
            }
            for (int i = 0; i < summary.SortedArray.Length; i++)
            {
                listBoxSorted.Items.Add(summary.SortedArray[i].ToString());
            }

            textBoxSwap.Text = summary.Iterations.ToString();
            textBoxSession.Text = Session.Name;
        }
    }
}
