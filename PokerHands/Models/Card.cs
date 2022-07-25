﻿namespace PokerHands.Models;

public enum Suit
{
   Hearts,
   Diamonds,
   Spades,
   Clubs
}

public class Card
{
   public Suit Suit { get; set; }

   public int Value { get; set; }
}