using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] public float damage;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeHealing(float healing)
    {
        health += healing;
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributesManager>();
        if (atm != null)
        {
            atm.TakeDamage(damage);
        }
    }
}
