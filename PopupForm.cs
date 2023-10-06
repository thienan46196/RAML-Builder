﻿namespace RAML_Builder
{
    public partial class PopupForm : Form
    {
        public PopupForm()
        {
            InitializeComponent();
        }

        public void ShowMessage(string message)
        {
            txbSelectTableName.Text = message;
            ShowDialog();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
