using System;
using System.Collections.Generic;
using System.Linq;

namespace TexasHoldem
{
    class TexasHoldem : ITable
    {
        public List<Player> Players { get; set; }
        public List<Card> Deck { get; set; }

        /// <summary>
        /// Contains the hand ranks, ordered lowest to highest
        /// </summary>
        public enum HandRank
        {
            HighCard = 0,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush
        }

        /// <summary>
        /// Constructor to Create TexasHoldem table and initialise properties
        /// </summary>
        public TexasHoldem()
        {
            Players = new List<Player>();
            Deck = new List<Card>();
        }

        public void CreateDeck()
        {
            throw new NotImplementedException();
        }

        public Card Draw()
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFullHouse(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if the passed in hand has a Pair in it
        /// </summary>
        /// <param name="hand">The Hand</param>
        /// <returns>True if pair detected</returns>
        public bool IsPair(List<Card> hand)
        {
            return hand.GroupBy(card => card.CardValue).Any(group => group.Count() == 2);
        }

        public bool IsRoyalFlush(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public bool IsStraight(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public bool IsStraightFlush(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if the passed in hand has a Two Pair in it
        /// </summary>
        /// <param name="hand">The Hand</param>
        /// <returns>True if two pair detected</returns>
        public bool IsTwoPair(List<Card> hand)
        {
            return hand.GroupBy(card => card.CardValue).Count(pairs => pairs.Count() == 2) == 2;
        }

        /// <summary>
        /// Determins the rank of the passed in hand
        /// </summary>
        /// <param name="hand">The hand</param>
        /// <returns>The rank of that hand</returns>
        public HandRank RankHand(List<Card> hand)
        {
            //This conditional would be extended to support all types checking highest to lowest
            if (IsTwoPair(hand))
            {
                return HandRank.TwoPair;
            }
            else if (IsPair(hand))
            {
                return HandRank.OnePair;
            }
            else
            {
                return HandRank.HighCard;
            }
        }

        /// <summary>
        /// Goes through all the players hands and finds the highest rank
        /// </summary>
        /// <returns>The player who won</returns>
        public Player WhoWon()
        {
            // Start with default winner being first in list
            Player winner = Players.First();
            for (int i = 1; i < Players.Count; i++)
            {
                // compare the current winner with the next player in the list
                var betterHand = CompareHands(winner.Hand, Players[i].Hand);
                // Determin if the current winner needs to change
                if (winner.Hand != betterHand)
                {
                    winner = Players[i];
                }
            }

            return winner;
        }

        /// <summary>
        /// Compares two hands and returns the higher ranked hand. 
        /// Currently doesnt support tieing but not sure how that works in texas holdem so just returns the first hand. 
        /// </summary>
        /// <param name="hand1">The first hand</param>
        /// <param name="hand2">The sencond hand</param>
        /// <returns>The higher ranked hand</returns>
        public List<Card> CompareHands(List<Card> hand1, List<Card> hand2)
        {
            if (RankHand(hand1) > RankHand(hand2))
            {
                return hand1;
            }
            else
            {
                return hand2;
            }
        }
    }    
}
