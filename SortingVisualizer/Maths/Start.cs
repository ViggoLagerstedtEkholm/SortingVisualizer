using SortingVisualizer.Validate;
using SortingVisualizer.Algorithms;
using SortingVisualizer.Maths;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualizer.Draw
{
    public partial class Start : Form
    {

        public Start()
        {
            InitializeComponent();
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Has integer?: " + Validator.TxfHasInteger(MinTxf) + " Has integer?: " +
            Validator.TxfHasInteger(MaxTxf) + " Has integer?: " + Validator.TxfHasInteger(BarCountTxf));

            if (Validator.CheckBoxListHasValue(AlgorithmsList) && 
            (Validator.TxfHasInteger(MinTxf) && Validator.TxfHasInteger(MaxTxf) && Validator.TxfHasInteger(BarCountTxf)) &&
            (Validator.TxfHasContent(MinTxf) && Validator.TxfHasContent(MaxTxf) && Validator.TxfHasContent(BarCountTxf)))
            {
      
                
                List<string> algorithms = new List<string>();
                int bars = Int32.Parse(BarCountTxf.Text);
                int min = Int32.Parse(MinTxf.Text);
                int max = Int32.Parse(MaxTxf.Text);
                Window window = new Window("SortingVisualizer");

                for (int i = 0; i < AlgorithmsList.Items.Count; i++)
                {
                    if (AlgorithmsList.GetItemChecked(i))
                    {
                        string str = (string)AlgorithmsList.Items[i];

                        algorithms.Add(str);
                    }
                }
                Console.WriteLine("Count: " + algorithms.Count);
                window.EnqueueItems(algorithms);
                window.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Make sure you only use integers with min/max/barCount and have selected atleast 1 algorithm!", "SortingVisaulizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
