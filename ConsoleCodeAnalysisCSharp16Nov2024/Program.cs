using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConsoleCodeAnalysisCSharp16Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main()
        {
            // Multiple C# samples with various statements missing braces
            var samples = new[]
            {
            @"
            class Test1
            {
                void Method()
                {
                    if (condition)
                        DoSomething();
                }
            }",

            @"
            class Test2
            {
                void Method()
                {
                    for (int i = 0; i < 10; i++)
                        Process(i);
                }
            }",

            @"
            class Test3
            {
                void Method()
                {
                    while (flag)
                        ContinueProcessing();
                }
            }",

            @"
            class Test4
            {
                void Method()
                {
                    if (check)
                        Execute();
                    else
                        HandleElse();
                }
            }"
        };

            // Process each code sample
            for (int i = 0; i < samples.Length; i++)
            {
                Console.WriteLine($"Processing Sample {i + 1}...\n");

                var syntaxTree = CSharpSyntaxTree.ParseText(samples[i]);
                var root = syntaxTree.GetRoot();

                var rewriter = new BracesRewriter();
                var newRoot = rewriter.Visit(root);

                // Print the transformed code
                Console.WriteLine(newRoot.ToFullString());
                Console.WriteLine(new string('-', 50)); // Separator for readability
            }

            /*
             Processing Sample 1...


            class Test1
            {
                void Method()
                {
                    if (condition)
{                        DoSomething();
}                }
            }
--------------------------------------------------
Processing Sample 2...


            class Test2
            {
                void Method()
                {
                    for (int i = 0; i < 10; i++)
{                        Process(i);
}                }
            }
--------------------------------------------------
Processing Sample 3...


            class Test3
            {
                void Method()
                {
                    while (flag)
{                        ContinueProcessing();
}                }
            }
--------------------------------------------------
Processing Sample 4...


            class Test4
            {
                void Method()
                {
                    if (check)
{                        Execute();
}else{                        HandleElse();
}                }
            }
--------------------------------------------------
             */


            Console.ReadLine();
        }
    }

    // Rewriter class that adds braces to if, for, while, and else statements
    class BracesRewriter : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitIfStatement(IfStatementSyntax node)
        {
            // Ensure the if statement has braces
            if (node.Statement is not BlockSyntax)
            {
                var newBlock = SyntaxFactory.Block(node.Statement);
                node = node.WithStatement(newBlock);
            }

            // Ensure the else statement (if present) has braces
            if (node.Else != null && node.Else.Statement is not BlockSyntax)
            {
                var newElseBlock = SyntaxFactory.Block(node.Else.Statement);
                node = node.WithElse(SyntaxFactory.ElseClause(newElseBlock));
            }

            return base.VisitIfStatement(node);
        }

        public override SyntaxNode VisitForStatement(ForStatementSyntax node)
        {
            // Ensure the for loop has braces
            if (node.Statement is not BlockSyntax)
            {
                var newBlock = SyntaxFactory.Block(node.Statement);
                node = node.WithStatement(newBlock);
            }

            return base.VisitForStatement(node);
        }

        public override SyntaxNode VisitWhileStatement(WhileStatementSyntax node)
        {
            // Ensure the while loop has braces
            if (node.Statement is not BlockSyntax)
            {
                var newBlock = SyntaxFactory.Block(node.Statement);
                node = node.WithStatement(newBlock);
            }

            return base.VisitWhileStatement(node);
        }
    }
}