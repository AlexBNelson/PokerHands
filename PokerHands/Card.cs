namespace PokerHands;

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

record Hands //TODO: Use in favour of List, List tuple.
{

}