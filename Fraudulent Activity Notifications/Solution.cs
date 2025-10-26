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
        int notifications = 0;
        int[] count = new int[201]; 

        for (int i = 0; i < d; i++)
            count[expenditure[i]]++;

        for (int i = d; i < expenditure.Count; i++)
        {
            double median = GetMedian(count, d);

            if (expenditure[i] >= 2 * median)
                notifications++;

            // Slide the window
            count[expenditure[i - d]]--;
            count[expenditure[i]]++;    
        }

        return notifications;
    }
        private static double GetMedian(int[] count, int d)
    {
        int sum = 0;

        if (d % 2 == 1)
        {
            int mid = d / 2 + 1;
            for (int i = 0; i < count.Length; i++)
            {
                sum += count[i];
                if (sum >= mid)
                    return i;
            }
        }
        else
        {
            int mid1 = d / 2;
            int mid2 = mid1 + 1;
            int m1 = -1, m2 = -1;

            for (int i = 0; i < count.Length; i++)
            {
                sum += count[i];
                if (m1 == -1 && sum >= mid1)
                    m1 = i;
                if (sum >= mid2)
                {
                    m2 = i;
                    break;
                }
            }
            return (m1 + m2) / 2.0;
        }

        return 0;
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
