using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : InventoryItem
{
    float maxDistance = 5f;
    GameObject prefab;
    Transform preview;  // to see where trap will be placed
    GameObject inHandModel;  // to see prefab in your hand
    Vector3 farAway = Vector3.down * 1000f;  // to hide things
    int amountLeft;


    public ObjectSpawner(GameObject prefab, Transform preview, GameObject inHandModel, int amount = 1)
    {
        this.prefab = prefab;
        this.preview = preview;
        this.inHandModel = inHandModel;
        this.amountLeft = amount;
    }


    public override void TryUse(Transform origin, Vector3 direction)
    {
        if (amountLeft > 0 &&
            Physics.Raycast(origin.position, direction, out RaycastHit hit, maxDistance))
        {
            GameObject.Instantiate(prefab, hit.point, Quaternion.identity);
            amountLeft--;
        }
    }
    

    public override void Update(Transform origin, Vector3 direction)
    {
        if (Physics.Raycast(origin.position, direction, out RaycastHit hit, maxDistance))
        {
            preview.position = hit.point;
        }
        else
        {
            preview.position = farAway;
        }

        inHandModel.transform.position = origin.TransformPoint(new Vector3(1f, -0.5f, 1f));
        inHandModel.transform.rotation = origin.rotation;
    }


    public override void OnSwitchedTo()
    {
        inHandModel.SetActive(true);
    }


    public override void OnSwitchedFrom()
    {
        preview.position = farAway;
        inHandModel.SetActive(false);
    }


    public override bool TryAdd(InventoryItem other)
    {
        bool result = false;

        if (other.GetType() == this.GetType() &&
            ((ObjectSpawner)other).prefab == this.prefab)
        {
            amountLeft += ((ObjectSpawner)other).amountLeft;
            result = true;
        }

        return result;
    }


    public override string GetNameAndAmount()
    {
        return "Bear trap (" + amountLeft + ")";
    }
}
