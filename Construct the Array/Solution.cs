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
     * Complete the 'countArray' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER x
     */

    public static long countArray(int n, int k, int x)
    {
        long mod = 1000000007;
        long[,] dp = new long[n + 1, 2];
        
        dp[1, 1] = (x == 1) ? 1 : 0; 
        dp[1, 0] = (x == 1) ? 0 : 1; 
        
        for (int i = 2; i <= n; i++)
        {
      
            dp[i, 1] = dp[i - 1, 0] % mod;

            dp[i, 0] = ((dp[i - 1, 1] * (k - 1)) % mod + (dp[i - 1, 0] * (k - 2)) % mod) % mod;
        }

        return dp[n, 1] % mod;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);
        int k = Convert.ToInt32(firstMultipleInput[1]);
        int x = Convert.ToInt32(firstMultipleInput[2]);

        long answer = Result.countArray(n, k, x);

        textWriter.WriteLine(answer);

        textWriter.Flush();
        textWriter.Close();
    }
}
