using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class FireArrow : MonoBehaviour  
{
    public GameObject arrow;
    
    public Transform firePos;
    public float cooldown;
    public bool canFire = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        

    }

    public void Fire()
    {
        if (canFire == true)
        {
            canFire = false;
            Instantiate(arrow, firePos.transform.position, firePos.rotation);
            StartCoroutine(weapCooldown());
            canFire = true;
        }

    }
 
        
    IEnumerator weapCooldown()
    {
        yield return new WaitForSeconds(cooldown);
    }
        
    
}
