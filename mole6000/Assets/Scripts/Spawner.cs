using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    
    public Transform spawnPoint_1;
    public Transform spawnPoint_2;
    public Transform spawnPoint_3;
    public Transform spawnPoint_4;
    public Transform spawnPoint_5;
    public Transform spawnPoint_6;
    public Transform spawnPoint_7;
    public Transform spawnPoint_8;
    public Transform spawnPoint_9;
    

    void Start() {
        SpawnMole();
    }

    void Update() {

    }

    void SpawnMole() {
        int position = Random.Range(0, 8);
        if (position == 0) {
            Instantiate(enemy, spawnPoint_1.position, spawnPoint_1.rotation);
        }
        if (position == 1) {
            Instantiate(enemy, spawnPoint_2.position, spawnPoint_2.rotation);
        }
        
    }
}
