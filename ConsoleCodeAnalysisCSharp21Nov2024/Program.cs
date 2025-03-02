using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConsoleCodeAnalysisCSharp21Nov2024
{
    // ChatGPT
    internal class Program
    {
        static void Main()
        {
            var sampleCodes = new[]
            {
            @"
            namespace TestNamespace
            {
                public class TestClass
                {
                    public void Method1() { }
                    public void Method2() { }
                    public void Method3() { }
                }

                public class AnotherClass
                {
                    public void Method()
                    {
                        var test = new TestClass();
                        test.Method1();
                    }
                }
            }",

            @"
            namespace SampleNamespace
            {
                public class SampleClass
                {
                    public void FunctionA() { }
                    public void FunctionB() { }
                }

                public class CallerClass
                {
                    public void Execute()
                    {
                        SampleClass instance = new SampleClass();
                        instance.FunctionB();
                    }
                }
            }",

            @"
            namespace ExternalNamespace
            {
                public class Utility
                {
                    public void HelperMethod() { }
                }

                public class Worker
                {
                    public void Process()
                    {
                        Utility util = new Utility();
                        util.HelperMethod();
                    }
                }
            }"
        };

            foreach (var (code, index) in sampleCodes.Select((code, index) => (code, index + 1)))
            {
                Console.WriteLine($"Processing Sample {index}...\n");

                SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
                Compilation compilation = CSharpCompilation.Create("TestCompilation")
                    .AddSyntaxTrees(tree);

                SemanticModel model = compilation.GetSemanticModel(tree);

                AnalyzeClassReferences(tree, model);

                Console.WriteLine(new string('-', 50));
            }

            /*
Processing Sample 1...

Class: TestClass
  - Method 'Method1' is invoked.
Class: AnotherClass
--------------------------------------------------
Processing Sample 2...

Class: SampleClass
  - Method 'FunctionB' is invoked.
Class: CallerClass
--------------------------------------------------
Processing Sample 3...

Class: Utility
  - Method 'HelperMethod' is invoked.
Class: Worker
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