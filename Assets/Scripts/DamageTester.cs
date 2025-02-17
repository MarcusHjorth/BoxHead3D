using Unity.VisualScripting;
using UnityEngine;

public class DamageTester : MonoBehaviour
{
   public AttributesManager playerAtm;
   public AttributesManager enemyAtm;
   
    
    private void Update()
    {
        //Deal player damage to the enemy health
        if (Input.GetKeyDown(KeyCode.F11))
        {
            playerAtm.DealDamage(enemyAtm.gameObject);
        }
        
        if (Input.GetKeyDown(KeyCode.F12))
        {
            enemyAtm.DealDamage(playerAtm.gameObject);
        }
    }
}
