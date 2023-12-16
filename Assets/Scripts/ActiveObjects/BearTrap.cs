using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;


// The bear trap creates a FixedJoint upon rigidbody detection.
public class BearTrap : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float unclenchTime = 3f;
    private bool activated = false;  // is the trap currently holding something?
    private Rigidbody victim_rb;
    private FixedJoint joint_with_victim;
    private float unclenchTimeLeft;
    private bool heldObjectIsPlayer;
    private Slider playerSlider;  // progress bar of unclenching


    private void Awake()
    {
        if (anim == null)
        {
            Debug.Log("You forgot to give the animator to a bear trap script instance.");
        }
    }


    // something or someone got into the trap
    public void SetOff(Transform perturbator)
    {
        activated = true;

        anim.SetBool("Activated", true);

        if (perturbator.TryGetComponent(out victim_rb) ||
            (perturbator.parent != null && perturbator.parent.parent != null &&
             perturbator.parent.parent.TryGetComponent(out victim_rb)))
        {
            joint_with_victim = victim_rb.gameObject.AddComponent<FixedJoint>();
            joint_with_victim.connectedBody = GetComponent<Rigidbody>();
            if (victim_rb.GetComponent<FirstPersonController>() != null)
            {
                heldObjectIsPlayer = true;
                unclenchTimeLeft = unclenchTime;
                if (victim_rb.TryGetComponent(out BearTrapUIGetter uiGetter))
                {
                    playerSlider = uiGetter.GetProgressBar();
                    playerSlider.gameObject.SetActive(true);
                }
            }
        }
    }


    private void Unclench()
    {
        if (playerSlider != null)
        {
            playerSlider.gameObject.SetActive(false);
        }

        Destroy(null);
        Destroy(joint_with_victim);
        victim_rb = null;
        joint_with_victim = null;
        playerSlider = null;
    }


    private void Update()
    {
        if (activated && victim_rb != null)
        {
            if (victim_rb.isKinematic ||
                (heldObjectIsPlayer && unclenchTimeLeft <= 0f))
            {
                Unclench();
            }
            
            unclenchTimeLeft -= Time.deltaTime;
            if (playerSlider != null)
            {
                playerSlider.value = 1f - unclenchTimeLeft / unclenchTime;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!activated) {
            SetOff(other.transform);
        }
    }
}
