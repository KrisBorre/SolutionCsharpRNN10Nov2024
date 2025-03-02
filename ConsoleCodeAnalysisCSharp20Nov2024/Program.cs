using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConsoleCodeAnalysisCSharp20Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main()
        {
            // Hardcoded C# samples with different variable usages
            var samples = new[]
            {
                @"
                public class Sample1
                {
                    public void UnusedVariableMethod()
                    {
                        int x = 10;
                        int y = 20; // Unused variable
                        int z = x + 5;
                    }
                }",

                @"
                public class Sample2
                {
                    public void FullyUsedVariables()
                    {
                        int a = 5;
                        int b = 10;
                        int sum = a + b;
                        Console.WriteLine(sum);
                    }
                }",

                @"
                public class Sample3
                {
                    public void MultipleUnusedVariables()
                    {
                        int p = 100;
                        int q = 200; // Unused variable
                        int r = 300; // Unused variable
                        Console.WriteLine(p);
                    }
                }"
            };

            foreach (var (code, index) in samples.Select((code, index) => (code, index + 1)))
            {
                Console.WriteLine($"Processing Sample {index}...\n");

                SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
                CompilationUnitSyntax root = (CompilationUnitSyntax)tree.GetRoot();
                var compilation = CSharpCompilation.Create("AnalysisCompilation").AddSyntaxTrees(tree);
                var semanticModel = compilation.GetSemanticModel(tree);

                foreach (var method in root.DescendantNodes().OfType<MethodDeclarationSyntax>())
                {
                    AnalyzeMethod(method, semanticModel);
                }

                Console.WriteLine(new string('-', 50));
            }

            /*
Processing Sample 1...

In method 'UnusedVariableMethod':
  - Variable 'y' is declared but never used.
  - Variable 'z' is declared but never used.
--------------------------------------------------
Processing Sample 2...

In method 'FullyUsedVariables', all variables are used properly.
--------------------------------------------------
Processing Sample 3...

In method 'MultipleUnusedVariables':
  - Variable 'q' is declared but never used.
  - Variable 'r' is declared but never used.
--------------------------------------------------
             
             */

            Console.ReadLine();
        }

        static void AnalyzeMethod(MethodDeclarationSyntax method, SemanticModel semanticModel)
        {
            var declaredVariables = method.DescendantNodes()
                .OfType<VariableDeclaratorSyntax>()
                .Select(v => v.Identifier.ValueText)
                .ToHashSet();

            var usedVariables = method.DescendantNodes()
                .OfType<IdentifierNameSyntax>()
                .Select(id => id.Identifier.ValueText)
                .ToHashSet();

            var unusedVariables = declaredVariables.Except(usedVariables);

            if (unusedVariables.Any())
            {
                Console.WriteLine($"In method '{method.Identifier.ValueText}':");
                foreach (var variable in unusedVariables)
                {
                    Console.WriteLine($"  - Variable '{variable}' is declared but never used.");
                }
            }
            else
            {
                Console.WriteLine($"In method '{method.Identifier.ValueText}', all variables are used properly.");
            }
        }
    }
}
