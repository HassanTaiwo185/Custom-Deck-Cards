/// Name: Hassan Ayinde
/// Date created: 11th of november, 2025
/// Date last modified: 13th of november,2025
/// Description: This is a Standard deck  class that inherint deck class and overide InitialiseDeckOfCard() method to 
/// initialize the deck with standard playing cards.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class StandardDeck:Deck
    {
        /// <summary>
        /// This method initialize the deck with standard playing cards.
        /// </summary>
        public override void InitialiseDeckOfCard()
        {
            cards.Clear();
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            // Iterate through arrays of suits
            foreach (string suit in suits)
            {
                // Itearte through arrays of ranks and add to list of card
                foreach (string rank in ranks)
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }
    }
}
