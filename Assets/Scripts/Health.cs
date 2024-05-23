using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    Rigidbody body;
    public float maxHealth = 100;
    public float healthValue;
    // Start is called before the first frame update
    void Start()
    {
        healthValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthValue <= 0 && gameObject.CompareTag("Player"))
        {
            EndGame();
        }
        else if (healthValue <= 0 && gameObject.CompareTag("Enemy"))
        {
            EnemyDeath();
        }


    }
    public float TakeDamage(float dmg)
    { 
        return healthValue -= dmg;
    }

    void EndGame()
    {
        Debug.Log("Player Died");

    }
    IEnumerator EnemyDeath()
    {
        //animate death here, wait, then despawn enemy? 
        //can branch out so bodies on wagons, etc dont disappear or make wagons crash then disappear later. 
        //not really in current scope for ragdoll or wagon crash
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
