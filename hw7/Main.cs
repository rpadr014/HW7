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
    }
}