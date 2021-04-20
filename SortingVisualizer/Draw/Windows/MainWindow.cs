using SortingVisualizer.Validate;
using SortingVisualizer.Algorithms;
using SortingVisualizer.Maths;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SortingVisualizer.Draw.Windows;
using WindowsFormsApp2.Algorithms;
using System.ComponentModel;
using WindowsFormsApp2.Draw.Windows;

namespace SortingVisualizer.Draw
{
    public partial class Start : Form
    {
        private SortingHandler sortingHandler;
        private readonly Queue<Handler> queueHandler;
        private readonly List<RadioButton> radioButtons;
        private readonly List<RadioButton> radioButtonsFiles;
        private Window window;
        private string selectedFolderPath;
        private int amountOfPillars;
        private FileType Type;
        private GenerationType GenerationType;
        private int WIDTH => SHOWCASE_PANEL.Width;
        private int HEIGHT => SHOWCASE_PANEL.Height;
        public Start()
        {
            InitializeComponent();
            radioButtons = new List<RadioButton>();
            radioButtonsFiles = new List<RadioButton>();
            queueHandler = new Queue<Handler>();
            InitializeState();
        }
        private void InitializeState()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            PauseBtn.Enabled = false;
            ResumeBtn.Enabled = false;
            InfoCheckBox.Enabled = false;
            FullscreenCheckBox.Enabled = false;
            sleepTimeBar.Enabled = false;

            radioButtons.Add(regularArray);
            radioButtons.Add(sineWave);
            radioButtonsFiles.Add(XMLRadioBtn);
            radioButtonsFiles.Add(JSONRadioBtn);
            radioButtonsFiles.Add(BINARYRadioBtn);

            LblSleep.Text = "2";
            LblSwaps.Text = "0";
        }

        private void Start_Load(object sender, EventArgs e)
        {
            AlgorithmsList.Items.AddRange(Enum.GetNames(typeof(ALGORITHM_TYPE)));
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
            btnStart.Enabled = false;

            window = new Window("SortingVisualizer", amountOfPillars, new Vector2D(WIDTH, HEIGHT), GenerationType);
            sortingHandler = new SortingHandler(queueHandler, window, Type, selectedFolderPath);
            window.SetSortingHandler(sortingHandler);
            window.TopLevel = false;
            window.RemoveFrame();
            window.Width = WIDTH;
            window.Height = HEIGHT;

            FillAlgotihms();
            CreateInformation();

            LblVisualize.Text = sortingHandler.Remaining().ToString();
            SHOWCASE_PANEL.Controls.Add(window);
            window.Show();

            sortingHandler.InitiateSorting();

            PauseBtn.Enabled = true;
            ResumeBtn.Enabled = true;
            InfoCheckBox.Enabled = true;
            FullscreenCheckBox.Enabled = true;
            sleepTimeBar.Enabled = true;
        }

        private void PopUpFullScreen()
        {
            SHOWCASE_PANEL.Controls.Remove(window);
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            window.TopLevel = true;
            window.SCREENDIMENSIONS = new Vector2D(width, height);
            window.Show();
            window.Toggle_FULLSCREEN(); 
        }
        private void CreateInformation()
        {
            Handler item = sortingHandler.GetCurrentSortingItem();

            item.PropertyChanged += AlgorithmPropertyChangedHandler;
            LblAmountOfBars.Text = amountOfPillars.ToString();
        }
        private void AlgorithmPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            Handler item = sortingHandler.GetCurrentSortingItem();
            
            switch (e.PropertyName)
            {
                case nameof(Handler.SleepTime):
                    LblSleep.BeginInvoke(new Action(() =>
                   {
                       LblSleep.Text = item.SleepTime.ToString();
                   })); 
                    break;
                case nameof(Handler.Swaps):
                    LblSwaps.BeginInvoke(new Action(() =>
                    {
                        LblSwaps.Text = item.Swaps.ToString();
                    }));
                    break;
                case nameof(Handler.ElapsedTime):
                    LblElapsedTime.BeginInvoke(new Action(() =>
                    {
                        LblElapsedTime.Text = item.ElapsedTime.ToString();
                    }));
                    break;
                case nameof(Handler.Name):
                    LblAlgorithmName.BeginInvoke(new Action(() =>
                    {
                        Console.WriteLine(item.Name.ToString());

                        LblAlgorithmName.Text = item.Name.ToString();
                    }));
                    break;
            }
        }

        void PropertyChangedInMyClass(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine(sortingHandler.GetCurrentSortingItem().Name);
        }

        private void FillAlgotihms()
        {
            foreach (object itemChecked in AlgorithmsList.CheckedItems)
            {
                switch (itemChecked.ToString())
                {
                    case "BUBBLE":
                        BubbleSort bubble = new BubbleSort(2, window);
                        queueHandler.Enqueue(bubble);
                        AddEventHandler(bubble);
                        bubble.Name = "Bubble sort";
                        break;
                    case "SELECTION":
                        SelectionSort selction = new SelectionSort(2, window);
                        queueHandler.Enqueue(selction);
                        AddEventHandler(selction);
                        selction.Name = "Selection sort";
                        break;
                    case "HEAP":
                        HeapSort heap = new HeapSort(2, window);
                        queueHandler.Enqueue(heap);
                        AddEventHandler(heap);
                        heap.Name = "Heap sort";
                        break;
                    case "MERGE":
                        MergeSort merge = new MergeSort(2, window);
                        queueHandler.Enqueue(merge);
                        AddEventHandler(merge);
                        merge.Name = "Merge sort";
                        break;
                    case "QUICK":
                        QuickSort quick = new QuickSort(2, window);
                        queueHandler.Enqueue(quick);
                        AddEventHandler(quick);
                        quick.Name = "Quick sort";
                        break;
                    case "INSERTION":
                        InsertionSort insertion = new InsertionSort(2, window);
                        queueHandler.Enqueue(insertion);
                        AddEventHandler(insertion);
                        insertion.Name = "Insertion sort";
                        break;
                    case "COCKTAIL":
                        CocktailSort cocktail = new CocktailSort(2, window);
                        queueHandler.Enqueue(cocktail);
                        AddEventHandler(cocktail);
                        cocktail.Name = "Cocktail sort";
                        break;
                    case "SHELL":
                        ShellSort shell = new ShellSort(2, window);
                        queueHandler.Enqueue(shell);
                        AddEventHandler(shell);
                        shell.Name = "Shell sort";
                        break;
                    case "COMB":
                        CombSort comb = new CombSort(2, window);
                        queueHandler.Enqueue(comb);
                        AddEventHandler(comb);
                        comb.Name = "Comb sort";
                        break;
                    case "CYCLE":
                        CycleSort cycle = new CycleSort(2, window);
                        queueHandler.Enqueue(cycle);
                        AddEventHandler(cycle);
                        cycle.Name = "Cycle sort";
                        break;
                    case "STOOGE":
                        StoogeSort stooge = new StoogeSort(2, window);
                        queueHandler.Enqueue(stooge);
                        AddEventHandler(stooge);
                        stooge.Name = "Stooge sort";
                        break;
                }
            }
        }

        private void AddEventHandler(Handler handler)
        {
            handler.PropertyChanged += AlgorithmPropertyChangedHandler;
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

        private void InfoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            window.Toggle_Info();
        }

        private void FullscreenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PopUpFullScreen();
        }

        private void SleepTimeBar_Scroll(object sender, EventArgs e)
        {
            window.GetCurrentAlgorithm().SleepTime = sleepTimeBar.Value;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialogForm openFileDialog = new OpenFileDialogForm();
            openFileDialog.Show();
        }
    }
}
