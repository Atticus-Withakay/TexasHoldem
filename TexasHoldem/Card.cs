namespace TexasHoldem
{
    public struct Card
    {
        public FaceValue CardValue { get; set; }
        public Suit CardSuit { get; set; }

        public Card(FaceValue value, Suit suit)
        {
            CardValue = value;
            CardSuit = suit;
        }
    }

    public enum FaceValue
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public enum Suit
    {
        Club = 0,
        Diamond,
        Spade,
        Heart
    }

}
