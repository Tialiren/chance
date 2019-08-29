using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum RarityCard
{
    Green = 0,
    Blue = 1,
    Violet = 2
}

public static class Box 
{
    private static float chanceGreen;
    private static float chanceBlue;
    private static float chanceViolet;

    private static float countCardMission;
    private static float countCardStore;

    public static float CountCardStore { get => countCardStore; set => countCardStore = value; }
    public static float CountCardMission { get => countCardMission; set => countCardMission = value; }
    public static float ChanceViolet { get => chanceViolet; set => chanceViolet = value; }
    public static float ChanceBlue { get => chanceBlue; set => chanceBlue = value; }
    public static float ChanceGreen { get => chanceGreen; set => chanceGreen = value; }

    public static Card OpenRandomBox(bool isStore, List<List<QueueItem>> queues){
        var _sumChance = chanceGreen+chanceBlue+chanceViolet;
        if(_sumChance > 1){
            Debug.LogError("Chance not equal 1! It is " + _sumChance);
        }

        Card cardOpened = new Card();
        float rnd = Random.Range(0f, 1f);

        if(rnd <= ChanceViolet){
            //фиолетовая карта
            List<QueueItem> _violetQue = queues.Where((queue, index) => queue[index].Rarity==RarityCard.Violet && queue[index].IsStore == isStore).First();
            cardOpened = Box.OpenVioletBox(isStore, _violetQue);          
        }else{
            if(rnd <= ChanceViolet+chanceBlue){
                //синяя
                List<QueueItem> _blueQue = queues.Where((queue, index) => queue[index].Rarity==RarityCard.Blue && queue[index].IsStore == isStore).First();
                cardOpened = OpenBlueBox(isStore, _blueQue);
            }            
            else{
                //зеленая
                List<QueueItem> _greenQue = queues.Where((queue, index) => queue[index].Rarity==RarityCard.Green && queue[index].IsStore == isStore).First();
                cardOpened = OpenGreenBox(isStore, _greenQue);
            }               
        }
    return cardOpened;
    }

    public static Card OpenGreenBox(bool isStore, List<QueueItem> queue){
        Card cardOpened = new Card();




        return cardOpened;
    }

    public static Card OpenBlueBox(bool isStore, List<QueueItem> queue){
        Card cardOpened = new Card();
        return cardOpened;
    }

    public static Card OpenVioletBox(bool isStore, List<QueueItem> queue){
        Card cardOpened = new Card();
        return cardOpened;
    }


}
