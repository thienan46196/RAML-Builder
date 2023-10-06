namespace RAML_Builder
{
    partial class PopupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txbSelectTableName = new TextBox();
            SuspendLayout();
            // 
            // txbSelectTableName
            // 
            txbSelectTableName.Location = new Point(84, 125);
            txbSelectTableName.Multiline = true;
            txbSelectTableName.Name = "txbSelectTableName";
            txbSelectTableName.ReadOnly = true;
            txbSelectTableName.ScrollBars = ScrollBars.Vertical;
            txbSelectTableName.Size = new Size(520, 167);
            txbSelectTableName.TabIndex = 0;
            // 
            // PopupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txbSelectTableName);
            Name = "PopupForm";
            Text = "PopupForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbSelectTableName;
    }
}