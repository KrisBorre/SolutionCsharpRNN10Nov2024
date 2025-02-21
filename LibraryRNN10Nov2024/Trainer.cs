namespace LibraryRNN10Nov2024
{
    public class Trainer
    {
        private RNN10Nov2024 recurrentNeuralNetwork;

        public Trainer(RNN10Nov2024 recurrentNeuralNetwork)
        {
            this.recurrentNeuralNetwork = recurrentNeuralNetwork;
        }

        // Train the RNN using a basic gradient descent approach
        public void Train(double[][] inputs, double[][] targets, int epochs)
        {
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                double totalLoss = 0.0;

                for (int t = 0; t < inputs.Length; t++)
                {
                    double[] x = inputs[t];
                    double[] target = targets[t];
                    int outputSize = target.Length;

                    double[] y = recurrentNeuralNetwork.Forward(x);

                    // Compute loss (mean squared error)
                    double loss = 0;
                    for (int i = 0; i < outputSize; i++)
                    {
                        loss += Math.Pow(target[i] - y[i], 2);
                    }
                    totalLoss += loss;
                                        
                    recurrentNeuralNetwork.Backward(y, target, x);
                }

                Console.WriteLine($"Epoch {epoch + 1}/{epochs}, Loss: {totalLoss}");
            }
        }

    }
}
