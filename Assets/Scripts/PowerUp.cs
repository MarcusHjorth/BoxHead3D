using System;
using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.4f;
    public float duration = 4f;
    private RandomSpawner randomSpawner;

    public GameObject pickupEffect;

    private void Start()
    {
        randomSpawner = FindAnyObjectByType<RandomSpawner>();
    }

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
        //GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<Collider>().enabled = false;
        
        // Remove the pickup from the spawner tracking list and destroy it instantly
        if (randomSpawner != null)
        {
            randomSpawner.RemovePickup(transform.parent.gameObject);
        }
        Destroy(transform.parent.gameObject); // Destroy the pickup instantly

        //Wait x amount of seconds
        yield return new WaitForSeconds(duration);

        //Reverse the effect on player
        stats.health /= multiplier;
    }
}