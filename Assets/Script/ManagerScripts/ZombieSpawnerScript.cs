using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnerScript : MonoBehaviour
{
    public int numberOfZombiesToSpawn;
    public GameObject[] zombiesPrefabs;
    public SpawnerVolume[] spawnerVolumes;

    GameObject followTarget;
    // Start is called before the first frame update
    void Start()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < numberOfZombiesToSpawn; i++)
        {
            SpawnZombies();
        }
    }

    private void SpawnZombies()
    {
        GameObject zombieToSpawn = zombiesPrefabs[Random.Range(0, zombiesPrefabs.Length)];
        SpawnerVolume spawnerVolume = spawnerVolumes[Random.Range(0, spawnerVolumes.Length)];
        //if (!followTarget) return;

        GameObject zombie = Instantiate(zombieToSpawn, spawnerVolume.GetPositionInBounds(), spawnerVolume.transform.rotation);

        zombie.GetComponent<ZombieComponent>().Initialize(followTarget);
    }
}
