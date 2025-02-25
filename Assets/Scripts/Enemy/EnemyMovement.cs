using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;

    private NavMeshAgent _navMeshAgent;

    // Set how close the enemy must be to trigger damage
    public float damageRadius = 1.0f;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (player != null)
        {
            _navMeshAgent.SetDestination(player.position);
        }
    }

    // This method checks if the enemy collides with the player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) // Assuming the player has a "Player" tag
        {
            var attributesManager = collision.collider.GetComponent<AttributesManager>();
            if (attributesManager != null)
            {
                // Call the DealDamage method when the enemy touches the player
                attributesManager.DealDamage(attributesManager.gameObject); // Pass the enemy gameObject to the DealDamage method
            }
        }
    }
}