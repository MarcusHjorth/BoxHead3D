using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    [SerializeField] public float health, maxHealth = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    } 
}
