//https://www.codingame.com/ide/puzzle/ascii-art
using System;
using System.Collections.Generic;
class Solution
{
    static void Main(string[] args) {
        (string Message, AsciiPrinter Hawat) = ReadInput();
        Hawat.TypeOutMessage(Message);
    }
    private static (string Message, AsciiPrinter Hawat) ReadInput() {
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine();
        AsciiPrinter Hawat = new(L, H);
        for (int i = 0; i < H; i++) {
            string Row = Console.ReadLine();
            Hawat.AddRow(Row);
        }
        return (T, Hawat);
    }
}
class AsciiPrinter
{
    private int _charWidth;
    private int _charHeight;
    private Dictionary<char, List<string>> _alphabet;
    private string _alph = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";
    public AsciiPrinter(int l, int h) {
        _charWidth = l;
        _charHeight = h;
        _alphabet = new();
        InitialiseAlphabet();
    }
    public void AddRow(string row) {
        for (int i = 0; i < 27; i++) {
            _alphabet[_alph[i]].Add(row[(i * _charWidth)..((i + 1) * _charWidth)]);
        }
    }
    public void TypeOutMessage(string input) {
        input = input.ToUpper();
        for (int i = 0; i < _charHeight; i++) {
            string line = "";
            foreach (char c in input) {
                if (Char.IsLetter(c)) line += _alphabet[c][i];
                else line += _alphabet['?'][i];
            }
            Console.WriteLine(line);
        }       
    }
    private void InitialiseAlphabet() {
        foreach (var item in _alph) {
            _alphabet.Add(item, new List<string>());
        }
    }
}