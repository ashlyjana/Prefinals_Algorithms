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
     * Complete the 'bomberMan' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING_ARRAY grid
     */

    public static List<string> bomberMan(int n, List<string> grid)
    {
         int r = grid.Count;
        int c = grid[0].Length;

        if (n == 1) return grid;


        if (n % 2 == 0)
            return Enumerable.Repeat(new string('O', c), r).ToList();

        List<string> Explode(List<string> g)
        {
            char[][] result = Enumerable.Repeat(new string('O', c), r)
                .Select(s => s.ToCharArray()).ToArray();

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (g[i][j] == 'O')
                    {
                        result[i][j] = '.';
                        if (i > 0) result[i - 1][j] = '.';
                        if (i < r - 1) result[i + 1][j] = '.';
                        if (j > 0) result[i][j - 1] = '.';
                        if (j < c - 1) result[i][j + 1] = '.';
                    }
                }
            }

            return result.Select(row => new string(row)).ToList();
        }

        List<string> first = Explode(grid);
        List<string> second = Explode(first);

        return ((n - 3) % 4 == 0) ? first : second;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r = Convert.ToInt32(firstMultipleInput[0]);

        int c = Convert.ToInt32(firstMultipleInput[1]);

        int n = Convert.ToInt32(firstMultipleInput[2]);

        List<string> grid = new List<string>();

        for (int i = 0; i < r; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.bomberMan(n, grid);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
