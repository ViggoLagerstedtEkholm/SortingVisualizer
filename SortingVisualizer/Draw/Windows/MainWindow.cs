using SortingVisualizer.Algorithms;
using SortingVisualizer.Draw.Windows;
using SortingVisualizer.Validate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp2.Algorithms;
using WindowsFormsApp2.Draw.Windows;
using WindowsFormsApp2.IO;

namespace SortingVisualizer.Draw
{
    public partial class Start : Form
    {
        private SortingHandler SortingHandler;
        private readonly Queue<Algorithm> QueueHandler;
        private readonly List<RadioButton> RadioButtonsFiles;
        private SortingWindow Window;
        private readonly Serialize Serializer;
        private readonly SessionViewer SessionViewer;
        private Algorithm CurrentAlgorithm { get; set; }
        private string FileName;
        private bool Save;
        private int AMOUNT_OF_PILLARS;
        private int SHOWCASE_PANEL_WIDTH => SHOWCASE_PANEL.Width;
        private int SHOWCASE_PANEL_HEIGHT => SHOWCASE_PANEL.Height;
        private int WINDOW_WIDTH => Screen.PrimaryScreen.Bounds.Width;
        private int WINDOW_HEIGHT => Screen.PrimaryScreen.Bounds.Height;
        private string Path => GetPath();
        private string DirectoryPath => GetDirectory();
        public Start()
        {
            InitializeComponent();
            DoubleBuffered = true;
            RadioButtonsFiles = new List<RadioButton>();
            QueueHandler = new Queue<Algorithm>();
            Serializer = new XMLSerializer(DirectoryPath);
            SessionViewer = new SessionViewer(Serializer)
            {
                TopLevel = false
            };
            DisableUIControlElements();
            InitializeState();
            CreateSessionInstance();
            EnableSideHud();
        }

