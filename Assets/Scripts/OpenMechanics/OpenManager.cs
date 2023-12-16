using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class OpenManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 0.3f;
    [SerializeField] private int OpenDuration = 300;
    [SerializeField] private int CloseDuration = 300;
    public Rigidbody rb;
    public Transform tr;
    private Vector3 startposition;
    private int CurProgress = 0;
    // private const int MaxProgress = 300;
    private OpenBar openbar;
    private ProgressBar progressBar;
    // private ChestMechanics mechanicScript;
    private MechanicsBase script;
    
    private enum State
    {
        Open,
        Close,
        Wait
    }

    private State state = State.Wait;
    private State previousState = State.Close;
    // private int direction = 1;

    // [SerializeField] private Transform pivot;
    // private void Awake()
    // {
    // }
 void Awake()
    {
        
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        // Debug.Log(tr.rotation.eulerAngles.y);
        var panel = tr.GetChild(0).gameObject;
        var bar = panel.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().GetChild(0);
        progressBar = bar.GetComponent<ProgressBar>();
        openbar = panel.GetComponent<OpenBar>();

        MechanicsBase tScript = GetComponent<ChestMechanics>();
        if (tScript)
        {
            script = tScript;
        }
        tScript = GetComponent<DoorMechanics>();
        if (tScript)
        {
            script = tScript;
        }
        startposition = tr.localRotation.eulerAngles;
       
    }

    public void NextState()
    {
        // Debug.Log(state);
        if (state == State.Close)
        {
            previousState = State.Close;
            state = State.Wait;
            
            return;
        }
        if (state == State.Open)
        {
            previousState = State.Open;
            state = State.Wait;
            return;
        }

        if (state == State.Wait)
        {
            if (previousState == State.Close)
            {
                state = State.Open;
            }
            if (previousState == State.Open)
            {
                state = State.Close;
            }

            return;
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        // var position = pivot.transform.position;
        // Debug.Log(openbar);
        // Debug.Log(state);
        // Debug.Log(CurProgress);
        //
        if (state == State.Open)
        {
            // direction = 1;
            script.Open();
            
        }
        if (state == State.Close)
        {
            script.Close();
            // Debug.Log(state);
            // direction = -1;
            // Vector3 aroundPosition = tr.position + new Vector3(0, 0.25f, 0);
            // tr.RotateAround(aroundPosition, new Vector3(0, 1, 0), direction * DoorSpeed);
            // // Debug.Log(tr.localRotation.eulerAngles.y);
            // if (Mathf.Abs(tr.localRotation.eulerAngles.y - startposition.y) <= 1 || Mathf.Abs(tr.localRotation.eulerAngles.y - startposition.y) > 350f)
            // {
            //     CurProgress = 0;
            //     NextState();
            //     // Debug.Log("open next state");
            //     // Debug.Log(state);
            // }
        }
    }

    public void StartBar()
    {
        if (state == State.Wait)
        {
            openbar.Open();
        }
    }

    public void LoadBar()
    {
        // Debug.Log("Started Open");
        if (state == State.Wait)
        {
            // openbar.Setup();
            CurProgress += 1;
            int MaxProgress = (previousState == State.Close) ? CloseDuration : OpenDuration;
            
            progressBar.SetBar(CurProgress, MaxProgress);
            if (CurProgress >= MaxProgress)
            {
                StopBar();
                NextState();
            }
        }
    }

    public void StopBar()
    {
        // state = State.Wait;
        CurProgress = 0;
        openbar.Close();
    }
}