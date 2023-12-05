using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(FirstPersonController))]
public class WallRunning : MonoBehaviour
{
    private Rigidbody rb;
    private FirstPersonController fpsContoller;

    [SerializeField] private LayerMask wall;

    [SerializeField] private float wallRunForce = 200f;

    private float horizontalInput;
    private float verticalInput;

    [SerializeField] private float wallCheckDistance = 0.7f;

    private RaycastHit leftWallHit;
    private RaycastHit rightWallHit;
    private bool isWallOnLeftSide;
    private bool isWallOnRightSide;

    private bool isWallRunning;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        fpsContoller = GetComponent<FirstPersonController>();
    }

    private void Update()
    {
        CheckWall();
        HandleWallRunningState();
    }

    private void FixedUpdate()
    {
        if (isWallRunning)
        {
            WallRunningMovement();
        }
    }

    private void CheckWall()
    {
        isWallOnRightSide = Physics.Raycast(transform.position, transform.right, out rightWallHit, wallCheckDistance, wall);
        isWallOnLeftSide = Physics.Raycast(transform.position, -transform.right, out leftWallHit, wallCheckDistance, wall);
    }

    private void HandleWallRunningState()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if ((isWallOnLeftSide || isWallOnRightSide) && verticalInput > 0 && !fpsContoller.isGrounded)
        {
            StartWallRunning();
        }
        else
        {
            StopWallRunning();
        }
    }

    private void StartWallRunning()
    {
        if (!isWallRunning)
        {
            isWallRunning = true;
        }
    }

    private void StopWallRunning()
    {
        if (isWallRunning)
        {
            isWallRunning = false;
            rb.useGravity = true;
        }
    }

    private void WallRunningMovement()
    {
        rb.useGravity = false;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        Vector3 wallNormal = isWallOnRightSide ? rightWallHit.normal : leftWallHit.normal;
        Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);

        if ((transform.forward - wallForward).magnitude > (transform.forward + wallForward).magnitude)
        {
            wallForward *= -1;
        }

        rb.AddForce(wallForward * wallRunForce, ForceMode.Force);

        if (!(isWallOnLeftSide && horizontalInput > 0) && !(isWallOnRightSide && horizontalInput < 0))
        {
            rb.AddForce(-wallNormal * 100, ForceMode.Force);
        }
    }
}
