//https://www.codingame.com/training/easy/character-replacement-problem
using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args) {
        Graph Hawat = ReadInput();
        PrintOutput(Hawat);
    }
    static Graph ReadInput() {
        string[] Code = Console.ReadLine().Split(' ');
        Graph Hawat = new();
        foreach (var code in Code) {
            Hawat.AddNodes(code);
        }
        return Hawat;
    }
    static void PrintOutput(Graph input) {
        if (!input.SolveTranslations()) {
            Console.WriteLine("ERROR");
            return;
        }
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++) {
            Console.WriteLine(input.TranslateString(Console.ReadLine()));
        }
    }
}

class Graph
{
    private Dictionary<char, List<char>> _nodes;
    private Dictionary<char, char> _translations;
    public Graph() {
        _nodes = new();
        _translations = new();
    }
    public void AddNodes(string input) {
        if (input[0] == input[1]) return;
        if (!_nodes.ContainsKey(input[0])) _nodes.Add(input[0], new List<char>());
        if (!_nodes.ContainsKey(input[1])) _nodes.Add(input[1], new List<char>());
        _nodes[input[0]].Add(input[1]);
    }
    public bool SolveTranslations() {
        foreach (var node in _nodes) {
            if (node.Value.Count > 1) return false;
            List<char> Visited = new();
            if (!FindTranslation(node.Key, ref Visited)) return false;
            _translations.Add(node.Key, Visited[^1]); 
        }
        return true;
    }
    public string TranslateString(string input) {
        foreach (var translation in _translations) {
            input = input.Replace(translation.Key, translation.Value);
        }
        return input;
    }
    private bool FindTranslation(char key, ref List<char> visited) {
        if (visited.Contains(key)) return false;
        visited.Add(key);
        if (_nodes[key].Count == 0) return true;
        return FindTranslation(_nodes[key][0], ref visited); 
    }
}