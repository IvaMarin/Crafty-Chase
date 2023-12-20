using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int price = 1;
    [SerializeField] private CoinCounter cc;

    [SerializeField] private string abilityName;
    [SerializeField] private int percent=5;

    public void OnBuyClick()
    {
        if (cc.GetAmount() > price)
        {
            string key = abilityName + "Coef";
            Debug.Log(key); 
            PlayerPrefs.SetFloat(key, PlayerPrefs.GetFloat(key) *(1f + (float)percent / 100f));
            cc.ChangeAmount(-price);
        }
    }
}
