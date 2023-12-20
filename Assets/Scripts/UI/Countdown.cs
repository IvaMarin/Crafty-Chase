using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    enum Scenes { 
        Menu,
        Store,
        SeaPort,
        EndGame
    }

    [SerializeField] private int timeRemaining = 120;
    [SerializeField] private Scenes nextSceneName;

    private TextMeshProUGUI displayTime;
    private bool isTimerStarted = false;

    private Color defaultColor;

    private Color stressColor;
    private void Start()    
    {
        Debug.Log(gameObject);
        displayTime = GetComponent<Transform>().GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();

        stressColor = new Color(255, 89, 86);

        defaultColor = new Color(255, 223, 172);
        DisplayTime(timeRemaining);
        displayTime.overrideColorTags = true;
        displayTime.faceColor = defaultColor;
    }

    void Update()
    {

        if (isTimerStarted == false)
        {
            isTimerStarted = true;
            StartCoroutine(DoStep());
        }

        if (timeRemaining == 0)
        {
 
             Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene(nextSceneName.ToString());
        }
    }

    IEnumerator DoStep()
    {
        DisplayTime(timeRemaining);
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            DisplayTime(timeRemaining);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        displayTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (timeToDisplay <= 5)
        {
            if (seconds % 2 == 1)
            {
                displayTime.overrideColorTags = true;
                displayTime.faceColor = Color.red;
            }
            else
            {
                displayTime.overrideColorTags = true;
                displayTime.faceColor = stressColor;
            }
        }
    }
}

