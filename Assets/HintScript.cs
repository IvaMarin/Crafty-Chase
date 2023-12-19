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
        Debug.Log(panel);
        panel.SetActive(false);
        // myDescription = description.text;
    }

    private void Update()
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnMouseExit");
        // description.SetText("");
        panel.SetActive(false);
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnMouseEnter");
        // Debug.Log(Input.mousePosition);
        // description.SetText(myDescription);
        panel.SetActive(true);
        // popupWindowObject.SetActive(true);
    }
}