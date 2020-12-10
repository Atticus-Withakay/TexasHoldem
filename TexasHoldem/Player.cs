using System.Collections.Generic;

namespace TexasHoldem
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }

        public Player()
        {
            this.Hand = new List<Card>();
        }

        public Player(string name, List<Card> cards)
        {
            this.Name = name;
            this.Hand = cards;
        }
    }
}