using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Maze
{
    private int Time { get; set; }
    protected int Width { get; set; }
    protected int Height { get; set; }
    protected List<char[]> MazeImage { get; set; }
    protected List<Tuple<char, int, int>> AsteroidPosition { get; set; }
    public Maze(int w, int h, int time) {
        Width = w;
        Height = h;
        MazeImage = new List<char[]>();
        AsteroidPosition = new List<Tuple<char, int, int>>();
        Time = time;
    }
    public Maze(int w, int h, List<char[]> s) {
        Width = w;
        Height = h;
        List<Tuple<char, int, int>> TempAP = new List<Tuple<char, int, int>>();
        for (int i = 0; i < h; i++) {
            for (int j = 0; j < w; j++) {
                if (s[i][j] != '.') {
                    TempAP.Add(new Tuple<char, int, int>(s[i][j], i, j));
                }
            }
        }
        AsteroidPosition = TempAP;
        MazeImage = s;
    }
    public static Maze operator +(Maze A, Maze B) {
        List<char[]> TempMazeImage = new List<char[]>();
        for (int i = 0; i < A.Height; i++) {
            char[] Temp = new char[A.Width];
            for (int j = 0; j < A.Width; j++) {
                Temp[j] = '.';
            }
            TempMazeImage.Add(Temp);
        }
        Maze Result = new Maze(A.Width, A.Height, TempMazeImage);
        foreach (var Asteroid in A.AsteroidPosition) {
            int Index = B.AsteroidPosition.FindIndex(x => x.Item1 == Asteroid.Item1);
            int XRes = 2 * B.AsteroidPosition[Index].Item2 - Asteroid.Item2;
            int YRes = 2 * B.AsteroidPosition[Index].Item3 - Asteroid.Item3;
            Result.AsteroidPosition.Add(new Tuple<char, int, int>(Asteroid.Item1, XRes, YRes));
        }
        Result.CompileImage();
        Result.Time = B.Time - A.Time + B.Time;
        return Result;
    }
    public static Maze SumWithTime(Maze A, Maze B, int T3) {
        List<char[]> TempMazeImage = new List<char[]>();
        for (int i = 0; i < A.Height; i++) {
            char[] Temp = new char[A.Width];
            for (int j = 0; j < A.Width; j++) {
                Temp[j] = '.';
            }
            TempMazeImage.Add(Temp);
        }
        Maze Result = new Maze(A.Width, A.Height, TempMazeImage);
        double Multiplier = Convert.ToDouble(T3 - B.Time) / (B.Time - A.Time);
        foreach (var Asteroid in A.AsteroidPosition) {
            int Index = B.AsteroidPosition.FindIndex(x => x.Item1 == Asteroid.Item1);
            int XRes = Convert.ToInt32(Math.Floor((B.AsteroidPosition[Index].Item2 - Asteroid.Item2) * Multiplier + B.AsteroidPosition[Index].Item2));
            int YRes = Convert.ToInt32(Math.Floor((B.AsteroidPosition[Index].Item3 - Asteroid.Item3) * Multiplier + B.AsteroidPosition[Index].Item3));
            Result.AsteroidPosition.Add(new Tuple<char, int, int>(Asteroid.Item1, XRes, YRes));
        }
        Result.CompileImage();
        Result.Time = B.Time - A.Time + B.Time;
        return Result;
    }
    private void CompileImage() {
        foreach (var chars in MazeImage) {
            for (int i = 0; i < chars.Length; i++) {
                chars[i] = '.';
            }
        }
        foreach (var P in AsteroidPosition) {
            try {
                if (MazeImage[P.Item2][P.Item3] > P.Item1 || MazeImage[P.Item2][P.Item3] == '.') {
                    MazeImage[P.Item2][P.Item3] = P.Item1;
                }
            }
            catch (IndexOutOfRangeException e) { }
            catch (ArgumentOutOfRangeException e) { }
        }
    }
    public void AddRow(string Row) {
        char[] TempLine = new char[Width];
        for (int i = 0; i < Width; i++) {
            TempLine[i] = Row[i];
        }
        MazeImage.Add(TempLine);
        if (MazeImage.Count == Height) {
            for (int i = 0; i < Height; i++) {
                for (int j = 0; j < Width; j++) {
                    if (MazeImage[i][j] != '.') {
                        AsteroidPosition.Add(new Tuple<char, int, int>(MazeImage[i][j], i, j));
                    }
                }
            }
        }
    }
    public void TypeOut(string Type) {
        if (Type == "Error") {
            for (int i = 0; i < Height; i++) {
                string line = "";
                for (int j = 0; j < Width; j++) {
                    line += MazeImage[i][j];
                }
                Console.Error.WriteLine(line);
            }
        }
        if (Type == "Answer") {
            for (int i = 0; i < Height; i++) {
                string line = "";
                for (int j = 0; j < Width; j++) {
                    line += MazeImage[i][j];
                }
                Console.WriteLine(line);
            }
        }
    }
}
class Solution
{
    static void Main(string[] args) {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]);
        int H = int.Parse(inputs[1]);
        int T1 = int.Parse(inputs[2]);
        int T2 = int.Parse(inputs[3]);
        int T3 = int.Parse(inputs[4]);
        Maze HawatA = new Maze(W, H, T1);
        Maze HawatB = new Maze(W, H, T2);
        for (int i = 0; i < H; i++) {
            inputs = Console.ReadLine().Split(' ');
            HawatA.AddRow(inputs[0]);
            HawatB.AddRow(inputs[1]);
        }
        Maze.SumWithTime(HawatA, HawatB, T3).TypeOut("Answer");
    }
}