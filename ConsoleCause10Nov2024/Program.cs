using Newtonsoft.Json;

namespace ConsoleCause10Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../cause.json";

            try
            {
                // Read the content of the JSON file
                string jsonContent = File.ReadAllText(filePath);

                // Parse the JSON into a dictionary
                var data = JsonConvert.DeserializeObject<CauseData>(jsonContent);

                // Check if the data contains causes and print them
                if (data?.Cause != null)
                {
                    foreach (var entry in data.Cause)
                    {
                        Console.WriteLine($"ID: {entry.Key}, Cause: {entry.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("No causes found in the JSON file.");
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
    class CauseData
    {
        [JsonProperty("cause")]
        public Dictionary<string, string> Cause { get; set; }
    }
}