﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Queue 
{
    static List<float> greenMission = new List<float>{3, 9, 9, 12, 12, 15};
    static List<float> blueMission = new List<float>{3, 9, 9, 12, 12, 15};
    static List<float> violMission = new List<float>{3, 9, 9, 12, 12, 15};
    static List<float> greenStore = new List<float>{15, 12, 12, 9, 9, 3};
    static List<float> blueStore = new List<float>{15, 12, 12, 9, 9, 3};
    static List<float> violStore = new List<float>{15, 12, 12, 9, 9, 3};

    private static float _totalWeight;
    public static float TotalWeight
	{
		get
		{
			if (_totalWeight == null || _totalWeight == 0){
                List<List<float>> weightsAll = new List<List<float>>{greenMission, blueMission, violMission, greenStore, blueStore, violStore};           
                                
                foreach(var _w in weightsAll){
                    if(_totalWeight == null || _totalWeight == 0){
                        _totalWeight = _w.Sum();
                    }
                    else{
                        if(_w.Sum()!=_totalWeight)
                            Debug.LogError("Sum not equal! Index of " + weightsAll.IndexOf(_w));
                    }      
                }
            }
			return _totalWeight;
		}
	}

 	public static List<List<QueueItem>> RandomQuery()
	{
		List<List<QueueItem>> _items = new List<List<QueueItem>>();
        
        _items.Add(QueueItem.GetQueuesList(greenMission, "Green Mission", RarityCard.Green, false));
        _items.Add(QueueItem.GetQueuesList(blueMission, "Blue Mission", RarityCard.Blue, false));
        _items.Add(QueueItem.GetQueuesList(violMission, "Violet Mission", RarityCard.Violet, false));
        _items.Add(QueueItem.GetQueuesList(greenStore, "Green Store", RarityCard.Green, true));
        _items.Add(QueueItem.GetQueuesList(blueStore, "Blue Store", RarityCard.Blue, true));
        _items.Add(QueueItem.GetQueuesList(violStore, "Violet Store", RarityCard.Violet, true));

        foreach(var _i in _items){
            Shuffle(_i);
        }

		return _items.Count <= 0 ? null : _items;	
	} 

    private static System.Random rng = new System.Random();  
    public static void Shuffle<QueueItem>(this List<QueueItem> list)  
    {  
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            QueueItem value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }

}
