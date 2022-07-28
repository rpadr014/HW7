using HW7;
using Microsoft.VisualBasic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace hw7
{
    public partial class Main : Form
    {
        private List<HW7.Text> textList;
        private string fileName = "";
        public Text textProp = new Text();
        private bool edited = false;
        private Document doc = new Document();

        private Control activeControl;
        private Point previousPosition;
        public Main()
        {
            InitializeComponent();
            textList = new List<HW7.Text>();

        }

        private void openSearchDialog()
        {
            if ((Application.OpenForms["SearchForm"] as SearchForm) == null)
            {
                using (SearchForm searchForm = new SearchForm())
                {
                    if (searchForm.ShowDialog() == DialogResult.OK)
                    {
                        string fileText = System.IO.File.ReadAllText(SearchForm.fileToImport);
                        HW7.TextInputDialog dialog = new HW7.TextInputDialog();
                        dialog.setText(fileText);
                        dialog.OnSave += OnTextBoxDialogSave;
                        dialog.ShowDialog();


                    }
                }
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (IsKeyLocked(Keys.CapsLock))
            {
                capsLabel.Text = "CapsLock is on!";
            }
            else
            {
                capsLabel.Text = "";
            }
        }

        private void OnInsertTextClick(object sender, EventArgs e)
        {
            HW7.TextInputDialog dialog = new HW7.TextInputDialog();
            dialog.OnSave += OnTextBoxDialogSave;
            dialog.ShowDialog();
        }

        private void OnTextBoxDialogSave(object sender, HW7.TextInputEventArgs e)
        {

            var panel = new HW7.SelectablePanel();
            panel.Location = e.TextInput.Location;
            panel.BackColor = e.TextInput.BackColor;
            panel.MouseDown += new MouseEventHandler(drawing_MouseDown);
            panel.MouseMove += new MouseEventHandler(drawing_MouseMove);
            panel.MouseUp += new MouseEventHandler(drawing_MouseUp);
            panel.Paint += new PaintEventHandler(drawing_Paint);
            panel.KeyDown += new KeyEventHandler(drawing_KeyDown);
            this.Controls.Add(panel);

            this.textList.Add(e.TextInput);
            textProp.SavedText = e.TextInput.SavedText;
            textProp.Font = e.TextInput.Font;
            textProp.Location = e.TextInput.Location;
            textProp.BrushColor = e.TextInput.Color;
            textProp.BackColor = e.TextInput.BackColor;
            panel.Refresh();

            this.CreateGraphics().DrawString(e.TextInput.SavedText, e.TextInput.Font, new SolidBrush(e.TextInput.Color), e.TextInput.Location);
            
        }

        private void importFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openSearchDialog();
        }

        private void serializer()
        {
            doc.TextList.Add(textProp);
            FileStream fs = new FileStream(fileName, FileMode.Create);
            SoapFormatter formatter = new SoapFormatter();

            try
            {
                //shape.ShapeSize = new Size(this.Size.Width, this.Size.Height);
                //shape.ShapeLocation = new Point(this.Location.X, this.Location.Y);
                //textProp.textTitle = fileName;
                formatter.Serialize(fs, doc);
                //statusLabel.Text = fileName + " was saved.  " + DateTime.Now.ToString();
            }
            catch (SerializationException er)
            {
                Console.WriteLine("Failed to serialize. Reason: " + er.Message);
                throw;
            }
            finally
            {
                fs.Close();
                edited = false;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == "")
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                serializer();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "soap files|*.soap";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                serializer();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                FileStream fs = new FileStream(fileName, FileMode.Open);
                try
                {
                    SoapFormatter formatter = new SoapFormatter();
                    Document newfeatures = (Document)formatter.Deserialize(fs);
                    doc = newfeatures;
                    loadFeatures(doc);
                    //statusLabel.Text = fileName + " was opened.";
                    this.Text = fileName;
                }
                catch (SerializationException er)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + er.Message);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }
        private void loadFeatures(Document theFeatures)
        {
            CreateGraphics().DrawString(theFeatures.TextList[0].SavedText, theFeatures.TextList[0].Font, new SolidBrush(theFeatures.TextList[0].BrushColor), theFeatures.TextList[0].Location);
            //foreach (Shape s in theFeatures.savedShapes)
            //{
            //    s.Pen = new Pen(s.PenColor, 1);
            //    //s.Pen.DashPattern = s.DashPattern;
            //}
            //this.pictureBox.Refresh();
        }
        private void drawing_MouseDown(object sender, MouseEventArgs e)
        {
            
                activeControl = sender as Control;
                InvokeOnClick(activeControl, EventArgs.Empty);
                previousPosition = e.Location;
                Cursor = Cursors.Hand;
        }
        private void drawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (activeControl == null || activeControl != sender)
            {
                return;
            }
            InvokeOnClick(activeControl, EventArgs.Empty);
            var location = activeControl.Location;
            location.Offset(e.Location.X - previousPosition.X, e.Location.Y - previousPosition.Y);
            activeControl.Location = location;
        }
        private void drawing_MouseUp(object sender, MouseEventArgs e)
        {
            activeControl = null;
            Cursor = Cursors.Default;
        }

        private void drawing_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            HW7.Text TextArgs = this.textList[this.textList.Count - 1];
            g.DrawString(TextArgs.SavedText, TextArgs.Font, new SolidBrush(TextArgs.Color), TextArgs.Location);

        }

        private void drawing_KeyDown(object sender, KeyEventArgs e)
        {
            activeControl = sender as Control;
            var location = activeControl.Location;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    location.Offset(-10, 0);
                    activeControl.Location = location;
                    break;
                case Keys.Right:
                    location.Offset(10, 0);
                    activeControl.Location = location;
                    break;
                case Keys.Up:
                    location.Offset(0,-10);
                    activeControl.Location = location;
                    break;
                case Keys.Down:
                    location.Offset(0, 10);
                    activeControl.Location = location;
                    break;
            }
          
        }
    }
}