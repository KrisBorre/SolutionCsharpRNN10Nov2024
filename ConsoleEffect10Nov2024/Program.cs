using Newtonsoft.Json;

namespace ConsoleEffect10Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../effect.json";

            try
            {
                // Read the content of the JSON file
                string jsonContent = File.ReadAllText(filePath);

                // Parse the JSON into a dictionary
                var data = JsonConvert.DeserializeObject<EffectData>(jsonContent);

                // Check if the data contains effects and print them
                if (data?.Effect != null)
                {
                    foreach (var entry in data.Effect)
                    {
                        Console.WriteLine($"ID: {entry.Key}, Effect: {entry.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("No effects found in the JSON file.");
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
    class EffectData
    {
        [JsonProperty("effect")]
        public Dictionary<string, string> Effect { get; set; }
    }
}