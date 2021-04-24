using SortingVisualizer.Validate;
using SortingVisualizer.Algorithms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SortingVisualizer.Draw.Windows;
using WindowsFormsApp2.Algorithms;
using System.ComponentModel;
using WindowsFormsApp2.Draw.Windows;
using System.Drawing;
using System.IO;

namespace SortingVisualizer.Draw
{
    public partial class Start : Form
    {
        private SortingHandler sortingHandler;
        private readonly Queue<Handler> queueHandler;
        private readonly List<RadioButton> radioButtonsFiles;
        private Window window;
        private string selectedFolderPath;
        private int amountOfPillars;
        private FILE_TYPE Type;
        private int WIDTH => SHOWCASE_PANEL.Width;
        private int HEIGHT => SHOWCASE_PANEL.Height;
        private Handler CurrentAlgorithm { get; set; }
        public Start()
        {
            InitializeComponent();
            radioButtonsFiles = new List<RadioButton>();
            queueHandler = new Queue<Handler>();
            InitializeState();
        }
        private void AddEventHandler(Handler handler)
        {
            handler.PropertyChanged += AlgorithmPropertyChangedHandler;
        }

        public void RestartWindowState(object sender, EventArgs e)
        {
            Console.WriteLine("Called to main.");
            SHOWCASE_PANEL.Controls.Clear();
            SHOWCASE_PANEL.Invalidate();
            ShowMessage("Sorting finished.");
            DisableUIControlElements();
            EnableSideHud();
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "SYSTEM_MESSAGE");
        }

        #region SIDEBAR/UI_CONTROLS
        private void InitializeState()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            DisableUIControlElements();

            tbPath.Text = GetDirectoryPath();

            radioButtonsFiles.Add(XMLRadioBtn);
            radioButtonsFiles.Add(JSONRadioBtn);
            radioButtonsFiles.Add(BINARYRadioBtn);

