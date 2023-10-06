using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Text;

namespace RAML_Builder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        #region Form's View
        private void BtnConvertJSON2RAML_Click(object sender, EventArgs e)
        {
            exeption.Hide();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    lblInputPathJSON.Text = "Input path: " + filePath;

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
                            lblOutputPathRAML.Text = "Output path: " + saveFileDialog.FileName;
                        }
                    }
                }
            }
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
                    lblInputPathRPT.Text = "Input path: " + filePath;

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
                            lblOutputPathJSON.Text = "Output path: " + saveFileDialog.FileName;
                        }
                    }
                }
            }
        }

        private void BtnShowSampleQuery_Click(object sender, EventArgs e)
        {
            PopupForm sampleQuery = new PopupForm();
            sampleQuery.ShowMessage("SELECT \r\n    COLUMN_NAME, \r\n    DATA_TYPE,\r\n    CHARACTER_MAXIMUM_LENGTH,\r\n    IS_NULLABLE\r\nFROM INFORMATION_SCHEMA.COLUMNS \r\nWHERE TABLE_NAME = 'Replace_With_Your_Actual_Table_Name'; \r\n\r\n\r\n Remember to change the behavior of F5 to export to .rpt file");
        }

        private void BtnBuildSelectQuery_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    lblInputPathJSONQuery.Text = "Input path: " + filePath;

                    var data = JArray.Parse(File.ReadAllText(filePath));
                    var sqlOutput = BuildSelectQuery(data, txbSelectTableName.Text);

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "RAML files (*.sql)|*.sql";
                        saveFileDialog.DefaultExt = "sql";
                        saveFileDialog.AddExtension = true;
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllText(saveFileDialog.FileName, sqlOutput);
                            lblOutputPathRAML.Text = "Output path: " + saveFileDialog.FileName;
                        }
                    }
                }
            }
        }

        #endregion

        #region Utils
        private void ShowEx(string message)
        {
            exeption.Text = message;
            exeption.Show();
        }

        private static string ToCamelCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            if (input.Length == 2 && input.All(char.IsUpper))
            {
                return input.ToLowerInvariant();
            }

            StringBuilder result = new StringBuilder();
            bool isPreviousCharUpper = true; // Assume true at the start to lowercase the first char
            foreach (var ch in input)
            {
                if (char.IsUpper(ch))
                {
                    if (isPreviousCharUpper)
                    {
                        result.Append(char.ToLowerInvariant(ch));
                    }
                    else
                    {
                        result.Append(ch);
                    }
                    isPreviousCharUpper = true;
                }
                else
                {
                    result.Append(ch);
                    isPreviousCharUpper = false;
                }
            }

            return result.ToString();
        }
        #endregion


        #region Main functionalities
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
                    record[headers[j]] = values[j] == "NULL" ? null : values[j].Trim();
                }

                results.Add(record);
            }

            if (!string.IsNullOrEmpty(_ex)) ShowEx(_ex);

            return JsonConvert.SerializeObject(results, Formatting.Indented);
        }

        private string ConvertToRaml(JArray data)
        {
            string raml = "#%RAML 1.0 DataType\ndisplayName: YOUR_DISPLAY_NAME\ndescription: YOUR_DESCRIPTION\ntype: object\nproperties:\n";
            foreach (var column in data)
            {
                string type;

                switch (column["DATA_TYPE"].ToString().Trim())
                {
                    case "int":
                    case "smallint":
                    case "mediumint":
                    case "bigint":
                    case "tinyint":
                        type = "number";
                        break;
                    case "float":
                    case "double":
                    case "decimal":
                        type = "number";
                        break;
                    case "char":
                    case "varchar":
                    case "text":
                    case "nvarchar":
                        type = "string";
                        break;
                    case "binary":
                    case "varbinary":
                    case "tinyblob":
                    case "blob":
                    case "mediumblob":
                    case "longblob":
                        type = "string"; // or "file" with additional encoding as required
                        break;
                    case "date":
                        type = "date-only";
                        break;
                    case "time":
                        type = "time-only";
                        break;
                    case "datetime":
                    case "timestamp":
                        type = "datetime";
                        break;
                    case "bit":
                        type = "boolean"; // or "integer" depending on specific usage
                        break;
                    case "bool":
                    case "boolean":
                        type = "boolean";
                        break;
                    case "json":
                        type = "any"; // or define a specific structure if known
                        break;
                    default:
                        type = column["DATA_TYPE"].ToString();
                        break;
                }

                if (column["IS_NULLABLE"].ToString() == "YES")
                    type += " | nil";
                var columnName = ToCamelCase(column["COLUMN_NAME"].ToString().Trim());
                raml += $"  {columnName}:\n";
                raml += $"    type: {type}\n";
                var length = column["CHARACTER_MAXIMUM_LENGTH"].ToString().Trim();
                if (!string.IsNullOrEmpty(length) && length != "NULL" && type == "string")
                    raml += $"    maxLength: {column["CHARACTER_MAXIMUM_LENGTH"]}\n";
                raml += $"    description: Description for {columnName}\n";
            }
            return raml;
        }
        #endregion

        private string BuildSelectQuery(JArray data, string tableName = "[YOUR_TABLE_NAME]")
        {
            if (data == null) return "";
            var fields = new List<string>();
            foreach (var column in data)
            {
                var col = column["COLUMN_NAME"].ToString();
                if (!string.IsNullOrEmpty(col))
                {
                    fields.Add(ToCamelCase(col.Trim()));
                }
            }

            return @$"SELECT {string.Join(", ", fields)} FROM {tableName}";
        }

        private void lblSelectTblName_Click(object sender, EventArgs e)
        {

        }
    }
}