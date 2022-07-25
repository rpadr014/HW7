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
    public partial class SearchForm : Form
    {
        CancellationTokenSource _tokenSource;
        BackgroundWorker worker;
        private delegate void DELEGATE();
        CancellationToken token;
        public SearchForm()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            _tokenSource = new CancellationTokenSource();
            token = _tokenSource.Token;
        }

        public void SearchForm_Load(object sender, EventArgs e)
        {
           
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            worker.DoWork += SearchFiles;
            worker.RunWorkerAsync();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _tokenSource.Cancel();
        }


        private void SearchFiles(object sender, DoWorkEventArgs e)
        {
            Delegate del = new DELEGATE(Search);
            this.Invoke(del);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0) return;
            var files = e.UserState as List<string>;
            var sb = new StringBuilder();
            foreach (var file in files)
            {
                this.filesListBox.Items.Add(file);
            }
        }
        private void Search()
        {
            foreach (String drive in Directory.GetLogicalDrives())
            {
                /*  Debug.WriteLine(drive);*//**/
                foreach (DirectoryInfo child in getDirectories(drive))
                {
                    /* Debug.WriteLine(child.FullName);*//**/
                    FindFiles(child);
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                }
            }
        }

        private void FindFiles(DirectoryInfo dir)
        {
            var progressLimit = 100;
            List<string> files = new List<string>();
            string fileExt = this.extDropdown.Text;
            try
            {
                DirectoryInfo[] children = getDirectories(dir);
                if (children.Length > 0)
                {
                    foreach (DirectoryInfo child in children)
                    {
                        /*         Debug.WriteLine(child.FullName);*/
                        FindFiles(child);
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    FileInfo[] Files = dir.GetFiles("*" + fileExt);
                    if (Files.Length > 0)
                    {
                        foreach (FileInfo File in Files)
                        {
                            Debug.WriteLine("FILE: " + File.FullName);
                            files.Add(File.FullName);
                            if (files.Count % progressLimit == 0)
                            {
                                worker.ReportProgress(files.Count, files.ToArray());
                                files.Clear();
                            }

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
    }
}
