using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConsoleCodeAnalysisCSharp11Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main()
        {
            string sampleCode = @" 
        class SampleClass 
        {
            void OldMethod() 
            {
                Console.WriteLine(\""Hello, World!\"");
            }
        }
        ";

            string oldMethodName = "OldMethod";
            string newMethodName = "NewMethod";

            var syntaxTree = CSharpSyntaxTree.ParseText(sampleCode);
            var root = syntaxTree.GetRoot();

            var methodDeclarations = root.DescendantNodesAndSelf()
                .OfType<MethodDeclarationSyntax>()
                .Where(md => md.Identifier.ValueText == oldMethodName);

            foreach (var methodDeclaration in methodDeclarations)
            {
                var newMethodDeclaration = methodDeclaration.WithIdentifier(SyntaxFactory.Identifier(newMethodName));
                root = root.ReplaceNode(methodDeclaration, newMethodDeclaration);
            }

            var newCsSourceCode = root.ToFullString();
            Console.WriteLine("Modified Code:\n" + newCsSourceCode);


            /*
            Modified Code:

            class SampleClass
            {
                void NewMethod()
                {
                    Console.WriteLine(\"Hello, World!\");
                }
            }
            */


            Console.ReadLine();
        }
    }
}