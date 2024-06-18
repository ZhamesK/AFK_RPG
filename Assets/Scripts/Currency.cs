using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    public int gold;

    public TextMeshProUGUI goldText;

    // Start is called before the first frame update
    void Start()
    {
        gold = 5000;
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = gold.ToString();
    }

    public void Buy(int price)
    {
        if(gold < price)
        {
            return;
        }
        gold -= price;
    }

    public void Sell(int price)
    {
        gold += price;
    }
}
