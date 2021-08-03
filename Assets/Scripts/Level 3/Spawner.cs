using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject ChildrenPrefab;

    private float time;
    private float spawnTime = 4f;

    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= spawnTime && !GameManager1.EggBroken)
            SpawnChildren();
    }

    public void SpawnChildren()
    {
        time = 0;
        Children.speed += 0.1f;
        int randomIndex = Random.Range(0, 14);
        Instantiate(ChildrenPrefab, spawnPoints[randomIndex].position, transform.rotation);
    }


}
