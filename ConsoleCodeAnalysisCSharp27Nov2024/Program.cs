using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace ConsoleCodeAnalysisCSharp27Nov2024
{
    public class Program
    {
        public static void Main()
        {
            // Hardcoded C# sample with multiple classes and references
            string code = @"
        namespace SampleNamespace
        {
            public class MyClass
            {
                public void SayHello() { Console.WriteLine(""Hello""); }
            }

            public class AnotherClass
            {
                public void UseMyClass()
                {
                    MyClass instance = new MyClass();
                    instance.SayHello();
                }
            }
        }";

            // Parse the syntax tree
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = (CompilationUnitSyntax)tree.GetRoot();

            // Create a semantic model
            var compilation = CSharpCompilation.Create("TestCompilation")
                .AddSyntaxTrees(tree);
            var semanticModel = compilation.GetSemanticModel(tree);

            // The class name to search for
            string className = "MyClass";

            // Find class declarations matching the given name
            var classDeclarations = root.DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .Where(c => c.Identifier.ValueText == className)
                .ToList();

            if (!classDeclarations.Any())
            {
                Console.WriteLine($"The class '{className}' was not found.");
                return;
            }

            Console.WriteLine($"Found class '{className}' definition(s):");
            foreach (var classDecl in classDeclarations)
            {
                Console.WriteLine($"- {classDecl.Identifier.ValueText} at line {GetLineNumber(classDecl)}");
            }

            // Find references to the class
            Console.WriteLine($"\nSearching for references to '{className}':");
            var references = FindClassReferences(root, className);
            if (!references.Any())
            {
                Console.WriteLine($"No references found for '{className}'.");
            }
            else
            {
                foreach (var refLocation in references)
                {
                    Console.WriteLine($"- Reference at line {refLocation}");
                }
            }

            /*
Found class 'MyClass' definition(s):
- MyClass at line 4

Searching for references to 'MyClass':
- Reference at line 13
- Reference at line 13

             */
        }

        // Helper method to find references to a class
        static List<int> FindClassReferences(SyntaxNode root, string className)
        {
            return root.DescendantNodes()
                .OfType<IdentifierNameSyntax>()
                .Where(id => id.Identifier.ValueText == className)
                .Select(id => GetLineNumber(id))
                .ToList();
        }

        // Helper method to get the line number of a syntax node
        static int GetLineNumber(SyntaxNode node)
        {
            var location = node.GetLocation().GetLineSpan();
            return location.StartLinePosition.Line + 1; // 1-based index
        }
    }
}