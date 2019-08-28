using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueItem 
{
    public float CardNumber;
    public float CardWeight;
    public string QueueName; 
    public bool IsStore;

    public QueueItem(float number, float weight, string name, bool isStore){
        CardNumber = number;
        CardWeight = weight;
        QueueName = name;
        IsStore = isStore;
    }

    public static List<QueueItem> GetQueuesList(List<float> weights, string name, bool isStore){
        List<QueueItem> _queues = new List<QueueItem>();
        int _number = 1;
        
        foreach(var _w in weights){
            for(int i=0; i<_w; i++){
                _queues.Add(new QueueItem(_number, _w, name, isStore));
            }
            _number++;
        }
        
        return _queues;
    }

}
