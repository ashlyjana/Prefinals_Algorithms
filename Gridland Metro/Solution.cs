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
     * Complete the 'gridlandMetro' function below.
     *
     * The function is expected to return a LONG (since the result can be large).
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER m
     *  3. INTEGER k
     *  4. 2D_INTEGER_ARRAY track
     */
    public static long gridlandMetro(int n, int m, int k, List<List<int>> track)
    {
        Dictionary<int, List<(int, int)>> rowTracks = new Dictionary<int, List<(int, int)>>();

        foreach (var t in track)
        {
            int row = t[0];
            int start = t[1];
            int end = t[2];

            if (!rowTracks.ContainsKey(row))
                rowTracks[row] = new List<(int, int)>();

            rowTracks[row].Add((start, end));
        }

        long totalTrackCells = 0;

        foreach (var kvp in rowTracks)
        {
            var intervals = kvp.Value.OrderBy(x => x.Item1).ToList();
            int currentStart = intervals[0].Item1;
            int currentEnd = intervals[0].Item2;

            long rowCovered = 0;

            for (int i = 1; i < intervals.Count; i++)
            {
                int nextStart = intervals[i].Item1;
                int nextEnd = intervals[i].Item2;

                if (nextStart <= currentEnd + 1)
                {
                   
                    currentEnd = Math.Max(currentEnd, nextEnd);
                }
                else
                {
                   
                    rowCovered += (currentEnd - currentStart + 1);
                    currentStart = nextStart;
                    currentEnd = nextEnd;
                }
            }

            rowCovered += (currentEnd - currentStart + 1);

            totalTrackCells += rowCovered;
        }

        long totalCells = (long)n * (long)m;
        long unoccupied = totalCells - totalTrackCells;

        return unoccupied;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);
        int m = Convert.ToInt32(firstMultipleInput[1]);
        int k = Convert.ToInt32(firstMultipleInput[2]);

        List<List<int>> track = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            track.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(trackTemp => Convert.ToInt32(trackTemp)).ToList());
        }

        long result = Result.gridlandMetro(n, m, k, track);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
