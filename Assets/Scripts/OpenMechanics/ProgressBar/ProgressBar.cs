using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform rt;
    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    public void SetBar(int cur, int max)
    {
        Vector3 direction = new Vector3(1, 0, 0);
        Vector3 default_ = new Vector3(0, 1, 1);
        rt.localScale = default_ + direction * (((float)cur / max));
    }
}
