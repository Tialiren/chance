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

    private static float totalWeight;

    public static float CountCardStore { get => countCardStore; set => countCardStore = value; }
    public static float CountCardMission { get => countCardMission; set => countCardMission = value; }
    public static float ChanceViolet { get => chanceViolet; set => chanceViolet = value; }
    public static float ChanceBlue { get => chanceBlue; set => chanceBlue = value; }
    public static float ChanceGreen { get => chanceGreen; set => chanceGreen = value; }
    public static float TotalWeight { get => totalWeight; set => totalWeight = value; }

    public static void OpenRandomBox(bool isStore, List<List<QueueItem>> queues, User user, bool isRandomBonus)
    {
        var _sumChance = chanceGreen+chanceBlue+chanceViolet;
        if(_sumChance > 1){
            Debug.LogError("Chance not equal 1! It is " + _sumChance);
        }

        if(queues.Count == 1){
            Box.OpenBox(isStore, queues[0], user);
            return;
        }

        
        float rnd = Random.Range(0f, 1f);

        if(rnd <= ChanceViolet){
            //фиолетовая карта
            List<QueueItem> _violetQue = queues.Where((queue, index) => queue[index].Rarity==RarityCard.Violet && queue[index].IsStore == isStore).First();
            Box.OpenBox(isStore, _violetQue, user);          
        }else{
            if(rnd <= ChanceViolet+chanceBlue){
                //синяя
                List<QueueItem> _blueQue = queues.Where((queue, index) => queue[index].Rarity==RarityCard.Blue && queue[index].IsStore == isStore).First();
                OpenBox(isStore, _blueQue, user);
            }            
            else{
                //зеленая
                List<QueueItem> _greenQue = queues.Where((queue, index) => queue[index].Rarity==RarityCard.Green && queue[index].IsStore == isStore).First();
                OpenBox(isStore, _greenQue, user);
            }               
        }
    
    }

    public static void OpenBox(bool isStore, List<QueueItem> queue, User user){
        
        RarityCard _rc = queue[0].Rarity;

        List<float> _numbers = new List<float>();
        int _inx;
        float _number;

        if(isStore){
            for(int i=0; i<CountCardStore;i++){
                _inx = queue[0].IndexQueue;
                _number = queue[_inx].CardNumber;
                _numbers.Add(_number);
                foreach(var q in queue){
                    if(q.IndexQueue + 1 < totalWeight){
                        q.IndexQueue++;
                    }else{
                        q.IndexQueue = 0;
                    }
                }
            }
        }else{
            for(int i=0; i<CountCardMission;i++){
                _inx = queue[0].IndexQueue;
                _number = queue[_inx].CardNumber;
                _numbers.Add(_number);
                foreach(var q in queue){
                    if(q.IndexQueue + 1 < totalWeight){
                        q.IndexQueue++;
                    }else{
                        q.IndexQueue = 0;
                    }
                }
            }
        }
        
        
        foreach(var d in user.Decks){
            if(d.RarityCard == _rc){
                foreach(var _n in _numbers){
                    Card card = new Card();
                    card.Quantity = 1;
                    card.Rarity = _rc;
                    card.Number = _n;
                    d.AddCard(card);
                }
               
            }
        }
 
    }


}
