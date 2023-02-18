using System;
using System.Linq;
using System.Collections.Generic;
class Solution
{
    static void Main() {
        AnnihilationBoard Hawat = ReadInput();
        Hawat.ProgressAllTurns();
        Console.WriteLine(Hawat.TurnCounter);
    }
    static AnnihilationBoard ReadInput() {
        string[] inputs = Console.ReadLine().Split(' ');
        int H = int.Parse(inputs[0]);
        int W = int.Parse(inputs[1]);
        AnnihilationBoard Hawat = new(H, W);
        for (int i = 0; i < H; i++) {
            Hawat.AddLine(Console.ReadLine());
        }
        return Hawat;
    }
}
class AnnihilationBoard
{
    public int TurnCounter { private set; get; } = 0;
    private int _height;
    private int _width;
    private List<char[]> _maze;
    private readonly Dictionary<char, (int X, int Y)> _direction = new Dictionary<char, (int X, int Y)> {
        { '^', (-1, 0) },
        { '>', (0, 1) },
        { 'v', (1, 0) },
        { '<', (0, -1) }
    };

    public AnnihilationBoard(int h, int w) {
        _height = h;
        _width = w;
        _maze = new();
    }
    public void AddLine(string v) {
        _maze.Add(v.ToArray());
    }
    public void ProgressAllTurns() {
        TurnCounter++;
        while (LookThroughField()) {
            _maze = ProgressWholeField();
        }
    }

    private List<char[]> ProgressWholeField() {
        char[] line = new string('.', _width).ToCharArray();
        List<char[]> Result = new();
        for (int i = 0; i < _height; i++) {
            Result.Add(line);
        }
        for (int i = 0; i < _height; i++) {
            for (int j = 0; j < _width; j++) {
                if (_maze[i][j] == '.') continue;
                var Transform = _direction[_maze[i][j]];
                int NextX = i + Transform.X;
                int NextY = j + Transform.Y;
                if (!InBounds(NextX, NextY)) continue;
                Result[NextX][NextY] = _maze[i][j];
            }
        }
        return Result;
    }
    private bool LookThroughField() {
        bool Result = false;
        for (int i = 0; i < _height; i++) {
            for (int j = 0; j < _width; j++) {
                if (_maze[i][j] == '.') continue;
                var Transform = _direction[_maze[i][j]];
                int NextX = i + Transform.X;
                int NextY = j + Transform.Y;
                if (!InBounds(NextX, NextY)) continue;
                CleanAround(NextX, NextY);
                Result = true;
            }
        }
        return Result;
    }

    private void CleanAround(int nextX, int nextY) {
        List<(int X, int Y)> CleanseCoords = new();
        foreach (var direction in _direction) {
            int TempX = nextX - direction.Value.X;
            int TempY = nextY - direction.Value.Y;
            if (!InBounds(TempX, TempY)) continue;
            if (_maze[TempX][TempY] == direction.Key) CleanseCoords.Add((TempX, TempY));
        }
        if (CleanseCoords.Count > 1) {
            foreach (var item in CleanseCoords) {
                _maze[item.X][item.Y] = '.';
            }
        }
    }
    private bool InBounds(int X, int Y) {
        if (X < 0 || Y < 0) return false;
        if (X >= _height || Y >= _width) return false;
        return true;
    }
}