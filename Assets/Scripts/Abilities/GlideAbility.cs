using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(FirstPersonController))]
[RequireComponent(typeof(Rigidbody))]
public class GlideAbility : MonoBehaviour
{
    private FirstPersonController fpsController;
    private Rigidbody rb;
    [SerializeField] private float downSpeed = 1f;
    [SerializeField] private float forwardSpeed = 6f;
    private bool isGliding = false;


    private void StartGliding()
    {
        isGliding = true;
        fpsController.playerCanMove = false;
    }

    private void StopGliding()
    {
        isGliding = false;
        fpsController.playerCanMove = true;
    }

    void Awake()
    {
        fpsController = GetComponent<FirstPersonController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // These are not complementary!
        // These are independent bools!
        bool shouldStartGliding = Input.GetKeyDown(KeyCode.Space) && !fpsController.isGrounded;
        bool shouldStopGliding = Input.GetKeyUp(KeyCode.Space) || fpsController.isGrounded;

        if (isGliding && shouldStopGliding)
        {
            StopGliding();
        }
        else if (!isGliding && shouldStartGliding)
        {
            StartGliding();
        }
    }

    private void FixedUpdate()
    {
        if (isGliding)
        {
            Vector3 newVelocity = transform.TransformDirection(0f, 0f, forwardSpeed) + downSpeed * Vector3.down;
            rb.velocity = newVelocity;
            fpsController.playerCanMove = false;
        }
    }
}
