namespace RAML_Builder
{
    public partial class SampleQuery : Form
    {
        public SampleQuery()
        {
            InitializeComponent();
        }

        public void ShowMessage(string message)
        {
            textBox1.Text = message;
            ShowDialog();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
