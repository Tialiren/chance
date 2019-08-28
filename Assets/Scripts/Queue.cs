using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Queue 
{
    static List<float> greenMission = new List<float>{1, 3, 4, 5, 5, 5};
    static List<float> blueMission = new List<float> {1, 3, 4, 5, 5, 5};
    static List<float> violMission = new List<float> {1, 3, 4, 5, 5, 5};
    static List<float> greenStore = new List<float> {1, 3, 4, 5, 5, 5};
    static List<float> blueStore = new List<float> {1, 3, 4, 5, 5, 5};
    static List<float> violStore = new List<float> {1, 3, 4, 5, 5, 5};

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
    
        _items.Add(QueueItem.GetQueuesList(greenMission, "Green Mission", false));
        _items.Add(QueueItem.GetQueuesList(blueMission, "Blue Mission", false));
        _items.Add(QueueItem.GetQueuesList(violMission, "Violet Mission", false));
        _items.Add(QueueItem.GetQueuesList(greenStore, "Green Store", true));
        _items.Add(QueueItem.GetQueuesList(blueStore, "Blue Store", true));
        _items.Add(QueueItem.GetQueuesList(violStore, "Violet Store", true));

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
