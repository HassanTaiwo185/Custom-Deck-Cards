/// Name: Hassan Ayinde
/// Date created: 11th of november, 2025
/// Date last modified: 13th of november,2025
/// Description: This is Card class that instantiated suit and rank properties , parameter constructor to give values to these 
/// properties and over ride string method to show our card details.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Card
    {
        // properties
        private string suit;
        private string rank;


        // Getter and setter
        public string Suit
        {
            get { return suit; }
            private set { suit = value; }
        }

        public string Rank
        {
            get { return rank; }
            private set { rank = value; }
        }


        // Parameter constructor
        public Card(string suit, string rank)
        { 
            this.Suit = suit;
            this.Rank = rank;
        }

        // Diplay card information
        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}
