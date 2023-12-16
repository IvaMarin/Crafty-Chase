using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicsBase : MonoBehaviour
{

    protected Transform tr;
    protected OpenManager manager;
    protected Vector3 startrotation;
    protected float DoorSpeed;
    void Start()
    {
        tr = GetComponent<Transform>();
        manager = GetComponent<OpenManager>();
        startrotation = tr.localRotation.eulerAngles;
        DoorSpeed = manager.Speed;
    }
    public virtual void Open()
    {
    }
    public virtual void Close()
    {
    }
}
