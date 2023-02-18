//https://www.codingame.com/ide/puzzle/conway-sequence
using System;
using System.Collections.Generic;
class Solution
{
    static void Main() {
        ProcessInput();
    }
    static void ProcessInput() {
        int R = int.Parse(Console.ReadLine());
        int L = int.Parse(Console.ReadLine());
        ConwayPrinter.PrintSequenceLast(R, L);
    }
}
static class ConwayPrinter
{
    public static void PrintSequenceLast(int r, int l) {
        List<List<int>> Sequence = FindSolution(r, l);
        Console.WriteLine(string.Join(" ", Sequence[^2]));
    }
    private static List<List<int>> FindSolution(int r, int l) {
        List<List<int>> Sequence = new();
        Sequence.Add(new List<int> { r });
        for (int i = 0; i < l; i++) {
            Sequence.Add(NextLine(Sequence[i]));
        }
        return Sequence;
    }
    private static void AddPair(ref int count, ref int number, ref List<int> result) {
        result.Add(count);
        result.Add(number);
        count = 0;
    }
    private static List<int> NextLine(List<int> input) {
        List<int> Result = new();
        int CurrentCount = 0, CurrentNumber = input[0];
        for (int i = 0; i < input.Count; i++) {
            if (CurrentNumber != input[i]) {
                AddPair(ref CurrentCount, ref CurrentNumber, ref Result);
                CurrentNumber = input[i];
            }
            CurrentCount++;
        }
        AddPair(ref CurrentCount, ref CurrentNumber, ref Result);
        return Result;
    }
}