//https://www.codingame.com/ide/puzzle/abcdefghijklmnopqrstuvwxyz
using System;
using System.Linq;
using System.Collections.Generic;
class Solution
{
    static void Main(string[] args) {
        Maze Hawat = ReadInput();
        Hawat.FindSolution();
        Hawat.PrintVictory();
    }
    static Maze ReadInput() {
        int n = int.Parse(Console.ReadLine());
        Maze Hawat = new Maze(n, n);
        for (int i = 0; i < n; i++) {
            Hawat.AddRow(Console.ReadLine(), i);
        }
        return Hawat;
    }
}
class Maze
{
    private const string _alphabet = "abcdefghijklmnopqrstuvwxyz";
    private (int DX, int DY)[] _modifier = { (1, 0), (-1, 0), (0, 1), (0, -1) };
    private char[,] _image;
    private int _height;
    private int _width;
    private List<(int X, int Y)> _startingPosition;
    private bool[,] _victory;
    public Maze(int w, int h) {
        _height = h;
        _width = w;
        _image = new char[h, w];
        _startingPosition = new List<(int X, int Y)>();
    }
    public void AddRow(string Line, int i) {
        int j = 0;
        foreach (char c in Line) {
            _image[i, j] = c;
            if (c == 'a') _startingPosition.Add((i, j));
            j++;
        }
    }
    public void FindSolution() {
        foreach (var s in _startingPosition) {
            bool[,] Visited = new bool[_height, _width];
            Move(Visited, 0, s.X, s.Y);
        }
    }
    public void PrintVictory() {
        for (int i = 0; i < _height; i++) {
            for (int j = 0; j < _width; j++) {
                Console.Write(_victory[i, j] ? _image[i, j] : '-');
            }
            Console.WriteLine();
        }
    }
    private bool InBounds(int index) {
        return (index >= 0) && (index < _height);
    }
    private void Move(bool[,] Visited, int Counter, int X, int Y) {
        Console.Error.WriteLine($"Im at {X}, {Y} and my Counter is {Counter}. My value is {_image[X, Y]}.");
        if (_alphabet[Counter] != _image[X, Y]) return;
        Visited[X, Y] = true;
        if (Counter == 25 && _image[X, Y] == 'z') { _victory = Visited; return; }
        if (Counter == 25) return;
        Counter++;
        foreach (var M in _modifier) {
            int NextX = M.DX + X, NextY = M.DY + Y;
            bool InRange = InBounds(NextX) && InBounds(NextY);
            if (InRange && !Visited[NextX, NextY]) Move(Visited, Counter, NextX, NextY);
        }
    }
}