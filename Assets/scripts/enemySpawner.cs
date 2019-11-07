using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class enemySpawner : NetworkBehaviour {


    public GameObject enemyPrefab;
    public int enemyNumbers;



    public override void OnStartServer()
    {
        for(int i=0; i<enemyNumbers; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-200.0f, 200.0f), 0.0f, Random.Range(-200.0f, 200.0f));
            Quaternion spawnRotation = Quaternion.Euler(0.0f, Random.Range(0, 180), 0);

            GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition , spawnRotation);
            NetworkServer.Spawn(enemy);
        }
    }
}
