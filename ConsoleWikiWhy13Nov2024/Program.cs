using LibraryWikiWhy13Nov2024;
using System.Data;

namespace ConsoleWikiWhy13Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of WikiWhyLoader
            WikiWhyLoader loader = new WikiWhyLoader();

            // Load the WikiWhy dataset
            DataTable wikiWhyData = loader.LoadWikiWhy();

            // Print the loaded DataTable (optional)
            foreach (DataRow row in wikiWhyData.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}