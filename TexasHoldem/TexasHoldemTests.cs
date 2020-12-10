using System.Collections.Generic;
using NUnit.Framework;
using static TexasHoldem.TexasHoldem;

namespace TexasHoldem
{
    [TestFixture]
    public class TexasHoldemTests
    {
        TexasHoldem table;

        List<Card> HighCardHand { get; set; }
        List<Card> OnePairHand { get; set; }
        List<Card> TwoPairHand { get; set; }

        [SetUp]
        public void SetUp()
        {
            table = new TexasHoldem();
            HighCardHand = new List<Card>()
            {
                new Card(FaceValue.Ace, Suit.Heart),
                new Card(FaceValue.King, Suit.Club),
                new Card(FaceValue.Queen, Suit.Diamond),
                new Card(FaceValue.Nine, Suit.Spade),
                new Card(FaceValue.Seven, Suit.Heart),
            };
            OnePairHand = new List<Card>()
            {
                new Card(FaceValue.Ace, Suit.Heart),
                new Card(FaceValue.Ace, Suit.Diamond),
                new Card(FaceValue.King, Suit.Diamond),
                new Card(FaceValue.Jack, Suit.Spade),
                new Card(FaceValue.Seven, Suit.Heart),
            };
            TwoPairHand = new List<Card>()
            {
                new Card(FaceValue.Ace, Suit.Heart),
                new Card(FaceValue.Ace, Suit.Diamond),
                new Card(FaceValue.King, Suit.Diamond),
                new Card(FaceValue.King, Suit.Spade),
                new Card(FaceValue.Seven, Suit.Heart),
            };
        }

        [TearDown]
        public void TearDown()
        {
            table = null;
            HighCardHand = null;
            OnePairHand = null;
            TwoPairHand = null;
        }

        /// <summary>
        /// Test to check the correct rank has been returned for a High Card hand
        /// </summary>
        [Test]
        public void RankHand_HighCard()
        {
            var expected = HandRank.HighCard;
            Assert.AreEqual(expected, table.RankHand(HighCardHand));
        }

        /// <summary>
        /// Test to check the correct rank has been returned for a One Pair hand
        /// </summary>
        [Test]
        public void RankHand_OnePair()
        {
            var expected = HandRank.OnePair;
            Assert.AreEqual(expected, table.RankHand(OnePairHand));
        }

        /// <summary>
        /// Test to check the correct rank has been returned for a Two Pair hand
        /// </summary>
        [Test]
        public void RankHand_TwoPair()
        {
            var expected = HandRank.TwoPair;
            var twoPairHand = new List<Card>()
            {
                new Card(FaceValue.Ace, Suit.Heart),
                new Card(FaceValue.Ace, Suit.Diamond),
                new Card(FaceValue.King, Suit.Diamond),
                new Card(FaceValue.King, Suit.Spade),
                new Card(FaceValue.Seven, Suit.Heart),
            };

            Assert.AreEqual(expected, table.RankHand(twoPairHand));
        }

        /// <summary>
        /// Test to check that HandRanking comparisons work
        /// </summary>
        [Test]
        public void CompareHands_ShouldReturnTheHighestRankedHand()
        {
            Assert.AreEqual(TwoPairHand, table.CompareHands(TwoPairHand, HighCardHand));
            Assert.AreEqual(OnePairHand, table.CompareHands(OnePairHand, HighCardHand));
            Assert.AreEqual(TwoPairHand, table.CompareHands(OnePairHand, TwoPairHand));

        }

        /// <summary>
        /// Test to check if 2 players could play a game
        /// </summary>
        [Test]
        public void WhoWon_TwoPairVsHighCard()
        {
            var player1 = new Player("Player 1", TwoPairHand);
            var player2 = new Player("Player 2", HighCardHand);

            table.Players.Add(player1);
            table.Players.Add(player2);

            Assert.AreEqual(player1, table.WhoWon());
        }

        /// <summary>
        /// Test to check if more than 2 players can be ranked together
        /// </summary>
        [Test]
        public void WhoWon_ThreePlayers()
        {
            var player1 = new Player("Player 1", OnePairHand);
            var player2 = new Player("Player 2", HighCardHand);
            var player3 = new Player("Player 3", TwoPairHand);

            table.Players.Add(player1);
            table.Players.Add(player2);
            table.Players.Add(player3);

            Assert.AreEqual(player3, table.WhoWon());

        }
    }
}
