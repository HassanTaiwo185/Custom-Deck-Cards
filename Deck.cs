/// Name: Hassan Ayinde
/// Date created: 11th of november, 2025
/// Date last modified: 13th of november,2025
/// Description: This is deck  class that  that manage collection of cards , initialise it with a 52 demo cards
/// returns the cards in our list, shuffle deck of cards and draw number of cards based on user input.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    internal class Deck
    {
        // Manage the  collection of cards
        protected List<Card> cards;
        private Random random = new Random();

        // Initialize empty list
        public Deck()
        {
            cards = new List<Card>();
        }

        /// <summary>
        /// This method Initialize the deck with a full set of 52 cards.
        /// </summary>
        public virtual void InitialiseDeckOfCard()
        {
            cards.Clear();

            for (int i = 0; i < 52; i++)
            {
                cards.Add(new Card("Demo card", $"Card{i}"));
            }
        }


        /// <summary>
        /// This method returns the cards in our deck
        /// </summary>
        /// <returns></returns>
        public List<Card> GetCards() 
        {
            return cards;
        }


        /// <summary>
        /// This method generate random number between 1 and  1000000
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private int GenerateRandomKey(Card x)
        {
            return random.Next(1, 1000000);
        }

        /// <summary>
        /// This method Will randomise the deck of cards.
        /// </summary>
        public void ShuffleDeck()
        {
            // A dictionary to store each card based on keys
            Dictionary<int, Card> shuffledCards = new Dictionary<int, Card>();

            // Iterate through each card and assign a key value and add to dictionary
            foreach (Card card in cards)
            {
                int key = GenerateRandomKey(card);

                // Make sure key is unique 
                while (shuffledCards.ContainsKey(key))
                {
                    // Get a NEW random key
                    key = GenerateRandomKey(card); 
                }

                shuffledCards.Add(key, card); 
            }

            // Create list of the cards key and sorted it
            List<int> sortedKeys = new List<int>(shuffledCards.Keys);
            sortedKeys.Sort();

            // Clear the list of card
            cards.Clear();

            // Iterate through the list of now sorted keys and use the key to add to cards to list as index number
            foreach (int key in sortedKeys)
            {
                cards.Add(shuffledCards[key]); 
            }

        }

        /// <summary>
        /// This method will pull number of cards from the deck based on user input
        /// </summary>
        /// <param name="numberOfCards"></param>
        /// <returns></returns>
        public List<Card> DealCards(int numberOfCards) 
        {
            // A list that contains deal number of cards
            List<Card> dealtCards = new List<Card>();

            // Check if number entered by user is not more than our cards count or less than 0
            if (numberOfCards > cards.Count || numberOfCards < 0)
            {
                return new List<Card>();
            }

            // Iterate to add number of cards to the list of dealtcards
            for (int i = 0; i < numberOfCards; i++)
            {
                dealtCards.Add(cards[i]);
            }

            // Remove dealt cards from the deck deck
            cards.RemoveRange(0, numberOfCards);
            return dealtCards;
        }

        /// <summary>
        /// This method the number of cards in our deck of card
        /// </summary>
        public int Count
        {
            get { return cards.Count; }
        }
    }
}
