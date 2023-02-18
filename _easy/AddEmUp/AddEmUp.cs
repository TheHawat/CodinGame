//https://www.codingame.com/ide/puzzle/addem-up
using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args) {
        Console.ReadLine();
        string Inputs = Console.ReadLine();
        Console.WriteLine(CardAccountant.CheapestPrice(Inputs));
    }
}
static class CardAccountant
{
    public static int CheapestPrice(string input) {
        List<int> SeparatedValues = Array.ConvertAll(input.Split(' '), x => Convert.ToInt32(x)).ToList();
        SeparatedValues.Sort();
        int Sum = 0;
        while (SeparatedValues.Count > 1) {
            int TempSum = SeparatedValues[0] + SeparatedValues[1];
            for (int i = 0; i < 2; i++) SeparatedValues.RemoveAt(0);
            Insert(ref SeparatedValues, TempSum);
            Sum += TempSum;
            Console.Error.WriteLine(string.Join(' ', SeparatedValues));
        }
        return Sum;
    }
    private static void Insert(ref List<int> separatedValues, int sum) {
        for (int i = 0; i < separatedValues.Count - 1; i++) {
            if (sum < separatedValues[i]) continue;
            if (sum > separatedValues[i + 1]) continue;
            Console.Error.WriteLine($"{separatedValues[i]}      {sum}");
            separatedValues.Insert(i + 1, sum);
            return;
        }
        separatedValues.Add(sum);
    }
}