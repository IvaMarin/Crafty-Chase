using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerBonus : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform preview;
    [SerializeField] GameObject inHandModel;
    [SerializeField] int amount = 1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Inventory inventory))
        {
            inventory.AcquireItem(new ObjectSpawner(prefab, preview, inHandModel, amount));
            gameObject.SetActive(false);
        }
    }
}
