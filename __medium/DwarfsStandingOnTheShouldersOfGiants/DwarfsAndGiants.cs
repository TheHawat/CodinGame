// https://www.codingame.com/ide/puzzle/dwarfs-standing-on-the-shoulders-of-giants
using System;
using System.Linq;
using System.Collections.Generic;
class Solution
{
    static void Main() {
        Graph Hawat = ReadInput();
        Console.WriteLine(Hawat.GetLongestPath());
    }
    static Graph ReadInput() {
        Graph Hawat = new();
        int N = int.Parse(Console.ReadLine()); // the number of relationships of influence
        for (int i = 0; i < N; i++) {
            string[] Inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(Inputs[0]); // a relationship of influence between two people (x influences y)
            int Y = int.Parse(Inputs[1]);
            Hawat.AddConnection(X, Y);
        }
        return Hawat;
    }
}
class Graph
{
    private Dictionary<int, List<int>> _nodeAdjList;
    private Dictionary<int, int> _nodeMaxDepth;
    public Graph() {
        _nodeAdjList = new();
        _nodeMaxDepth = new();
    }
    public void AddConnection(int start, int end) {
        if (!_nodeAdjList.ContainsKey(start)) _nodeAdjList.Add(start, new());
        if (!_nodeAdjList.ContainsKey(end)) _nodeAdjList.Add(end, new());
        _nodeAdjList[start].Add(end);
    }
    public string GetLongestPath() {
        foreach (var node in _nodeAdjList) {
            _nodeMaxDepth.Add(node.Key, TraverseGraph(node.Key, 0));
        }
        var MaxPath = _nodeMaxDepth.MaxBy(x => x.Value).Value;
        return MaxPath.ToString();
    }
    private int TraverseGraph(int currentNode, int currentDepth) {
        int Max = ++currentDepth;
        foreach (var Node in _nodeAdjList[currentNode]) {
            Max = Math.Max(TraverseGraph(Node, currentDepth), Max);
        }
        return Max;
    }
}
