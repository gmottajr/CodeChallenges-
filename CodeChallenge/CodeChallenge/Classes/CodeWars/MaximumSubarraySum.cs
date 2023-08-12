using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Classes.CodeWars
{
    public static class MaximumSubarraySum
    {
        private static IDictionary<int, int[]> _subarray = new Dictionary<int, int[]>();
        private static IDictionary<int, int[]> _sumOfContiguousSubsequence = new Dictionary<int, int[]>();
        /// The maximum sum subarray problem consists in finding the maximum sum of a contiguous subsequence in an array or list of integers:
        /// maxSequence [-2, 1, -3, 4, -1, 2, 1, -5, 4]
        /// -- should be 6: [4, -1, 2, 1]
        /// Easy case is when the list is made up of only positive numbers and the maximum sum is the sum of the whole array. If the list is made up of only negative numbers, return 0 instead.
        ///
        /// Empty list is considered to have zero greatest sum. Note that the empty list or array is also a valid sublist/subarray.
        public static int MaxSequence(int[] arr)
        {
            _subarray.Clear();
            _sumOfContiguousSubsequence.Clear();
            if (arr.Length == 0)
                return 0;
            
            for (int i = 0; i < arr.Length; i++)
            {
                var segment = arr.Skip(i).Take(arr.Length -i).ToArray(); 
                
                if (!_subarray.ContainsKey(i))
                  _subarray.Add(i, segment);
            }

            // determine contiguous subsequence
            foreach(var element in _subarray)
            {
                var arrayPart = element.Value;
                var gotSum = arrayPart.Sum();
                if (!_sumOfContiguousSubsequence.ContainsKey(gotSum))
                    _sumOfContiguousSubsequence.Add(gotSum, arrayPart);
                for (int i = arrayPart.Length - 1; i >= 0 ; i--)
                {
                    int[] segment = new int[i];
                    Array.Copy(arrayPart, 0, segment, 0, i);
                    gotSum = segment.Sum();
                    if (!_sumOfContiguousSubsequence.ContainsKey(gotSum))
                        _sumOfContiguousSubsequence.Add(gotSum, arrayPart);
                }

                
                
            }
            return _sumOfContiguousSubsequence.Keys.Max();
        }

        public static int MaxSequenceOptimized(int[] arr)
        {
            int max = 0, res = 0, sum = 0;
            foreach (var item in arr)
            {
                sum += item;
                max = sum > max ? max : sum;
                res = res > sum - max ? res : sum - max;
            }
            return res;
        }
    }
}
