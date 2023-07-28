using System.ComponentModel;
using System;

namespace CodeChallenge.Classes
{
    internal static class TimeComplexity
    {
        /// <summary>
        /// Write a function:
        /// class Solution { public int solution(int[] A); }
        /// that, given an array A of N integers, returns the smallest positive integer(greater than 0) that does not occur in A.
        /// For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.
        /// 
        /// Given A = [1, 2, 3], the function should return 4.
        /// 
        /// Given A = [−1, −3], the function should return 1.
        /// 
        /// Write an efficient algorithm for the following assumptions:
        /// 
        /// N is an integer within the range[1..100, 000];
        /// each element of array A is an integer within the range[−1, 000, 000..1, 000, 000].
        /// </summary>
        /// <param name="aArray">Given int array</param>
        /// <returns></returns>
        public static int SmallestMissingPositiveInteger(int[] aArray)
        { 
            HashSet<int> positiveIntegerLst = new HashSet<int>();

            foreach (var item in aArray)
            {
                if(item > 0)
                    positiveIntegerLst.Add(item);
            }

            var smallestInteger = 1;
            while (positiveIntegerLst.Contains(smallestInteger))
            {
                smallestInteger++;
            }

            return smallestInteger;
        }

        /// <summary>
        /// Write a function:
        /// class Solution { public int solution(int[] A); }
        /// that, given an array A of N integers, returns the smallest positive integer(greater than 0) that does not occur in A.
        /// For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.
        /// 
        /// Given A = [1, 2, 3], the function should return 4.
        /// 
        /// Given A = [−1, −3], the function should return 1.
        /// 
        /// Write an efficient algorithm for the following assumptions:
        /// 
        /// N is an integer within the range[1..100, 000];
        /// each element of array A is an integer within the range[−1, 000, 000..1, 000, 000].
        /// </summary>
        /// <param name="aArray">Given int array</param>
        /// <returns></returns>
        public static int SmallestMissingPositiveIntegerNoHash(int[] aArray)
        {
            aArray.ToList().RemoveAll(num => num < 0);
            
            var smallestInteger = 1;
            while (aArray.ToList().Contains(smallestInteger))
            {
                smallestInteger++;
            }

            return smallestInteger;
        }

        /// <summary>
        /// Finds the missing element in an array of distinct integers in the range [1..(N + 1)].
        /// The array contains integers from 1 to N + 1, but exactly one element is missing.
        /// </summary>
        /// <param name="A">The input array of distinct integers.</param>
        /// <returns>The missing element in the range from 1 to (N + 1).</returns>
        public static int PermMissingElem(int[] aArray) 
        {
            int N = aArray.Length;
            long expectedSum = (long)(N + 1) * (N + 2) / 2;
            long actualSum = 0;

            for (int i = 0; i < N; i++)
            {
                actualSum += aArray[i];
            }

            return (int)(expectedSum - actualSum);
        }
    }
}
