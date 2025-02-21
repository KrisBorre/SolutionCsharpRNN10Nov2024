namespace LibraryRNN10Nov2024
{
    public class RNN10Nov2024
    {
        private int inputSize;
        private int hiddenSize;
        private int outputSize;
        private double learningRate;

        private double[,] Wx; // Input weight matrix
        private double[,] Wh; // Hidden weight matrix
        private double[,] Wy; // Output weight matrix
        private double[] bh; // Hidden bias
        private double[] by; // Output bias

        private double[] hPrev; // Previous hidden state

        private Calculator calculator = new Calculator();

        public RNN10Nov2024(int inputSize, int hiddenSize, int outputSize, double learningRate = 0.01)
        {
            this.inputSize = inputSize;
            this.hiddenSize = hiddenSize;
            this.outputSize = outputSize;
            this.learningRate = learningRate;

            // Initialize weights and biases
            InitializerUniform initializer = new InitializerUniform();
            Wx = initializer.InitializeMatrix(hiddenSize, inputSize);
            Wh = initializer.InitializeMatrix(hiddenSize, hiddenSize);
            Wy = initializer.InitializeMatrix(outputSize, hiddenSize);
            bh = new double[hiddenSize];
            by = new double[outputSize];

            hPrev = new double[hiddenSize];
        }

        // Forward pass for a single time step
        public double[] Forward(double[] x)
        {
            // Hidden state calculation: h(t) = tanh(Wx * x + Wh * h_prev + bh)
            double[] hCurrent = calculator.AddVectors(calculator.AddVectors(calculator.MatrixVectorMultiply(Wx, x), calculator.MatrixVectorMultiply(Wh, hPrev)), bh);
            hCurrent = calculator.ApplyActivationTanh(hCurrent);

            // Output calculation: y(t) = Wy * h(t) + by
            double[] y = calculator.AddVectors(calculator.MatrixVectorMultiply(Wy, hCurrent), by);

            hPrev = hCurrent; // Store current hidden state as previous for the next time step
            return y;
        }

        // Backpropagation through time (BPTT) for updating weights
        public void Backward(double[] output, double[] target, double[] x)
        {
            // Compute output layer error
            double[] outputError = new double[outputSize];
            for (int i = 0; i < outputSize; i++)
            {
                outputError[i] = 2 * (output[i] - target[i]);
            }

            // Gradient for output weights and biases
            double[] hCurrentGrad = calculator.MatrixVectorMultiply(calculator.Transpose(Wy), outputError);
            for (int i = 0; i < outputSize; i++)
            {
                for (int j = 0; j < hiddenSize; j++)
                {
                    Wy[i, j] -= learningRate * outputError[i] * hPrev[j];
                }
                by[i] -= learningRate * outputError[i];
            }

            // Gradient for hidden layer (backpropagated through tanh)
            double[] hGrad = calculator.ApplyActivationTanhDerivative(hPrev);
            for (int i = 0; i < hiddenSize; i++)
            {
                hGrad[i] *= hCurrentGrad[i];
            }

            // Update hidden weights and biases
            for (int i = 0; i < hiddenSize; i++)
            {
                for (int j = 0; j < inputSize; j++)
                {
                    Wx[i, j] -= learningRate * hGrad[i] * x[j];
                }
                for (int j = 0; j < hiddenSize; j++)
                {
                    Wh[i, j] -= learningRate * hGrad[i] * hPrev[j];
                }
                bh[i] -= learningRate * hGrad[i];
            }
        }

    }

}
