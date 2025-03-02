using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace ConsoleCodeAnalysisCSharp23Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main()
        {
            // C# source code with a deliberate semantic error (undefined variable `y`)
            var code = @"
            using System;
            class Example
            {
                void Main()
                {
                    int x = 10;
                    int y = undefinedVariable; // Undefined variable
                    Console.WriteLine(x + y);
                }
            }";

            // Parse the code into a syntax tree
            var syntaxTree = CSharpSyntaxTree.ParseText(code);

            // Create a C# compilation
            var compilation = CSharpCompilation.Create("TempCompilation")
                .AddSyntaxTrees(syntaxTree)
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));

            // Retrieve compilation diagnostics (both syntax and semantic)
            var diagnostics = compilation.GetDiagnostics();

            // Report syntax and semantic errors
            if (diagnostics.Any())
            {
                Console.WriteLine("Compilation Errors:\n");

                foreach (var diagnostic in diagnostics)
                {
                    Console.WriteLine($"[{diagnostic.Severity}] {diagnostic.Id}: {diagnostic.GetMessage()}");
                    Console.WriteLine($"Location: {diagnostic.Location}");
                    Console.WriteLine(new string('-', 50));
                }
            }
            else
            {
                Console.WriteLine("No errors found in the code.");
            }

            /*
Compilation Errors:

[Error] CS5001: Program does not contain a static 'Main' method suitable for an entry point
Location: None
--------------------------------------------------
[Error] CS0103: The name 'undefinedVariable' does not exist in the current context
Location: SourceFile([180..197))
--------------------------------------------------
[Error] CS0103: The name 'Console' does not exist in the current context
Location: SourceFile([242..249))
--------------------------------------------------
[Hidden] CS8019: Unnecessary using directive.
Location: SourceFile([14..27))
--------------------------------------------------
             */
        }
    }
}
