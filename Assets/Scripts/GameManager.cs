using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject goldUI;

    public void ChangeGoldText(int goldCount)
    {
        TextMeshProUGUI tmp = goldUI.GetComponent<TextMeshProUGUI>();
        tmp.text = "Gold: " + goldCount;
    }
}
