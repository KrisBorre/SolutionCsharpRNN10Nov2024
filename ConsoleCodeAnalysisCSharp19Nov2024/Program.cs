using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConsoleCodeAnalysisCSharp19Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main()
        {
            // Hardcoded C# samples
            var samples = new[]
            {
                @"
                namespace SampleNamespace1
                {
                    public class TargetClass
                    {
                        public void MethodA() { }
                    }
                }",

                @"
                namespace SampleNamespace2
                {
                    public class AnotherClass
                    {
                        public void UseTarget()
                        {
                            TargetClass obj = new TargetClass();
                        }
                    }
                }",

                @"
                namespace SampleNamespace3
                {
                    public class SomeOtherClass
                    {
                        public void ReferenceTarget()
                        {
                            var instance = new SampleNamespace1.TargetClass();
                            instance.MethodA();
                        }
                    }
                }"
            };

            // Class to search for
            string className = "TargetClass";

            // Process each sample code
            foreach (var (code, index) in samples.Select((code, index) => (code, index + 1)))
            {
                Console.WriteLine($"Processing Sample {index}...\n");

                SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
                CompilationUnitSyntax root = (CompilationUnitSyntax)tree.GetRoot();

                // Find all references to the specified class
                var references = new List<string>();

                foreach (var identifier in root.DescendantNodes().OfType<IdentifierNameSyntax>())
                {
                    if (identifier.Identifier.ValueText == className)
                    {
                        references.Add(identifier.ToFullString());
                    }
                }

                // Print references found in the sample
                if (references.Any())
                {
                    Console.WriteLine($"References to class '{className}' in Sample {index}:");
                    foreach (var reference in references)
                    {
                        Console.WriteLine($"  - {reference}");
                    }
                }
                else
                {
                    Console.WriteLine($"No references found for class '{className}' in Sample {index}.");
                }

                Console.WriteLine(new string('-', 50));
            }

            /*
Processing Sample 1...

No references found for class 'TargetClass' in Sample 1.
--------------------------------------------------
Processing Sample 2...

References to class 'TargetClass' in Sample 2:
  -                             TargetClass
  - TargetClass
--------------------------------------------------
Processing Sample 3...

References to class 'TargetClass' in Sample 3:
  - TargetClass
--------------------------------------------------
             */

            Console.ReadLine();
        }
    }
}