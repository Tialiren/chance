using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueItem 
{
    private float cardNumber;
    private float cardWeight;
    private string queueName;
    private bool isStore;
    private RarityCard rarity;

    public float CardNumber { get => cardNumber; set => cardNumber = value; }
    public float CardWeight { get => cardWeight; set => cardWeight = value; }
    public string QueueName { get => queueName; set => queueName = value; }
    public bool IsStore { get => isStore; set => isStore = value; }
    public RarityCard Rarity { get => rarity; set => rarity = value; }

    public QueueItem(float number, float weight, string name, RarityCard rarity, bool isStore){
        CardNumber = number;
        CardWeight = weight;
        QueueName = name;
        IsStore = isStore;
        Rarity = rarity;
    }

    public static List<QueueItem> GetQueuesList(List<float> weights, string name, RarityCard rarity, bool isStore){
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
