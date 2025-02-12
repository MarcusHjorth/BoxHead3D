using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSpawner : MonoBehaviour
{
    public GameObject pickUpPrefab;
    public int maxSpawnedPickups = 3; // Max spawned pickups at a time

    private List<GameObject> spawnedPickups = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnPickupRoutine());
    }

    IEnumerator SpawnPickupRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(30f, 60f);
            yield return new WaitForSeconds(waitTime);

            // Check if the number of spawned pickups is below the limit
            if (spawnedPickups.Count < maxSpawnedPickups)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-7, 18), -10, Random.Range(14, 11));
                GameObject newPickup = Instantiate(pickUpPrefab, randomSpawnPosition, Quaternion.identity);

                // Add the new pickup to the list
                spawnedPickups.Add(newPickup);
            }
        }
    }

    // Optional: Call this method when a pickup is collected/destroyed
    public void RemovePickup(GameObject pickup)
    {
        spawnedPickups.Remove(pickup);
        Destroy(pickup);
    }
}