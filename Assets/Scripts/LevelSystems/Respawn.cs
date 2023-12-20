using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Respawn : MonoBehaviour
{
    private Collider collisions;

    [SerializeField] private GameObject player;
    [SerializeField] private Transform respawnPoint;

    private void Awake()
    {
        collisions = GetComponent<Collider>();
        collisions.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPoint.transform.position;
    }
}
