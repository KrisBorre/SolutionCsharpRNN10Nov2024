using Newtonsoft.Json;

namespace ConsoleQuestion10Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../question.json";

            try
            {
                // Read the content of the JSON file
                string jsonContent = File.ReadAllText(filePath);

                // Parse the JSON into a dictionary
                var data = JsonConvert.DeserializeObject<QuestionData>(jsonContent);

                // Check if the data contains questions and print them
                if (data?.Question != null)
                {
                    foreach (var entry in data.Question)
                    {
                        Console.WriteLine($"ID: {entry.Key}, Question: {entry.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("No questions found in the JSON file.");
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
    class QuestionData
    {
        [JsonProperty("question")]
        public Dictionary<string, string> Question { get; set; }
    }
}