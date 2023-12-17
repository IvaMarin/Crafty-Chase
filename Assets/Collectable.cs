using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int value = 1;
    // Update is called once per frame
    public int Collect()
    {
        Destroy(gameObject);
        return value;
    }
}
