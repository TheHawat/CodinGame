//https://www.codingame.com/ide/puzzle/artificial-emotional-intelligence
using System;
using System.Collections.Generic;
class Solution
{
    static void Main(string[] args) {
        string Name = Console.ReadLine();
        MessageGenerator Hawat = new MessageGenerator(Name);
        Hawat.WriteMessage();
    }
}

class MessageGenerator
{
    public string Name { get; set; }
    private string _lowerName;
    private List<int> _indexes = new List<int>();
    private List<char> _repeats = new List<char>();
    private string[] _adjList =  { "adaptable", "adventurous", "affectionate", "courageous", "creative", "dependable",
                              "determined", "diplomatic", "giving", "gregarious", "hardworking", "helpful", "hilarious",
                              "honest", "non-judgmental", "observant", "passionate", "sensible", "sensitive", "sincere" };
    private string[] _goodList = { "love", "forgiveness", "friendship", "inspiration", "epic transformations", "wins" };
    private string[] _badList = { "crime", "disappointment", "disasters", "illness", "injury", "investment loss" };
    private string _vowels = "aeiouy";
    private string _constants = "bcdfghjklmnpqrstvwxz";

    public MessageGenerator(string? name) {
        Name = name;
        _lowerName = name.ToLower();
        _indexes = new();
        _repeats = new();
    }
    public void WriteMessage() {
        GenerateIndexes();
        TypeOut();
    }
    private void GenerateIndexes() {
        _indexes.Clear();
        _repeats.Clear();
        List<int> VowelIndexes = new();
        for (int i = 0; i < _lowerName.Length; i++) {
            if (!Char.IsLetter(_lowerName[i])) continue;
            if (_vowels.Contains(_lowerName[i])) {
                VowelIndexes.Add(Array.IndexOf(_vowels.ToCharArray(), _lowerName[i]));
                continue;
            }
            if (_repeats.Contains(_lowerName[i])) continue;
            _indexes.Add(Array.IndexOf(_constants.ToCharArray(), _lowerName[i]));
            _repeats.Add(_lowerName[i]);
        }
        if (_indexes.Count < 3 || VowelIndexes.Count < 2) return;
        _indexes = _indexes.GetRange(0, 3);
        _indexes.AddRange(VowelIndexes.GetRange(0, 2));
    }
    private void TypeOut() {
        if (_indexes.Count < 5) {
            Console.WriteLine($"Hello {Name}.");
        }
        else {
            Console.WriteLine($"It's so nice to meet you, my dear {_adjList[_indexes[0]]} {Name}.");
            Console.WriteLine($"I sense you are both {_adjList[_indexes[1]]} and {_adjList[_indexes[2]]}.");
            Console.WriteLine($"May our future together have much more {_goodList[_indexes[3]]} than {_badList[_indexes[4]]}.");
        }
    }
}