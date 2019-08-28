using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Card OpenBox(bool isStore, int indexQueue, List<QueueItem> queue){

    }



}
