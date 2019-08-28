using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Card
{
    public float Number { get => number; set => number = value; }
    public float Quantity { get => quantity; set => quantity = value; }
    public RarityCard Rarity { get => rarity; set => rarity = value; }

    private float number;
    private float quantity;
    private RarityCard rarity;

}
public class Deck {
    private string name;
    private float points;
    private List<Card> cards;
    public string Name { get => name; set => name = value; }
    public float Points { get => points; set => points = value; }
    public List<Card> Cards { get => cards; }
    public RarityCard RarityCard { get => rarityCard; set => rarityCard = value; }

    private RarityCard rarityCard;

    public Deck(int sizeDeck, RarityCard rariry){
        cards = new List<Card>();
        for(int i =0; i<sizeDeck; i++){
            cards.Add(new Card(){Number=i+1, Quantity = 0, Rariry = rariry});
        }
    }

    public void AddCard(Card card){
        foreach(var _c in cards){
            if(card.Number==_c.Number){
                _c.Quantity++;
            }
        }
    }

    public float GetFullDecks(){
        List<float> _quantity = new List<float>();
        foreach(var _c in cards){
            _quantity.Add(_c.Quantity);
        }
        return _quantity.Min();
    }



}


