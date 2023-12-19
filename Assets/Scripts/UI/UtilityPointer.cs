using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityPointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake () {
        Cursor.lockState= CursorLockMode.None;

        Cursor.visible = true;

        Time.timeScale = 1.0f;
    }
	
    // Update is called once per frame
    void Update () {
        Cursor.lockState= CursorLockMode.None;

        Cursor.visible = true;

        Time.timeScale = 1.0f;
    }
}
