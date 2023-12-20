using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    enum Scenes { 
        Menu,
        Store,
        SeaPort,
        EndGame
    }
	
	[SerializeField] private GameObject Player;
    [SerializeField] private float speed;
	[SerializeField] private Scenes nextSceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GhostAI());
    }

    IEnumerator GhostAI()
    {
        while (enabled)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * speed);

            var direction = Player.transform.position - transform.position;
            var rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
            yield return null;
        }
    }
	
	void OnTriggerEnter(Collider col) {
		
		if (col.gameObject.tag == "Player") {		
			Cursor.lockState = CursorLockMode.None;
			SceneManager.LoadScene(nextSceneName.ToString());
			PlayerPrefs.SetInt("Gold", 0);
		}
	}
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
