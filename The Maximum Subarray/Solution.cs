using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'maxSubarray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> maxSubarray(List<int> arr)
    {
        int n = arr.Count;

        int currentSum = arr[0];
        int maxSubarraySum = arr[0];

        for (int i = 1; i < n; i++)
        {
            currentSum = Math.Max(arr[i], currentSum + arr[i]);
            maxSubarraySum = Math.Max(maxSubarraySum, currentSum);
        }

        int maxSubsequenceSum = 0;
        bool hasPositive = arr.Any(x => x > 0);

        if (hasPositive)
        {
            maxSubsequenceSum = arr.Where(x => x > 0).Sum();
        }
        else
        {
            maxSubsequenceSum = arr.Max();
        }

        return new List<int> { maxSubarraySum, maxSubsequenceSum };
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Result.maxSubarray(arr);

            textWriter.WriteLine(String.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
