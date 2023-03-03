//https://www.codingame.com/ide/puzzle/encryptiondecryption-of-enigma-machine
using System;
using System.Collections.Generic;

class Solution
{
    static void Main() {
        ProcessInput();
    }
    public static void ProcessInput() {
        string operation = Console.ReadLine();
        int pseudoRandomNumber = int.Parse(Console.ReadLine());
        Enigma Result = new();
        for (int i = 0; i < 3; i++) {
            Result.AddRotor(Console.ReadLine());
        }
        string message = Console.ReadLine();
        if (operation == "ENCODE") {
            Console.WriteLine(Result.Encrypt(message, pseudoRandomNumber));
        }
        else {
            Console.WriteLine(Result.Decrypt(message, pseudoRandomNumber));
        }
    }
}

class Enigma
{
    private List<string> _rotors = new();
    public void AddRotor(string? v) {
        _rotors.Add(v);
    }
    public string Encrypt(string input, int shift) {
        char[] message = input.ToCharArray();
        for (int i = 0; i < message.Length; i++) {
            int letter = message[i] - 'A' + shift++;
            letter = letter % 26;
            foreach (var encoder in _rotors) {
                letter = encoder[letter] - 'A';
            }
            message[i] = (char)('A' + letter);
        }
        return new string(message);
    }
    public string Decrypt(string input, int shift) {
        char[] message = input.ToCharArray();
        for (int i = 0; i < message.Length; i++) {
            int letter = message[i] - 'A';
            for (int j = _rotors.Count - 1; j >= 0; j--) {
                letter = _rotors[j].IndexOf((char)('A' + letter));
            }
            letter -= shift++;
            while (letter < 0) letter += 26;
            message[i] = (char)('A' + letter);
        }
        return new string(message);
    }
}