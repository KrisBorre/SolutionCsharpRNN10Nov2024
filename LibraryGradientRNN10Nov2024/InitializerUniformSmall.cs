namespace LibraryGradientRNN10Nov2024
{
    public class InitializerUniformSmall
    {
        private readonly Random rand;

        public InitializerUniformSmall(Random random = null)
        {
            this.rand = random ?? new Random();
        }

        public double[,] InitializeMatrix(int rows, int cols)
        {
            double[,] matrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = (rand.NextDouble() * 0.2 - 0.1);  // Small random values
                }
            }
            return matrix;
        }
    }
}
