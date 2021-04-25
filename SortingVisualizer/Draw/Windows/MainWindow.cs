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
using WindowsFormsApp2.IO;

namespace SortingVisualizer.Draw
{
    public partial class Start : Form
    {
        private SortingHandler SortingHandler;
        private readonly Queue<Handler> QueueHandler;
        private readonly List<RadioButton> RadioButtonsFiles;
        private SortingWindow Window;
        private readonly Serialize Serializer;
        private readonly SessionViewer SessionViewer;
        private Handler CurrentAlgorithm { get; set; }
        private string FileName;
        private bool Save;
        private int AMOUNT_OF_PILLARS;
        private int WIDTH => SHOWCASE_PANEL.Width;
        private int HEIGHT => SHOWCASE_PANEL.Height;
        private string Path => GetPath();
        private string DirectoryPath => GetDirectory();
        public Start()
        {
            InitializeComponent();
            RadioButtonsFiles = new List<RadioButton>();
            QueueHandler = new Queue<Handler>();
            Serializer = new XMLSerializer(DirectoryPath);
            SessionViewer = new SessionViewer(Serializer)
            {
                TopLevel = false
            };
            InitializeState();
            CreateSessionInstance();
        }

        private string GetDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            return projectDirectory + @"\SavedFiles";
        }

        private string GetPath()
        {
            return DirectoryPath + @"\" + textBoxFileName.Text + ".xml";
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
            Window.Close();
            if (!Window.Fullscreen)
            {
                ShowMessage("Sorting finished.");
            }
            SessionViewer.UpdateSessions();
            DisableUIControlElements();
            btnStart.Enabled = true;
            CheckFileSlot();
        }

        private void ShowMessage(string message)
        {
        
            MessageBox.Show(message, "SYSTEM_MESSAGE");
           
            CreateSessionInstance();
        }

        #region SIDEBAR/UI_CONTROLS
        private void InitializeState()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            DisableUIControlElements();

            tbPath.Text = Path;

            tbPath.Enabled = false;
            textBoxFileName.Enabled = false;
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
            else if (Validator.CheckRadioBtnHasSelected(RadioButtonsFiles))
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
            else if (!CheckFileSlot())
            {
                MessageBox.Show("Serialization path is faulty.", "SortingVisaulizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AMOUNT_OF_PILLARS = Int32.Parse(BarCountTxf.Text);
                int sleep = Int32.Parse(textBoxSleepStart.Text);
                int shuffleSleep = Int32.Parse(textBoxShuffleSpeed.Text);
                sleepTimeBar.Value = sleep;
                shuffleSleepTimeBar.Value = shuffleSleep;
                CreateWindowInstance();
            }
        }

        private void CreateSessionInstance()
        {
            SHOWCASE_PANEL.Controls.Clear();
            SHOWCASE_PANEL.Controls.Add(SessionViewer);
            DisableFrame(SessionViewer);
            SessionViewer.Show();
        }
        private void CreateWindowInstance()
        {
            SHOWCASE_PANEL.Controls.Clear();
            int SLEEP = Int32.Parse(textBoxSleepStart.Text);
            int SHUFFLE_SPEED = Int32.Parse(textBoxShuffleSpeed.Text);

            Window = new SortingWindow(AMOUNT_OF_PILLARS, new Size(WIDTH, HEIGHT), SHUFFLE_SPEED);
            SortingHandler = new SortingHandler(QueueHandler, Serializer, Window, FileName, Save);
            Window.SetSortingHandler(SortingHandler);
            SortingHandler.RestartWindowState += RestartWindowState;
            Window.MinimizeScreen += MinimizeScreen;
            DisableFrame(Window);

            textBoxAmountOfBars.Text = AMOUNT_OF_PILLARS.ToString();
            textBoxVisualize.Text = SortingHandler.Remaining.ToString();
            textBoxShuffleSp.Text = textBoxShuffleSpeed.Text;
            FillAlgotihms(SLEEP);

            btnStart.Enabled = false;
            EnableUIControlElements();

            SHOWCASE_PANEL.Controls.Add(Window);
            Window.Show();
            SortingHandler.InitiateSorting(GetCurrentAlgorithm);
        }

        private void DisableFrame(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Width = WIDTH;
            form.Height = HEIGHT;
        }

        private void GetCurrentAlgorithm(Handler algorithm)
        {
            CurrentAlgorithm = algorithm;
            textBoxAlgorithmName.BeginInvoke(new Action(() =>
            {
                textBoxAlgorithmName.Text = algorithm.Name;
            }));

            textBoxSleep.BeginInvoke(new Action(() =>
            {
                textBoxSleep.Text = algorithm.SleepTime.ToString();
            }));
        }

        private void PopUpFullScreen()
        {
            SHOWCASE_PANEL.Controls.Remove(Window);
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            Window.TopLevel = true;
            Window.WindowState = FormWindowState.Normal;
            Window.Size = new Size(width, height);
            Window.SCREENDIMENSIONS = new Size(width, height);
            Window.Show();
        }

