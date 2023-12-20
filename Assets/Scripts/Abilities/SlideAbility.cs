using UnityEngine;

[RequireComponent(typeof(FirstPersonController))]
[RequireComponent(typeof(Rigidbody))]
public class SlideAbility : MonoBehaviour
{
    private FirstPersonController fpsController;
    private Rigidbody rb;
    [SerializeField] private float minimumSpeed = 6f;
    [SerializeField] PhysicMaterial feetMaterial;  // to set friction
    private float originalStaticFeetFriction;
    private float originalDynamicFeetFriction;
    private float minimumSpeedSqr;

    void StartSliding()
    {
        fpsController.playerCanMove = false;
        fpsController.crouchHeight = 0.5f;
        feetMaterial.staticFriction = 0f;
        feetMaterial.dynamicFriction = 0.1f;
    }

    void StopSliding()
    {
        fpsController.playerCanMove = true;
        fpsController.crouchHeight = 0.75f;
        feetMaterial.staticFriction = originalStaticFeetFriction;
        feetMaterial.dynamicFriction = originalDynamicFeetFriction;
    }

    void Awake()
    {
        fpsController = GetComponent<FirstPersonController>();
        rb = GetComponent<Rigidbody>();

        if (feetMaterial == null)
        {
            Debug.Log("Set feet collider! It's required for slide ability.");
        } else
        {
            originalStaticFeetFriction = feetMaterial.staticFriction;
            originalDynamicFeetFriction = feetMaterial.dynamicFriction;
        }

        minimumSpeedSqr = minimumSpeed * minimumSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(fpsController.crouchKey) && rb.velocity.sqrMagnitude > minimumSpeedSqr)
        {
            StartSliding();
        }
        else if (Input.GetKeyUp(fpsController.crouchKey))
        {
            StopSliding();
        }
    }
}
