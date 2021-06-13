using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnTime = 5.0f;
    public GameObject flower;

    void Start() {
        InvokeRepeating("SpawnFlower", 2.0f, spawnTime);
    }

    void SpawnFlower() {
        int indx = Random.Range(0, spawnPoints.Length);
        Instantiate(flower, spawnPoints[indx].position, spawnPoints[indx].rotation);
    }

}