        public void MinimizeScreen(object sender, EventArgs e)
        {
            Window.TopLevel = false;
            FullscreenCheckBox.Checked = false;
            SHOWCASE_PANEL.Controls.Add(Window);
            Window.SCREENDIMENSIONS = new Size(WIDTH, HEIGHT);
            Window.Show();
        }
        private void AlgorithmPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {            
            switch (e.PropertyName)
            {
                case nameof(Handler.SleepTime):
                    textBoxSleep.BeginInvoke(new Action(() =>
                   {
                       textBoxSleep.Text = CurrentAlgorithm.SleepTime.ToString();
                   })); 
                    break;
                case nameof(Handler.Swaps):
                    textBoxSwaps.BeginInvoke(new Action(() =>
                    {
                        textBoxSwaps.Text = CurrentAlgorithm.Swaps.ToString();
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
                        BubbleSort bubble = new BubbleSort(SLEEP, Window);
                        QueueHandler.Enqueue(bubble);
                        AddEventHandler(bubble);
                        bubble.Name = "Bubble sort";
                        break;
                    case "SELECTION":
                        SelectionSort selction = new SelectionSort(SLEEP, Window);
                        QueueHandler.Enqueue(selction);
                        AddEventHandler(selction);
                        selction.Name = "Selection sort";
                        break;
                    case "HEAP":
                        HeapSort heap = new HeapSort(SLEEP, Window);
                        QueueHandler.Enqueue(heap);
                        AddEventHandler(heap);
                        heap.Name = "Heap sort";
                        break;
                    case "MERGE":
                        MergeSort merge = new MergeSort(SLEEP, Window);
                        QueueHandler.Enqueue(merge);
                        AddEventHandler(merge);
                        merge.Name = "Merge sort";
                        break;
                    case "QUICK":
                        QuickSort quick = new QuickSort(SLEEP, Window);
                        QueueHandler.Enqueue(quick);
                        AddEventHandler(quick);
                        quick.Name = "Quick sort";
                        break;
                    case "INSERTION":
                        InsertionSort insertion = new InsertionSort(SLEEP, Window);
                        QueueHandler.Enqueue(insertion);
                        AddEventHandler(insertion);
                        insertion.Name = "Insertion sort";
                        break;
                    case "COCKTAIL":
                        CocktailSort cocktail = new CocktailSort(SLEEP, Window);
                        QueueHandler.Enqueue(cocktail);
                        AddEventHandler(cocktail);
                        cocktail.Name = "Cocktail sort";
                        break;
                    case "SHELL":
                        ShellSort shell = new ShellSort(SLEEP, Window);
                        QueueHandler.Enqueue(shell);
                        AddEventHandler(shell);
                        shell.Name = "Shell sort";
                        break;
                    case "COMB":
                        CombSort comb = new CombSort(SLEEP, Window);
                        QueueHandler.Enqueue(comb);
                        AddEventHandler(comb);
                        comb.Name = "Comb sort";
                        break;
                    case "CYCLE":
                        CycleSort cycle = new CycleSort(SLEEP, Window);
                        QueueHandler.Enqueue(cycle);
                        AddEventHandler(cycle);
                        cycle.Name = "Cycle sort";
                        break;
                    case "STOOGE":
                        StoogeSort stooge = new StoogeSort(SLEEP, Window);
                        QueueHandler.Enqueue(stooge);
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
                    FileName = saveDialog.FileName;
                }
            }
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
            Window.SetPause();
        }

        private void ResumeBtn_Click(object sender, EventArgs e)
        {
            ResumeBtn.Enabled = false;
            PauseBtn.Enabled = true;
            Window.SetResume();
        }

        private void InfoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (InfoCheckBox.Checked)
            {
                Window.ShowInfo = true;
            }
            else
            {
                Window.ShowInfo = false;
            }
        }

        private void FullscreenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FullscreenCheckBox.Checked)
            {
                PopUpFullScreen();
            }
        }

        private void SleepTimeBar_Scroll(object sender, EventArgs e)
        {
            CurrentAlgorithm.SleepTime = sleepTimeBar.Value;
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
            Window.SHUFFLE_SPEED = shuffleSleepTimeBar.Value;
            textBoxShuffleSp.Text = Window.SHUFFLE_SPEED.ToString();    
        }

        private void CheckBoxSerialize_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSerialize.Checked)
            {
                tbPath.Enabled = true;
                textBoxFileName.Enabled = true;
                Save = true;
            }
            else
            {
                tbPath.Enabled = false;
                textBoxFileName.Enabled = false;
                Save = false;
            }
        }

        private void TextBoxFileName_TextChanged(object sender, EventArgs e)
        {
            CheckFileSlot();
        }

        private bool CheckFileSlot()
        {
            if (!File.Exists(Path))
            {
                LblHasBeenUsed.BackColor = Color.Green;
                LblHasBeenUsed.Text = "Not already used.";
                FileName = textBoxFileName.Text;
                return true;
            }
            else
            {
                LblHasBeenUsed.BackColor = Color.Red;
                LblHasBeenUsed.Text = "Already used.";
                FileName = textBoxFileName.Text;
                return false;
            }
        }

        private void Start_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