        #region Events/Callbacks
        private void AlgorithmPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Algorithm.SleepTime):
                    textBoxSleep.BeginInvoke(new Action(() =>
                    {
                        textBoxSleep.Text = CurrentAlgorithm.SleepTime.ToString();
                    }));
                    break;
                case nameof(Algorithm.Swaps):
                    textBoxSwaps.BeginInvoke(new Action(() =>
                    {
                        textBoxSwaps.Text = CurrentAlgorithm.Swaps.ToString();
                    }));
                    break;
            }
        }
        private void GetCurrentAlgorithm(Algorithm algorithm)
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

        private void AddEventHandler(Algorithm handler)
        {
            handler.PropertyChanged += AlgorithmPropertyChangedHandler;
        }

        public void RestartWindowState(object sender, EventArgs e)
        {
            Console.WriteLine("Called to main.");
            SHOWCASE_PANEL.Controls.Clear();
            SHOWCASE_PANEL.Invalidate();
            Window.Close();

            ShowMessage("Sorting finished.");
            
            SessionViewer.UpdateSessions();
            DisableUIControlElements();
            CreateSessionInstance();
            CheckFileSlot();
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "SYSTEM_MESSAGE");
            CreateSessionInstance();
        }
        #endregion

        #region SIDEBAR/UI_CONTROLS
        private void InitializeState()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            tbPath.Text = Path;
            tbPath.Enabled = false;

            textBoxFileName.Enabled = false;
        }

        private void DisableUIControlElements()
        {
            checkBoxBlack.Enabled = false;
            checkBoxGray.Enabled = false;
            checkBoxDarkBlue.Enabled = false;
            PauseBtn.Enabled = false;
            ResumeBtn.Enabled = false;
            InfoCheckBox.Enabled = false;
            sleepTimeBar.Enabled = false;
            shuffleSleepTimeBar.Enabled = false;
        }

        private void EnableUIControlElements()
        {
            checkBoxBlack.Enabled = true;
            checkBoxGray.Enabled = true;
            checkBoxDarkBlue.Enabled = true;
            PauseBtn.Enabled = true;
            ResumeBtn.Enabled = true;
            InfoCheckBox.Enabled = true;
            sleepTimeBar.Enabled = true;
            shuffleSleepTimeBar.Enabled = true;
        }

        private void EnableSideHud()
        {
            btnStart.Enabled = true;
        }

        private void DisableSideHud()
        {
            btnStart.Enabled = false;
        }

        #endregion

        #region Load
        private void Start_Load(object sender, EventArgs e)
        {
            AlgorithmsList.Items.AddRange(Enum.GetNames(typeof(ALGORITHM_TYPE)));
            AlgorithmsList.CheckOnClick = true;
        }
        #endregion

        #region Validate inputs
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
        #endregion

        #region Create instances
        private void CreateSessionInstance()
        {
            SHOWCASE_PANEL.Controls.Clear();
            SHOWCASE_PANEL.Controls.Add(SessionViewer);
            SessionViewer.Show();
        }
        private void CreateWindowInstance()
        {
            SHOWCASE_PANEL.Controls.Clear();

            int SLEEP = Int32.Parse(textBoxSleepStart.Text);
            int SHUFFLE_SPEED = Int32.Parse(textBoxShuffleSpeed.Text);

            Window = new SortingWindow(AMOUNT_OF_PILLARS, new Size(SHOWCASE_PANEL_WIDTH, SHOWCASE_PANEL_HEIGHT), SHUFFLE_SPEED);
            SortingHandler = new SortingHandler(QueueHandler, Serializer, Window, FileName, Save);
            Window.SetSortingHandler(SortingHandler);
            SortingHandler.RestartWindowState += RestartWindowState;
            Window.MinimizeScreen += MinimizeScreen;
            Window.MaximizeScreen += MaximizeScreen;

            textBoxAmountOfBars.Text = AMOUNT_OF_PILLARS.ToString();
            textBoxVisualize.Text = SortingHandler.Remaining.ToString();
            textBoxShuffleSp.Text = textBoxShuffleSpeed.Text;
            FillAlgotihms(SLEEP);

            DisableSideHud();
            EnableUIControlElements();
            SHOWCASE_PANEL.Controls.Add(Window);
            Window.Show();

            SortingHandler.InitiateSorting(GetCurrentAlgorithm);
        }
        #endregion

        #region Window states
        public void MinimizeScreen(object sender, EventArgs e)
        {
            Console.WriteLine("Minimizing...");
            Window.Fullscreen = false;
            Window.WindowState = FormWindowState.Normal;
            Window.FormBorderStyle = FormBorderStyle.None;
            Window.TopLevel = false;
            SHOWCASE_PANEL.Controls.Add(Window);
            Window.Size = new Size(SHOWCASE_PANEL_WIDTH, SHOWCASE_PANEL_HEIGHT);
            Window.Show();
        }

        public void MaximizeScreen(object sender, EventArgs e)
        {
            Console.WriteLine("Maximizing...");
            Window.Fullscreen = true;
            SHOWCASE_PANEL.Controls.Remove(Window);
            Window.TopLevel = true;
            Window.WindowState = FormWindowState.Normal;
            Window.FormBorderStyle = FormBorderStyle.None;
            Window.Size = new Size(WINDOW_WIDTH, WINDOW_HEIGHT);
            Window.Show();
        }
        #endregion

        #region Algorithms
        private void FillAlgotihms(int SLEEP)
        {
            foreach (object itemChecked in AlgorithmsList.CheckedItems)
            {
                switch (itemChecked.ToString())
                {
                    case "BUBBLE":
                        QueueHandler.Enqueue(new BubbleSort(SLEEP, Window, "Bubble sort"));
                        break;
                    case "SELECTION":
                        QueueHandler.Enqueue(new SelectionSort(SLEEP, Window, "Selection sort"));
                        break;
                    case "HEAP":
                        QueueHandler.Enqueue(new HeapSort(SLEEP, Window, "Heap sort"));
                        break;
                    case "MERGE":
                        QueueHandler.Enqueue(new MergeSort(SLEEP, Window, "Merge sort"));
                        break;
                    case "QUICK":
                        QueueHandler.Enqueue(new QuickSort(SLEEP, Window, "Quick sort"));
                        break;
                    case "INSERTION":
                        QueueHandler.Enqueue(new InsertionSort(SLEEP, Window, "Insertion sort"));
                        break;
                    case "COCKTAIL":
                        QueueHandler.Enqueue(new CocktailSort(SLEEP, Window, "Cocktail sort"));
                        break;
                    case "SHELL":
                        QueueHandler.Enqueue(new ShellSort(SLEEP, Window, "Shell sort"));
                        break;
                    case "COMB":
                        QueueHandler.Enqueue(new CombSort(SLEEP, Window, "Comb sort"));
                        break;
                    case "CYCLE":
                        QueueHandler.Enqueue(new CycleSort(SLEEP, Window, "Cycle sort"));
                        break;
                    case "STOOGE":
                        QueueHandler.Enqueue(new StoogeSort(SLEEP, Window, "Stooge sort"));
                        break;
                }
            }
            foreach (Algorithm algorithm in QueueHandler)
            {
                AddEventHandler(algorithm);
            }
        }
        #endregion

        #region Directory

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
        #endregion

        #region Event handlers
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
        #endregion

        private void CheckBoxBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBlack.Checked)
            {
                Window.BGColor = Brushes.Black;
                checkBoxGray.Checked = false;
                checkBoxDarkBlue.Checked = false;
            }
        }

        private void CheckBoxGray_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGray.Checked)
            {
                Window.BGColor = Brushes.Gray;
                checkBoxDarkBlue.Checked = false;
                checkBoxBlack.Checked = false;
            }
        }

        private void CheckBoxDarkBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDarkBlue.Checked)
            {
                Window.BGColor = Brushes.DarkBlue;
                checkBoxBlack.Checked = false;
                checkBoxGray.Checked = false;
            }
        }
    }
}
