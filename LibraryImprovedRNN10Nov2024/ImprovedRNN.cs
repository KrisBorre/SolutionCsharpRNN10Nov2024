using LibraryRNN10Nov2024;

namespace LibraryImprovedRNN10Nov2024
{
    public class ImprovedRNN
    {
        private int inputSize;
        private int hiddenSize;
        private int outputSize;
        private double learningRate;

        private double[,] Wx;
        private double[,] Wh;
        private double[] Bh;
        private double[,] Wo;
        private double[] Bo;
        private double[] h;

        public double[,] WeightInputToHidden => Wx;
        public double[,] WeightHiddenToHidden => Wh;
        public double[,] WeightHiddenToOutput => Wo;
        public double[] BiasHidden => Bh;
        public double[] BiasOutput => Bo;

        public ImprovedRNN(int inputSize, int hiddenSize, int outputSize, double learningRate = 0.001)
        {
            this.inputSize = inputSize;
            this.hiddenSize = hiddenSize;
            this.outputSize = outputSize;
            this.learningRate = learningRate;

            InitializerXavier initializerXavier = new InitializerXavier();
            Wx = initializerXavier.InitializeMatrix(inputSize, hiddenSize);
            Wh = initializerXavier.InitializeMatrix(hiddenSize, hiddenSize);
            Bh = new double[hiddenSize];
            Wo = initializerXavier.InitializeMatrix(hiddenSize, outputSize);
            Bo = new double[outputSize];
            h = new double[hiddenSize];
        }

        public double[] Forward(double[] input)
        {
            double[] newH = new double[hiddenSize];

            for (int j = 0; j < hiddenSize; j++)
            {
                for (int i = 0; i < inputSize; i++)
                {
                    newH[j] += input[i] * Wx[i, j];
                }

                for (int k = 0; k < hiddenSize; k++)
                {
                    newH[j] += h[k] * Wh[k, j];
                }

                newH[j] = Math.Tanh(newH[j] + Bh[j]);
            }

            h = newH;

            var output = new double[outputSize];
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
            double[] dOutput = new double[output.Length];

            for (int i = 0; i < output.Length; i++)
            {
                dOutput[i] = 2 * (output[i] - target[i]);
            }

            double[] dH = new double[hiddenSize];

            for (int j = 0; j < hiddenSize; j++)
            {
                for (int k = 0; k < outputSize; k++)
                {
                    dH[j] += dOutput[k] * Wo[j, k];
                    Wo[j, k] -= learningRate * dOutput[k] * h[j];
                }

                dH[j] *= (1 - h[j] * h[j]); // Derivative of tanh
            }

            for (int k = 0; k < outputSize; k++)
            {
                Bo[k] -= learningRate * dOutput[k];
            }

            for (int j = 0; j < hiddenSize; j++)
            {
                for (int i = 0; i < inputSize; i++)
                {
                    Wx[i, j] -= learningRate * dH[j] * input[i];
                }
                Bh[j] -= learningRate * dH[j];
            }

            for (int j = 0; j < hiddenSize; j++)
            {
                for (int k = 0; k < hiddenSize; k++)
                {
                    Wh[j, k] -= learningRate * dH[k] * h[j];
                }
            }
        }
    }
}
