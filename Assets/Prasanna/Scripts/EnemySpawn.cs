using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject helicopter_Prefab;
    public float timeDelayToSpawnHelicopter = 1.0f;
    private float timer;
    public Transform[] helicopterSpawnPositions;
    public int spawnPoint;
    private float spawnHeightVariations;

    void Update()
    {
        if (GameManager.instance.gameStarted == false)
        {
            return;
        }
        timer += Time.deltaTime;
        if(timer >= GameManager.instance.gameLevel) 
        {
            spawnPoint = Random.Range(0, 3);
            spawnHeightVariations = Random.Range(-1.0f, 1.0f);

            Instantiate(helicopter_Prefab, new Vector3(helicopterSpawnPositions[spawnPoint].position.x, helicopterSpawnPositions[spawnPoint].position.y + spawnHeightVariations, helicopterSpawnPositions[spawnPoint].position.z), helicopterSpawnPositions[spawnPoint].rotation);
            timer = 0.0f;
            
        }
        
    }
}
