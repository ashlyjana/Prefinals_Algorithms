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
     * Complete the 'lilysHomework' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int lilysHomework(List<int> arr)
    {
        List<int> asc = new List<int>(arr);
        List<int> desc = new List<int>(arr);

        asc.Sort();
        desc.Sort();
        desc.Reverse();

        int ascSwaps = CountSwaps(arr, asc);
        int descSwaps = CountSwaps(arr, desc);

        return Math.Min(ascSwaps, descSwaps);
    }
     private static int CountSwaps(List<int> arr, List<int> target)
    {
        int n = arr.Count;
        int swaps = 0;

        Dictionary<int, int> indexMap = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
            indexMap[arr[i]] = i;

        List<int> temp = new List<int>(arr);

        for (int i = 0; i < n; i++)
        {
            if (temp[i] != target[i])
            {
                swaps++;

                int correctValue = target[i];
                int toSwapIdx = indexMap[correctValue];

                indexMap[temp[i]] = toSwapIdx;
                indexMap[correctValue] = i;

                int tempVal = temp[i];
                temp[i] = temp[toSwapIdx];
                temp[toSwapIdx] = tempVal;
            }
        }
        return swaps;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.lilysHomework(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
