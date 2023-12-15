using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenBar : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform rt;
    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    public void Open()
    {
        
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}