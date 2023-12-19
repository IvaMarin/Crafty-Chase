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
        // Debug.Log(txt);
        ChangeGoldText(PlayerPrefs.GetInt("Gold"));
    }

    public void Setup()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }
    

    public void ChangeGoldText(int goldCount)
    {
        // haha this so evil recursion ^_^

        if (txt)
        {
        txt.text = ": " + goldCount;
        }
        else
        {
            Debug.Log("FUCKING NULL");
            txt = GetComponent<TextMeshProUGUI>();
            txt.text = ": " + goldCount;
        }
    }
}
