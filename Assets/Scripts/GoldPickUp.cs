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
        if (col.gameObject.tag == "Gold")
        {
            gold += 1;
            PlayerPrefs.SetInt("Gold", gold);
            gameManager.ChangeGoldText(gold);
            col.gameObject.SetActive(false);
            Destroy(col.gameObject);
        }
    }
    
    
}
