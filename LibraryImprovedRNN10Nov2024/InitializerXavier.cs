namespace LibraryRNN10Nov2024
{
    public class InitializerXavier
    {
        public InitializerXavier() { }

        public double[,] InitializeMatrix(int rows, int cols)
        {
            var rand = new Random();
            double[,] matrix = new double[rows, cols];
            double scale = Math.Sqrt(2.0 / (rows + cols)); // Xavier initialization

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = (rand.NextDouble() * 2 - 1) * scale;
            return matrix;
        }
    }
}
