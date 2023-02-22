//https://www.codingame.com/ide/puzzle/mountain-map
using System;
using System.Collections.Generic;
using System.Linq;
class Solution
{
    static void Main() {
        _ = Console.ReadLine();
        string line = Console.ReadLine();
        Mountains.PrintMountain(line);
    }
}

static class Mountains
{
    public static void PrintMountain(string mountains) {
        int[] inputs = Array.ConvertAll(mountains.Split(' '), s => int.Parse(s));
        List<string> Image = new();
        for (int i = 0; i < inputs.Max(); i++) {
            string Line = GenerateLine(inputs, i);
            Image.Insert(0, Line.TrimEnd(' '));
        }
        Console.WriteLine(String.Join("\n", Image));
    }
    private static string GenerateLine(int[] inputs, int i) {
        string Line = "";
        foreach (int H in inputs) {
            if (i < H) {
                Line += new string(' ', i) + "/";
                Line += new string(' ', 2 * (H - (i + 1))) + "\\";
                Line += new string(' ', i);
            }
            else {
                Line += new string(' ', 2 * H);
            }
        }
        return Line;
    }
}