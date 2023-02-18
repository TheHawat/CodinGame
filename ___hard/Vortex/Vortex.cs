//https://www.codingame.com/ide/puzzle/vortex
using System;
using System.Collections.Generic;
using System.Numerics;

class Solution
{
    static void Main(string[] args) {
        Vortex Hawat = ReadInput();
        Hawat.CrankMatrix();
        Hawat.TypeOut();
    }
    static Vortex ReadInput() {
        string[] inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]);
        int H = int.Parse(inputs[1]);
        int X = int.Parse(Console.ReadLine());
        Vortex Hawat = new(X);
        for (int i = 0; i < H; i++) {
            int[] line = Array.ConvertAll(Console.ReadLine().Split(' '), v => Int32.Parse(v));
            Hawat.AddToMatrix(line);
        }
        return Hawat;
    }
}
public class Vortex
{
    public List<int[]> Matrix { private set; get; }
    private int _cranksToGo;
    private int _ringsToCrank = 0;

    public Vortex(int x) {
        _cranksToGo = x;
        Matrix = new();
    }
    public void AddToMatrix(int[] line) {
        Matrix.Add(line);
    }
    public void TypeOut() {
        foreach (int[] line in Matrix) Console.WriteLine(string.Join(" ", line));
    }
    public void CrankMatrix() {
        _ringsToCrank = Math.Min(Matrix.Count, Matrix[0].Length) / 2;
        for (int i = 0; i < _ringsToCrank; i++) {
            int NormalisedCranks = _cranksToGo % (((Matrix.Count - (2 * i) - 1) + (Matrix[0].Length - (2 * i) - 1)) * 2);
            for (int j = 0; j < NormalisedCranks; j++) CrankRingOnce(i);
        }
    }
    private void CrankRingOnce(int RingToSpin) {
        List<int[]> TempCopy = EmptyCopy();
        for (int i = 0 + RingToSpin; i < Matrix[0].Length - RingToSpin - 1; i++) {
            TempCopy[RingToSpin][i] = Matrix[RingToSpin][i + 1];
        }
        for (int i = 1 + RingToSpin; i < Matrix[0].Length - RingToSpin; i++) {
            TempCopy[^(RingToSpin + 1)][i] = Matrix[^(RingToSpin + 1)][i - 1];
        }
        for (int i = 0 + RingToSpin; i < Matrix.Count - RingToSpin - 1; i++) {
            TempCopy[i][^(RingToSpin + 1)] = Matrix[i + 1][^(RingToSpin + 1)];
        }
        for (int i = 1 + RingToSpin; i < Matrix.Count - RingToSpin; i++) {
            TempCopy[i][RingToSpin] = Matrix[i - 1][RingToSpin];
        }
        Matrix = new(TempCopy);
    }
    private List<int[]> EmptyCopy() {
        List<int[]> Result = new();
        for (int i = 0; i < Matrix.Count; i++) Result.Add((int[])Matrix[i].Clone());
        return Result;
    }
}