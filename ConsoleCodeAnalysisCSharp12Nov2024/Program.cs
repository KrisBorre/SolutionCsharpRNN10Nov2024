using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace ConsoleCodeAnalysisCSharp12Nov2024
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
                Console.WriteLine(\""Hello, World!\"");
            }
}
";

            var syntaxTree = CSharpSyntaxTree.ParseText(sampleCode);
            var root = syntaxTree.GetRoot();

            var normalizedRoot = root.NormalizeWhitespace();
            var formattedCode = normalizedRoot.ToFullString();

            Console.WriteLine(formattedCode);
        }
    }
}