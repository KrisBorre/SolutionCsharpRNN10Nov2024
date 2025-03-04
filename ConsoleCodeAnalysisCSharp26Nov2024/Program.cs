using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConsoleCodeAnalysisCSharp26Nov2024
{
    class Program
    {
        static void Main()
        {
            // Hardcoded C# code samples
            var codeSamples = new List<string>
            {
                @"
                namespace ExampleNamespace
                {
                    public class ExampleClass1 { }
                    public class ExampleClass2 { }
                }

                namespace AnotherNamespace
                {
                    public class ExampleClass3 { }
                    public struct ExampleStruct { }
                }",
                @"
                namespace NestedNamespace
                {
                    namespace InnerNamespace
                    {
                        public class InnerClass { }
                    }

                    public interface IExample { }
                }",
                @"
                public class GlobalClass { } // No namespace",
                @"
                namespace PartialExample
                {
                    public partial class PartialClass { }
                }

                namespace PartialExample
                {
                    public partial class PartialClass { }
                }"
            };

            // Dictionary to store extracted namespaces and class/struct/interface names
            var namespacesAndTypes = new Dictionary<string, List<string>>();

            // Process each sample
            foreach (var code in codeSamples)
            {
                SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
                SyntaxNode root = tree.GetRoot();
                ExtractNamespaceAndTypes(root, namespacesAndTypes);
            }

            // Print extracted information
            foreach (var kvp in namespacesAndTypes)
            {
                string namespaceLabel = string.IsNullOrEmpty(kvp.Key) ? "[Global Scope]" : $"Namespace: {kvp.Key}";
                Console.WriteLine(namespaceLabel);
                foreach (var typeName in kvp.Value)
                {
                    Console.WriteLine($"  - {typeName}");
                }
            }

            /*
Namespace: ExampleNamespace
  - ExampleClass1
  - ExampleClass2
Namespace: AnotherNamespace
  - ExampleClass3
  - ExampleStruct
Namespace: InnerNamespace
  - InnerClass
Namespace: NestedNamespace
  - IExample
[Global Scope]
  - GlobalClass
Namespace: PartialExample
  - PartialClass
  - PartialClass
             */

            Console.ReadLine();
        }

        static void ExtractNamespaceAndTypes(SyntaxNode root, Dictionary<string, List<string>> namespacesAndTypes)
        {
            foreach (var node in root.DescendantNodes())
            {
                if (node is BaseTypeDeclarationSyntax typeDeclaration)
                {
                    string typeName = typeDeclaration.Identifier.ValueText;
                    string namespaceName = GetContainingNamespace(typeDeclaration);

                    // Ensure namespace exists in dictionary
                    if (!namespacesAndTypes.ContainsKey(namespaceName))
                    {
                        namespacesAndTypes[namespaceName] = new List<string>();
                    }

                    // Add the class, struct, or interface name
                    namespacesAndTypes[namespaceName].Add(typeName);
                }
            }
        }

        static string GetContainingNamespace(SyntaxNode node)
        {
            SyntaxNode current = node.Parent;
            while (current != null)
            {
                if (current is NamespaceDeclarationSyntax namespaceDeclaration)
                {
                    return namespaceDeclaration.Name.ToString();
                }
                current = current.Parent;
            }
            return ""; // Global scope (no namespace)
        }
    }
}
