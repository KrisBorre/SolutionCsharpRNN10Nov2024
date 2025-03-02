using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ConsoleCodeAnalysisCSharp10Nov2024
{
    // ChatGPT
    class Program
    {
        static void Main(string[] args)
        {
            string className = "GradientRNN";

            string rnnCode = @"public class GradientRNN 
        {
            private readonly int inputSize;
            private readonly int hiddenSize;
            private readonly int outputSize;
            private readonly double learningRate;
            private readonly double gradientThreshold;

            public double[,] Wx { get; private set; }
            public double[,] Wh { get; private set; }
            public double[] Bh { get; private set; }
            public double[] h { get; private set; }
            public double[,] Wo { get; private set; }
            public double[] Bo { get; private set; }

            private readonly Random rand;

            public GradientRNN(int inputSize, int hiddenSize, int outputSize, double learningRate = 0.001, double gradientThreshold = 1.0, Random random = null)
            {
                this.inputSize = inputSize;
                this.hiddenSize = hiddenSize;
                this.outputSize = outputSize;
                this.learningRate = learningRate;
                this.gradientThreshold = gradientThreshold;
                this.rand = random ?? new Random();

                Wx = InitializeMatrix(inputSize, hiddenSize);
                Wh = InitializeMatrix(hiddenSize, hiddenSize);
                Bh = new double[hiddenSize];
                Wo = InitializeMatrix(hiddenSize, outputSize);
                Bo = new double[outputSize];
                h = new double[hiddenSize];
            }
        }";

            string rnnClientCode = @"static void Main(string[] args)
        {
            string gloveFilePath = ""../../../../../../../GloVe/glove.6B.50d.txt""; 
            int embeddingDim = 50;
            var glove = new GloveLoader(gloveFilePath, embeddingDim);

            string filePath = ""../../../../LibraryPrompts4Nov2024/prompts.csv"";
            PromptReader promptReader = new PromptReader();
            var prompts = promptReader.ReadPromptsFromCsv(filePath);
            var first10Prompts = prompts.Take(10).ToList();

            int hiddenSize = 900;
            double learningRate = 0.001;
            double gradientThreshold = 0.001;
            int epochs = 300;

            GradientRNN rnn = new GradientRNN(inputSize: embeddingDim, hiddenSize: hiddenSize, outputSize: embeddingDim, learningRate: learningRate, gradientThreshold: gradientThreshold, random: new Random());

            for (int epoch = 0; epoch <= epochs; epoch++)
            {
                double totalLoss = 0;

                foreach (var prompt in first10Prompts)
                {
                    var words = prompt.PromptText.Split(' ').Select(w => w.ToLower()).ToArray();
                    List<double[]> wordEmbeddings = words.Select(word => glove.GetEmbedding(word)).ToList();

                    for (int i = 0; i < wordEmbeddings.Count - 1; i++)
                    {
                        double[] inputEmbedding = wordEmbeddings[i];
                        double[] targetEmbedding = wordEmbeddings[i + 1];

                        double[] outputEmbedding = rnn.Forward(inputEmbedding);

                        double loss = 0;
                        for (int j = 0; j < outputEmbedding.Length; j++)
                        {
                            loss += Math.Pow(outputEmbedding[j] - targetEmbedding[j], 2);
                        }
                        loss /= embeddingDim;
                        totalLoss += loss;

                        rnn.Backward(outputEmbedding, targetEmbedding, inputEmbedding);
                    }
                }

                totalLoss /= first10Prompts.Count;

                if (epoch % 100 == 0)
                {
                    Console.WriteLine($""Epoch {epoch}/{epochs}, Average Loss: {totalLoss}"");
                }
            }

            Console.WriteLine(""\nTesting trained RNN on prompts:"");
            foreach (var prompt in first10Prompts)
            {
                Console.WriteLine($""Act: {prompt.Act}"");
                Console.Write(""Prompt Input: "");
                foreach (var word in prompt.PromptText.Split(' '))
                {
                    Console.Write(word + "" "");
                }

                Console.Write(""\nPredicted: "");
                var words = prompt.PromptText.Split(' ').Select(w => w.ToLower()).ToArray();
                List<double[]> wordEmbeddings = words.Select(word => glove.GetEmbedding(word)).ToList();

                for (int i = 0; i < wordEmbeddings.Count - 1; i++)
                {
                    double[] outputEmbedding = rnn.Forward(wordEmbeddings[i]);
                    string predictedWord = glove.FindClosestWord(outputEmbedding);
                    Console.Write(predictedWord + "" "");
                }
                Console.WriteLine(""\n"");
            }
        }";

            var syntaxTree = CSharpSyntaxTree.ParseText(rnnCode + "\n" + rnnClientCode);
            var root = syntaxTree.GetRoot();

            var classReferences = new List<(string Reference, string Context)>();

            foreach (var node in root.DescendantNodes().OfType<IdentifierNameSyntax>())
            {
                if (node.Identifier.Text == className)
                {
                    var parentNode = node.Parent?.ToString() ?? "No context available";
                    classReferences.Add((node.ToString(), parentNode));
                }
            }

            if (classReferences.Any())
            {
                Console.WriteLine($"References to class {className} in RNN code:");
                foreach (var (reference, context) in classReferences)
                {
                    Console.WriteLine($"Reference: {reference}\nContext: {context}\n");
                }
            }
            else
            {
                Console.WriteLine($"No references found for class {className}.");
            }

            /*
            References to class GradientRNN in RNN code:
            Reference: GradientRNN
            Context: GradientRNN rnn = new GradientRNN(inputSize: embeddingDim, hiddenSize: hiddenSize, outputSize: embeddingDim, learningRate: learningRate, gradientThreshold: gradientThreshold, random: new Random())

            Reference: GradientRNN
            Context: new GradientRNN(inputSize: embeddingDim, hiddenSize: hiddenSize, outputSize: embeddingDim, learningRate: learningRate, gradientThreshold: gradientThreshold, random: new Random())
            */

            Console.ReadLine();
        }
    }
}