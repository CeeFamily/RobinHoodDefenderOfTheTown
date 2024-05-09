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
        GetComponentInParent<FireArrow>();

        body = GetComponent<Rigidbody>();

        body.AddForce(transform.forward * flingAmt, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //CheckHit();
    }
    void CheckHit()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, damageRange))
        {
            Debug.DrawRay(transform.position, transform.forward * damageRange, Color.blue);
            if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("Enemy"))
            {
                Health healthScript = hit.collider.GetComponent<Health>();
                healthScript.TakeDamage(arrowDamage);
                Debug.Log("Hit");
                

            }

        }

    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Health healthScript = collision.gameObject.GetComponent<Health>();
            healthScript.TakeDamage(arrowDamage);
            Debug.Log("Hit");
            Collider arrowBox = GetComponent<Collider>();
            if (arrowBox != null)
            {
                transform.SetParent(collision.transform);
                body.isKinematic = true;
                arrowBox.enabled = false;
            }

        }
        
    }
}
