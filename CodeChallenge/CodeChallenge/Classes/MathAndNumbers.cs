namespace CodeChallenge.Classes
{
    public class MathAndNumbers
    {
        public static void CheckPrimeNumbers()
        {
            Console.WriteLine("Enter a number to find prime numbers up to that:");
            int gotNumber = 0;
            try
            {
                if (int.TryParse(Console.ReadLine(), out gotNumber))
                {
                    Console.WriteLine("Prime numbers:");

                    for (int i = 2; i <= gotNumber; i++)
                    {
                        if (IsPrimeNumber(i))
                        {
                            Console.Write(i + " ");
                        }
                    }
                    Console.WriteLine("");
                }
                else {
                    Console.WriteLine("Invalid entry! Please type a valid positive numeric value.");
                }
                Console.WriteLine("*************************************");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}.", ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        public static void TwoPosivetOutOfThree()
        {
            Console.WriteLine("Enter three numbers comma separated:");
            string? numbersStr = Console.ReadLine();
            var numberList = numbersStr?.Split(",").ToList();

            if (numberList == null || (numberList.Count != 3))
            {
                Console.WriteLine("Invalid entry");
                return;
            }
            var gotPositive = 0;

            for (int i = 0; i <= numberList.Count - 1; i++)
            {
                var gotNumber = -1;
                if (int.TryParse(numberList[i], out gotNumber))
                {
                    if (gotNumber >= 0)
                        gotPositive++;
                }

            }
            var msgOut = gotPositive == 2 ? "Got two positives out of three." : " There was no two possives numbers.";
            Console.WriteLine(msgOut);
        }

        public static void TransposeMatrix()
        {
            Console.WriteLine("********************Let's transpose matrixes **************************");
            var gotMtrx = BuildMatrixRandom();
            Console.WriteLine("Got a matrix X");
            PrintMatrix(gotMtrx);
            var transposedOne = TransposeMatrix<int>(gotMtrx);
            Console.WriteLine("matrix X transposed here: ");
            PrintMatrix(transposedOne);
        }

        private static void PrintMatrix(int[,] mtrx)
        {
            var rows = mtrx.GetLength(0);
            var cols = mtrx.GetLength(1);

            // Find the maximum length of elements in the matrix
            int maxLength = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int elementLength = mtrx[i, j].ToString().Length;
                    if (elementLength > maxLength)
                    {
                        maxLength = elementLength;
                    }
                }
            }

            // Print the top border
            Console.WriteLine("+" + new string('-', (maxLength + 2) * cols - 1) + "+");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(mtrx[i, j].ToString().PadLeft(maxLength) + " ");
                }
                Console.WriteLine("|");
            }

            Console.WriteLine("+" + new string('-', (maxLength + 2) * cols - 1) + "+");
        }

        private static T[,] TransposeMatrix<T>(T[,] originalMtrx)
        {
            var rowsNum = originalMtrx.GetLength(0);
            var colsNum = originalMtrx.GetLength(1);
            T[,] matrix = new T[colsNum, rowsNum];

            for (int i = 0; i < rowsNum; i++)
            {
                for (int j = 0; j < colsNum; j++)
                {
                    matrix[j, i] = originalMtrx[i, j];
                }
            }

            return matrix;
        }

        private static int[,] BuildMatrixRandom()
        {
            var rnd = new Random();
            var rows = rnd.Next(2, 12);
            var cols = rnd.Next(2, 15);

            var rstMtrx = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for(int j =0; j < cols; j++)
                {
                    rstMtrx[i, j] = rnd.Next(0, 4500);
                }
            }

            return rstMtrx;
        }
        private static bool IsPrimeNumber(int pNum)
        {
            if (pNum <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(pNum); i++)
            {
                if (pNum % i == 0)
                    return false;
            }

            return true;
        }
    }
}
