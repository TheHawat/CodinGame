//https://www.codingame.com/ide/puzzle/1000000000d-world
using System;
class Solution
{
    static void Main(string[] args) {
        long[] A = Array.ConvertAll(Console.ReadLine().Split(' '), x => Convert.ToInt64(x));
        long[] B = Array.ConvertAll(Console.ReadLine().Split(' '), x => Convert.ToInt64(x));
        int j = 0, i = 0;
        long Result = 0;
        long Checker = 1000000000;
        while (Checker > 0) {
            if (A[i] > B[j]) {
                Result += B[j] * A[i + 1] * B[j + 1];
                A[i] -= B[j];
                Checker -= B[j];
                j += 2;
            }
            else if (A[i] < B[j]) {
                Result += A[i] * A[i + 1] * B[j + 1];
                B[j] -= A[i];
                Checker -= A[i];
                i += 2;
            }
            else {
                Result += A[i] * A[i + 1] * B[j + 1];
                Checker -= B[j];
                j += 2;
                i += 2;
            }
        }
        Console.WriteLine(Result);
    }
}