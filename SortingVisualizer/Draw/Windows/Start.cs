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
using static System.Windows.Forms.CheckedListBox;

namespace SortingVisualizer.Draw
{
    public partial class Start : Form
    {
        /// <summary>
        /// Note to self: Give the user the option to select different pattern of values, the sine wave for example.
        /// </summary>

        private readonly string[] algorithms = { "Bubble sort", "Selection sort", "Heap sort", "Merge sort", "Quick sort", "Insertion sort",
                                                "Cocktail sort", "Shell sort", "Comb sort", "Cycle sort", "Stooge sort"};
        private SortingHandler sortingHandler;
        private List<ISortAlgorithms> queueHandler;
        private List<RadioButton> radioButtons;
        private bool fullscreen;

        Window window;
        public Start()
        {
            InitializeComponent();
            StopBtn.Enabled = false;
            ResumeBtn.Enabled = false;
            radioButtons = new List<RadioButton>();
            radioButtons.Add(regularArray);
            radioButtons.Add(sineWave);
            //Closing += (obj, e) => sound.Stop();
            this.queueHandler = new List<ISortAlgorithms>();
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


                if ((Validator.MinMax(min, max)))
                {
                    for(int i = 0; i < radioButtons.Count; i++)
                    {
                        if (radioButtons[i].Checked)
                        {
                            if (fullscreenCheckbox.Checked)
                            {
                                window = new Window("SortingVisualizer", bars, min, max, new Vector2D(1920, 1080), radioButtons[i]);
                                fillAlgotihms();
                                sortingHandler = new SortingHandler(queueHandler, window);
                                window.SET_FULLSCREEN();
                                this.Hide();
                                window.Show();
                                StopBtn.Enabled = true;
                            }
                            else
                            {
                                window = new Window("SortingVisualizer", bars, min, max, new Vector2D(SortingPanel.Width, SortingPanel.Height), radioButtons[i]);
                                window.TopLevel = false;

                                fillAlgotihms();
                                sortingHandler = new SortingHandler(queueHandler, window);

                                this.SortingPanel.Controls.Add(window);
                                window.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                                window.Dock = DockStyle.Fill;
                                window.Show();
                                StopBtn.Enabled = true;
                            }

                            //window.Show();
                            //this.Hide();
                        }
                    }
  
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
                        queueHandler.Add(new BubbleSort(2, window));
                        break;
                    case "Selection sort":
                        queueHandler.Add(new SelectionSort(2, window));
                        break;
                    case "Heap sort":
                        queueHandler.Add(new HeapSort(2, window));
                        break;
                    case "Merge sort":
                        queueHandler.Add(new MergeSort(2, window));
                        break;
                    case "Quick sort":
                        queueHandler.Add(new QuickSort(2, window));
                        break;
                    case "Insertion sort":
                        queueHandler.Add(new InsertionSort(2, window));
                        break;
                    case "Cocktail sort":
                        queueHandler.Add(new CocktailSort(2, window));
                        break;
                    case "Shell sort":
                        queueHandler.Add(new ShellSort(2, window));
                        break;
                    case "Comb sort":
                        queueHandler.Add(new CombSort(2, window));
                        break;
                    case "Cycle sort":
                        queueHandler.Add(new CycleSort(2, window));
                        break;
                    case "Stooge sort":
                        queueHandler.Add(new StoogeSort(2, window));
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

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            PauseBtn.Enabled = false;
            ResumeBtn.Enabled = true;
            window.setPause();
        }

        private void ResumeBtn_Click(object sender, EventArgs e)
        {
            ResumeBtn.Enabled = false;
            PauseBtn.Enabled = true;
            window.setResume();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            sortingHandler.stop();
        }

        private void sleepTimeBar_Scroll(object sender, EventArgs e)
        {
            int t = sleepTimeBar.Value;
            sortingHandler.getCurrentSortingItem().setSleep(t);
        }

        private void sineWave_CheckedChanged(object sender, EventArgs e)
        {
            regularArray.Checked = false;
        }

        private void regularArray_CheckedChanged(object sender, EventArgs e)
        {
            sineWave.Checked = false;
        }
    }
}
