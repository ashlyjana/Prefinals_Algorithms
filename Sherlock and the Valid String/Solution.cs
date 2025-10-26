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
     * Complete the 'isValid' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string isValid(string s)
    {
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }
        Dictionary<int, int> freqCount = new Dictionary<int, int>();
        foreach (int count in charCount.Values)
        {
            if (freqCount.ContainsKey(count))
                freqCount[count]++;
            else
                freqCount[count] = 1;
        }
        if (freqCount.Count == 1)
            return "YES";
        else if (freqCount.Count == 2)
        {
            var keys = freqCount.Keys.ToList();
            int key1 = keys[0];
            int key2 = keys[1];
            if ((freqCount[key1] == 1 && (key1 - 1 == key2 || key1 - 1 == 0)) ||
                (freqCount[key2] == 1 && (key2 - 1 == key1 || key2 - 1 == 0)))
            {
                return "YES";
            }
        }
        return "NO";

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.isValid(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
