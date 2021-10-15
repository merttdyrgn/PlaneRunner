using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    public GameObject player;
    private int distance = 50;
    private int minDistance = 15;
    private int cooldown = 8;
    private float creationTime = 8;
    private float playerPosZ;
    private float spawnPosZ;
    private float spawnPosX;
    private bool death = false;
    private int lastPrefabIndex = 0;
    Vector3 spawnPosition;
    
    // Update is called once per frame
    void Update() {
        if (Time.time > creationTime)
        {
            creationTime = Time.time + cooldown;
            if (death == false)
            {
                playerPosZ = player.transform.position.z;
                spawnPosZ = playerPosZ + distance;

                if (Random.value < 1 / 3)
                    spawnPosX = -10;
                else if (1 / 3 <= Random.value && Random.value < 2 / 3)
                    spawnPosX = 0;
                else
                    spawnPosX = 10;
                
                spawnPosition = new Vector3(spawnPosX, 1.5f, spawnPosZ);

                ScoreSpawn();
            }
        } 
    }
    
    

    private void ScoreSpawn()
    {
        Instantiate(coin, spawnPosition, Quaternion.identity);
    }
}
