//Ugly Solution, Battle method very ugly
//https://www.codingame.com/ide/puzzle/winamax-battle
using System;
using System.Linq;
using System.Collections.Generic;
class Solution
{
    static List<HandOfCards> Players = new List<HandOfCards>();
    static void Main() {
        ReadInput();
        PrintResult();
    }
    static void ReadInput() {
        for (int x = 0; x < 2; x++) {
            int n = int.Parse(Console.ReadLine());
            HandOfCards CurrentHand = new();
            for (int i = 0; i < n; i++) {
                string Card = Console.ReadLine();
                int Value = char.IsDigit(Card[0]) ? int.Parse(Card.Remove(Card.Length - 1)) :
                                   Card[0] == 'J' ? 11 :
                                   Card[0] == 'Q' ? 12 :
                                   Card[0] == 'K' ? 13 : 14;
                char Suit = Card[1];
                CurrentHand.AddCard((Value, Suit));
            }
            Players.Add(CurrentHand);
        }
    }
    static void PrintResult() {
        HandOfCards PlayerOne = Players[0];
        HandOfCards PlayerTwo = Players[1];
        Console.WriteLine(HandOfCards.DetermineWinner(ref PlayerOne, ref PlayerTwo));
    }
}

class HandOfCards
{
    private Queue<(int Value, char Suit)> _cards;
    public HandOfCards() {
        _cards = new Queue<(int Value, char Suit)>();
    }
    public void AddCard((int Value, char Suit) Card) {
        _cards.Enqueue(Card);
    }
    public (int Value, char Suit) DealCard() {
        if (_cards.Count == 0) { throw new ArgumentException("NoMoreCards"); }
        return _cards.Dequeue();
    }
    public static HandOfCards operator +(HandOfCards Left, HandOfCards Right) {
        HandOfCards Result = Left;
        while (Right._cards.Count > 0) {
            Result.AddCard(Right.DealCard());
        }
        return Result;
    }
    private static void Battle(ref HandOfCards Left, ref HandOfCards Right) {
        (int Value, char Suit) LeftCard = Left.DealCard();
        (int Value, char Suit) RightCard = Right.DealCard();
        string Winner = LeftCard.Value == RightCard.Value ? "Tie" :
                        LeftCard.Value > RightCard.Value ? "Left" : "Right";

        switch (Winner) {
            case "Tie":
                HandOfCards LeftResults = new HandOfCards();
                HandOfCards RightResults = new HandOfCards();
                Winner = War(ref Left, ref Right, ref LeftResults, ref RightResults);
                switch (Winner) {
                    case "Left":
                        Left.AddCard(LeftCard);
                        Left += LeftResults;
                        Left.AddCard(RightCard);
                        Left += RightResults;
                        break;
                    case "Right":
                        Right.AddCard(LeftCard);
                        Right += LeftResults;
                        Right.AddCard(RightCard);
                        Right += RightResults;
                        break;
                }
                break;
            case "Left":
                Left.AddCard(LeftCard);
                Left.AddCard(RightCard);
                break;
            case "Right":
                Right.AddCard(LeftCard);
                Right.AddCard(RightCard);
                break;
        }
    }
    private static string War(ref HandOfCards Left, ref HandOfCards Right, ref HandOfCards LeftResults, ref HandOfCards RightResults) {
        int LeftScore = 0, RightScore = 0;
        string Winner = "";
        for (int i = 0; i < 4; i++) {
            (int Value, char Suit) LeftCard = Left.DealCard();
            LeftResults.AddCard(LeftCard);
            (int Value, char Suit) RightCard = Right.DealCard();
            RightResults.AddCard(RightCard);
            if (i == 3) {
                Winner = LeftCard.Value == RightCard.Value ? "Tie" :
                                        LeftCard.Value > RightCard.Value ? "Left" : "Right";
            }
        }
        if (Winner == "Tie") {
            Winner = War(ref Left, ref Right, ref LeftResults, ref RightResults);
        }
        return Winner;
    }
    public static string DetermineWinner(ref HandOfCards Left, ref HandOfCards Right) {
        int TurnCount = 0;
        while (Left._cards.Count > 0 && Right._cards.Count > 0) {
            try {
                Battle(ref Left, ref Right);
                TurnCount++;
            }
            catch (ArgumentException e) {
                return "PAT";
            }
        }
        string Result = (Left._cards.Count == 0 ? "2 " : "1 ") + TurnCount;
        return Result;
    }
}