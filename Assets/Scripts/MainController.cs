using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainController : MonoBehaviour
{
    // Start is called before the first frame updat
    
    public UnityEngine.UI.Text _totalWeight;
    public List<List<QueueItem>> Queues { get => queues; set => queues = value; }

    private User User;
    private List<List<QueueItem>> queues;

    public UnityEngine.UI.Text _greenCount;
    public UnityEngine.UI.Text _blueCount;
    public UnityEngine.UI.Text _violetCount;

    public UnityEngine.UI.Text green1;
    public UnityEngine.UI.Text green2;
    public UnityEngine.UI.Text green3;
    public UnityEngine.UI.Text green4;
    public UnityEngine.UI.Text green5;
    public UnityEngine.UI.Text green6;

    public UnityEngine.UI.Text blue1;
    public UnityEngine.UI.Text blue2;
    public UnityEngine.UI.Text blue3;
    public UnityEngine.UI.Text blue4;
    public UnityEngine.UI.Text blue5;
    public UnityEngine.UI.Text blue6;

    public UnityEngine.UI.Text violet1;
    public UnityEngine.UI.Text violet2;
    public UnityEngine.UI.Text violet3;
    public UnityEngine.UI.Text violet4;
    public UnityEngine.UI.Text violet5;
    public UnityEngine.UI.Text violet6;

    public UnityEngine.UI.Text boxMission;
    public UnityEngine.UI.Text boxStore;

    private int countMission;
    private int countStore;

    void Start()
    {     
        _totalWeight.text = Queue.TotalWeight.ToString();

        queues = Queue.RandomQuery();

        User = new User(6);

        Box.CountCardMission = 1;
        Box.CountCardStore = 6;
        Box.ChanceViolet = 0.03f;
        Box.ChanceBlue = 0.1f;
        Box.ChanceGreen = 0.87f;
        Box.TotalWeight = Queue.TotalWeight;
        
    }

    // Update is called once per frame
    void Update()
    {
        _greenCount.text = User.Decks[0].GetFullDecks().ToString();
        _blueCount.text = User.Decks[1].GetFullDecks().ToString();
        _violetCount.text = User.Decks[2].GetFullDecks().ToString();

        green1.text = User.Decks[0].Cards[0].Quantity.ToString();
        green2.text = User.Decks[0].Cards[1].Quantity.ToString();
        green3.text = User.Decks[0].Cards[2].Quantity.ToString();
        green4.text = User.Decks[0].Cards[3].Quantity.ToString();
        green5.text = User.Decks[0].Cards[4].Quantity.ToString();
        green6.text = User.Decks[0].Cards[5].Quantity.ToString();
        blue1.text = User.Decks[1].Cards[0].Quantity.ToString();
        blue2.text = User.Decks[1].Cards[1].Quantity.ToString();
        blue3.text = User.Decks[1].Cards[2].Quantity.ToString();
        blue4.text = User.Decks[1].Cards[3].Quantity.ToString();
        blue5.text = User.Decks[1].Cards[4].Quantity.ToString();
        blue6.text = User.Decks[1].Cards[5].Quantity.ToString();
        violet1.text = User.Decks[2].Cards[0].Quantity.ToString();
        violet2.text = User.Decks[2].Cards[1].Quantity.ToString();
        violet3.text = User.Decks[2].Cards[2].Quantity.ToString();
        violet4.text = User.Decks[2].Cards[3].Quantity.ToString();
        violet5.text = User.Decks[2].Cards[4].Quantity.ToString();
        violet6.text = User.Decks[2].Cards[5].Quantity.ToString();

    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenRandomMissionBox(int count){
        for(int i=0; i<count; i++){
            Box.OpenRandomBox(false, queues, User);
            countMission++;
            boxMission.text = countMission.ToString();

        }
    }

    public void OpenRandomStoreBox(int count){
        for(int i=0; i<count; i++){
            Box.OpenRandomBox(true, queues, User);
            countStore++;
            boxStore.text = countStore.ToString();
        }
    }

    public void OpenGreenStoreBox(int count){
        for(int i=0; i<count; i++){
            List<List<QueueItem>> _q = new List<List<QueueItem>>();
            _q.Add(queues[3]);
            Box.OpenRandomBox(true, _q, User);
            countStore++;
            boxStore.text = countStore.ToString();
        }
    }

    public void OpenBlueStoreBox(int count){
        for(int i=0; i<count; i++){
            List<List<QueueItem>> _q = new List<List<QueueItem>>();
            _q.Add(queues[4]);
            Box.OpenRandomBox(true, _q, User);
            countStore++;
            boxStore.text = countStore.ToString();
        }
    }

    public void OpenVioletStoreBox(int count){
        for(int i=0; i<count; i++){
            List<List<QueueItem>> _q = new List<List<QueueItem>>();
            _q.Add(queues[5]);
            Box.OpenRandomBox(true, _q, User);
            countStore++;
            boxStore.text = countStore.ToString();
        }
    }


}
