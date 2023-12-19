using UnityEngine;
using UnityEngine.UI;

public class ScrollViewLerp : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float lerpDuration = 1.0f;
    public float targetValue = 1.0f;

    private float startValue;
    private float startTime;

    void Start()
    {
        startValue = scrollRect.verticalNormalizedPosition;
        startTime = Time.time;
    }

    void Update()
    {
        float timePassed = Time.time - startTime;
        float lerpProgress = Mathf.Clamp01(timePassed / lerpDuration);
        scrollRect.verticalNormalizedPosition = Mathf.Lerp(startValue, targetValue, lerpProgress);
    }
}
