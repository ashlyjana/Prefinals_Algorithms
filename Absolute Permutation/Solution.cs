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
     * Complete the 'absolutePermutation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     */

    public static List<int> absolutePermutation(int n, int k)
    {
        List<int> permutation = new List<int>(new int[n]);
        if (k == 0)
        {
            for (int i = 0; i < n; i++)
            {
                permutation[i] = i + 1;
            }
            return permutation;
        }
        if (n % (2 * k) != 0)
        {
            return new List<int> { -1 };
        }
        bool add = true;
        for (int i = 0; i < n; i++)
        {
            if (add)
            {
                permutation[i] = i + 1 + k;
            }
            else
            {
                permutation[i] = i + 1 - k;
            }
            if ((i + 1) % k == 0)
            {
                add = !add;
            }
        }
        return permutation;

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
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> result = Result.absolutePermutation(n, k);

            textWriter.WriteLine(String.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
