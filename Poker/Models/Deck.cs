using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.Models
{
    public class Deck
    {
        
        public string Deck_Id{ get; set; }
        public Card[] Cards { get; set; }
    }

    public class DeckData
    {
        public string Id { get; set; }
        public bool Success { get; set; }
        public string Deck_Id { get; set; }
        public bool Shuffled { get; set; }
        public int Remaining { get; set; }
    }
    public class Card 
    {
        public Uri Image { get; set; }
        public string Value { get; set; }
        public string Suit { get; set; }
        

    }

}
