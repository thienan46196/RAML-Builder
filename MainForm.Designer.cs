
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
            btnBuildSelectQuery = new Button();
            lblInputPathJSONQuery = new Label();
            lblOutPathJSONQuery = new Label();
            txbSelectTableName = new TextBox();
            lblSelectTblName = new Label();
            SuspendLayout();
            // 
            // LoadJSON
            // 
            LoadJSON.Location = new Point(16, 198);
            LoadJSON.Name = "LoadJSON";
            LoadJSON.Size = new Size(139, 46);
            LoadJSON.TabIndex = 0;
            LoadJSON.Text = "Phase2: Choose JSON";
            LoadJSON.UseVisualStyleBackColor = true;
            LoadJSON.Click += BtnConvertJSON2RAML_Click;
            // 
            // lblInputPathJSON
            // 
            lblInputPathJSON.AutoSize = true;
            lblInputPathJSON.Location = new Point(24, 245);
            lblInputPathJSON.Name = "lblInputPathJSON";
            lblInputPathJSON.Size = new Size(68, 15);
            lblInputPathJSON.TabIndex = 1;
            lblInputPathJSON.Text = "Input path: ";
            // 
            // lblOutputPathRAML
            // 
            lblOutputPathRAML.AutoSize = true;
            lblOutputPathRAML.Location = new Point(24, 260);
            lblOutputPathRAML.Name = "lblOutputPathRAML";
            lblOutputPathRAML.Size = new Size(78, 15);
            lblOutputPathRAML.TabIndex = 2;
            lblOutputPathRAML.Text = "Output path: ";
            // 
            // LoadRPT
            // 
            LoadRPT.Location = new Point(16, 69);
            LoadRPT.Name = "LoadRPT";
            LoadRPT.Size = new Size(139, 48);
            LoadRPT.TabIndex = 3;
            LoadRPT.Text = "Phase1: Choose RPT";
            LoadRPT.UseVisualStyleBackColor = true;
            LoadRPT.Click += BtnConvertRPT2JSON_Click;
            // 
            // lblInputPathRPT
            // 
            lblInputPathRPT.AutoSize = true;
            lblInputPathRPT.Location = new Point(25, 121);
            lblInputPathRPT.Name = "lblInputPathRPT";
            lblInputPathRPT.Size = new Size(68, 15);
            lblInputPathRPT.TabIndex = 4;
            lblInputPathRPT.Text = "Input path: ";
            // 
            // lblOutputPathJSON
            // 
            lblOutputPathJSON.AutoSize = true;
            lblOutputPathJSON.Location = new Point(24, 136);
            lblOutputPathJSON.Name = "lblOutputPathJSON";
            lblOutputPathJSON.Size = new Size(78, 15);
            lblOutputPathJSON.TabIndex = 5;
            lblOutputPathJSON.Text = "Output path: ";
            // 
            // exeption
            // 
            exeption.AutoSize = true;
            exeption.Location = new Point(133, 468);
            exeption.Name = "exeption";
            exeption.Size = new Size(65, 15);
            exeption.TabIndex = 6;
            exeption.Text = "Exception: ";
            // 
            // sampleQueryBtn
            // 
            sampleQueryBtn.Location = new Point(730, 69);
            sampleQueryBtn.Name = "sampleQueryBtn";
            sampleQueryBtn.Size = new Size(130, 48);
            sampleQueryBtn.TabIndex = 7;
            sampleQueryBtn.Text = "Sample Query To Get Table's Design";
            sampleQueryBtn.UseVisualStyleBackColor = true;
            sampleQueryBtn.Click += BtnShowSampleQuery_Click;
            // 
            // btnBuildSelectQuery
            // 
            btnBuildSelectQuery.Location = new Point(350, 69);
            btnBuildSelectQuery.Name = "btnBuildSelectQuery";
            btnBuildSelectQuery.Size = new Size(159, 48);
            btnBuildSelectQuery.TabIndex = 8;
            btnBuildSelectQuery.Text = "Phase3: Build Select Query";
            btnBuildSelectQuery.UseVisualStyleBackColor = true;
            btnBuildSelectQuery.Click += BtnBuildSelectQuery_Click;
            // 
            // lblInputPathJSONQuery
            // 
            lblInputPathJSONQuery.AutoSize = true;
            lblInputPathJSONQuery.Location = new Point(361, 161);
            lblInputPathJSONQuery.Name = "lblInputPathJSONQuery";
            lblInputPathJSONQuery.Size = new Size(65, 15);
            lblInputPathJSONQuery.TabIndex = 9;
            lblInputPathJSONQuery.Text = "Input path:";
            // 
            // lblOutPathJSONQuery
            // 
            lblOutPathJSONQuery.AutoSize = true;
            lblOutPathJSONQuery.Location = new Point(361, 179);
            lblOutPathJSONQuery.Name = "lblOutPathJSONQuery";
            lblOutPathJSONQuery.Size = new Size(75, 15);
            lblOutPathJSONQuery.TabIndex = 10;
            lblOutPathJSONQuery.Text = "Output path:";
            // 
            // txbSelectTableName
            // 
            txbSelectTableName.Location = new Point(442, 128);
            txbSelectTableName.Name = "txbSelectTableName";
            txbSelectTableName.Size = new Size(206, 23);
            txbSelectTableName.TabIndex = 11;
            // 
            // lblSelectTblName
            // 
            lblSelectTblName.AutoSize = true;
            lblSelectTblName.Location = new Point(361, 136);
            lblSelectTblName.Name = "lblSelectTblName";
            lblSelectTblName.Size = new Size(75, 15);
            lblSelectTblName.TabIndex = 12;
            lblSelectTblName.Text = "Table Name: ";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 533);
            Controls.Add(lblSelectTblName);
            Controls.Add(txbSelectTableName);
            Controls.Add(lblOutPathJSONQuery);
            Controls.Add(lblInputPathJSONQuery);
            Controls.Add(btnBuildSelectQuery);
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
        private Button btnBuildSelectQuery;
        private Label lblInputPathJSONQuery;
        private Label lblOutPathJSONQuery;
        private TextBox txbSelectTableName;
        private Label lblSelectTblName;
    }
}