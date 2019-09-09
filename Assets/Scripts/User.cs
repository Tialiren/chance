using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User {

    private  List<Deck> decks;

    private int countGreen;
    private int countBlue;
    private int countViolet;

    public User(int deckSize){
        decks = new List<Deck>();
        Deck greenDeck = new Deck(deckSize, RarityCard.Green, 150, "Green");
        Deck blueDeck = new Deck(deckSize, RarityCard.Blue, 2200, "Blue");
        Deck violetDeck = new Deck(deckSize, RarityCard.Violet, 17000, "Violet");
        decks.Add(greenDeck);
        decks.Add(blueDeck);
        decks.Add(violetDeck);
      
    }

    public List<Deck> Decks { get => decks; }
    public int CountViolet { get => countViolet; set => countViolet = value; }
    public int CountBlue { get => countBlue; set => countBlue = value; }
    public int CountGreen { get => countGreen; set => countGreen = value; }
}
