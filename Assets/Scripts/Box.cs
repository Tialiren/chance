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

public class Box 
{
    private float chanceGreen;
    private float chanceBlue;
    private float chanceViolet;

    private float countCardMission;
    private float countCardStore;

    public float CountCardStore { get => countCardStore; set => countCardStore = value; }
    public float CountCardMission { get => countCardMission; set => countCardMission = value; }
    public float ChanceViolet { get => chanceViolet; set => chanceViolet = value; }
    public float ChanceBlue { get => chanceBlue; set => chanceBlue = value; }
    public float ChanceGreen { get => chanceGreen; set => chanceGreen = value; }

    public Card OpenRandomBox(bool isStore, int indexQueue, List<List<QueueItem>> queues){
        var _sumChance = chanceGreen+chanceBlue+chanceViolet;
        if(_sumChance > 1){
            Debug.LogError("Chance not equal 1! It is " + _sumChance);
        }

        float rnd = Random.Range(0f, 1f);

        if(rnd <= ChanceViolet){
            //фиолетовая карта
            List<QueueItem> _violetQue = queues.Select((queues, index) => new { index, q = queues.r })          
            
        }else{
            if(rnd <= ChanceViolet+chanceBlue){
                //синяя
            


            }            
            else{
                //зеленая



            }               
        }


    }

    public Card OpenGreenBox(bool isStore, int indexQueue, List<QueueItem> queue){

    }

    public Card OpenBlueBox(bool isStore, int indexQueue, List<QueueItem> queue){

    }

    public Card OpenVioletBox(bool isStore, int indexQueue, List<QueueItem> queue){

    }


}
