using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 50f;

    void Awake()
    {
        Destroy(gameObject, 3); // Destroys the projectile after 3 seconds
        Rigidbody rigidbody = GetComponent<Rigidbody>(); 
        rigidbody.AddForce(transform.forward * this.speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<AttributesManager>(out AttributesManager enemyBean))
        {
            enemyBean.TakeDamage(10);
        }
    }
}