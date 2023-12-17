using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
    [SerializeField] private int gold = 0;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        gold = PlayerPrefs.GetInt("Gold");
    }
    
    private void Start() {
        gameManager.ChangeGoldText(gold);
    }
    
    public void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("Gold")) return;
        gold += 1;
        PlayerPrefs.SetInt("Gold", gold);
        gameManager.ChangeGoldText(gold);
        GameObject o;
        (o = col.gameObject).SetActive(false);
        Destroy(o);
    }
    
    
}
