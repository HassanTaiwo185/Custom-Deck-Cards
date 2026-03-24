# Deck of Cards Application (C# Windows Forms)

## 📌 Overview
This project is a C# Windows Forms application that simulates a deck of playing cards. It was developed as part of the COSC 2100 – Software Development course at Durham College.

The application demonstrates object-oriented programming principles, UI/UX design practices, and collection-based data management by modeling real-world card deck behavior such as shuffling, dealing, and adding custom cards.

---

## 🎯 Features

- View full deck of cards (52 standard cards)
- Shuffle deck using randomized logic
- Deal a specified number of cards
- Add custom cards dynamically
- Input validation with user-friendly error messages
- Reset and exit functionality with keyboard and UI controls

---

## 🧠 Key Concepts Applied

- Object-Oriented Programming (OOP)
  - Inheritance (StandardDeck, CustomDeck)
  - Encapsulation (Card properties)
  - Abstraction (Deck behavior)
- Collections for managing card data
- Exception handling and input validation
- Windows Forms UI/UX best practices

---

## 🏗️ Project Structure

### Classes

- **Card.cs**
  - Represents a single card (Suit, Rank)
  - Overrides `ToString()` for display

- **Deck.cs**
  - Base class managing a collection of cards
  - Contains methods for shuffle, deal, and display

- **StandardDeck.cs**
  - Inherits from Deck
  - Initializes a standard 52-card deck

- **CustomDeck.cs**
  - Inherits from Deck
  - Allows dynamic addition of custom cards

---

## 🔄 Application Workflow

1. User interacts with UI controls (buttons, inputs)
2. Input validation ensures correctness
3. Deck operations are performed:
   - Shuffle → Randomizes deck order
   - Deal → Removes and displays selected cards
   - Add Custom → Adds new cards to deck
4. Results are displayed using ListView controls

---

## 🧪 Validation Rules

- Suit and Rank must not be empty
- Draw amount must be:
  - Greater than 0
  - Less than total cards in deck
- Errors are displayed using MessageBox

---

## 🖥️ UI/UX Features

- Centered form on launch
- Disabled maximize/minimize for controlled layout
- Keyboard accessibility (Enter, Esc, shortcuts)
- Tooltips for all interactive controls
- Logical tab navigation for usability

---

## 🛠️ Technologies Used

- C#
- .NET 6 / .NET 7
- Windows Forms
- Visual Studio

---

## 📈 What This Project Demonstrates

- Strong understanding of OOP design principles
- Ability to build structured, maintainable applications
- Experience with UI development and user interaction
- Implementation of validation and error handling
- Writing clean, modular, and documented code

---

## 👨‍💻 Author

Hassan Ayinde  
[GitHub](https://github.com/HassanTaiwo185)  
[LinkedIn](https://www.linkedin.com/in/hassan-ayinde/)
