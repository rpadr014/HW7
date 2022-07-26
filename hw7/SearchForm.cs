using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw7
{
    enum SearchState
    {
        Stopped,
        Running,
        Paused,
        Cancelled
    }
    public partial class SearchForm : Form
    {
        BackgroundWorker worker;
        ManualResetEvent _busy;
        SearchState workerState;
        string workerExt;
        Dictionary<string, FileInfo> myFiles;

        public SearchForm()
        {
            InitializeComponent();
            _busy = new ManualResetEvent(false);
            workerState = SearchState.Stopped;
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += Search;
            worker.RunWorkerCompleted += SearchCompleted;
            myFiles = new Dictionary<string, FileInfo>();
        }

        public void SearchForm_Load(object sender, EventArgs e)
        {
            this.extDropdown.SelectedIndex = 0;
            this.extDropdown.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if(workerState == SearchState.Stopped)
            {
                this.filesListBox.Items.Clear();
                this.searchButton.Text = "Pause";
                workerState = SearchState.Running;
                this.statusLabel.Text = "Searching";
                worker.RunWorkerAsync();
                _busy.Set();
            }
            else if(workerState == SearchState.Running)
            {
                _busy.Reset();
                this.searchButton.Text = "Resume";
                this.statusLabel.Text = "Paused";
                workerState = SearchState.Paused;
            }
            else if (workerState == SearchState.Paused)
            {
                this.searchButton.Text = "Pause";
                this.statusLabel.Text = "Searching";
                workerState = SearchState.Running;
                _busy.Set();
            }
        }

        private void SearchCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.searchButton.Text = "Search";
            this.statusLabel.Text = "Stopped";
            if (workerState == SearchState.Cancelled)
            {
                MessageBox.Show("Search Cancelled. " + this.filesListBox.Items.Count + " Files Found");
            }
            else
            {
                MessageBox.Show("Search Completed. " + this.filesListBox.Items.Count + " Files Found");
            }
            workerState = SearchState.Stopped;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
            {
                this.searchButton.Text = "Search";
                workerState = SearchState.Cancelled;
                worker.CancelAsync();
                _busy.Set();
            }
        }

        private void Search(object sender, DoWorkEventArgs e)
        {
            foreach (String drive in Directory.GetLogicalDrives())
            {
                foreach (DirectoryInfo child in getDirectories(drive))
                {
                    _busy.WaitOne();
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                            return;
                    }
                    FindFiles(child,e);
                }
            }
        }

        private void FindFiles(DirectoryInfo dir, DoWorkEventArgs e)
        {
            try
            {
                DirectoryInfo[] children = getDirectories(dir);
                if (children.Length > 0)
                {
                    foreach (DirectoryInfo child in children)
                    {
                        _busy.WaitOne();
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                        FindFiles(child,e);
                    }
                }
                else
                {
                    FileInfo[] Files = dir.GetFiles("*" + workerExt);
                    if (Files.Length > 0)
                    {
                        foreach (FileInfo File in Files)
                        {
                            _busy.WaitOne();
                            if (worker.CancellationPending)
                            {
                                e.Cancel = true;
                                return;
                            }
                            Debug.WriteLine("FILE: " + File.FullName);
                           
                            filesListBox.BeginInvoke(new MethodInvoker(() => {
                                myFiles.Add(File.FullName, File);
                                filesListBox.Items.Add(File.FullName);
                            }));
                           

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);

            }
        }

        private bool AttrOn(FileAttributes attr, FileAttributes field)
        {
            return (attr & field) == field;
        }

        public DirectoryInfo[] getDirectories(DirectoryInfo dir)
        {
            if (AttrOn(dir.Attributes, FileAttributes.Offline))
            {
                Console.Out.WriteLine(dir.Name + " is not mapped ");
                return new DirectoryInfo[] { };
            }
            if (!dir.Exists)
            {
                Console.Out.WriteLine(dir.Name + " does not exist ");
                return new DirectoryInfo[] { };
            }
            try
            {
                return dir.GetDirectories();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
                Console.Out.WriteLine(ex.StackTrace);
                return new DirectoryInfo[] { };
            }
        }

        public DirectoryInfo[] getDirectories(String strDrive)
        {
            DirectoryInfo dir = new DirectoryInfo(strDrive);
            return getDirectories(dir);
        }

        private void extDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            workerExt = this.extDropdown.Text;
        }

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();
                _busy.Set();
            }
        }

        private void filesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.filesListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                MessageBox.Show("TO DO: IMPORT FILE WITH INDEX -> " + index.ToString() );
            }
        }
    }
}
