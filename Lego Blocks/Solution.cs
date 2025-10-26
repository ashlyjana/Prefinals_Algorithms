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
     * Complete the 'legoBlocks' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER m
     */

    public static int legoBlocks(int n, int m)
    {
        const long MOD = 1000000007;

      
        long[] rowWays = new long[m + 1];
        rowWays[0] = 1;

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= 4; j++)
            {
                if (i - j >= 0)
                    rowWays[i] = (rowWays[i] + rowWays[i - j]) % MOD;
            }
        }

        long[] totalWays = new long[m + 1];
        for (int i = 1; i <= m; i++)
        {
            totalWays[i] = 1;
            for (int j = 0; j < n; j++)
                totalWays[i] = (totalWays[i] * rowWays[i]) % MOD;
        }

        long[] stableWays = new long[m + 1];
        stableWays[0] = 0;
        stableWays[1] = 1;

        for (int i = 2; i <= m; i++)
        {
            long unstable = 0;
            for (int j = 1; j < i; j++)
            {
                unstable = (unstable + stableWays[j] * totalWays[i - j]) % MOD;
            }

            stableWays[i] = (totalWays[i] - unstable + MOD) % MOD;
        }

        return (int)stableWays[m];
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

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int result = Result.legoBlocks(n, m);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
