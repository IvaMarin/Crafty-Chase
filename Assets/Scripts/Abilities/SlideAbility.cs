using UnityEngine;

[RequireComponent(typeof(FirstPersonController))]
[RequireComponent(typeof(Rigidbody))]
public class SlideAbility : MonoBehaviour
{
    private FirstPersonController fpsController;
    private Rigidbody rb;
    [SerializeField] private float minimumSpeed = 6f;
    private float minimumSpeedSqr;

    void StartSliding()
    {
        fpsController.playerCanMove = false;
        fpsController.crouchHeight = 0.5f;
    }

    void StopSliding()
    {
        fpsController.playerCanMove = true;
        fpsController.crouchHeight = 0.75f;
    }

    void Awake()
    {
        fpsController = GetComponent<FirstPersonController>();
        rb = GetComponent<Rigidbody>();
        minimumSpeedSqr = minimumSpeed * minimumSpeed;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(fpsController.crouchKey) && rb.velocity.sqrMagnitude > minimumSpeedSqr)
        {
            StartSliding();
        }
        else if (!Input.GetKey(fpsController.crouchKey))
        {
            StopSliding();
        }
    }
}
