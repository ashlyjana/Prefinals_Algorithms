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
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */

    public static string biggerIsGreater(string w)
    {
        string result = "no answer";
        char[] arr = w.ToCharArray();
        int i = arr.Length - 1;

        while (i > 0 && arr[i - 1] >= arr[i])
        {
            i--;
        }

        if (i > 0)
        {
            int j = arr.Length - 1;
            while (arr[j] <= arr[i - 1])
            {
                j--;
            }
            char temp = arr[i - 1];
            arr[i - 1] = arr[j];
            arr[j] = temp;
            Array.Reverse(arr, i, arr.Length - i);
            result = new string(arr);
        }
        return result;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
