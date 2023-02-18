//https://www.codingame.com/ide/puzzle/1d-bush-fire
using System;
class Solution
{
    static void Main(string[] args) {
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++) {
            HowManyDrops(Console.ReadLine());
        }
    }
    private static void HowManyDrops(string? input) {
        char[] Forest = input.ToCharArray();
        int Counter = 0;
        for (int i = 0; i < Forest.Length; i++) {
            if (Forest[i] == 'f') {
                Forest[i] = '.';
                if (i < Forest.Length - 1) Forest[i + 1] = '.';
                if (i < Forest.Length - 2) Forest[i + 2] = '.';
                Counter++;
            }
        }
        Console.WriteLine(Counter);
    }
}