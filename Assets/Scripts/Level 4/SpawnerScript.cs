using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject ChickenPrefabs;
    private float time;
    private float spawnTime = 2f;


    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
            SpawnChicken();
    }

    public void SpawnChicken()
    {
        time = 0;
        ChickenScript.speed += 0.1f;
        if (spawnTime > 0.3f)
        spawnTime -= 0.01f;
        int randomIndex = Random.Range(0, 8);
        Instantiate(ChickenPrefabs, spawnPoints[randomIndex].position, Quaternion.identity);
    }


}
