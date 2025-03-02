using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConsoleCodeAnalysisCSharp18Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main()
        {
            // Multiple C# samples to analyze different method declarations
            var samples = new[]
            {
            @"
            public class Sample1
            {
                public virtual void MyMethod()
                {
                    // Public virtual method
                }
            }",

            @"
            public class Sample2
            {
                public void NonVirtualMethod()
                {
                    // Public but NOT virtual
                }
            }",

            @"
            public class Sample3
            {
                protected virtual void ProtectedMethod()
                {
                    // Protected virtual method
                }
            }",

            @"
            public class Sample4
            {
                public static void StaticMethod()
                {
                    // Static method (not virtual)
                }
            }",

            @"
            public abstract class Sample5
            {
                public abstract void AbstractMethod();
            }",

            @"
            public class Sample6 : Sample5
            {
                public override void AbstractMethod()
                {
                    // Overriding an abstract method
                }
            }"
        };

            foreach (var (code, index) in samples.Select((code, index) => (code, index + 1)))
            {
                Console.WriteLine($"Processing Sample {index}...\n");

                var syntaxTree = CSharpSyntaxTree.ParseText(code);
                var compilation = CSharpCompilation.Create("SampleCompilation")
                    .AddSyntaxTrees(syntaxTree);

                var semanticModel = compilation.GetSemanticModel(syntaxTree);

                // Extract method declarations
                var methodDeclarations = syntaxTree.GetRoot().DescendantNodes()
                    .OfType<MethodDeclarationSyntax>();

                foreach (var methodDeclaration in methodDeclarations)
                {
                    var methodSymbol = semanticModel.GetDeclaredSymbol(methodDeclaration);

                    if (methodSymbol != null)
                    {
                        // Determine method characteristics
                        var isPublic = methodSymbol.DeclaredAccessibility == Accessibility.Public;
                        var isVirtual = methodSymbol.IsVirtual;
                        var isAbstract = methodSymbol.IsAbstract;
                        var isOverride = methodSymbol.IsOverride;
                        var isStatic = methodSymbol.IsStatic;

                        Console.WriteLine($"Method: {methodSymbol.Name}");
                        Console.WriteLine($"  - Public: {isPublic}");
                        Console.WriteLine($"  - Virtual: {isVirtual}");
                        Console.WriteLine($"  - Abstract: {isAbstract}");
                        Console.WriteLine($"  - Override: {isOverride}");
                        Console.WriteLine($"  - Static: {isStatic}");

                        if (isPublic && isVirtual)
                        {
                            Console.WriteLine($"✔️ The method '{methodSymbol.Name}' is public and virtual.");
                        }
                        else
                        {
                            Console.WriteLine($"❌ The method '{methodSymbol.Name}' is NOT both public and virtual.");
                        }

                        Console.WriteLine(new string('-', 50));
                    }
                }
            }

            /*
Processing Sample 1...

Method: MyMethod
  - Public: True
  - Virtual: True
  - Abstract: False
  - Override: False
  - Static: False
?? The method 'MyMethod' is public and virtual.
--------------------------------------------------
Processing Sample 2...

Method: NonVirtualMethod
  - Public: True
  - Virtual: False
  - Abstract: False
  - Override: False
  - Static: False
? The method 'NonVirtualMethod' is NOT both public and virtual.
--------------------------------------------------
Processing Sample 3...

Method: ProtectedMethod
  - Public: False
  - Virtual: True
  - Abstract: False
  - Override: False
  - Static: False
? The method 'ProtectedMethod' is NOT both public and virtual.
--------------------------------------------------
Processing Sample 4...

Method: StaticMethod
  - Public: True
  - Virtual: False
  - Abstract: False
  - Override: False
  - Static: True
? The method 'StaticMethod' is NOT both public and virtual.
--------------------------------------------------
Processing Sample 5...

Method: AbstractMethod
  - Public: True
  - Virtual: False
  - Abstract: True
  - Override: False
  - Static: False
? The method 'AbstractMethod' is NOT both public and virtual.
--------------------------------------------------
Processing Sample 6...

Method: AbstractMethod
  - Public: True
  - Virtual: False
  - Abstract: False
  - Override: True
  - Static: False
? The method 'AbstractMethod' is NOT both public and virtual.
--------------------------------------------------

             
             */

            Console.ReadLine();
        }
    }

}