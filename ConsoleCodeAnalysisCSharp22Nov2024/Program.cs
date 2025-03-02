using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConsoleCodeAnalysisCSharp22Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main()
        {
            var sampleCodes = new[]
            {
            @"
            namespace FirstNamespace
            {
                public class ExampleClass
                {
                    public void Display() { Console.WriteLine(""Hello from ExampleClass!""); }
                }

                public class UserClass
                {
                    public void Execute()
                    {
                        var obj = new ExampleClass();
                        obj.Display();
                    }
                }
            }",

            @"
            namespace SecondNamespace
            {
                public class SampleClass
                {
                    public void Run() { Console.WriteLine(""Running SampleClass!""); }
                }

                public class TestClass
                {
                    public void Perform()
                    {
                        SampleClass sample = new SampleClass();
                        sample.Run();
                    }
                }
            }",

            @"
            namespace ThirdNamespace
            {
                public class HelperClass
                {
                    public void Assist() { Console.WriteLine(""Assisting...""); }
                }

                public class WorkerClass
                {
                    public void Work()
                    {
                        HelperClass helper = new HelperClass();
                        helper.Assist();
                    }
                }
            }"
        };

            foreach (var (code, index) in sampleCodes.Select((code, index) => (code, index + 1)))
            {
                Console.WriteLine($"Processing Sample {index}...\n");

                SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
                Compilation compilation = CSharpCompilation.Create($"SampleCompilation{index}")
                    .AddSyntaxTrees(tree);

                SemanticModel model = compilation.GetSemanticModel(tree);

                AnalyzeClassReferences(tree, model);

                Console.WriteLine(new string('-', 50));
            }

            /*
Processing Sample 1...

Class: ExampleClass
  - Method 'Display' is invoked.
Class: UserClass
--------------------------------------------------
Processing Sample 2...

Class: SampleClass
  - Method 'Run' is invoked.
Class: TestClass
--------------------------------------------------
Processing Sample 3...

Class: HelperClass
  - Method 'Assist' is invoked.
Class: WorkerClass
--------------------------------------------------
             */

            Console.ReadLine();
        }

        static void AnalyzeClassReferences(SyntaxTree tree, SemanticModel model)
        {
            var root = tree.GetRoot();

            var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
            foreach (var classDeclaration in classDeclarations)
            {
                var classSymbol = model.GetDeclaredSymbol(classDeclaration);
                if (classSymbol == null) continue;

                Console.WriteLine($"Class: {classSymbol.Name}");

                var methodReferences = root.DescendantNodes()
                    .OfType<InvocationExpressionSyntax>()
                    .Select(invocation => model.GetSymbolInfo(invocation).Symbol)
                    .Where(symbol => symbol is IMethodSymbol)
                    .Cast<IMethodSymbol>()
                    .Where(methodSymbol => methodSymbol.ContainingType.Equals(classSymbol, SymbolEqualityComparer.Default));

                foreach (var methodSymbol in methodReferences)
                {
                    Console.WriteLine($"  - Method '{methodSymbol.Name}' is invoked.");
                }
            }
        }
    }
}