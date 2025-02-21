using Newtonsoft.Json;

namespace ConsoleExplanation10Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../explanation.json";

            try
            {
                // Read the content of the JSON file
                string jsonContent = File.ReadAllText(filePath);

                // Parse the JSON into a dictionary
                var data = JsonConvert.DeserializeObject<ExplanationData>(jsonContent);

                // Check if the data contains explanations and print them
                if (data?.Explanation != null)
                {
                    foreach (var entry in data.Explanation)
                    {
                        Console.WriteLine($"ID: {entry.Key}, Explanation: {entry.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("No explanations found in the JSON file.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file '{filePath}' was not found.");
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Error: Failed to parse JSON. Details: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error occurred: {e.Message}");
            }
        }
    }

    // Define a class to represent the JSON structure
    class ExplanationData
    {
        [JsonProperty("explanation")]
        public Dictionary<string, string> Explanation { get; set; }
    }
}