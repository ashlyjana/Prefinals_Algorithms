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
    const long MOD = 1000000007;
    const int MAX = 100000;
    static long[] fact = new long[MAX + 1];
    static long[] invFact = new long[MAX + 1];
    static int[,] prefix = new int[26, MAX + 1];
    static string str;

    static void Precompute()
    {
        fact[0] = 1;
        for (int i = 1; i <= MAX; i++)
            fact[i] = (fact[i - 1] * i) % MOD;

        invFact[MAX] = ModPow(fact[MAX], MOD - 2);
        for (int i = MAX - 1; i >= 0; i--)
            invFact[i] = (invFact[i + 1] * (i + 1)) % MOD;
    }

    static long ModPow(long baseVal, long exp)
    {
        long res = 1;
        baseVal %= MOD;
        while (exp > 0)
        {
            if ((exp & 1) == 1)
                res = (res * baseVal) % MOD;
            baseVal = (baseVal * baseVal) % MOD;
            exp >>= 1;
        }
        return res;
    }
    public static void initialize(string s)
    {
      str = s;
        Precompute();

        int n = s.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 26; j++)
                prefix[j, i + 1] = prefix[j, i];
            prefix[s[i] - 'a', i + 1]++;
        }
}
    public static int answerQuery(int l, int r)
    {
    int[] count = new int[26];
        for (int j = 0; j < 26; j++)
            count[j] = prefix[j, r] - prefix[j, l - 1];

        int pairs = 0, odds = 0;
        foreach (int c in count)
        {
            pairs += c / 2;
            if (c % 2 == 1) odds++;
        }

        long res = fact[pairs];
        foreach (int c in count)
            res = (res * invFact[c / 2]) % MOD;

        if (odds > 0) res = (res * odds) % MOD;

        return (int)(res % MOD);
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
