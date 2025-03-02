using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace ConsoleCodeAnalysisCSharp14Nov2024
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class LongMethodAnalyzer : DiagnosticAnalyzer
    {
        private const string Category = "Maintainability";

        private static readonly DiagnosticDescriptor Descriptor = new DiagnosticDescriptor(
            "M001",
            "Long method",
            "The method '{0}' has {1} lines of code. Consider refactoring it.",
            Category,
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(Descriptor);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();
            context.RegisterSyntaxNodeAction(AnalyzeMethod, SyntaxKind.MethodDeclaration);
        }

        private static void AnalyzeMethod(SyntaxNodeAnalysisContext context)
        {
            var methodDeclaration = (MethodDeclarationSyntax)context.Node;

            var linesOfCode = methodDeclaration.GetText().Lines.Count(line => !string.IsNullOrWhiteSpace(line.ToString()));

            if (linesOfCode > 10)
            {
                var diagnostic = Diagnostic.Create(
                    Descriptor,
                    methodDeclaration.Identifier.GetLocation(),
                    methodDeclaration.Identifier.Text,
                    linesOfCode);

                context.ReportDiagnostic(diagnostic);
            }
        }
    }

    // ChatGPT
    class Program
    {
        static void Main()
        {
            string sampleCode = @"using System; 
        class Sample 
        { 
            void LongMethod() 
            { 
                Console.WriteLine(1);
                Console.WriteLine(2);
                Console.WriteLine(3);
                Console.WriteLine(4);
                Console.WriteLine(5);
                Console.WriteLine(6);
                Console.WriteLine(7);
                Console.WriteLine(8);
                Console.WriteLine(9);
                Console.WriteLine(10);
                Console.WriteLine(11); 
            } 
        }";

            var syntaxTree = CSharpSyntaxTree.ParseText(sampleCode);
            var compilation = CSharpCompilation.Create("Analysis", syntaxTrees: new[] { syntaxTree });

            var analyzer = new LongMethodAnalyzer();
            var analyzerOptions = new AnalyzerOptions(ImmutableArray<AdditionalText>.Empty);
            var compilationWithAnalyzers = compilation.WithAnalyzers(ImmutableArray.Create<DiagnosticAnalyzer>(analyzer));

            var diagnostics = compilationWithAnalyzers.GetAnalyzerDiagnosticsAsync().Result;

            foreach (var diagnostic in diagnostics)
            {
                Console.WriteLine(diagnostic);
            }

            // (4,18): warning M001: The method 'LongMethod' has 14 lines of code. Consider refactoring it.

            Console.ReadLine();
        }
    }

}