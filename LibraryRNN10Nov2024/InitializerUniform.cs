namespace LibraryRNN10Nov2024
{
    public class InitializerUniform
    {
        public InitializerUniform() { }

        public double[,] InitializeMatrix(int rows, int cols)
        {
            var rand = new Random();
            double[,] matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.NextDouble() - 0.5;
                }
            }

            return matrix;
        }
    }
}
