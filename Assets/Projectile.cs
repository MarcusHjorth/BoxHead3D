using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 1000;

    void Awake()
    {
        Destroy(gameObject, 3); // Destroys the projectile after 3 seconds
        Rigidbody rigidbody = GetComponent<Rigidbody>(); 
        rigidbody.AddForce(transform.forward * this.speed, ForceMode.Impulse);
    }
}