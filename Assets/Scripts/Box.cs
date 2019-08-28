using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Card OpenRandomBox(bool isStore, int indexQueue, List<QueueItem> queue){

    }

    public Card OpenGreenBox(bool isStore, int indexQueue, List<QueueItem> queue){

    }

    public Card OpenBlueBox(bool isStore, int indexQueue, List<QueueItem> queue){

    }

    public Card OpenVioletBox(bool isStore, int indexQueue, List<QueueItem> queue){

    }


}
