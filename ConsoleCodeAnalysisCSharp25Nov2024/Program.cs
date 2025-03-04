using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConsoleCodeAnalysisCSharp25Nov2024
{
    class Program
    {
        static void Main()
        {
            // Hardcoded C# samples instead of reading from a file
            var codeSamples = new List<string>
            {
                @"
                namespace SampleNamespace
                {
                    public class SampleClass
                    {
                        public void MethodA() { }
                        public void MethodB() { MethodA(); }
                    }
                }",
                @"
                namespace AnotherNamespace
                {
                    public class AnotherClass
                    {
                        public void SomeMethod()
                        {
                            var obj = new SampleNamespace.SampleClass();
                            obj.MethodA();
                        }
                    }
                }"
            };

            // Define the target class to find
            string classToFind = "SampleClass";

            // Parse all code samples
            var syntaxTrees = codeSamples.Select(code => CSharpSyntaxTree.ParseText(code)).ToList();

            // Create a compilation
            CSharpCompilation compilation = CSharpCompilation.Create("TempCompilationAssembly")
                .AddSyntaxTrees(syntaxTrees);

            // Analyze each syntax tree
            foreach (var tree in syntaxTrees)
            {
                var semanticModel = compilation.GetSemanticModel(tree);
                var root = tree.GetRoot() as CompilationUnitSyntax;

                if (root == null) continue;

                // Find the target class declaration
                var classDeclaration = root.DescendantNodes().OfType<ClassDeclarationSyntax>()
                                           .FirstOrDefault(c => c.Identifier.ValueText == classToFind);

                if (classDeclaration != null)
                {
                    var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration);
                    if (classSymbol == null) continue;

                    Console.WriteLine($"Class '{classToFind}' found in: {tree.FilePath}");

                    // Find references to the class
                    foreach (var reference in classSymbol.DeclaringSyntaxReferences)
                    {
                        Console.WriteLine($"Class Declaration at: {reference.Span}");
                    }

                    // Find method calls inside the class
                    var methodCalls = root.DescendantNodes().OfType<InvocationExpressionSyntax>()
                        .Where(invocation =>
                        {
                            var symbol = semanticModel.GetSymbolInfo(invocation).Symbol as IMethodSymbol;
                            return symbol?.ContainingType?.Name == classToFind;
                        });

                    foreach (var methodCall in methodCalls)
                    {
                        Console.WriteLine($"Method call to '{methodCall}' found at: {methodCall.GetLocation().GetLineSpan()}");
                    }
                }
            }

            /*
Class 'SampleClass' found in:
Class Declaration at: [84..267)
Method call to 'MethodA()' found at: : (6,48)-(6,57)
            */

            Console.ReadLine();
        }
    }
}
