using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConsoleCodeAnalysisCSharp24Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main()
        {
            // C# code snippet to parse
            var code = @"
            public class Example
            {
                public void OldMethodName()
                {
                }

                public void AnotherMethod()
                {
                    OldMethodName();
                }
            }";

            // Parse the code
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetRoot();

            // Define the old and new method names
            var oldMethodName = "OldMethodName";
            var newMethodName = "NewMethodName";

            // Create and apply the rewriter
            var rewriter = new MethodRenamer(oldMethodName, newMethodName);
            var newRoot = rewriter.Visit(root);

            // Print the modified code
            Console.WriteLine(newRoot.ToFullString());

            /*
             
            public class Example
            {
                public void NewMethodName()
                {
                }

                public void AnotherMethod()
                {
NewMethodName();
                }
            }
             */

            Console.WriteLine(newRoot.NormalizeWhitespace().ToFullString());

            /*
public class Example
{
    public void NewMethodName()
    {
    }

    public void AnotherMethod()
    {
        NewMethodName();
    }
}
             */

        }
    }

    // Roslyn Rewriter to Rename Methods
    class MethodRenamer : CSharpSyntaxRewriter
    {
        private readonly string _oldMethodName;
        private readonly string _newMethodName;

        public MethodRenamer(string oldMethodName, string newMethodName)
        {
            _oldMethodName = oldMethodName;
            _newMethodName = newMethodName;
        }

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            // Rename method declarations
            if (node.Identifier.ValueText == _oldMethodName)
            {
                return node.WithIdentifier(SyntaxFactory.Identifier(_newMethodName));
            }

            return base.VisitMethodDeclaration(node);
        }

        public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            // Rename method invocations
            if (node.Expression is IdentifierNameSyntax identifier && identifier.Identifier.ValueText == _oldMethodName)
            {
                return node.WithExpression(SyntaxFactory.IdentifierName(_newMethodName));
            }

            return base.VisitInvocationExpression(node);
        }
    }
}