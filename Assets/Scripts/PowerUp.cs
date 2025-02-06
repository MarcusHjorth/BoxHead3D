using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.2f;
    public float duration = 4f;

    public GameObject pickupEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        //Spawn a cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //Apply effect to player
        // (Make player smaller) player.transform.localScale *= --multiplier;

        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.health *= multiplier;
        
        //Disable graphics for powerup (mesh renderer and collider)
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Wait x amount of seconds
        yield return new WaitForSeconds(duration);

        //Reverse the effect on player
        stats.health /= multiplier;

        //Remove power up object
        Destroy(gameObject);
    }
}