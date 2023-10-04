
namespace RAML_Builder
{
    partial class MainForm
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
            LoadJSON = new Button();
            lblInputPathJSON = new Label();
            lblOutputPathRAML = new Label();
            LoadRPT = new Button();
            lblInputPathRPT = new Label();
            lblOutputPathJSON = new Label();
            exeption = new Label();
            sampleQueryBtn = new Button();
            SuspendLayout();
            // 
            // LoadJSON
            // 
            LoadJSON.Location = new Point(16, 198);
            LoadJSON.Name = "LoadJSON";
            LoadJSON.Size = new Size(139, 46);
            LoadJSON.TabIndex = 0;
            LoadJSON.Text = "Choose JSON";
            LoadJSON.UseVisualStyleBackColor = true;
            LoadJSON.Click += BtnConvertJSON2RAML_Click;
            // 
            // lblInputPathJSON
            // 
            lblInputPathJSON.AutoSize = true;
            lblInputPathJSON.Location = new Point(16, 245);
            lblInputPathJSON.Name = "lblInputPathJSON";
            lblInputPathJSON.Size = new Size(41, 15);
            lblInputPathJSON.TabIndex = 1;
            lblInputPathJSON.Text = "Input: ";
            // 
            // lblOutputPathRAML
            // 
            lblOutputPathRAML.AutoSize = true;
            lblOutputPathRAML.Location = new Point(16, 260);
            lblOutputPathRAML.Name = "lblOutputPathRAML";
            lblOutputPathRAML.Size = new Size(51, 15);
            lblOutputPathRAML.TabIndex = 2;
            lblOutputPathRAML.Text = "Output: ";
            // 
            // LoadRPT
            // 
            LoadRPT.Location = new Point(16, 69);
            LoadRPT.Name = "LoadRPT";
            LoadRPT.Size = new Size(139, 48);
            LoadRPT.TabIndex = 3;
            LoadRPT.Text = "Choose RPT";
            LoadRPT.UseVisualStyleBackColor = true;
            LoadRPT.Click += BtnConvertRPT2JSON_Click;
            // 
            // lblInputPathRPT
            // 
            lblInputPathRPT.AutoSize = true;
            lblInputPathRPT.Location = new Point(25, 121);
            lblInputPathRPT.Name = "lblInputPathRPT";
            lblInputPathRPT.Size = new Size(41, 15);
            lblInputPathRPT.TabIndex = 4;
            lblInputPathRPT.Text = "Input: ";
            // 
            // lblOutputPathJSON
            // 
            lblOutputPathJSON.AutoSize = true;
            lblOutputPathJSON.Location = new Point(24, 136);
            lblOutputPathJSON.Name = "lblOutputPathJSON";
            lblOutputPathJSON.Size = new Size(47, 15);
            lblOutputPathJSON.TabIndex = 5;
            lblOutputPathJSON.Text = "Ouput: ";
            // 
            // exeption
            // 
            exeption.AutoSize = true;
            exeption.Location = new Point(211, 365);
            exeption.Name = "exeption";
            exeption.Size = new Size(65, 15);
            exeption.TabIndex = 6;
            exeption.Text = "Exception: ";
            // 
            // sampleQueryBtn
            // 
            sampleQueryBtn.Location = new Point(658, 69);
            sampleQueryBtn.Name = "sampleQueryBtn";
            sampleQueryBtn.Size = new Size(101, 48);
            sampleQueryBtn.TabIndex = 7;
            sampleQueryBtn.Text = "Sample Query";
            sampleQueryBtn.UseVisualStyleBackColor = true;
            sampleQueryBtn.Click += btnShowMessage_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sampleQueryBtn);
            Controls.Add(exeption);
            Controls.Add(lblOutputPathJSON);
            Controls.Add(lblInputPathRPT);
            Controls.Add(LoadRPT);
            Controls.Add(LoadJSON);
            Controls.Add(lblInputPathJSON);
            Controls.Add(lblOutputPathRAML);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoadJSON;
        private Label lblInputPathJSON;
        private Label lblOutputPathRAML;
        private Button LoadRPT;
        private Label lblInputPathRPT;
        private Label lblOutputPathJSON;
        private Label exeption;
        private Button sampleQueryBtn;
    }
}