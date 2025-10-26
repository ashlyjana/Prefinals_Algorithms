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
     * Complete the 'matrixRotation' function below.
     *
     * The function accepts following parameters:
     *  1. 2D_INTEGER_ARRAY matrix
     *  2. INTEGER r
     */

    public static void matrixRotation(List<List<int>> matrix, int r)
    {
        int m = matrix.Count;
        int n = matrix[0].Count;
        int layers = Math.Min(m, n) / 2;
        for (int layer = 0; layer < layers; layer++)
        {
            List<int> elements = new List<int>();
            // Extract elements of the current layer
            for (int i = layer; i < n - layer; i++)
                elements.Add(matrix[layer][i]);
            for (int i = layer + 1; i < m - layer - 1; i++)
                elements.Add(matrix[i][n - layer - 1]);
            for (int i = n - layer - 1; i >= layer; i--)
                elements.Add(matrix[m - layer - 1][i]);
            for (int i = m - layer - 2; i > layer; i--)
                elements.Add(matrix[i][layer]);
            int len = elements.Count;
            int rotations = r % len;
            // Rotate the elements
            List<int> rotated = elements.Skip(rotations).Concat(elements.Take(rotations)).ToList();
            // Place rotated elements back into the matrix
            int index = 0;
            for (int i = layer; i < n - layer; i++)
                matrix[layer][i] = rotated[index++];
            for (int i = layer + 1; i < m - layer - 1; i++)
                matrix[i][n - layer - 1] = rotated[index++];
            for (int i = n - layer - 1; i >= layer; i--)
                matrix[m - layer - 1][i] = rotated[index++];
            for (int i = m - layer - 2; i > layer; i--)
                matrix[i][layer] = rotated[index++];
        }
        
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row));
        }

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(firstMultipleInput[0]);

        int n = Convert.ToInt32(firstMultipleInput[1]);

        int r = Convert.ToInt32(firstMultipleInput[2]);

        List<List<int>> matrix = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
        }

        Result.matrixRotation(matrix, r);
    }
}
