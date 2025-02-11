using Unity.VisualScripting;
using UnityEngine;

public class DamageTester : MonoBehaviour
{
   public AttributesManager playerAtm;
   public AttributesManager enemyAtm;
   
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            enemyAtm.DealDamage(enemyAtm.gameObject);
        }
        
        if (Input.GetKeyDown(KeyCode.F12))
        {
            playerAtm.DealDamage(playerAtm.gameObject);
        }
    }
}
