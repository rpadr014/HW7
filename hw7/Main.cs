using Microsoft.VisualBasic;

namespace hw7
{
    public partial class Main : Form
    {
        private List<HW7.Text> textList;

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
            //string input = Interaction.IntputBox("Ener your text: ", "Text Input", "", 10, 10);
            var font = new Font("TimesNewRoman", 25, FontStyle.Bold, GraphicsUnit.Pixel);

            this.textList.Add(e.TextInput);

            this.CreateGraphics().DrawString(e.TextInput.SavedText, e.TextInput.Font, new SolidBrush(e.TextInput.Color), e.TextInput.Location);
        }

        private void importFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openSearchDialog();
        }
    }
}