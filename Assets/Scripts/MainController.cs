using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    // Start is called before the first frame updat
    
    public UnityEngine.UI.Text _totalWeight;
    public UnityEngine.UI.Text TotalWeight { get => _totalWeight; set => _totalWeight = value; }
    public List<List<QueueItem>> Queues { get => queues; set => queues = value; }

    private User User;
    private List<List<QueueItem>> queues;


    void Start()
    {     
        TotalWeight.text = Queue.TotalWeight.ToString();

        queues = Queue.RandomQuery();

        User = new User(6);

        Box.CountCardMission = 1;
        Box.CountCardStore = 6;
        Box.ChanceViolet = 0.03f;
        Box.ChanceBlue = 0.1f;
        Box.ChanceGreen = 0.87f;
        
        OpenRandomMissionBox(1);

    }

    // Update is called once per frame
    void Update()
    {
    }


    void OpenRandomMissionBox(int count){

        List<Card> _cards = new List<Card>();

        for(int i=0; i<count; i++){
            _cards.Add(Box.OpenRandomBox(false, queues));
        }
        

    }

    void OpenRandomStoreBox(int count){
        List<Card> _cards = new List<Card>();

        for(int i=0; i<count; i++){
            _cards.Add(Box.OpenRandomBox(true, queues));
        }
    }


}
