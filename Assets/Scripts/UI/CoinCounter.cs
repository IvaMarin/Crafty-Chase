using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    // Start is called before the first frame update
    private int gold;
    private TextMeshProUGUI txt;
    void Start()
    {
        gold = PlayerPrefs.GetInt("Gold");
        PlayerPrefs.SetInt("Gold", gold);
        txt = GetComponent<TextMeshProUGUI>();
        txt.SetText(": "+ gold);
    }

    

    public void ChangeAmount(int delta)
    {
        gold = PlayerPrefs.GetInt("Gold") + delta;
        PlayerPrefs.SetInt("Gold", gold);
        txt.SetText(": "+gold);
        
    }
}
