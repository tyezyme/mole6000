using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    public Transform[] spawnPoints;
    

    void Start() {

        SpawnMole();
    }
    void SpawnMole() {
        int p = Random.Range(0, 8);
        Instantiate(enemy, spawnPoints[p].position, spawnPoints[p].rotation);
        //spawn the mole at the random spawnpoint
    }
}
