/// Name: Hassan Ayinde
/// Date created: 11th of november, 2025
/// Date last modified: 13th of november,2025
/// Description: This is a simple wpf application that instantiated the application with 52 stanadard card, user get to add their
/// custom cards to make custom deck of cards. User can draw cards from this standard or custom deck of cards based on their input 
///, view custom or standard deck of cards, shuffle the deck of cards, reset the program and exit the program.



using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Card> displayedCards = new ObservableCollection<Card>();
        private ObservableCollection<Card> displayedDealtCards = new ObservableCollection<Card>();

        private StandardDeck standardDeck;
        private CustomDeck customDeck;

        private bool customDeckCreated = false;
        public MainWindow()
        {
            InitializeComponent();

            // Focus cursor on suit inputs
            txtSuit.Focus();

            // Deck ListView is bind to our observable collection
            lvDeck.ItemsSource = displayedCards;
            lvCardsDealt.ItemsSource = displayedDealtCards;

            // Initialize standard decks
            standardDeck = new StandardDeck(); 
            standardDeck.InitialiseDeckOfCard();

            // Initialize custom decks
            customDeck = new CustomDeck();
        }




        /// <summary>
        /// This method validates user input, add custom cards and display it 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCard_Click(object sender, RoutedEventArgs e)
        {
            // Trim text boxes
            string suit = txtSuit.Text.Trim();
            string rank = txtRank.Text.Trim();

            if (ValidateAddInputs(suit, rank))
            {
                try
                {
                    // create custom cards
                    customDeck.AddCustomCard(suit, rank);
                    customDeckCreated = true;


                    // Show custom deck in ListView
                    displayedCards.Clear();
                    foreach (Card card in customDeck.GetCards())
                    {
                        displayedCards.Add(card);
                    }

                    // Clear inputs
                    txtSuit.Clear();
                    txtRank.Clear();

                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }


        /// <summary>
        /// This method display whatever deck of cards is active either custom cards or standard cards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewDeck_Click(object sender, RoutedEventArgs e)
        {
            displayedCards.Clear();

            // If custom deck already created 
            if (customDeckCreated)
            {
                // check if custom cards is now empty
                if (customDeck.GetCards().Count == 0)
                {
                    MessageBox.Show("Custom deck is now empty , reset to standard deck or add more custom cards.");
                    return;
                }

                // iterate through cards and display it
                foreach (var card in customDeck.GetCards())
                {
                    displayedCards.Add(card);
                }
                    
            }
            else
            {

                // Check if standard card is not empty
                if (standardDeck.GetCards().Count == 0)
                {
                    MessageBox.Show("Standard deck is empty, please reset or add  custom cards.");
                    return;
                }

                foreach (var card in standardDeck.GetCards())
                {
                    displayedCards.Add(card);
                }
                    
            }
        }


        /// <summary>
        /// This method shuffle deck of cards based on the cards that is active either custom cards or standard cards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShuffleCards_Click(object sender, RoutedEventArgs e)
        {
            // If custom deck  already 
            if (customDeckCreated)
            {

                // check if custom cards is now empty
                if (customDeck.GetCards().Count == 0)
                {
                    MessageBox.Show("Custom deck is now empty , reset to standard deck or add more custom cards.");
                    return;
                }

                // shuffle custom deck and clear our deck view
                customDeck.ShuffleDeck();
                displayedCards.Clear();

                // Iterate through our shuffled custom deck cards and display it
                foreach (var card in customDeck.GetCards())
                    displayedCards.Add(card);
            }
            else
            {
                // Check if standard card is not empty
                if (standardDeck.GetCards().Count == 0)
                {
                    MessageBox.Show("Standard deck is empty, please reset or add  custom cards.");
                    return;
                }

                // shuffle standard deck and clear our deck view
                standardDeck.ShuffleDeck();

                // Iterate through our shuffled standard deck cards and display it
                displayedCards.Clear();
                foreach (var card in standardDeck.GetCards())
                    displayedCards.Add(card);
            }

            
        }

        /// <summary>
        /// This method validates user input draw number deck of cards  cards based on the inputs and check if inputs is not more
        /// than the active deck of cards (custom or standard deck of cards), display drawn cards in cards dealt , refresh deck of cards
        /// and display it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DealCard_Click(object sender, RoutedEventArgs e)
        {
            string deal = txtDeal.Text.Trim();

            // Vakidate user input
            if (ValidateDealInputs(deal))
            {
                try
                {
                    // If custom deck  already created  draw from it
                    if (customDeckCreated)
                    {
                        // convert user inputs to integer
                        int drawNumber = Convert.ToInt32(txtDeal.Text);

                        // check if custom cards is now empty
                        if (customDeck.GetCards().Count == 0)
                        {
                            MessageBox.Show("Custom deck is now empty , reset to standard deck or add more custom.");
                            return;
                        }

                        // Check if user input is less than or equal to number of custom deck of cards
                        if (drawNumber <= customDeck.GetCards().Count)
                        {
                            // Draw number of custom deck of cards based on user input
                            var dealtCards = customDeck.DealCards(drawNumber);

                            // Clear  dealt cards
                            displayedDealtCards.Clear();

                            // Iterate through dealt cards anddisplay it
                            foreach (var card in dealtCards)
                            {
                                displayedDealtCards.Add(card);
                            }

                            // Refresh remaining deck
                            displayedCards.Clear();
                            foreach (var card in customDeck.GetCards())
                            {
                                displayedCards.Add(card);

                            }
                                

                        }
                        else
                        {
                            MessageBox.Show("Custom deck do not have enough cards to deal with that.");
                        }
                    }
                    else
                    {
                        // convert user inpits to integer
                        int drawNumber = Convert.ToInt32(txtDeal.Text);

                        // Check if standard card is not empty
                        if (standardDeck.GetCards().Count == 0)
                        {
                            MessageBox.Show("Standard deck is empty, please reset add  custom cards.");
                            return;
                        }

                        // Check if user input is less than or equal to number of available deck of cards
                        if (drawNumber <= standardDeck.GetCards().Count)
                        {
                            // Draw number of stsandard deck cards based on user input
                            var dealt = standardDeck.DealCards(drawNumber);


                            // Clear  dealt cards
                            displayedDealtCards.Clear();

                            // Iterate through dealt cards anddisplay it
                            foreach (var card in dealt)
                            {
                                displayedDealtCards.Add(card);
                            }

                            // Refresh remaining deck
                            displayedCards.Clear();
                            foreach (var card in standardDeck.GetCards())
                            {
                                displayedCards.Add(card);
                            }
                                

                        }
                        else
                        {
                            MessageBox.Show("Standard deck do not have enough cards to deal with that.");
                        }
                    }

                    txtDeal.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }


        /// <summary>
        /// This methods rest the program by delting all text inputs and initialised standard cards again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear all text boxes and list view
            txtSuit.Clear();
            txtRank.Clear();
            txtDeal.Clear();
            displayedCards.Clear();
            displayedDealtCards.Clear();

            // Reset both decks
            standardDeck = new StandardDeck();
            standardDeck.InitialiseDeckOfCard();
            customDeck = new CustomDeck();

            customDeckCreated = false;
        }

        /// <summary>
        /// This method rest the program and closes it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            ResetButton_Click((object) sender, e);
            this.Close();
        }

        /// <summary>
        /// This method validates deal inputs if empty and between acceptable range
        /// </summary>
        /// <param name="dealText"></param>
        /// <returns></returns>
        private bool ValidateDealInputs(string dealText)
        {
            // check if deal is not empty
            if (string.IsNullOrWhiteSpace(dealText))
            {
                MessageBox.Show("Please enter a number of cards to deal with.");
                txtDeal.Focus();
                return false;
            }

            // check if its an integer and not less than zero or greater than 52
            if (!int.TryParse(dealText, out int deal) || deal <= 0 || deal > 52)
            {
                MessageBox.Show("Please enter a valid number between 1 and 52.");
                txtDeal.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// This method validate suit and rank inputs if they are not empty
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        private Boolean ValidateAddInputs(String suit, String rank)
        {
            // Validate if suit is empty
            if (string.IsNullOrWhiteSpace(suit))
            {
                MessageBox.Show("Suit cannot be empty!");
                txtSuit.Focus();
                return false;
            }

            // Validate if rank is empty
            if (string.IsNullOrWhiteSpace(rank))
            {
                MessageBox.Show("Rank cannot be empty");
                txtRank.Focus();
                return false;
            }


            return true;

        }
    }
}