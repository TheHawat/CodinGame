//https://www.codingame.com/ide/puzzle/an-adventure-in-the-fantasy-world
using System;
using System.Collections.Generic;
class Solution
{
    static void Main() {
        ReadInput().TypeOutSolution();
    }
    static Maze ReadInput() {
        string Path = Console.ReadLine();
        Maze Result = new(Path);
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++) {
            string[] line = Console.ReadLine().Split(' ');
            int x = int.Parse(line[0]);
            int y = int.Parse(line[1]);
            int v = line[3][0] == 'g' ? -1 : line[3][0] == 's' ? -2 : int.Parse(line[3][..^1]);
            Result.FieldAdd((x, y), v);
        }
        return Result;
    }
}
class Maze
{
    private Dictionary<(int X, int Y), int> _specialFields;
    private Queue<char> _path;
    private (int X, int Y) _currentPosition = (0, 0);
    private int _currentCash = 50;
    public Maze(string path) {
        _path = new();
        foreach (char c in path) _path.Enqueue(c);
        _specialFields = new();
    }
    public void TypeOutSolution() {
        Console.WriteLine(ProcessGame());
    }
    internal void FieldAdd((int x, int y) value, int v) {
        _specialFields.Add(value, v);
    }
    private (int, int) Move() {
        char Direction = _path.Dequeue();
        if (Direction == 'U') return (_currentPosition.X - 1, _currentPosition.Y);
        if (Direction == 'D') return (_currentPosition.X + 1, _currentPosition.Y);
        if (Direction == 'L') return (_currentPosition.X, _currentPosition.Y - 1);
        return (_currentPosition.X, _currentPosition.Y + 1);
    }
    private bool ProcessCurrentPosition() {
        if (!_specialFields.ContainsKey(_currentPosition)) return true; ;
        if (_specialFields[_currentPosition] == -2) return false;
        if (_specialFields[_currentPosition] == -1) {
            if (_currentCash < 50) return false;
            _currentCash -= 50;
            return true;
        }
        _currentCash += _specialFields[_currentPosition];
        _specialFields[_currentPosition] = 0;
        return true;
    }
    private string ProcessGame() {
        while (_path.Count > 0) {
            _currentPosition = Move();
            if (!ProcessCurrentPosition()) {
                string Enemy = _specialFields[_currentPosition] == -1 ? "goblin" : "slime";
                return $"{_currentPosition.X} {_currentPosition.Y} {_currentCash}G {Enemy}";
            }
        }
        return $"GameClear {_currentPosition.X} {_currentPosition.Y} {_currentCash}G";
    }
}
