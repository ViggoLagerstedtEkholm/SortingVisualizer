using SortingVisualizer.Validate;
using SortingVisualizer.Algorithms;
using SortingVisualizer.Maths;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SortingVisualizer.Draw.Windows;
using WindowsFormsApp2.Algorithms;
using WindowsFormsApp2.Draw.Windows;

namespace SortingVisualizer.Draw
{
    public partial class Start : Form
    {
        private readonly string[] algorithms = { "Bubble sort", "Selection sort", "Heap sort", "Merge sort", "Quick sort", "Insertion sort",
                                                "Cocktail sort", "Shell sort", "Comb sort", "Cycle sort", "Stooge sort"};
        private SortingHandler sortingHandler;
        private readonly List<Handler> queueHandler;
        private readonly List<RadioButton> radioButtons;
        private readonly List<RadioButton> radioButtonsFiles;
        private Window window;
        private string selectedFolderPath;
        private int amountOfPillars;
        private FileType Type;
        private GenerationType GenerationType;
        public Start()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            radioButtons = new List<RadioButton>();
            radioButtonsFiles = new List<RadioButton>();

            radioButtons.Add(regularArray);
            radioButtons.Add(sineWave);
            radioButtonsFiles.Add(XMLRadioBtn);
            radioButtonsFiles.Add(JSONRadioBtn);
            radioButtonsFiles.Add(BINARYRadioBtn);

            this.queueHandler = new List<Handler>();
        }
        private void Start_Load(object sender, EventArgs e)
        {
            AlgorithmsList.Items.AddRange(algorithms);
            AlgorithmsList.CheckOnClick = true;
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!Validator.CheckBoxListHasValue(AlgorithmsList))
            {
                MessageBox.Show("Select atleast 1 algorithm!", "SortingVisaulizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Validator.CheckRadioBtnHasSelected(radioButtons))
            {
                MessageBox.Show("Select a data generation type.", "SortingVisaulizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Validator.CheckRadioBtnHasSelected(radioButtonsFiles))
            {
                MessageBox.Show("Select a file type (XMLM JSON, BINARY)", "SortingVisaulizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Validator.TxfHasInteger(BarCountTxf))
            {
                MessageBox.Show("Enter a valid bar count.", "SortingVisaulizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                amountOfPillars = Int32.Parse(BarCountTxf.Text);
                CreateWindowInstance();
            }
        }
        private void CreateWindowInstance()
        {
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

            window = new Window("SortingVisualizer", amountOfPillars, new Vector2D(width, height), GenerationType);
          
            if (radioButton1.Checked)
            {
                sortingHandler = new SortingHandler(queueHandler, window, Type, selectedFolderPath);
            }
            else
            {
                sortingHandler = new SortingHandler(queueHandler, window);
            }
            window.SetSortingHandler(sortingHandler);

            Controls controls = new Controls(window);

            FillAlgotihms();

            Hide();
            window.SetFullscreen();
            window.Show();
            controls.Show();
        }
        private void FillAlgotihms()
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
            Type = FileType.BINARY;
        }

        private void XMLRadioBtn_Click(object sender, EventArgs e)
        {
            BINARYRadioBtn.Checked = false;
            JSONRadioBtn.Checked = false;
            Type = FileType.BINARY;
        }

        private void JSONRadioBtn_Click(object sender, EventArgs e)
        {
            BINARYRadioBtn.Checked = false;
            XMLRadioBtn.Checked = false;
            Type = FileType.JSON;
        }

        private void RadioButton1_Click(object sender, EventArgs e)
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
        private void SineWave_Click(object sender, EventArgs e)
        {
            regularArray.Checked = false;
            GenerationType = GenerationType.REGULAR;
        }
        private void RegularArray_Click(object sender, EventArgs e)
        {
            sineWave.Checked = false;
            GenerationType = GenerationType.SINE_WAVE;
        }
    }
}
