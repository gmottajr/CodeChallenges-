using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                }
                else {
                    Console.WriteLine("Invalid entry! Please type a valid positive numeric value.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}.", ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
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
