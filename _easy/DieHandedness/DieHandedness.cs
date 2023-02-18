//https://www.codingame.com/ide/puzzle/die-handedness
using System;
using System.Collections.Generic;
class Solution
{
    static void Main() {
        Dice Hawat = ReadInput();
        Console.WriteLine(Hawat.GetDiceDescription());
    }
    static Dice ReadInput() {
        List<int> Sides = new();
        for (int i = 0; i < 3; i++) {
            string Line = Console.ReadLine();
            foreach (char c in Line) {
                if (c != ' ') Sides.Add((int)c - 48);
            }
        }
        return new Dice(Sides);
    }
}
class Dice
{
    private List<int> _s;
    private List<(int[] Ring, int Up, int Down)> _cycles;
    public Dice(List<int> diceDefinition) {
        _s = diceDefinition;
        _cycles = new();
        InitialiseCycles();
    }
    public string GetDiceDescription() {
        if (!(_s[0] + _s[5] == 7 && _s[1] + _s[3] == 7 && _s[2] + _s[4] == 7)) return "degenerate";
        foreach (var Cycle in _cycles) {
            if (CheckCycle(Cycle)) return "left-handed";
        }
        return "right-handed";
    }
    private void InitialiseCycles() {
        _cycles.Clear();
        _cycles.Add((new[] { _s[1], _s[2], _s[3], _s[4] }, _s[5], _s[0]));
        _cycles.Add((new[] { _s[0], _s[4], _s[5], _s[2] }, _s[3], _s[1]));
        _cycles.Add((new[] { _s[0], _s[3], _s[5], _s[1] }, _s[2], _s[4]));
    }
    private static bool CheckCycle((int[] Ring, int Up, int Down) cycle) {
        int One = Array.IndexOf(cycle.Ring, 1);
        if (One == -1) return false;
        if (((One == 3 ? cycle.Ring[0] : cycle.Ring[One + 1]) == 2 && cycle.Up == 3) ||
            ((One == 0 ? cycle.Ring[3] : cycle.Ring[One - 1]) == 2 && cycle.Down == 3)) return true;
        return false;
    }
}