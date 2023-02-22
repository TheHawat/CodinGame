//https://www.codingame.com/ide/puzzle/happy-numbers
using System;
using System.Collections.Generic;

class Solution
{
    static void Main() {
        ProcessInput();
    }
    static void ProcessInput() {
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++) {
            string input = Console.ReadLine();
            Console.WriteLine(input + (HappyNumber.IsHappy(input) ? " :)" : " :("));
        }
    }
}
static class HappyNumber
{
    public static bool IsHappy(string input) {
        string CurrentIteration = input;
        List<string> PreviousHits = new();
        do {
            if (CurrentIteration == "1") return true;
            PreviousHits.Add(CurrentIteration);
            CurrentIteration = CalcOneIteration(CurrentIteration);
        }
        while (!PreviousHits.Contains(CurrentIteration));
        return false;
    }
    private static string CalcOneIteration(string input) {
        int Result = 0;
        foreach (var c in input) {
            int n = c - '0';
            Result += n * n;
        }
        return Result.ToString();
    }

}