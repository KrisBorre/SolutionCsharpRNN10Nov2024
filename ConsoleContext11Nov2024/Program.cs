using Newtonsoft.Json;

namespace ConsoleContext11Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../context.json";

            try
            {
                // Read the content of the JSON file
                string jsonContent = File.ReadAllText(filePath);

                // Deserialize the JSON content into a strongly typed object
                var contextData = JsonConvert.DeserializeObject<ContextData>(jsonContent);

                // Check if the context data exists and print it
                if (contextData?.Ctx != null)
                {
                    foreach (var entry in contextData.Ctx)
                    {
                        Console.WriteLine($"ID: {entry.Key}");
                        Console.WriteLine($"Context: {entry.Value}");
                        Console.WriteLine(new string('-', 50)); // Separator for readability
                    }
                }
                else
                {
                    Console.WriteLine("No context data found in the JSON file.");
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

    // Define a class to represent the structure of the JSON file
    class ContextData
    {
        [JsonProperty("ctx")]
        public Dictionary<string, string> Ctx { get; set; }
    }
}