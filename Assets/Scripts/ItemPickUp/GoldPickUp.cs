using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
     private int gold = 0;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        gold = PlayerPrefs.GetInt("Gold");
        // Debug.Log("awake gp");
    }
    
    private void Start() {
        // Debug.Log("gamemanager " + gameManager);
        // Debug.Log("start gold " + gold);
        gameManager.Setup();
        gameManager.ChangeGoldText(gold);
    }
    
    public void Collect(int value)
    {

        gold += value;
        PlayerPrefs.SetInt("Gold", gold);
        // Debug.Log("set   "+gold);
        gameManager.ChangeGoldText(gold);
        // GameObject o;
        // (o = col.gameObject).SetActive(false);
        // Destroy(o);
    }
    
    
}
