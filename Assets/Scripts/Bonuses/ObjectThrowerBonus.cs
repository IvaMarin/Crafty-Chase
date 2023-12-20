using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrowerBonus : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject inHandModel;
    [SerializeField] int amount = 1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out Inventory inventory))
        {
            inventory.AcquireItem(new ObjectThrower(prefab, inHandModel, amount, 20f));
            gameObject.SetActive(false);
        }
    }
}
