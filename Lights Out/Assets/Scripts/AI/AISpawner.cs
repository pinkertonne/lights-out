using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    [Range(0.00f, 1.00f)]
    public float frequency = 1;
    [Range(0.00f, 1.00f)]
    public float closeness = 1;
    [Range(0.00f, 1.00f)]
    public float randomized = 1;

    private float targetTime;
    public float thisTime = 100f;

    public GameObject enemy;
    public GameObject player;


    private void Start()
    {
        targetTime = thisTime * frequency;
    }

    private void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            SpawnAI();
            targetTime = thisTime * frequency;
        }
    }

    private void SpawnAI()
    {
        Vector3 spawnSpot = new Vector3(player.transform.position.x + Random.Range(-100 * closeness, 100 * closeness) * randomized, player.transform.position.y, player.transform.position.z + Random.Range(-100 * closeness, 100 * closeness) * randomized);
        Vector3 spawn2 = new Vector3(spawnSpot.x, spawnSpot.y + 2, spawnSpot.z);
        if (Physics.CheckCapsule(spawnSpot, spawn2, .5f))
        {
            return;
        }
        else
        {
            GameObject creature = Instantiate(enemy, spawnSpot, Quaternion.identity);
        }
    }
}
