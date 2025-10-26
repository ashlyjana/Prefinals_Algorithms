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
     * Complete the 'anagram' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int anagram(string s)
    {
        int result = 0;
        if (s.Length % 2 != 0)
        {
            return -1;
        }
        string firstHalf = s.Substring(0, s.Length / 2);
        string secondHalf = s.Substring(s.Length / 2, s.Length / 2);

        Dictionary<char, int> charCount = new Dictionary<char, int>();
        
        foreach (char c in firstHalf)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }
        foreach (char c in secondHalf)
        {
            if (charCount.ContainsKey(c) && charCount[c] > 0)
            {
                charCount[c]--;
            }
            else
            {
                result++;
            }
        }
        return result;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = Result.anagram(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
