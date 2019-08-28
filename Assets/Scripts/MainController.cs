using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    // Start is called before the first frame updat
    
    public UnityEngine.UI.Text _totalWeight;
    public UnityEngine.UI.Text TotalWeight { get => _totalWeight; set => _totalWeight = value; }

    void Start()
    {     

        TotalWeight.text = Queue.TotalWeight.ToString();
        var queue = Queue.RandomQuery();
    }

    // Update is called once per frame
    void Update()
    {
    }


    
}
