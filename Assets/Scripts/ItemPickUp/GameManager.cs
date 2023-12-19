using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    // [SerializeField]private GameObject goldUI;
    // [SerializeField]
    private TextMeshProUGUI txt;
    // private int k = 0;
    private void Start()
    {

        txt = GetComponent<TextMeshProUGUI>();
    }

    public void Setup()
    {
        // txt = GetComponent<TextMeshProUGUI>();
    }
    

    public void ChangeGoldText(int goldCount)
    {
        if (txt)
        {
        txt.text = ": " + goldCount;
        }
        else
        {
            txt = GetComponent<TextMeshProUGUI>();
            ChangeGoldText(goldCount);
        }
    }
}
