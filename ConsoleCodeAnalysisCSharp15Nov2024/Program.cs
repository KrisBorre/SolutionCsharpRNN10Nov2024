using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace ConsoleCodeAnalysisCSharp15Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main()
        {
            // Create example syntax trees
            var syntaxTrees = new List<SyntaxTree>
            {
                CSharpSyntaxTree.ParseText(@"
                    namespace Test1 
                    { 
                        public class Class1 
                        { 
                            public void Method1() {} 
                        } 
                    }"),
                CSharpSyntaxTree.ParseText(@"
                    namespace Test2 
                    { 
                        public class Class2 
                        { 
                            private int x; // Unused field to potentially trigger a diagnostic
                        } 
                    }"),
            };

            // Create a C# compilation with specific options
            var compilation = CSharpCompilation.Create("MyCompilation")
                .AddSyntaxTrees(syntaxTrees)
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location) // Required for System types
                );

            // Get all diagnostics from the compilation
            var compilationDiagnostics = compilation.GetDiagnostics();

            // Output diagnostics or indicate no issues found
            if (compilationDiagnostics.Any())
            {
                Console.WriteLine("Compilation Diagnostics Found:");
                foreach (var diagnostic in compilationDiagnostics)
                {
                    Console.WriteLine($"ID: {diagnostic.Id} | Severity: {diagnostic.Severity}");
                    Console.WriteLine($"Message: {diagnostic.GetMessage()}");
                    Console.WriteLine($"Location: {diagnostic.Location}");
                    Console.WriteLine(new string('-', 50));
                }
            }
            else
            {
                Console.WriteLine("Compilation successful! No diagnostics found.");
            }

            /*
            Compilation Diagnostics Found:
            ID: CS0169 | Severity: Warning
            Message: The field 'Class2.x' is never used
            Location: SourceFile([178..179))
            --------------------------------------------------
            */

            Console.ReadLine();
        }
    }
}