            LblSleep.Text = "2";
            LblSwaps.Text = "0";
            LblShuffleSpeed.Text = "0";
        }
        
        private void DisableSideHud()
        {
            btnStart.Enabled = false;
        }

        private void EnableSideHud()
        {
            btnStart.Enabled = true;
        }

        private void DisableUIControlElements()
        {
            PauseBtn.Enabled = false;
            ResumeBtn.Enabled = false;
            InfoCheckBox.Enabled = false;
            FullscreenCheckBox.Enabled = false;
            sleepTimeBar.Enabled = false;
            shuffleSleepTimeBar.Enabled = false;
        }

        private void EnableUIControlElements()
        {
            PauseBtn.Enabled = true;
            ResumeBtn.Enabled = true;
            InfoCheckBox.Enabled = true;
            FullscreenCheckBox.Enabled = true;
            sleepTimeBar.Enabled = true;
            shuffleSleepTimeBar.Enabled = true;
        }
        #endregion

        private string GetDirectoryPath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            return projectDirectory + @"\SavedFiles";
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
            else if (Validator.CheckRadioBtnHasSelected(radioButtonsFiles))
            {
                MessageBox.Show("Select a file type (XMLM JSON, BINARY)", "SortingVisaulizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Validator.TxfHasInteger(BarCountTxf))
            {
                MessageBox.Show("Enter a valid bar count.", "SortingVisaulizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!Validator.TxfHasInteger(textBoxSleepStart) || !Validator.TxfHasInteger(textBoxShuffleSpeed))
            {
                MessageBox.Show("Enter sleep times.", "SortingVisaulizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                amountOfPillars = Int32.Parse(BarCountTxf.Text);
                int sleep = Int32.Parse(textBoxSleepStart.Text);
                int shuffleSleep = Int32.Parse(textBoxShuffleSpeed.Text);
                sleepTimeBar.Value = sleep;
                shuffleSleepTimeBar.Value = shuffleSleep;
                CreateWindowInstance();
            }
        }
        private void CreateWindowInstance()
        {
            int SLEEP = Int32.Parse(textBoxSleepStart.Text);
            int SHUFFLE_SPEED = Int32.Parse(textBoxShuffleSpeed.Text);

            window = new Window("SortingVisualizer", amountOfPillars, new Size(WIDTH, HEIGHT), SHUFFLE_SPEED);
            sortingHandler = new SortingHandler(queueHandler, window, Type, selectedFolderPath);
            window.SetSortingHandler(sortingHandler);
            sortingHandler.RestartWindowState += RestartWindowState;
            window.TopLevel = false;
            window.FormBorderStyle = FormBorderStyle.None;
            window.Width = WIDTH;
            window.Height = HEIGHT;

            LblAmountOfBars.Text = amountOfPillars.ToString();
            LblVisualize.Text = sortingHandler.Remaining.ToString();
            FillAlgotihms(SLEEP);

            DisableSideHud();
            EnableUIControlElements();

            SHOWCASE_PANEL.Controls.Add(window);
            window.Show();
            sortingHandler.InitiateSorting(GetCurrentAlgorithm);
        }

        private void GetCurrentAlgorithm(Handler algorithm)
        {
            CurrentAlgorithm = algorithm;
            LblAlgorithmName.BeginInvoke(new Action(() =>
            {
                LblAlgorithmName.Text = algorithm.Name;
            }));

            LblSleep.BeginInvoke(new Action(() =>
            {
                LblSleep.Text = algorithm.SleepTime.ToString();
            }));
        }

        private void PopUpFullScreen()
        {
            SHOWCASE_PANEL.Controls.Remove(window);
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            window.TopLevel = true;
            window.SCREENDIMENSIONS = new Size(width, height);
            window.Show();
            window.Toggle_FULLSCREEN(); 
        }
        private void AlgorithmPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {            
            switch (e.PropertyName)
            {
                case nameof(Handler.SleepTime):
                    LblSleep.BeginInvoke(new Action(() =>
                   {
                       LblSleep.Text = CurrentAlgorithm.SleepTime.ToString();
                   })); 
                    break;
                case nameof(Handler.Swaps):
                    LblSwaps.BeginInvoke(new Action(() =>
                    {
                        LblSwaps.Text = CurrentAlgorithm.Swaps.ToString();
                    }));
                    break;
            }
        }

        private void FillAlgotihms(int SLEEP)
        {
            foreach (object itemChecked in AlgorithmsList.CheckedItems)
            {
                switch (itemChecked.ToString())
                {
                    case "BUBBLE":
                        BubbleSort bubble = new BubbleSort(SLEEP, window);
                        queueHandler.Enqueue(bubble);
                        AddEventHandler(bubble);
                        bubble.Name = "Bubble sort";
                        break;
                    case "SELECTION":
                        SelectionSort selction = new SelectionSort(SLEEP, window);
                        queueHandler.Enqueue(selction);
                        AddEventHandler(selction);
                        selction.Name = "Selection sort";
                        break;
                    case "HEAP":
                        HeapSort heap = new HeapSort(SLEEP, window);
                        queueHandler.Enqueue(heap);
                        AddEventHandler(heap);
                        heap.Name = "Heap sort";
                        break;
                    case "MERGE":
                        MergeSort merge = new MergeSort(SLEEP, window);
                        queueHandler.Enqueue(merge);
                        AddEventHandler(merge);
                        merge.Name = "Merge sort";
                        break;
                    case "QUICK":
                        QuickSort quick = new QuickSort(SLEEP, window);
                        queueHandler.Enqueue(quick);
                        AddEventHandler(quick);
                        quick.Name = "Quick sort";
                        break;
                    case "INSERTION":
                        InsertionSort insertion = new InsertionSort(SLEEP, window);
                        queueHandler.Enqueue(insertion);
                        AddEventHandler(insertion);
                        insertion.Name = "Insertion sort";
                        break;
                    case "COCKTAIL":
                        CocktailSort cocktail = new CocktailSort(SLEEP, window);
                        queueHandler.Enqueue(cocktail);
                        AddEventHandler(cocktail);
                        cocktail.Name = "Cocktail sort";
                        break;
                    case "SHELL":
                        ShellSort shell = new ShellSort(SLEEP, window);
                        queueHandler.Enqueue(shell);
                        AddEventHandler(shell);
                        shell.Name = "Shell sort";
                        break;
                    case "COMB":
                        CombSort comb = new CombSort(SLEEP, window);
                        queueHandler.Enqueue(comb);
                        AddEventHandler(comb);
                        comb.Name = "Comb sort";
                        break;
                    case "CYCLE":
                        CycleSort cycle = new CycleSort(SLEEP, window);
                        queueHandler.Enqueue(cycle);
                        AddEventHandler(cycle);
                        cycle.Name = "Cycle sort";
                        break;
                    case "STOOGE":
                        StoogeSort stooge = new StoogeSort(SLEEP, window);
                        queueHandler.Enqueue(stooge);
                        AddEventHandler(stooge);
                        stooge.Name = "Stooge sort";
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
            Type = FILE_TYPE.BINARY;
        }

        private void XMLRadioBtn_Click(object sender, EventArgs e)
        {
            BINARYRadioBtn.Checked = false;
            JSONRadioBtn.Checked = false;
            Type = FILE_TYPE.BINARY;
        }

        private void JSONRadioBtn_Click(object sender, EventArgs e)
        {
            BINARYRadioBtn.Checked = false;
            XMLRadioBtn.Checked = false;
            Type = FILE_TYPE.JSON;
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
            if (InfoCheckBox.Checked)
            {
                window.ShowInfo = true;
            }
            else
            {
                window.ShowInfo = false;
            }
        }

        private void FullscreenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PopUpFullScreen();
        }

        private void SleepTimeBar_Scroll(object sender, EventArgs e)
        {
            CurrentAlgorithm.SleepTime = sleepTimeBar.Value;
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialogForm openFileDialog = new OpenFileDialogForm();
            openFileDialog.Show();
        }

        private void CheckBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.Checked)
            {
                for (int i = 0; i < AlgorithmsList.Items.Count; i++)
                {
                    AlgorithmsList.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < AlgorithmsList.Items.Count; i++)
                {
                    AlgorithmsList.SetItemChecked(i, false);
                }
            }
        }

        private void ShuffleSleepTimeBar_Scroll(object sender, EventArgs e)
        {
            window.SHUFFLE_SPEED = shuffleSleepTimeBar.Value;
            LblShuffleSpeed.Text = window.SHUFFLE_SPEED.ToString();
        }

        private void CheckBoxSerialize_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSerialize.Checked)
            {
                BINARYRadioBtn.Enabled = false;
                JSONRadioBtn.Enabled = false;
                XMLRadioBtn.Enabled = false;
            }
        }
    }
}
