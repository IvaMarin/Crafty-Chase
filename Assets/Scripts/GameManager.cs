using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // [SerializeField]private GameObject goldUI;
    // [SerializeField]
    private TextMeshProUGUI txt;
    private int k = 0;
    private void Start()
    {

        txt = GetComponent<TextMeshProUGUI>();
        
        Debug.Log("txt in manager     " + txt);
    }
    

    public void ChangeGoldText(int goldCount)
    {
        // TextMeshProUGUI tmp = goldUI.GetComponent<TextMeshProUGUI>();
        txt.text = "Gold: " + goldCount;
    }
}
