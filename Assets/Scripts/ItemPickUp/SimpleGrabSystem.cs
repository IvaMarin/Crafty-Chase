using UnityEngine;

public class SimpleGrabSystem : MonoBehaviour
{
    // Reference to the character camera.
    [SerializeField] private Camera characterCamera;

    // Reference to the slot for holding picked item.
    [SerializeField] private Transform slot;

    // Reference to the currently held item.
    private PickableItem pickedItem;

    private bool hasItem = false;
    private bool isDooring = false;
    private OpenDoor currentDoor;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && pickedItem)
        {
            hasItem = true;
        }

        // Execute logic only on button pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Check if player picked some item already
            if (pickedItem && hasItem)
            {
                // If yes, drop picked item
                ThrowItem(pickedItem);
                hasItem = false;
            }
            else
            {
                // If no, try to pick item in front of the player
                // Create ray from center of the screen
                var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
                RaycastHit hit;
                // Shot ray to find object to pick
                if (Physics.Raycast(ray, out hit, 2.5f)) //was 1.5f
                {
                    // Check if object is pickable
                    var pickable = hit.transform.GetComponent<PickableItem>();
                    var openable = hit.transform.GetComponent<OpenDoor>();

                    // If object has PickableItem class
                    if (pickable)
                    {
                        // Pick it
                        PickItem(pickable);
                    }
                }
            }
        }

        if (Input.GetMouseButton(0) && isDooring==false)
        {
            var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5f)) //was 1.5f
            {
                var openable = hit.transform.GetComponent<OpenDoor>();

                // If object has PickableItem class
                if (openable)
                {
                    isDooring = true;
                    currentDoor = openable;
                    openable.StartBar();
                }
            }
        }
        else if (Input.GetMouseButton(0) && isDooring == true)
        {
            currentDoor.Process();
        }
        else
        {
            if (isDooring)
            {
                currentDoor.StopBar();
                isDooring = false;
            }
        }


        if (Input.GetMouseButtonDown(2))
        {
            if (pickedItem)
            {
                DropItem(pickedItem);
                hasItem = false;
            }
        }
    }


    private void PickItem(PickableItem item)
    {
        // Assign reference
        pickedItem = item;

        // Disable rigidbody and reset velocities
        item.rb.isKinematic = true;


        // Set Slot as a parent
        item.transform.SetParent(slot);

        // Reset position and rotation
        item.transform.localPosition = new Vector3(1, 0, 1);
        item.transform.localEulerAngles = Vector3.zero;
    }

    private void ThrowItem(PickableItem item)
    {
        // Remove reference
        pickedItem = null;

        // Remove parent
        item.transform.SetParent(null);


        // Enable rigidbody
        item.rb.isKinematic = false;

        // Add force to throw item a little bit
        item.rb.AddForce(item.transform.forward * 15, ForceMode.VelocityChange);
    }

    private void DropItem(PickableItem item)
    {
        // Remove reference
        pickedItem = null;

        // Remove parent
        item.transform.SetParent(null);

        // Enable rigidbody
        item.rb.isKinematic = false;

        // Add force to throw item a little bit
        item.rb.AddForce(item.transform.forward * 1, ForceMode.VelocityChange);
    }
}