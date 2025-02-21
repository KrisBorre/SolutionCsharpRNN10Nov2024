using LibraryGlobalVectors10Nov2024;
using LibraryGradientRNN10Nov2024;

namespace ConsoleGradientRNNGloVe10Nov2024_300d
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load Glove embeddings
            string gloveFilePath = "../../../../../../../GloVe/glove.6B.300d.txt";
            int embeddingDim = 300;
            var glove = new GloveLoader(gloveFilePath, embeddingDim);

            int hiddenSize = 5;  // Adjusted hidden size for learning capacity
            double learningRate = 0.1;  // Adjusted learning rate for gradual learning
            int epochs = 300;  // Increased epochs for better training over time

            GradientRNN rnn = new GradientRNN(inputSize: embeddingDim, hiddenSize: hiddenSize, outputSize: embeddingDim, learningRate: learningRate);

            // Define input-target pairs using GloVe embeddings
            string[] inputWords = { "atom", "king", "electron", "salsa", "genetics" };
            string[] targetWords = { "molecule", "queen", "proton", "samba", "evolution" };

            double[][] inputs = inputWords.Select(w => glove.GetEmbedding(w)).ToArray();
            double[][] targets = targetWords.Select(w => glove.GetEmbedding(w)).ToArray();

            // Validate that embeddings were successfully loaded
            if (inputs.Contains(null) || targets.Contains(null))
            {
                Console.WriteLine("Error: One or more words are not in the GloVe dictionary.");
                return;
            }

            // Track initial and last loss
            double initialLoss = double.MaxValue;
            double lastLoss = initialLoss;

            // Training loop over epochs
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                double totalLoss = 0;

                // Process each input-target pair
                for (int i = 0; i < inputs.Length; i++)
                {
                    // Forward pass
                    double[] output = rnn.Forward(inputs[i]);

                    // Calculate Mean Squared Error loss for the current pair
                    double loss = 0;
                    for (int j = 0; j < output.Length; j++)
                    {
                        loss += Math.Pow(output[j] - targets[i][j], 2);
                    }
                    loss /= embeddingDim;  // Normalize loss by the embedding dimension
                    totalLoss += loss;

                    // Backward pass
                    rnn.Backward(output, targets[i], inputs[i]);

                    // Display closest words for input and predicted output
                    string inputWord = glove.FindClosestWord(inputs[i]);
                    string predictedWord = glove.FindClosestWord(output);
                    string targetWord = glove.FindClosestWord(targets[i]);
                    Console.WriteLine($"Input: {inputWord}, Target: {targetWord}, Predicted: {predictedWord}");
                }

                // Average loss for the epoch
                totalLoss /= inputs.Length;

                // Check if the loss decreases
                if (totalLoss > lastLoss)
                {
                    Console.WriteLine($"Warning: Epoch {epoch + 1}: Loss did not decrease. Loss: {totalLoss}");
                }

                lastLoss = totalLoss;

                // Display progress at regular intervals
                Console.WriteLine($"Epoch {epoch + 1}/{epochs}, Average Loss: {totalLoss}");

                // Set initial loss after the first epoch to gauge improvement
                if (epoch == 0) initialLoss = lastLoss;
            }

            // Verify that overall learning occurred
            if (lastLoss < initialLoss)
            {
                Console.WriteLine("Model successfully decreased loss, indicating learning over epochs.");
            }
            else
            {
                Console.WriteLine("Loss did not decrease significantly, consider revising parameters.");
            }

            /*
            Epoch 296/300, Average Loss: 1,3131043050982312E-14
            Input: atom, Target: molecule, Predicted: molecule
            Input: king, Target: queen, Predicted: queen
            Input: electron, Target: proton, Predicted: proton
            Input: salsa, Target: samba, Predicted: samba
            Input: genetics, Target: evolution, Predicted: evolution
            Epoch 297/300, Average Loss: 1,1836323697317951E-14
            Input: atom, Target: molecule, Predicted: molecule
            Input: king, Target: queen, Predicted: queen
            Input: electron, Target: proton, Predicted: proton
            Input: salsa, Target: samba, Predicted: samba
            Input: genetics, Target: evolution, Predicted: evolution
            Epoch 298/300, Average Loss: 1,0669146026015244E-14
            Input: atom, Target: molecule, Predicted: molecule
            Input: king, Target: queen, Predicted: queen
            Input: electron, Target: proton, Predicted: proton
            Input: salsa, Target: samba, Predicted: samba
            Input: genetics, Target: evolution, Predicted: evolution
            Epoch 299/300, Average Loss: 9,616957177490053E-15
            Input: atom, Target: molecule, Predicted: molecule
            Input: king, Target: queen, Predicted: queen
            Input: electron, Target: proton, Predicted: proton
            Input: salsa, Target: samba, Predicted: samba
            Input: genetics, Target: evolution, Predicted: evolution
            Epoch 300/300, Average Loss: 8,668438720143413E-15
            Model successfully decreased loss, indicating learning over epochs.
            */

            Console.Read();
        }
    }
}
