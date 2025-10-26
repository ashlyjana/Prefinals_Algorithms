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
     * Complete the 'initialize' function below.
     *
     * The function accepts STRING s as parameter.
     */

    public static void initialize(string s)
    {
        // This function is called once before all queries.

    }

    /*
     * Complete the 'answerQuery' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER l
     *  2. INTEGER r
     */

    public static int answerQuery(int l, int r)
    {
        int count = 0;
        for (int i = l; i <= r; i++)
        {
            if (i % 2 == 0)
            {
                count++;
            }
        }
        return count;


    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        Result.initialize(s);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int l = Convert.ToInt32(firstMultipleInput[0]);

            int r = Convert.ToInt32(firstMultipleInput[1]);

            int result = Result.answerQuery(l, r);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
