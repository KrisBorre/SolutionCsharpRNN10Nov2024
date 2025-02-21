namespace LibraryGradientRNN10Nov2024
{
    public class GradientRNN
    {
        private readonly int inputSize;
        private readonly int hiddenSize;
        private readonly int outputSize;
        private readonly double learningRate;
        private readonly double gradientThreshold;  // Threshold for gradient clipping

        public double[,] Wx { get; private set; }  // Input to hidden layer weights
        public double[,] Wh { get; private set; }  // Hidden to hidden layer weights
        public double[] Bh { get; private set; }   // Hidden layer bias
        public double[] h { get; private set; }    // Hidden state
        public double[,] Wo { get; private set; }  // Hidden to output layer weights
        public double[] Bo { get; private set; }   // Output layer bias


        public GradientRNN(int inputSize, int hiddenSize, int outputSize, double learningRate = 0.001, double gradientThreshold = 1.0, Random random = null)
        {
            this.inputSize = inputSize;
            this.hiddenSize = hiddenSize;
            this.outputSize = outputSize;
            this.learningRate = learningRate;
            this.gradientThreshold = gradientThreshold;

            InitializerUniformSmall initializerUniformSmall = new InitializerUniformSmall();

            Wx = initializerUniformSmall.InitializeMatrix(inputSize, hiddenSize);
            Wh = initializerUniformSmall.InitializeMatrix(hiddenSize, hiddenSize);
            Bh = new double[hiddenSize];
            Wo = initializerUniformSmall.InitializeMatrix(hiddenSize, outputSize);
            Bo = new double[outputSize];
            h = new double[hiddenSize];
        }


        public double[] Forward(double[] input)
        {
            double[] newH = new double[hiddenSize];

            // Hidden state calculation with tanh activation
            for (int j = 0; j < hiddenSize; j++)
            {
                double sum = 0;
                for (int i = 0; i < inputSize; i++)
                {
                    sum += input[i] * Wx[i, j];
                }
                for (int k = 0; k < hiddenSize; k++)
                {
                    sum += h[k] * Wh[k, j];
                }
                newH[j] = Math.Tanh(sum + Bh[j]);
            }
            h = newH;

            // Output calculation (no activation function here to keep things linear)
            double[] output = new double[outputSize];
            for (int k = 0; k < outputSize; k++)
            {
                for (int j = 0; j < hiddenSize; j++)
                {
                    output[k] += h[j] * Wo[j, k];
                }
                output[k] += Bo[k];
            }

            return output;
        }


        public void Backward(double[] output, double[] target, double[] input)
        {
            // Output gradient calculation
            double[] dOutput = new double[output.Length];
            for (int i = 0; i < output.Length; i++)
            {
                dOutput[i] = 2 * (output[i] - target[i]);
            }

            // Calculate gradient for hidden layer
            double[] dH = new double[hiddenSize];
            for (int j = 0; j < hiddenSize; j++)
            {
                for (int k = 0; k < outputSize; k++)
                {
                    dH[j] += dOutput[k] * Wo[j, k];
                }
                dH[j] *= (1 - h[j] * h[j]);  // Derivative of tanh
            }

            // Check for exploding gradient
            double gradientNorm = CalculateNorm(dH);

            // Rescale gradients if they are too large
            if (gradientNorm > gradientThreshold)
            {
                double scalingFactor = gradientThreshold / gradientNorm;
                for (int j = 0; j < dH.Length; j++)
                {
                    dH[j] *= scalingFactor;
                }
            }

            // Update output weights
            for (int j = 0; j < hiddenSize; j++)
            {
                for (int k = 0; k < outputSize; k++)
                {
                    Wo[j, k] -= learningRate * dOutput[k] * h[j];
                }
            }

            // Update hidden weights and biases
            for (int j = 0; j < hiddenSize; j++)
            {
                for (int i = 0; i < inputSize; i++)
                {
                    Wx[i, j] -= learningRate * dH[j] * input[i];
                }
                for (int k = 0; k < hiddenSize; k++)
                {
                    Wh[k, j] -= learningRate * dH[j] * h[k];
                }
                Bh[j] -= learningRate * dH[j];
            }

            // Update output bias
            for (int k = 0; k < outputSize; k++)
            {
                Bo[k] -= learningRate * dOutput[k];
            }
        }


        private double CalculateNorm(double[] vector)
        {
            double sum = 0;
            foreach (var val in vector)
            {
                sum += val * val;
            }
            return Math.Sqrt(sum);
        }
    }
}
