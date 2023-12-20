using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseEnablePopupWindow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // public GameObject popupWindowObject;
  
    // private string myDescription;
    private GameObject panel;
    private void Start()
    {
        panel= GetComponent<Transform>().GetChild(2).gameObject;
        panel.SetActive(false);
        // myDescription = description.text;
    }

    private void Update()
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panel.SetActive(false);
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        panel.SetActive(true);
    }
}