/// Name: Hassan Ayinde
/// Date created: 11th of november, 2025
/// Date last modified: 13th of november,2025
/// Description: This is a Custom deck  class that inherint deck class and add custom deck of cards to 
/// card list based on user input
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class CustomDeck : Deck
    {
        public CustomDeck() 
        {
            // Empty deck of cards
            cards.Clear(); 
        }

        

        // Add a customize card to our deck of cards
        public void AddCustomCard(string suit, string rank)
        {
            // Check if our deck of cards is not more than 52
            if (cards.Count > 52)
            {
                throw new InvalidOperationException("Deck cannot be more than 52 cards.");
            }
                
            // Add customize cards to card list
            cards.Add(new Card(suit, rank));


        }
    }
}
