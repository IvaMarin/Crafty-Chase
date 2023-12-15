using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public Transform tr;
    private Transform startposition;
    private int CurProgress = 0;
    private const int MaxProgress = 300;
    [SerializeField] private OpenBar openbar;
    [SerializeField] private ProgressBar progressBar; 
    private enum State
    {
        Open, Close, Wait
    }

    private State state = State.Wait;
    
    private int direction = 1;
    // [SerializeField] private Transform pivot;
    private void Awake()
    {

    }

    void Start()
    {              
        
                // openbar = GetComponentInChildren<OpenBar>();
                rb = GetComponent<Rigidbody>();
                tr = GetComponent<Transform>();
                startposition = tr;
                
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
            Vector3 aroundPosition = tr.position + new Vector3(0, 0.25f, 0);
            tr.RotateAround(aroundPosition, new Vector3(0, 1, 0), direction*0.3f);
            if (tr.rotation.eulerAngles.y >= 100f)
            {
                state = State.Wait;
            }
        }
    }

    public void StartBar()
    {
        if (state == State.Wait)
        {
            openbar.Setup();
        }
    }

    public void Open()
    {
        // Debug.Log("Started Open");
        if (state == State.Wait)
        {
            // openbar.Setup();
            CurProgress += 1;
            progressBar.SetBar(CurProgress, MaxProgress);
            if (CurProgress >= MaxProgress)
            {
                StopBar();
                state = State.Open;
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
