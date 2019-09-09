using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class MainController : MonoBehaviour
{
    // Start is called before the first frame updat
    
    public UnityEngine.UI.Text _totalWeight;
    public List<List<QueueItem>> Queues { get => queues; set => queues = value; }

    private User User;
    private List<List<QueueItem>> queues;

    public UnityEngine.UI.InputField _countBox;

    public UnityEngine.UI.Text _greenCount;
    public UnityEngine.UI.Text _greenPlus;
    public UnityEngine.UI.Text _blueCount;
    public UnityEngine.UI.Text _violetCount;

    public UnityEngine.UI.Text green1;
    public UnityEngine.UI.Text green2;
    public UnityEngine.UI.Text green3;
    public UnityEngine.UI.Text green4;
    public UnityEngine.UI.Text green5;
    public UnityEngine.UI.Text green6;


    public UnityEngine.UI.Text green1_rest;
    public UnityEngine.UI.Text green2_rest;
    public UnityEngine.UI.Text green3_rest;
    public UnityEngine.UI.Text green4_rest;
    public UnityEngine.UI.Text green5_rest;
    public UnityEngine.UI.Text green6_rest;

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
    public UnityEngine.UI.Text boxStoreOne;

    public UnityEngine.UI.Toggle IsRandomBonus;

    private int countMission;
    private int countStore;
    private int countStoreOne;

    private float countIntGreen;
    private float countIntBlue;
    private float countIntViolet;

    public UnityEngine.UI.InputField chanceGreen;
    public UnityEngine.UI.InputField chanceBlue;
    public UnityEngine.UI.InputField chanceViolet;

    void Start()
    {
        _totalWeight.text = Queue.TotalWeight.ToString();

        queues = Queue.RandomQuery();

        User = new User(6);
        
        Box.CountCardMission = 1;
        Box.CountCardStore = 6;
        Box.ChanceViolet = float.Parse(chanceViolet.text);
        Box.ChanceBlue =float.Parse(chanceBlue.text);
        Box.ChanceGreen = float.Parse(chanceGreen.text);
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

    public void UpdateChances(){
        Box.ChanceViolet = float.Parse(chanceViolet.text);
        Box.ChanceBlue =float.Parse(chanceBlue.text);
        Box.ChanceGreen = float.Parse(chanceGreen.text);
    }

    public void OnRestartClick(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateCards(){
        var _countGreen = User.Decks[0].GetFullDecks();
        var _countBlue = User.Decks[1].GetFullDecks();
        var _countViolet = User.Decks[2].GetFullDecks();

        if(_countGreen != countIntGreen){
            _greenCount.text = _countGreen.ToString();
            _greenPlus.text = "+" + (_countGreen-countIntGreen).ToString();
            countIntGreen = _countGreen;
        }else{
            _greenPlus.text = "";
        }

        green1_rest.text = (User.Decks[0].Cards[0].Quantity - countIntGreen).ToString();
        green2_rest.text = (User.Decks[0].Cards[1].Quantity - countIntGreen).ToString();
        green3_rest.text = (User.Decks[0].Cards[2].Quantity - countIntGreen).ToString();
        green4_rest.text = (User.Decks[0].Cards[3].Quantity - countIntGreen).ToString();
        green5_rest.text = (User.Decks[0].Cards[4].Quantity - countIntGreen).ToString();
        green6_rest.text = (User.Decks[0].Cards[5].Quantity - countIntGreen).ToString();

    }

    public void OpenRandomMissionBox(int count){
        if (count == 0)
        {
            count = Convert.ToInt32(_countBox.text);
        }
        
        for (int i=0; i<count; i++){
            Box.OpenRandomBox(false, queues, User, IsRandomBonus);
            countMission++;
            boxMission.text = countMission.ToString();
        }
        UpdateCards();
    }

    public void OpenRandomStoreBox(bool isOne){
        var count = Convert.ToInt32(_countBox.text);

        if(isOne){
            Box.CountCardStore = 1;
        }    

        for (int i=0; i<count; i++){
            Box.OpenRandomBox(true, queues, User, IsRandomBonus);
            if(isOne){
                countStoreOne++;
                boxStoreOne.text = countStoreOne.ToString();
            }else{
                countStore++;
                boxStore.text = countStore.ToString();
            }
            
        }
        Box.CountCardStore = 6;
        UpdateCards();
    }

    public void OpenGreenStoreBox(int count){
        if (count == 0)
        {
            count = Convert.ToInt32(_countBox.text);
        }
        for (int i=0; i<count; i++){
            List<List<QueueItem>> _q = new List<List<QueueItem>>();
            _q.Add(queues[3]);
            Box.OpenRandomBox(true, _q, User, IsRandomBonus);
            countStore++;
            boxStore.text = countStore.ToString();
        }
        UpdateCards();
    }

    public void OpenBlueStoreBox(int count){
        if (count == 0)
        {
            count = Convert.ToInt32(_countBox.text);
        }
        for (int i=0; i<count; i++){
            List<List<QueueItem>> _q = new List<List<QueueItem>>();
            _q.Add(queues[4]);
            Box.OpenRandomBox(true, _q, User, IsRandomBonus);
            countStore++;
            boxStore.text = countStore.ToString();
        }
        UpdateCards();
    }

    public void OpenVioletStoreBox(int count){
        if (count ==0)
        {
            count = Convert.ToInt32(_countBox.text);
        }
        for (int i=0; i<count; i++){
            List<List<QueueItem>> _q = new List<List<QueueItem>>();
            _q.Add(queues[5]);
            Box.OpenRandomBox(true, _q, User, IsRandomBonus);
            countStore++;
            boxStore.text = countStore.ToString();
        }
        UpdateCards();
    }

    public void SaveResult(){
        string path = @"\BoxOpened.txt";
        string line = "";
        string text;
        line += "Коробков стора: " + boxStore.text + " Коробков миссий: " + boxMission.text + " Зеленых: " + _greenCount.text + " Синих: " + _blueCount.text + " Фиолетовых: " + _violetCount.text;
        using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
        {
            sw.WriteLine(line);
        }
    }


}
