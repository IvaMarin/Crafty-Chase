using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


// This object has a list of items and allows the player to use them.
[RequireComponent(typeof(FirstPersonController))]
public class Inventory : MonoBehaviour
{
    [SerializeField] new Transform camera;  // new to override inherited member
    [SerializeField] TMP_Text nameAndAmountText;
    List<InventoryItem> items;
    int activeItemIndex = 0;

    private void Awake()
    {
        items = new List<InventoryItem>
        {
            new InventoryItem()  // Empty hand
        };

        nameAndAmountText.text = items[activeItemIndex].GetNameAndAmount();
    }

    void Update()
    {
        if (items.Count > 0)
        {
            items[activeItemIndex].Update(camera, camera.forward);

            if (Input.mouseScrollDelta.y > 0)
            {
                TrySwitchNext();
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                TrySwitchPrev();
            }
            else if (Input.GetMouseButtonDown(0))
            {
                TryUseCurrentItem();
            }
        }
    }


    // This is not implemented right now.
    public void AcquireItem(InventoryItem item)
    {
        bool itemIsNew = true;
        foreach(var current in items)
        {
            if (current.TryAdd(item))
            {
                itemIsNew = false;
                break;
            }
        }
        
        if (itemIsNew)
        {
            items.Add(item);
        }
    }


    void TrySwitchNext()
    {
        if (items[activeItemIndex].CanSwitchFrom() && activeItemIndex < items.Count - 1)
        {
            items[activeItemIndex].OnSwitchedFrom();
            activeItemIndex++;
            items[activeItemIndex].OnSwitchedTo();

            nameAndAmountText.text = items[activeItemIndex].GetNameAndAmount();
        }
    }

    void TrySwitchPrev()
    {
        if (items[activeItemIndex].CanSwitchFrom() && activeItemIndex > 0)
        {
            items[activeItemIndex].OnSwitchedFrom();
            activeItemIndex--;
            items[activeItemIndex].OnSwitchedTo();

            nameAndAmountText.text = items[activeItemIndex].GetNameAndAmount();
        }
    }

    void TryUseCurrentItem()
    {
        if (activeItemIndex > 0)
        {
            items[activeItemIndex].TryUse(camera, camera.forward);
            nameAndAmountText.text = items[activeItemIndex].GetNameAndAmount();
        }
    }
}


// Is an item of the Inventory list
public class InventoryItem
{
    // Can inventory switch from this item right now?
    public virtual bool CanSwitchFrom()
    {
        return true;
    }


    public virtual void TryUse(Transform origin, Vector3 direction) {}


    public virtual void OnSwitchedTo() {}


    public virtual void OnSwitchedFrom() {}


    // called when the ability is held
    public virtual void Update(Transform origin, Vector3 direction) {}


    // If one of them is ability to put down bear traps and grants 3 bear traps,
    // and another is ability to put down 5 bear traps, then first should become ability
    // to put down 8 = 3 + 5 bear traps.
    // If resource can't be replenished like that, this method must return false.
    public virtual bool TryAdd(InventoryItem other)
    {
        return other.GetType() == this.GetType();
    }


    public virtual string GetNameAndAmount()
    {
        return "empty";
    }
}
