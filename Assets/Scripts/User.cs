using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User {

    private static List<Deck> decks;

    public User(int deckSize){
        decks = new List<Deck>();
        Deck greenDeck = new Deck(deckSize, RarityCard.Green, 150, "Green");
        Deck blueDeck = new Deck(deckSize, RarityCard.Blue, 2200, "Blue");
        Deck violetDeck = new Deck(deckSize, RarityCard.Violet, 17000, "Violet");
        decks.Add(greenDeck);
        decks.Add(blueDeck);
        decks.Add(violetDeck);
    }

    public static List<Deck> Decks { get => decks; }
}
