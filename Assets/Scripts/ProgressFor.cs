using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressFor : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    public Vector3 EndGoal;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.MovePosition(transform.position + Vector3.right * moveSpeed);
    }
}
