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
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {
        string str = s.Replace(" ", "");
        int len = str.Length;
        int rows = (int)Math.Floor(Math.Sqrt(len));
        int cols = (int)Math.Ceiling(Math.Sqrt(len));
        if (rows * cols < len)
        {
            rows++;
        }
        char[,] matrix = new char[rows, cols];
        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (index < len)
                {
                    matrix[i, j] = str[index];
                    index++;
                }
                else
                {
                    matrix[i, j] = '\0';
                }
            }
        }
        return string.Join(" ", Enumerable.Range(0, cols).Select(j => string.Concat(Enumerable.Range(0, rows).Select(i => matrix[i, j]).Where(c => c != '\0'))));

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
