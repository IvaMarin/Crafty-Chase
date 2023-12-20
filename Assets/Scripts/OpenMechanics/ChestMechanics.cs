using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMechanics : MechanicsBase
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    

    
    // Update is called once per frame

    // private void Update()
    // {
    //    
    //         tr.Rotate(-100*DoorSpeed*Time.deltaTime, 0,  0, Space.Self);
    // }

    public override void Open()
    {
        // Debug.Log("COM");
        int direction = -1;
        Vector3 aroundPosition = tr.position;
        // tr.RotateAround(aroundPosition, new Vector3(1, 0, 0), direction * DoorSpeed);
        // tr.localRotation.eulerAngles.y += Time.deltaTime;
        // transform.Rotate(*Time.deltaTime, 0, 0, Space.Self);
        tr.Rotate(direction* DoorSpeed*Time.deltaTime, 0,  0, Space.Self);
        // Debug.Log(Mathf.Abs(tr.localRotation.eulerAngles.y - startrotation.y));
        if (Mathf.Abs(tr.localRotation.eulerAngles.y - startrotation.y) >= 100f)
        {
            manager.NextState();
            manager.StopBar();
            // Debug.Log("open next state ");
            // Debug.Log(state);
        }
    }

    public override void Close()
    {
        // Debug.Log("CCM");
        int direction = 1;
        Vector3 aroundPosition = tr.position;
        // tr.RotateAround(aroundPosition, new Vector3(1, 0, 0), direction * DoorSpeed);
        tr.Rotate(direction* DoorSpeed*Time.deltaTime, 0,  0, Space.Self);
        // Debug.Log(tr.localRotation.eulerAngles.y);
        // Debug.Log("Closing" + Mathf.Abs(tr.localRotation.eulerAngles.x - startrotation.x));
        if (Mathf.Abs(tr.localRotation.eulerAngles.x - startrotation.x) <= 1 ||
            Mathf.Abs(tr.localRotation.eulerAngles.x - startrotation.x) > 359f)
        {
            manager.StopBar();
            manager.NextState();
        }
    }
}