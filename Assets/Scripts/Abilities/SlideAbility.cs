using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(FirstPersonController))]
[RequireComponent(typeof(Rigidbody))]
public class SlideAbility : MonoBehaviour
{
    private FirstPersonController controller;
    new private Rigidbody rigidbody;
    [SerializeField] private float minimumSpeed = 6f;
    private float minimumSpeedSqr;

    void StartSliding()
    {
        controller.playerCanMove = false;
        controller.crouchHeight = 0.5f;
    }

    void StopSliding()
    {
        controller.playerCanMove = true;
        controller.crouchHeight = 0.75f;
    }

    void Awake()
    {
        controller = GetComponent<FirstPersonController>();
        rigidbody = GetComponent<Rigidbody>();
        minimumSpeedSqr = minimumSpeed * minimumSpeed;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl) && rigidbody.velocity.sqrMagnitude > minimumSpeedSqr)
        {
            StartSliding();
        }
        else if (!Input.GetKey(KeyCode.LeftControl))
        {
            StopSliding();
        }
    }
}
