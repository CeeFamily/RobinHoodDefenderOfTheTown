using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public float initialDelay = 2.0f;
    public float delayBetween = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", initialDelay, delayBetween);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemies()
    {
        Vector3 spawnOffset = new Vector3(-70, 0, 0);
        int randomEnemy = Random.Range(0, enemyPrefabs.Count);
        Instantiate(enemyPrefabs[randomEnemy], spawnOffset, enemyPrefabs[randomEnemy].transform.rotation);
    }
}
