using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int price = 1;
    [SerializeField] private CoinCounter cc;



    public void OnBuyClick()
    {
        cc.ChangeAmount(-price);
    }
}
