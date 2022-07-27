namespace hw7
{
    public partial class Main : Form
    {
        private string fileText { get; set; }
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openSearchDialog();
        }

        private void openSearchDialog()
        {
            using (SearchForm searchForm = new SearchForm())
            {
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    fileText = "Hello From Dialog";
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
    }
}