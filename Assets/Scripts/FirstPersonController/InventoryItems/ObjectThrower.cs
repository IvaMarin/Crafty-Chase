using UnityEngine;


// Similar to ObjectSpawner, but throws objects instead of calmly placing them.
public class ObjectThrower : InventoryItem
{
    float awayDistance = 2f;  // how far from player to instantiate them
    float throwForce;
    GameObject prefab;
    GameObject inHandModel;  // to see prefab in your hand
    int amountLeft;


    public ObjectThrower(GameObject prefab, GameObject inHandModel, int amount = 1, float throwForce = 1f)
    {
        this.prefab = prefab;
        this.inHandModel = inHandModel;
        this.amountLeft = amount;
        this.throwForce = throwForce;
    }


    public override void TryUse(Transform origin, Vector3 direction)
    {
        if (amountLeft > 0 &&
            !Physics.Raycast(origin.position, direction, out RaycastHit hit, 1f))
        {
            var obj = GameObject.Instantiate(prefab, origin.position + direction * awayDistance, Quaternion.identity);

            if (obj.TryGetComponent(out Rigidbody rb))
            {
                rb.AddForce(direction * throwForce, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("Hey, where banana rigidbody?");
            }

            amountLeft--;
        }
    }


    public override void Update(Transform origin, Vector3 direction)
    {
        inHandModel.transform.position = origin.TransformPoint(new Vector3(1f, -0.5f, 1f));
        inHandModel.transform.rotation = origin.rotation;
    }


    public override void OnSwitchedTo()
    {
        inHandModel.SetActive(true);
    }


    public override void OnSwitchedFrom()
    {
        inHandModel.SetActive(false);
    }

    public override bool TryAdd(InventoryItem other)
    {
        bool result = false;

        if (other.GetType() == this.GetType() &&
            ((ObjectThrower)other).prefab == this.prefab)
        {
            amountLeft += ((ObjectThrower)other).amountLeft;
            result = true;
        }

        return result;
    }


    public override string GetNameAndAmount()
    {
        return "Banana (" + amountLeft + ")";
    }
}
