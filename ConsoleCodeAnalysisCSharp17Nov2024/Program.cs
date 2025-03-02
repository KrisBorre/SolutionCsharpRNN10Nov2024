using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConsoleCodeAnalysisCSharp17Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main()
        {
            // Multiple C# samples with string literals
            var samples = new[]
            {
            @"
            public class Sample1
            {
                public void Method()
                {
                    string message = ""Hello, World!"";
                    Console.WriteLine(message);
                }
            }",

            @"
            public class Sample2
            {
                private string greeting = ""Welcome to the system!"";

                public void PrintGreeting()
                {
                    Console.WriteLine(greeting);
                }
            }",

            @"
            public class Sample3
            {
                public string GetMessage()
                {
                    return ""This is a return statement!"";
                }
            }",

            @"
            [Description(""This class represents an example."")]
            public class Sample4
            {
                public void Display()
                {
                    Console.WriteLine(""Attribute example."");
                }
            }"
        };

            // Process each code sample
            for (int i = 0; i < samples.Length; i++)
            {
                Console.WriteLine($"Processing Sample {i + 1}...\n");

                var syntaxTree = CSharpSyntaxTree.ParseText(samples[i]);
                var root = syntaxTree.GetRoot();

                var rewriter = new StringLiteralToResourceRewriter();
                var newRoot = rewriter.Visit(root);

                // Print the transformed code
                Console.WriteLine(newRoot.ToFullString());
                Console.WriteLine(new string('-', 50)); // Separator for readability
            }

            /*
             Processing Sample 1...


            public class Sample1
            {
                public void Method()
                {
                    string message = MyResources.Resource_1918902895;
                    Console.WriteLine(message);
                }
            }
--------------------------------------------------
Processing Sample 2...


            public class Sample2
            {
                private string greeting = MyResources.Resource_2045247408;

                public void PrintGreeting()
                {
                    Console.WriteLine(greeting);
                }
            }
--------------------------------------------------
Processing Sample 3...


            public class Sample3
            {
                public string GetMessage()
                {
                    return MyResources.Resource_1540294141;
                }
            }
--------------------------------------------------
Processing Sample 4...


            [Description(MyResources.Resource_1595936570)]
            public class Sample4
            {
                public void Display()
                {
                    Console.WriteLine(MyResources.Resource_1404408286);
                }
            }
--------------------------------------------------
             */

            Console.ReadLine();
        }
    }

    // Rewriter class that replaces string literals with resource references
    class StringLiteralToResourceRewriter : CSharpSyntaxRewriter
    {
        private readonly Dictionary<string, string> resourceReferences = new Dictionary<string, string>();

        public override SyntaxNode VisitLiteralExpression(LiteralExpressionSyntax node)
        {
            // Check if the literal expression is a string literal
            if (node.Kind() == SyntaxKind.StringLiteralExpression)
            {
                // Get the string value of the literal
                var stringValue = node.Token.ValueText;

                // Generate a unique key for the resource reference
                var resourceKey = GenerateResourceKey(stringValue);

                // Store the string value and its resource key in the dictionary
                resourceReferences[resourceKey] = stringValue;

                // Replace the string literal with a reference to the resource key
                return SyntaxFactory.ParseExpression($"MyResources.{resourceKey}");
            }

            return base.VisitLiteralExpression(node);
        }

        private string GenerateResourceKey(string value)
        {
            // Simplified key generation (could be improved)
            return "Resource_" + Math.Abs(value.GetHashCode());
        }
    }
}