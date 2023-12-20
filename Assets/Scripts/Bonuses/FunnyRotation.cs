using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnyRotation : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;

    void Update()
    {
        // Just changing the current rotation by some value.
        // Please don't change it unless you understand it.
        // Yes, here we need multiplication, not addition.
        float change = Time.deltaTime * speed;
        Quaternion rotation = Quaternion.Euler(change, change * Mathf.Sin(Time.time) * 2f, change);
        transform.rotation = rotation * transform.rotation;
    }
}
