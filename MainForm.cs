using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace RAML_Builder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnConvertJSON2RAML_Click(object sender, EventArgs e)
        {
            exeption.Hide();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    lblInputPathJSON.Text = "Input: " + filePath;

                    var data = JArray.Parse(File.ReadAllText(filePath));
                    var ramlOutput = ConvertToRaml(data);

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "RAML files (*.raml)|*.raml";
                        saveFileDialog.DefaultExt = "raml";
                        saveFileDialog.AddExtension = true;
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllText(saveFileDialog.FileName, ramlOutput);
                            lblOutputPathRAML.Text = "Output: " + saveFileDialog.FileName;
                        }
                    }
                }
            }
        }

        private void ShowEx(string message)
        {
            exeption.Text = message;
            exeption.Show();
        }

        private static string FirstCharToLower(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToLower(input[0]) + input.Substring(1);
        }

        private void BtnConvertRPT2JSON_Click(object sender, EventArgs e)
        {
            exeption.Hide();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "RPT files (*.rpt)|*.rpt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    lblInputPathRPT.Text = "Input: " + filePath;

                    var data = File.ReadAllText(filePath);
                    Console.Write(data);
                    var jsonOuput = ConvertToJSON(data);

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "JSON files (*.json)|*.json";
                        saveFileDialog.DefaultExt = "json";
                        saveFileDialog.AddExtension = true;
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllText(saveFileDialog.FileName, jsonOuput);
                            lblOutputPathJSON.Text = "Output: " + saveFileDialog.FileName;
                        }
                    }
                }
            }
        }

        public string ConvertToJSON(string content)
        {
            var _ex = "";
            var lines = content.Trim().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length < 3) // Check if there are headers and at least one line of data
            {
                throw new Exception("Insufficient data lines provided.");
            }

            var headers = lines[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var results = new List<Dictionary<string, string>>();

            for (int i = 2; i < lines.Length; i++)
            {
                var line = lines[i].Trim();
                var values = line.Split(new[] { "  " }, StringSplitOptions.None).Where(value => !string.IsNullOrEmpty(value)).ToList(); // Splitting by two spaces

                if (values.Count != headers.Length)
                {
                    _ex = "Catch not appropriate line of data";
                    break;
                }

                var record = new Dictionary<string, string>();
                for (int j = 0; j < headers.Length; j++)
                {
                    record[headers[j]] = values[j] == "NULL" ? null : values[j];
                }

                results.Add(record);
            }

            if (!string.IsNullOrEmpty(_ex)) ShowEx(_ex);

            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        private string ConvertToRaml(JArray data)
        {
            string raml = "#%RAML 1.0\ntitle: MuleSoft API\n\ntypes:\n";
            foreach (var column in data)
            {
                string type;
                switch (column["DATA_TYPE"].ToString())
                {
                    case "int":
                        type = "integer";
                        break;
                    case "nvarchar":
                        type = "string";
                        break;
                    default:
                        type = column["DATA_TYPE"].ToString();
                        break;
                }
                if (column["IS_NULLABLE"].ToString() == "YES")
                    type += " | nil";
                var columnName = FirstCharToLower(column["COLUMN_NAME"].ToString());
                raml += $"  {columnName}:\n";
                raml += $"    type: {type}\n";
                if (column["CHARACTER_MAXIMUM_LENGTH"].HasValues)
                    raml += $"    maxLength: {column["CHARACTER_MAXIMUM_LENGTH"]}\n";
                raml += $"    description: Description for {columnName}\n";
            }
            return raml;
        }

        private void btnShowMessage_Click(object sender, EventArgs e)
        {
            SampleQuery sampleQuery = new SampleQuery();
            sampleQuery.ShowMessage("SELECT \r\n    COLUMN_NAME, \r\n    DATA_TYPE,\r\n    CHARACTER_MAXIMUM_LENGTH,\r\n    IS_NULLABLE\r\nFROM INFORMATION_SCHEMA.COLUMNS \r\nWHERE TABLE_NAME = 'Replace_With_Your_Actual_Table_Name'; \r\n\r\n\r\n Remember to change the behavior of F5 to export to .rpt file");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }


}