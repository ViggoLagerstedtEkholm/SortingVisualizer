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
using System.IO;

namespace SortingVisualizer.Draw
{
    public enum fileType
    {
        XML,
        BINARY,
        JSON
    };
    public enum generationType
    {
        REGULAR,
        SINE_WAVE
    };
    public partial class Start : Form
    {
        private readonly string[] algorithms = { "Bubble sort", "Selection sort", "Heap sort", "Merge sort", "Quick sort", "Insertion sort",
                                                "Cocktail sort", "Shell sort", "Comb sort", "Cycle sort", "Stooge sort"};
        private SortingHandler sortingHandler;
        private List<ISortAlgorithms> queueHandler;
        private List<RadioButton> radioButtons;
        private List<RadioButton> radioButtonsFiles;
        private Window window;
        private string selectedFolderPath;
        private int min;
        private int max;
        private int amountOfPillars;
        private fileType Type;
        private generationType GenerationType;
        public Start()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            StopBtn.Enabled = false;
            ResumeBtn.Enabled = false;
            PauseBtn.Enabled = false;
            panel5.Visible = false;

            radioButtons = new List<RadioButton>();
            radioButtonsFiles = new List<RadioButton>();

            radioButtons.Add(regularArray);
            radioButtons.Add(sineWave);
            radioButtonsFiles.Add(XMLRadioBtn);
            radioButtonsFiles.Add(JSONRadioBtn);
            radioButtonsFiles.Add(BINARYRadioBtn);

            this.queueHandler = new List<ISortAlgorithms>();
        }
        private void Start_Load(object sender, EventArgs e)
        {
            AlgorithmsList.Items.AddRange(algorithms);
            AlgorithmsList.CheckOnClick = true;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Validator.CheckBoxListHasValue(AlgorithmsList) &&
            (Validator.TxfHasInteger(MinTxf) && Validator.TxfHasInteger(MaxTxf) && Validator.TxfHasInteger(BarCountTxf)) &&
            (Validator.TxfHasContent(MinTxf) && Validator.TxfHasContent(MaxTxf) && Validator.TxfHasContent(BarCountTxf)))
            {
                amountOfPillars = Int32.Parse(BarCountTxf.Text);
                min = Int32.Parse(MinTxf.Text);
                max = Int32.Parse(MaxTxf.Text);

                if ((Validator.MinMax(min, max)))
                {
                    if (Validator.CheckRadioBtnHasSelected(radioButtons))
                    {
                        if (radioButton1.Checked)
                        {
                            if (Validator.CheckRadioBtnHasSelected(radioButtonsFiles))
                            {
                                createWindowInstance();
                            }
                            else
                            {
                                MessageBox.Show("Select a file type (XMLM JSON, BINARY)", "SortingVisaulizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            createWindowInstance();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select a data generation type.", "SortingVisaulizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Make sure you only use integers with min/max/barCount and have selected atleast 1 algorithm!", "SortingVisaulizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void createWindowInstance()
        {
            if (fullscreenCheckbox.Checked)
            {
                int width = Screen.PrimaryScreen.Bounds.Width;
                int height = Screen.PrimaryScreen.Bounds.Height;

                window = new Window("SortingVisualizer", amountOfPillars, min, max, new Vector2D(width, height), GenerationType);
                fillAlgotihms();

                window.SET_FULLSCREEN();
                this.Hide();
                window.Show();
            }
            else
            {
                window = new Window("SortingVisualizer", amountOfPillars, min, max, new Vector2D(SortingPanel.Width, SortingPanel.Height), GenerationType);
                window.TopLevel = false;
                fillAlgotihms();

                this.SortingPanel.Controls.Add(window);

                window.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                window.Dock = DockStyle.Fill;
                window.Show();
            }

            if (radioButton1.Checked)
            {
                sortingHandler = new SortingHandler(queueHandler, window, Type, selectedFolderPath);
            }
            else
            {
                sortingHandler = new SortingHandler(queueHandler, window);
            }

            StopBtn.Enabled = true;
            PauseBtn.Enabled = true;
        }
        private void fillAlgotihms()
        {
            foreach (object itemChecked in AlgorithmsList.CheckedItems)
            {
                switch (itemChecked.ToString())
                {
                    case "Bubble sort":
                        queueHandler.Add(new BubbleSort(2, window, "Bubble sort"));
                        break;
                    case "Selection sort":
                        queueHandler.Add(new SelectionSort(2, window, "Selection sort"));
                        break;
                    case "Heap sort":
                        queueHandler.Add(new HeapSort(2, window, "Heap sort"));
                        break;
                    case "Merge sort":
                        queueHandler.Add(new MergeSort(2, window, "Merge sort"));
                        break;
                    case "Quick sort":
                        queueHandler.Add(new QuickSort(2, window, "Quick sort"));
                        break;
                    case "Insertion sort":
                        queueHandler.Add(new InsertionSort(2, window, "Insertion sort"));
                        break;
                    case "Cocktail sort":
                        queueHandler.Add(new CocktailSort(2, window, "Cocktail sort"));
                        break;
                    case "Shell sort":
                        queueHandler.Add(new ShellSort(2, window, "Shell sort"));
                        break;
                    case "Comb sort":
                        queueHandler.Add(new CombSort(2, window, "Comb sort"));
                        break;
                    case "Cycle sort":
                        queueHandler.Add(new CycleSort(2, window, "Cycle sort"));
                        break;
                    case "Stooge sort":
                        queueHandler.Add(new StoogeSort(2, window, "Stooge sort"));
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
            if(sortingHandler != null)
            {
                sortingHandler.getCurrentSortingItem().setSleep(t);
            }
        }
        private void FileChooseBtn_Click(object sender, EventArgs e)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                DialogResult result = saveDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                     selectedFolderPath = saveDialog.FileName;
                }
            }
    
        }

        private void BINARYRadioBtn_Click(object sender, EventArgs e)
        {
            XMLRadioBtn.Checked = false;
            JSONRadioBtn.Checked = false;
            Type = fileType.BINARY;
        }

        private void XMLRadioBtn_Click(object sender, EventArgs e)
        {
            BINARYRadioBtn.Checked = false;
            JSONRadioBtn.Checked = false;
            Type = fileType.BINARY;
        }

        private void JSONRadioBtn_Click(object sender, EventArgs e)
        {
            BINARYRadioBtn.Checked = false;
            XMLRadioBtn.Checked = false;
            Type = fileType.JSON;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel5.Visible = true;
            }
            else
            {
                panel5.Visible = false;
            }
            
        }
        private void sineWave_Click(object sender, EventArgs e)
        {
            regularArray.Checked = false;
            GenerationType = generationType.REGULAR;
        }
        private void regularArray_Click(object sender, EventArgs e)
        {
            sineWave.Checked = false;
            GenerationType = generationType.SINE_WAVE;
        }
    }
}
