using Newtonsoft.Json.Linq;
using System.Data;

namespace LibraryWikiWhy13Nov2024
{
    // ChatGPT
    public class WikiWhyLoader
    {
        // File-to-column mapping
        private readonly Dictionary<string, List<string>> fileColumnMapping = new Dictionary<string, List<string>>
            {
                { "context.json", new List<string> { "ctx", "title", "topic", "split" } },
                { "question.json", new List<string> { "question" } },
                { "cause.json", new List<string> { "cause" } },
                { "effect.json", new List<string> { "effect" } },
                { "explanation.json", new List<string> { "explanation" } }
            };

        // Method to load the WikiWhy dataset into a DataTable
        public DataTable LoadWikiWhy(string directoryPath = "../../../../LibraryWikiWhy13Nov2024/")
        {
            DataTable dataTable = new DataTable();

            try
            {
                foreach (var entry in fileColumnMapping)
                {
                    string fileName = entry.Key;
                    List<string> columnSubset = entry.Value;

                    string filePath = Path.Combine(directoryPath, fileName);

                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Read and parse the JSON file
                    string jsonContent = File.ReadAllText(filePath);
                    JObject jsonObject = JObject.Parse(jsonContent);

                    // Add columns to the DataTable if not already present
                    foreach (var column in columnSubset)
                    {
                        if (!dataTable.Columns.Contains(column))
                        {
                            dataTable.Columns.Add(column);
                        }
                    }

                    // Extract data and populate the DataTable
                    DataRow newRow = dataTable.NewRow();
                    foreach (var column in columnSubset)
                    {
                        if (jsonObject[column] != null)
                        {
                            newRow[column] = jsonObject[column].ToString();
                        }
                    }
                    dataTable.Rows.Add(newRow);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading the dataset: {ex.Message}");
            }

            return dataTable;
        }
    }
}