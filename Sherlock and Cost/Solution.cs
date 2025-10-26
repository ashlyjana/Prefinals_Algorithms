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
     * Complete the 'cost' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY B as parameter.
     */

    public static int cost(List<int> B)
    {
        int n = B.Count;
        int low = 0;  
        int high = 0;  

        for (int i = 1; i < n; i++)
        {
            int lowToLow = low;
            int highToLow = high + Math.Abs(B[i - 1] - 1); 
            int lowToHigh = low + Math.Abs(B[i] - 1); 
            int highToHigh = high + Math.Abs(B[i] - B[i - 1]);

            int newLow = Math.Max(lowToLow, highToLow);
            int newHigh = Math.Max(lowToHigh, highToHigh);

            low = newLow;
            high = newHigh;
        }

        return Math.Max(low, high);
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

            List<int> B = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

            int result = Result.cost(B);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
