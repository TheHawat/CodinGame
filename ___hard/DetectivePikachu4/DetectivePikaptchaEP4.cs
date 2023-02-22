// https://www.codingame.com/ide/puzzle/detective-pikaptcha-ep4
using System;
using System.Linq;
using System.Collections.Generic;
class Player
{
    static char[] Directions = new char[] { '^', '>', 'v', '<' };
    static int Direction = 0;
    static (int, int) Position = (0, 0);
    static void Main(string[] args) {
        PikaMaze Hawat = ReadInput();
        Hawat.ProgressAllMoves();
        Hawat.TypeOut();
    }
    private static PikaMaze ReadInput() {
        int N = int.Parse(Console.ReadLine());
        List<int[]> Maze = new();
        Maze = ReadMaze(N);
        bool Side = Console.ReadLine()[0] == 'R' ? true : false;
        return new PikaMaze(N, Direction, Side, Maze, Position);
    }
    private static List<int[]> ReadMaze(int N) {
        List<int[]> Maze = new();
        for (int i = 0; i < 6 * N; i++) {
            Maze.Add(Array.ConvertAll(Console.ReadLine().ToCharArray(), x => x == '#' ? -1 : x == '0' ? 0 : Array.IndexOf(Directions, x) - 5));
            int StartingIndex = Maze[i].Min();
            if (StartingIndex < -1) {
                Direction = StartingIndex + 5;
                Position = (i, Array.IndexOf(Maze[i], StartingIndex));
                Maze[i][Array.IndexOf(Maze[i], StartingIndex)] = 0;
            }
        }
        return Maze;
    }
}

class PikaMaze
{
    private int _n, _direction, _tempDirection;
    private (int X, int Y) _position, _tempPosition;
    private bool _side;
    private bool _justRotated = false;
    private List<int[]> _maze;
    private readonly List<(int X, int Y)> _swaps = new() { (-1, 0), (0, 1), (1, 0), (0, -1) };
    private readonly List<List<(int AdjSquare, int Turn)>> _adjList = new(){
        new List<(int AdjSquare, int Turn)>{ (5, 0), (3, 1), (2, 0), (1,-1) },
        new List<(int AdjSquare, int Turn)>{ (0, 1), (2, 0), (4,-1), (5,-2) },
        new List<(int AdjSquare, int Turn)>{ (0, 0), (3, 0), (4, 0), (1, 0) },
        new List<(int AdjSquare, int Turn)>{ (0,-1), (5, 2), (4, 1), (2, 0) },
        new List<(int AdjSquare, int Turn)>{ (2, 0), (3,-1), (5, 0), (1, 1) },
        new List<(int AdjSquare, int Turn)>{ (4, 0), (3, 2), (0, 0), (1,-2) },
    };
    public PikaMaze(int n, int direction, bool side, List<int[]> maze, (int, int) position) {
        _n = n;
        _side = side;
        _maze = maze;
        _direction = direction;
        _position = position;
    }
    private int Rotate(bool way) {
        if (way) return _direction == 3 ? 0 : _direction + 1;
        return _direction == 0 ? 3 : _direction - 1;
    }
    public void ProgressAllMoves() {
        (int X, int Y) StartingPosition = _position;
        int i = 0;
        do {
            Move();
            i++;
        }
        while (!_position.Equals(StartingPosition) || i < 4);
    }
    private void Move() {
        if (CellTransformation(_direction, true) > -1 && (CellTransformation(Rotate(_side), false) == -1 || _justRotated)) {
            StepForward();
        }
        else if (CellTransformation(Rotate(_side), false) > -1) {
            _direction = Rotate(_side);
            _justRotated = true;
        }
        else {
            _direction = Rotate(!_side);
            _justRotated = true;
        }
    }
    private void StepForward() {
        _position = _tempPosition;
        _direction = _tempDirection;
        _maze[_position.X][_position.Y]++;
        _justRotated = false;
    }
    private int CellTransformation(int dir, bool tempMove) {
        int CurrentSquare = _position.X / _n;
        (int X, int Y) Result = (_position.X + _swaps[dir].X, _position.Y + _swaps[dir].Y);
        int NewDirection = dir;
        if (SquareIsOutOfRange(Result, CurrentSquare)) {
            (int AdjSquare, int Turn) = _adjList[CurrentSquare][dir];
            Result.X = _position.X - _n * CurrentSquare;
            Result = ProcessTransformation(Turn, ref NewDirection, Result);
            Result.X += _n * AdjSquare;
        }
        if (tempMove) (_tempPosition, _tempDirection) = (Result, NewDirection);
        return _maze[Result.X][Result.Y];
    }
    private bool SquareIsOutOfRange((int X, int Y) result, int currentSquare) {
        if (result.X / _n != currentSquare) return true;
        if (result.Y == _n) return true;
        if (result.Y < 0) return true;
        if (result.X == -1) return true;
        return false;
    }
    private (int, int) ProcessTransformation(int turn, ref int newDirection, (int X, int Y) result) {
        if (turn == 0) return StraightAhead(newDirection, result);
        if (turn == 1) return TurnRight(ref newDirection, result);
        if (turn == -1) return TurnLeft(ref newDirection, result);
        if (turn == 2) return SpinRight(ref newDirection, result);
        return SpinLeft(ref newDirection, result);
    }
    private (int, int) StraightAhead(int direction, (int X, int Y) position) {
        if (direction == 0) return (_n - 1, position.Y);
        if (direction == 1) return (position.X, 0);
        if (direction == 2) return (0, position.Y);
        return (position.X, _n - 1);
    }
    private (int, int) TurnRight(ref int direction, (int X, int Y) position) {
        int SavedDirection = direction;
        direction = Rotate(true);
        if (SavedDirection == 0) return (position.Y, 0);
        if (SavedDirection == 1) return (0, _n - 1 - position.X);
        if (SavedDirection == 2) return (position.Y, _n - 1);
        return (_n - 1, _n - 1 - position.X);
    }
    private (int, int) TurnLeft(ref int direction, (int X, int Y) position) {
        int SavedDirection = direction;
        direction = Rotate(false);
        if (SavedDirection == 0) return (_n - 1 - position.Y, _n - 1);
        if (SavedDirection == 1) return (_n - 1, position.X);
        if (SavedDirection == 2) return (_n - 1 - position.Y, 0);
        return (0, position.X);
    }
    private (int, int) SpinRight(ref int newDirection, (int X, int Y) result) {
        newDirection = 3;
        return (_n - 1 - result.X, _n - 1);
    }
    private (int, int) SpinLeft(ref int newDirection, (int X, int Y) result) {
        newDirection = 1;
        return (_n - 1 - result.X, 0);
    }
    public void TypeOut() {
        for (int i = 0; i < _maze.Count; i++) {
            Console.WriteLine(Array.ConvertAll(_maze[i], x => x == -1 ? '#' : x.ToString()[0]).ToArray());
        }
    }
}