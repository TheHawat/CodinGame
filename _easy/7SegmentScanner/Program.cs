using System;
using System.Collections.Generic;
class Solution
{
    static void Main(string[] args) {
        List<string> lines = new();
        lines.Add(Console.ReadLine());
        lines.Add(Console.ReadLine());
        lines.Add(Console.ReadLine());
        SegmentReader.Translate(lines);
    }
}
static class SegmentReader
{
    private static readonly List<string[]> Patterns = new(){
    new string[] {" _ " , "| |" , "|_|"},
    new string[] {"   " , "  |" , "  |"},
    new string[] {" _ " , " _|", "|_ "},
    new string[] {" _ " , " _|", " _|"},
    new string[] {"   " , "|_|", "  |"},
    new string[] {" _ " , "|_ ", " _|"},
    new string[] {" _ " , "|_ ", "|_|"},
    new string[] {" _ " , "  |", "  |"},
    new string[] {" _ " , "|_|", "|_|"},
    new string[] {" _ " , "|_|", " _|"}
    };
    public static void Translate(List<string> Input) {
        string Result = "";
        for (int i = 0; i < Input[0].Length; i += 3) {
            for (int j = 0; j < Patterns.Count; j++) {
                if (Input[0][i..(i + 3)] != Patterns[j][0]) continue;
                if (Input[1][i..(i + 3)] != Patterns[j][1]) continue;
                if (Input[2][i..(i + 3)] != Patterns[j][2]) continue;
                Result += j;
            }
        }
        Console.WriteLine(Result);
    }
}