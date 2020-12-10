using System.Collections.Generic;

namespace TexasHoldem
{

    interface ITable
    {
        // Will need players
        List<Player> Players { get; set; }
        // Will need some cards for a proper game
        List<Card> Deck { get; set; }

        // Will need to have a proper deck
        void CreateDeck();
        // Will need a way to draw from that deck
        Card Draw();

        // If creating an interface for team support I would define the checks needed to rank each type of card
        bool IsRoyalFlush(List<Card> hand);
        bool IsStraightFlush(List<Card> hand);
        bool IsFourOfAKind(List<Card> hand);
        bool IsFullHouse(List<Card> hand);
        bool IsFlush(List<Card> hand);
        bool IsStraight(List<Card> hand);
        bool IsThreeOfAKind(List<Card> hand);
        bool IsTwoPair(List<Card> hand);
        bool IsPair(List<Card> hand);
        bool IsHighCard(List<Card> hand);

        // Need a way to compare 2 hands
        List<Card> CompareHands(List<Card> hand1, List<Card> hand2);

        // Need to determine a winner
        Player WhoWon();
    }
}
