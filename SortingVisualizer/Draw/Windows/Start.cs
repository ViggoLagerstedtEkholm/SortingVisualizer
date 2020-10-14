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
using SortingVisualizer.Draw.Windows;

namespace SortingVisualizer.Draw
{
    public partial class Start : Form
    {
        /// <summary>
        /// Note to self: Give the user the option to select different pattern of values, the sine wave for example.
        /// </summary>
        /// 
        private List<ISortAlgorithms> existingAlgorithms;
        private readonly int sleepTime = 10;
        private readonly string[] algorithms = { "Bubble sort", "Selection sort", "Heap sort", "Merge sort", "Quick sort", "Insertion sort",
                                                "Cocktail sort", "Shell sort", "Comb sort", "Cycle sort", "Stooge sort"};
        private SortingHandler sortingHandler;
        Window window;
        public Start()
        {
            InitializeComponent();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            AlgorithmsList.Items.AddRange(algorithms);
            AlgorithmsList.CheckOnClick = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Has integer?: " + Validator.TxfHasInteger(MinTxf) + " Has integer?: " +
            Validator.TxfHasInteger(MaxTxf) + " Has integer?: " + Validator.TxfHasInteger(BarCountTxf));

            if (Validator.CheckBoxListHasValue(AlgorithmsList) && 
            (Validator.TxfHasInteger(MinTxf) && Validator.TxfHasInteger(MaxTxf) && Validator.TxfHasInteger(BarCountTxf)) &&
            (Validator.TxfHasContent(MinTxf) && Validator.TxfHasContent(MaxTxf) && Validator.TxfHasContent(BarCountTxf)))
            {
                int bars = Int32.Parse(BarCountTxf.Text);
                int min = Int32.Parse(MinTxf.Text);
                int max = Int32.Parse(MaxTxf.Text);

                if((Validator.MinMax(min, max)))
                {
                    window = new Window("SortingVisualizer", bars, min, max);
                    existingAlgorithms = new List<ISortAlgorithms>();
                    fillAlgotihms();
                    sortingHandler = new SortingHandler(existingAlgorithms, window);
                    window.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Min is greater than max! Make min value less than max...", "SortingVisaulizer", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Make sure you only use integers with min/max/barCount and have selected atleast 1 algorithm!", "SortingVisaulizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillAlgotihms()
        {
            foreach (object itemChecked in AlgorithmsList.CheckedItems)
            {
                switch (itemChecked.ToString())
                {
                    case "Bubble sort":
                        existingAlgorithms.Add(new BubbleSort(2, window));
                        break;
                    case "Selection sort":
                        existingAlgorithms.Add(new SelectionSort(2, window));
                        break;
                    case "Heap sort":
                        existingAlgorithms.Add(new HeapSort(2, window));
                        break;
                    case "Merge sort":
                        existingAlgorithms.Add(new MergeSort(2, window));
                        break;
                    case "Quick sort":
                        existingAlgorithms.Add(new QuickSort(2, window));
                        break;
                    case "Insertion sort":
                        existingAlgorithms.Add(new InsertionSort(2, window));
                        break;
                    case "Cocktail sort":
                        existingAlgorithms.Add(new CocktailSort(2, window));
                        break;
                    case "Shell sort":
                        existingAlgorithms.Add(new ShellSort(2, window));
                        break;
                    case "Comb sort":
                        existingAlgorithms.Add(new CombSort(2, window));
                        break;
                    case "Cycle sort":
                        existingAlgorithms.Add(new CycleSort(2, window));
                        break;
                    case "Stooge sort":
                        existingAlgorithms.Add(new StoogeSort(2, window));
                        break;
                }
            }
        }

        private void AlgorithmsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAlgorithmListBox.Items.Clear();
            for (int i = 0; i < AlgorithmsList.CheckedItems.Count; i++)
            {
                selectedAlgorithmListBox.Items.Add(AlgorithmsList.CheckedItems[i]);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
