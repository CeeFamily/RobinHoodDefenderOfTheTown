using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyandHurt : MonoBehaviour {
    public float arrowDamage;
    Rigidbody body;
    public float flingAmt = 20f;
    public float damageRange = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Collider arrowBox = GetComponent<Collider>();

        body = GetComponent<Rigidbody>();

        body.AddForce(transform.forward * flingAmt, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        CheckHit();
    }
    private void FixedUpdate()
    {
        if (body.velocity != Vector3.zero)
        {
            body.rotation = Quaternion.LookRotation(body.velocity);
        }

        

    }
    void CheckHit()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, damageRange))
        {
            
            if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("Enemy"))
            {
                Health healthScript = hit.collider.GetComponent<Health>();
                healthScript.TakeDamage(arrowDamage);
                Debug.Log("RaycastHit");
            }

        }

    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject != null)
        {

            Health healthScript = collision.gameObject.GetComponent<Health>();
            if (healthScript != null)
            {
                healthScript.TakeDamage(arrowDamage);
            }   


            Debug.Log("Hit");
            Collider arrowBox = GetComponent<Collider>();
            if (arrowBox.enabled)
            {
                Debug.Log("Collider hit: " + collision.gameObject);
                
                transform.parent = collision.transform;
                
                body.isKinematic = true;
                arrowBox.enabled = false;
            }

        }
        
    }
}
