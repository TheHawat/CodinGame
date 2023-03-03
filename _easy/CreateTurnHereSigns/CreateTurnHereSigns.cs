using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args) {
        string input = Console.ReadLine();
        ArrowGenerator.DrawArrows(input);
    }
}


public static class ArrowGenerator
{
    public static void DrawArrows(string definition) {
        string[] SeparatedInputs = definition.Split(' ');
        int[] ConvertedInputs = Array.ConvertAll(SeparatedInputs[1..], x => int.Parse(x));
        string line = new string(SeparatedInputs[0] == "right" ? '>' : '<', ConvertedInputs[2]);
        line += new string(' ', ConvertedInputs[3]);
        line = string.Join("", Enumerable.Repeat(line, ConvertedInputs[0]));
        List<string> Res = new();
        if (SeparatedInputs[0] == "right") {
            for (int i = 0; i < ConvertedInputs[1] / 2; i++) {
                Res.Insert(i, line);
                Res.Insert(Res.Count - i, line);
                line = new string(' ', ConvertedInputs[4]) + line;
            }
            Res.Insert(ConvertedInputs[1] / 2, line);
        }
        else {
            Res.Add(line);
            for (int i = 0; i < ConvertedInputs[1] / 2; i++) {
                line = new string(' ', ConvertedInputs[4]) + line;
                Res.Insert(Res.Count / 2 - i, line);
                Res.Insert(Res.Count / 2 + i + 1, line);
            }
        }
        Res.ForEach(x => Console.WriteLine(x.TrimEnd()));
    }
}