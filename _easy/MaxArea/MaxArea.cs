// https://www.codingame.com/ide/puzzle/max-area
using System;
class Solution
{
    static void Main(string[] args) {
        Console.ReadLine();
        Bucket Hawat = new Bucket(Console.ReadLine());
        Hawat.FindMaxVolume();
        Console.WriteLine(Hawat.MaxVolume);
    }
}
class Bucket
{
    private int[] _bucketHeights;
    public int MaxVolume {private set; get; }
    public Bucket(string input) {
        _bucketHeights = Array.ConvertAll(input.Split(' '), x => Convert.ToInt32(x));
    }
    public void FindMaxVolume() {
        for (int i = 0; i < _bucketHeights.Length; i++) {
            for (int j = i + 1; j < _bucketHeights.Length; j++) {
                int H = Math.Min(_bucketHeights[i], _bucketHeights[j]);
                int V = (j - i) * H;
                if (V > MaxVolume) MaxVolume = V;
            }
        }
    }
}