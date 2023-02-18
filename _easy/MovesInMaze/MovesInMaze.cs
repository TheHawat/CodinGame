//https://www.codingame.com/ide/puzzle/moves-in-maze
using System;
using System.Collections.Generic;
class Solution
{
    static void Main() {
        ReadInput().SolveMaze();
    }
    static Maze ReadInput() {
        string[] inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]);
        int H = int.Parse(inputs[1]);
        Maze Hawat = new Maze(W, H);
        for (int i = 0; i < H; i++) {
            Hawat.AddRow(Console.ReadLine(), i);
        }
        return Hawat;
    }
}

class Maze
{
    private int[,] _image;
    private bool[,] _initialVisited;
    private (int X, int Y) _startingPosition;
    private readonly (int DX, int DY)[] _modifier = { (1, 0), (-1, 0), (0, 1), (0, -1) };
    public Maze(int w, int h) {
        _image = new int[h, w];
        _initialVisited = new bool[h, w];
    }
    public void AddRow(string line, int i) {
        for (int j = 0; j < _image.GetLength(1); j++) {
            ProcessChar(line[j], i, j);
        }
    }
    public void SolveMaze() {
        Move(_initialVisited, 0, _startingPosition.X, _startingPosition.Y);
        TypeOut();
    }
    public void TypeOut() {
        for (int i = 0; i < _image.GetLength(0); i++) {
            string line = "";
            for (int j = 0; j < _image.GetLength(1); j++) {
                line += ConvertCell(i, j);
            }
            Console.WriteLine(line);
        }
    }
    private void ProcessChar(char c, int i, int j) {
        _image[i, j] = c == '.' || c == 'S' ? 0 : -1;
        _initialVisited[i, j] = c == '#' ? true : false;
        _startingPosition = c == 'S' ? (i, j) : _startingPosition;
    }
    private (int X, int Y) NextCoordinates(int modifierIndex, int x, int y) {
        int NextX = _modifier[modifierIndex].DX + x, NextY = _modifier[modifierIndex].DY + y;
        NextX = NextX < 0 ? _image.GetLength(0) - 1 : NextX == _image.GetLength(0) ? 0 : NextX;
        NextY = NextY < 0 ? _image.GetLength(1) - 1 : NextY == _image.GetLength(1) ? 0 : NextY;
        return (NextX, NextY);
    }
    private void Move(bool[,] visited, int score, int x, int y) {
        if (!(_image[x, y] > score || _image[x, y] == 0)) return;
        bool[,] NewVisited = (bool[,])visited.Clone();
        NewVisited[x, y] = true;
        _image[x, y] = score;
        for (int i = 0; i < _modifier.Length; i++) {
            (int NextX, int NextY) = NextCoordinates(i, x, y);
            if (!visited[NextX, NextY]) Move(NewVisited, score + 1, NextX, NextY);
        }
    }
    private char ConvertCell(int i, int j) {
        if (_image[i, j] == -1) return '#';
        if (_image[i, j] == 0 && !_startingPosition.Equals((i, j))) return '.';
        return Convert.ToChar(_image[i, j] > 9 ? _image[i, j] + 55 : _image[i, j] + 48);
    }
}