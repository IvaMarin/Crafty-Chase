using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanics : MechanicsBase
{
    // Start is called before the first frame update


    // Update is called once per frame
    public override void Close()
    {
        // Debug.Log("DCM");
        int direction = -1;
        Vector3 aroundPosition = tr.position + new Vector3(0, 0.25f, 0);
        tr.RotateAround(aroundPosition, new Vector3(0, 1, 0), direction * DoorSpeed);
        // Debug.Log(tr.localRotation.eulerAngles.y);
        if (Mathf.Abs(tr.localRotation.eulerAngles.y - startrotation.y) <= 1 || Mathf.Abs(tr.localRotation.eulerAngles.y - startrotation.y) > 359f)
        {
            manager.StopBar();
            manager.NextState();
            
        }
    }

    public override void Open()
    {
        // Debug.Log("DOM");
        int direction = 1;
        Vector3 aroundPosition = tr.position + new Vector3(0, 0.25f, 0);
        tr.RotateAround(aroundPosition, new Vector3(0, 1, 0), direction * DoorSpeed);
        // Debug.Log(Mathf.Abs(tr.localRotation.eulerAngles.y - startrotation.y));
        if (Mathf.Abs(tr.localRotation.eulerAngles.y - startrotation.y) >= 100f)
        {
            manager.NextState();
            manager.StopBar();
            // Debug.Log("open next state ");
            // Debug.Log(state);
        }
    }
}
