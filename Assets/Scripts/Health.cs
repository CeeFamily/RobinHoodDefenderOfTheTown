using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
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
    void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
