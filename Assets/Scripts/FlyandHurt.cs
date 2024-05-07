using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyandHurt : MonoBehaviour
{
    Rigidbody body;
    public float flingAmt = 20f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.AddForce(Vector3.forward * flingAmt,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
