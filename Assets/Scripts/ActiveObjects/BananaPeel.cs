using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;


// based on joints, moves the player who steps on it
[RequireComponent(typeof(Rigidbody))]
public class BananaPeel : MonoBehaviour
{
    [SerializeField] float speed = 15f;  // must be greater than zero
    [SerializeField] float slippingTime = 5f;  // how long does this have effect?
    float slippingTimeLeft;
    FixedJoint joint_with_victim = null;
    FirstPersonController playerController = null;
    Rigidbody victim;
    Rigidbody rb;


    private void Awake()
    {
        if (speed <= 0f)
        {
            Debug.Log("You probably made a mistake, banana speed must be greater than zero!");
        }

        if (!TryGetComponent(out rb))
        {
            Debug.Log("Add rigibody to banana please.");
        }
    }


    private void Update()
    {
        slippingTimeLeft -= Time.deltaTime;

        if (slippingTimeLeft < 0f || victim == null || victim.isKinematic)
        {
            Destroy(joint_with_victim);

            if (playerController != null)
            {
                playerController.playerCanMove = true;
                playerController.cameraCanMove = true;
            }

            victim = null;
            joint_with_victim = null;
            playerController = null;
        }
    }


    private void FixedUpdate()
    {
        if (joint_with_victim != null)
        {
            NormalizeNonverticalVelocity(victim);
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (joint_with_victim == null && collision.rigidbody != null)
        {
            victim = collision.rigidbody;
            joint_with_victim = victim.AddComponent<FixedJoint>();
            joint_with_victim.connectedBody = rb;
            if (victim.TryGetComponent(out playerController))
            {
                playerController.playerCanMove = false;
                playerController.cameraCanMove = false;
            }
            slippingTimeLeft = slippingTime;
        }
    }


    // The heart of this object.
    // Here velocity of the poor victim rigidbody is adjusted in a weird way.
    void NormalizeNonverticalVelocity(Rigidbody rigidbody)
    {
        // divide velocity into components
        Vector3 verticalVelocity = Vector3.up * rigidbody.velocity.y;
        Vector3 nonverticalVelocity = rigidbody.velocity - verticalVelocity;

        // the procedure
        if (nonverticalVelocity.sqrMagnitude == 0)
        {
            nonverticalVelocity = new Vector3(Random.value, 0f, Random.value);
        }
        nonverticalVelocity.Normalize();
        nonverticalVelocity *= speed;

        // assign velocity
        rigidbody.velocity = nonverticalVelocity + verticalVelocity;
    }
}
