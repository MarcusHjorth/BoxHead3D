using UnityEngine;

public class PlayerSys : MonoBehaviour
{
    
    
    [SerializeField] int health, maxHealth = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
