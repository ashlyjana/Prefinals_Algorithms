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
     * Complete the 'activityNotifications' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY expenditure
     *  2. INTEGER d
     */

    public static int activityNotifications(List<int> expenditure, int d)
    {
        int count = 0;
        int n = expenditure.Count;
        for (int i = d; i < n; i++)
        {
            List<int> trailingExpenditures = expenditure.GetRange(i - d, d);
            trailingExpenditures.Sort();
            double median;
            if (d % 2 == 0)
            {
                median = (trailingExpenditures[d / 2 - 1] + trailingExpenditures[d / 2]) / 2.0;
            }
            else
            {
                median = trailingExpenditures[d / 2];
            }
            if (expenditure[i] >= 2 * median)
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

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> expenditure = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(expenditureTemp => Convert.ToInt32(expenditureTemp)).ToList();

        int result = Result.activityNotifications(expenditure, d);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
