using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConsoleCodeAnalysisCSharp13Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main()
        {
            string sampleCode = @" 
        class SampleClass 
        {
            void SampleMethod() 
            {
                int unusedVar = 10;
                int usedVar = 20;
                Console.WriteLine(usedVar);
            }
        }";

            var syntaxTree = CSharpSyntaxTree.ParseText(sampleCode);
            var root = syntaxTree.GetRoot();
            var methodName = "SampleMethod";

            var methodDeclaration = root.DescendantNodesAndSelf()
                .OfType<MethodDeclarationSyntax>()
                .FirstOrDefault(md => md.Identifier.ValueText == methodName);

            if (methodDeclaration == null)
            {
                Console.WriteLine("Method not found.");
                return;
            }

            var declaredVariables = methodDeclaration.DescendantNodesAndSelf()
                .OfType<VariableDeclarationSyntax>()
                .SelectMany(vds => vds.Variables)
                .Select(v => v.Identifier.ValueText)
                .ToHashSet();

            var usedVariables = methodDeclaration.DescendantNodesAndSelf()
                .OfType<IdentifierNameSyntax>()
                .Select(id => id.Identifier.ValueText)
                .ToHashSet();

            foreach (var variable in declaredVariables)
            {
                if (!usedVariables.Contains(variable))
                {
                    Console.WriteLine($"Variable '{variable}' is declared but never used in method '{methodName}'.");
                }
            }

            // Variable 'unusedVar' is declared but never used in method 'SampleMethod'.

            Console.ReadLine();
        }
    }
}