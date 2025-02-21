using LibraryGlobalVectors10Nov2024;
using LibraryRNN10Nov2024;

// see solution SolutionCsharpGloVe3Sep2024, project ConsoleSimpleRNNGloVe14Sep2024_300d
namespace ConsoleRNNGloVe10Nov2024_300d
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

            RNN10Nov2024 rnn = new RNN10Nov2024(inputSize: embeddingDim, hiddenSize: hiddenSize, outputSize: embeddingDim, learningRate: learningRate);

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
            Input: atom, Target: molecule, Predicted: juston
            Input: king, Target: queen, Predicted: gurez
            Input: electron, Target: proton, Predicted: tahini
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: environment
            Epoch 1/300, Average Loss: 0,09465152709670402
            Input: atom, Target: molecule, Predicted: samba
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 2/300, Average Loss: 0,004933385351968913
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 3/300, Average Loss: 0,0027996349322445516
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 4: Loss did not decrease. Loss: 0,002801002353241838
            Epoch 4/300, Average Loss: 0,002801002353241838
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 5/300, Average Loss: 0,0028009885213258374
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 6/300, Average Loss: 0,002800988408621503
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 7/300, Average Loss: 0,002800988406857513
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 8: Loss did not decrease. Loss: 0,0028009884171359594
            Epoch 8/300, Average Loss: 0,0028009884171359594
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 9/300, Average Loss: 0,002800988412452662
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 10: Loss did not decrease. Loss: 0,0028009884176405622
            Epoch 10/300, Average Loss: 0,0028009884176405622
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 11/300, Average Loss: 0,002800988415305587
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 12: Loss did not decrease. Loss: 0,0028009884178884868
            Epoch 12/300, Average Loss: 0,0028009884178884868
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 13/300, Average Loss: 0,0028009884167244747
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 14: Loss did not decrease. Loss: 0,0028009884180105866
            Epoch 14/300, Average Loss: 0,0028009884180105866
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 15/300, Average Loss: 0,002800988417430255
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 16: Loss did not decrease. Loss: 0,002800988418070734
            Epoch 16/300, Average Loss: 0,002800988418070734
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 17/300, Average Loss: 0,002800988417781379
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 18: Loss did not decrease. Loss: 0,0028009884181003754
            Epoch 18/300, Average Loss: 0,0028009884181003754
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 19/300, Average Loss: 0,0028009884179560846
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 20: Loss did not decrease. Loss: 0,0028009884181149853
            Epoch 20/300, Average Loss: 0,0028009884181149853
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 21/300, Average Loss: 0,002800988418043027
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 22: Loss did not decrease. Loss: 0,0028009884181221896
            Epoch 22/300, Average Loss: 0,0028009884181221896
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 23/300, Average Loss: 0,0028009884180863
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 24: Loss did not decrease. Loss: 0,002800988418125744
            Epoch 24/300, Average Loss: 0,002800988418125744
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 25/300, Average Loss: 0,0028009884181078417
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 26: Loss did not decrease. Loss: 0,002800988418127495
            Epoch 26/300, Average Loss: 0,002800988418127495
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 27/300, Average Loss: 0,0028009884181185666
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 28: Loss did not decrease. Loss: 0,0028009884181283617
            Epoch 28/300, Average Loss: 0,0028009884181283617
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 29/300, Average Loss: 0,002800988418123907
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 30: Loss did not decrease. Loss: 0,002800988418128791
            Epoch 30/300, Average Loss: 0,002800988418128791
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 31/300, Average Loss: 0,0028009884181265663
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 32: Loss did not decrease. Loss: 0,002800988418129001
            Epoch 32/300, Average Loss: 0,002800988418129001
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 33/300, Average Loss: 0,002800988418127893
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 34: Loss did not decrease. Loss: 0,0028009884181291063
            Epoch 34/300, Average Loss: 0,0028009884181291063
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 35/300, Average Loss: 0,0028009884181285525
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 36: Loss did not decrease. Loss: 0,0028009884181291584
            Epoch 36/300, Average Loss: 0,0028009884181291584
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 37/300, Average Loss: 0,002800988418128881
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 38: Loss did not decrease. Loss: 0,002800988418129184
            Epoch 38/300, Average Loss: 0,002800988418129184
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 39/300, Average Loss: 0,0028009884181290456
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 40: Loss did not decrease. Loss: 0,002800988418129196
            Epoch 40/300, Average Loss: 0,002800988418129196
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 41/300, Average Loss: 0,002800988418129127
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 42: Loss did not decrease. Loss: 0,0028009884181292026
            Epoch 42/300, Average Loss: 0,0028009884181292026
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 43/300, Average Loss: 0,0028009884181291684
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 44: Loss did not decrease. Loss: 0,002800988418129205
            Epoch 44/300, Average Loss: 0,002800988418129205
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 45/300, Average Loss: 0,0028009884181291874
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 46: Loss did not decrease. Loss: 0,002800988418129207
            Epoch 46/300, Average Loss: 0,002800988418129207
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 47/300, Average Loss: 0,0028009884181291996
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 48: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 48/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 49/300, Average Loss: 0,002800988418129205
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 50: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 50/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 51/300, Average Loss: 0,002800988418129205
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 52: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 52/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 53/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 54/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 55/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 56: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 56/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 57/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 58/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 59: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 59/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 60/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 61/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 62: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 62/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 63: Loss did not decrease. Loss: 0,0028009884181292087
            Epoch 63/300, Average Loss: 0,0028009884181292087
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 64/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 65/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 66/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 67/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 68/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 69: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 69/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 70/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 71/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 72: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 72/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 73: Loss did not decrease. Loss: 0,0028009884181292087
            Epoch 73/300, Average Loss: 0,0028009884181292087
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 74/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 75/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 76/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 77: Loss did not decrease. Loss: 0,0028009884181292087
            Epoch 77/300, Average Loss: 0,0028009884181292087
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 78/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 79/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 80/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 81/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 82/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 83: Loss did not decrease. Loss: 0,0028009884181292087
            Epoch 83/300, Average Loss: 0,0028009884181292087
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 84/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 85: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 85/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 86/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 87: Loss did not decrease. Loss: 0,0028009884181292087
            Epoch 87/300, Average Loss: 0,0028009884181292087
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 88/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 89: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 89/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 90/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 91: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 91/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 92/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 93/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 94/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 95/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 96/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 97: Loss did not decrease. Loss: 0,0028009884181292087
            Epoch 97/300, Average Loss: 0,0028009884181292087
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 98/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 99: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 99/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 100/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 101/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 102/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 103: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 103/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 104/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 105: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 105/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 106/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 107: Loss did not decrease. Loss: 0,002800988418129209
            Epoch 107/300, Average Loss: 0,002800988418129209
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 108/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 109: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 109/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 110/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 111/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 112/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 113/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 114/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 115/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 116/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 117/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 118/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 119: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 119/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 120/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 121: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 121/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 122/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 123/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 124/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 125/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 126/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 127: Loss did not decrease. Loss: 0,002800988418129209
            Epoch 127/300, Average Loss: 0,002800988418129209
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 128/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 129/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 130/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 131/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 132/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 133/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 134/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 135: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 135/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 136/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 137: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 137/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 138/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 139/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 140/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 141/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 142/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 143/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 144/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 145: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 145/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 146/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 147: Loss did not decrease. Loss: 0,0028009884181292087
            Epoch 147/300, Average Loss: 0,0028009884181292087
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 148/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 149/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 150/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 151: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 151/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 152/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 153/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 154/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 155/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 156/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 157/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 158/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 159: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 159/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 160/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 161/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 162/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 163: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 163/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 164/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 165: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 165/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 166/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 167: Loss did not decrease. Loss: 0,002800988418129209
            Epoch 167/300, Average Loss: 0,002800988418129209
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 168/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 169: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 169/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 170/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 171/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 172/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 173/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 174/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 175: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 175/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 176/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 177/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 178/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 179/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 180/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 181/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 182/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 183/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 184/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 185: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 185/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 186/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 187: Loss did not decrease. Loss: 0,002800988418129209
            Epoch 187/300, Average Loss: 0,002800988418129209
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 188/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 189: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 189/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 190/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 191/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 192/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 193/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 194/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 195/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 196/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 197/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 198/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 199/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 200/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 201: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 201/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 202/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 203/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 204/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 205: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 205/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 206/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 207: Loss did not decrease. Loss: 0,0028009884181292087
            Epoch 207/300, Average Loss: 0,0028009884181292087
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 208/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 209/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 210/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 211: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 211/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 212/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 213/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 214/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 215/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 216/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 217: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 217/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 218/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 219: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 219/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 220/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 221/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 222/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 223/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 224/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 225/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 226/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 227: Loss did not decrease. Loss: 0,002800988418129209
            Epoch 227/300, Average Loss: 0,002800988418129209
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 228/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 229: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 229/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 230/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 231: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 231/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 232/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 233: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 233/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 234/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 235: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 235/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 236/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 237: Loss did not decrease. Loss: 0,0028009884181292087
            Epoch 237/300, Average Loss: 0,0028009884181292087
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 238/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 239/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 240/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 241/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 242/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 243/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 244/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 245/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 246/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 247: Loss did not decrease. Loss: 0,002800988418129209
            Epoch 247/300, Average Loss: 0,002800988418129209
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 248/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 249: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 249/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 250/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 251/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 252/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 253/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 254/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 255/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 256/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 257/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 258/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 259: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 259/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 260/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 261/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 262/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 263/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 264/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 265: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 265/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 266/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 267: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 267/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 268/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 269/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 270/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 271: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 271/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 272/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 273/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 274/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 275/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 276/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 277/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 278/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 279/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 280/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 281: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 281/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 282/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 283/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 284/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 285/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 286/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 287: Loss did not decrease. Loss: 0,002800988418129209
            Epoch 287/300, Average Loss: 0,002800988418129209
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 288/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 289: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 289/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 290/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 291: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 291/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 292/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 293/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 294/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 295: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 295/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 296/300, Average Loss: 0,002800988418129208
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Warning: Epoch 297: Loss did not decrease. Loss: 0,0028009884181292083
            Epoch 297/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 298/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 299/300, Average Loss: 0,0028009884181292083
            Input: atom, Target: molecule, Predicted: proton
            Input: king, Target: queen, Predicted: samba
            Input: electron, Target: proton, Predicted: molecule
            Input: salsa, Target: samba, Predicted: queen
            Input: genetics, Target: evolution, Predicted: proton
            Epoch 300/300, Average Loss: 0,002800988418129208
            Model successfully decreased loss, indicating learning over epochs.
            */

            Console.Read();
        }
    }
}
