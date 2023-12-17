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
        txt = GetComponent<TextMeshProUGUI>();
        Debug.Log(txt);
        txt.text = ":" + gold;
        Debug.Log("gold "+gold);
    }

    // Update is called once per frame
    public void ChangeAmount(int delta)
    {
        PlayerPrefs.SetInt("Gold", gold + delta);
        txt.text = ":" + gold;
    }
}
