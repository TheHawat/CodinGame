//https://www.codingame.com/training/easy/crop-circles
using System;
class Crops
{
    private bool[,] _cropField;
    private int _height = 25;
    private int _width = 19;
    public Crops() {
        _cropField = new bool[_height, _width];
        InitialiseSeeds();
    }
    private void InitialiseSeeds() {
        for (int i = 0; i < _height; i++) {
            for (int j = 0; j < _width; j++) {
                _cropField[i, j] = true;
            }
        }
    }
    public void TypeOut() {
        for (int i = 0; i < _height; i++) {
            string line = "";
            for (int j = 0; j < _width; j++) {
                line += _cropField[i, j] ? "{}" : "  ";
            }
            Console.WriteLine(line);
        }
    }
    private bool Flop(int mode, int x, int y) {
        if (mode == 0) return false;
        if (mode == 2) return true;
        return !_cropField[x, y];
    }
    private void DoTheWork(int mode, int x, int y, double r) {
        double R2 = r * r;
        for (int i = (int)-r; i < r; i++) {
            for (int j = (int)-r; j < r; j++) {
                int NextX = x + i, NextY = y + j;
                if (InRange(NextX, NextY) && (i * i) + (j * j) < R2) {
                    _cropField[NextX, NextY] = Flop(mode, NextX, NextY);
                }
            }
        }
    }
    private bool InRange(int nextX, int nextY) {
        if (nextX >= 0 && nextY >= 0 && nextX < _height && nextY < _width) return true;
        return false;
    }

    public void ProcessInstruction(string instruction) {
        int Mode = ChoseMode(ref instruction);
        int X = instruction[1] - 'a';
        int Y = instruction[0] - 'a';
        instruction = instruction.Substring(2);
        double R = Convert.ToDouble(instruction) / 2;
        DoTheWork(Mode, X, Y, R);
    }
    private int ChoseMode(ref string instruction) {
        if (instruction.StartsWith("PLANTMOW")) {
            instruction = instruction.Replace("PLANTMOW", "");
            return 1;
        }
        if (instruction.StartsWith("PLANT")) {
            instruction = instruction.Replace("PLANT", "");
            return 2;
        }
        return 0;
    }
    public void ProcessLine(string instructions) {
        string[] SeparateInstructions = Console.ReadLine().Split(' ');
        foreach (string Instruction in SeparateInstructions) {
            ProcessInstruction(Instruction);
        }
    }
}
class Solution
{
    static Crops ProcessInput() {
        string Instructions = Console.ReadLine();
        Crops Hawat = new();
        Hawat.ProcessLine(Instructions);
        return Hawat;
    }
    static void Main(string[] args) {
        Crops Hawat = ProcessInput();
        Hawat.TypeOut();
    }
}