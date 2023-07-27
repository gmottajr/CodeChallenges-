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
                    if(gotNumber >= 0)
                        gotPositive++;
                }

            }
            var msgOut = gotPositive == 2 ? "Got two positives out of three." : " There was no two possives numbers.";
            Console.WriteLine(msgOut);
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
