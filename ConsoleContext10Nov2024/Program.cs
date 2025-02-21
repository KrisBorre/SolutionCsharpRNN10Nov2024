using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleContext10Nov2024
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

                // Parse the JSON content dynamically
                var jsonObject = JObject.Parse(jsonContent);

                // Display the JSON structure
                Console.WriteLine("Parsed JSON Content:");
                PrintJson(jsonObject, 0);
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

        // Recursive method to print JSON content with proper formatting
        static void PrintJson(JToken token, int indent)
        {
            if (token is JProperty property)
            {
                Console.Write(new string(' ', indent));
                Console.WriteLine($"{property.Name}:");

                PrintJson(property.Value, indent + 2);
            }
            else if (token is JObject obj)
            {
                foreach (var child in obj.Properties())
                {
                    PrintJson(child, indent);
                }
            }
            else if (token is JArray array)
            {
                foreach (var child in array)
                {
                    PrintJson(child, indent + 2);
                }
            }
            else
            {
                Console.Write(new string(' ', indent));
                Console.WriteLine(token);
            }
        }
    }
}