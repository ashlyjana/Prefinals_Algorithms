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
     * Complete the 'almostSorted' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void almostSorted(List<int> arr)
    {
        List<int> sortedArr = new List<int>(arr);
        sortedArr.Sort();
        List<int> diffIndices = new List<int>();
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] != sortedArr[i])
            {
                diffIndices.Add(i);
            }
        }
        if (diffIndices.Count == 0)
        {
            Console.WriteLine("yes");
        }
        else if (diffIndices.Count == 2)
        {
            Console.WriteLine("yes");
            Console.WriteLine($"swap {diffIndices[0] + 1} {diffIndices[1] + 1}");
        }
        else
        {
            int start = diffIndices[0];
            int end = diffIndices[diffIndices.Count - 1];
            List<int> sublist = arr.GetRange(start, end - start + 1);
            sublist.Reverse();
            bool canSortByReversing = true;
            for (int i = 0; i < sublist.Count; i++)
            {
                if (sublist[i] != sortedArr[start + i])
                {
                    canSortByReversing = false;
                    break;
                }
            }
            if (canSortByReversing)
            {
                Console.WriteLine("yes");
                Console.WriteLine($"reverse {start + 1} {end + 1}");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.almostSorted(arr);
    }
}
