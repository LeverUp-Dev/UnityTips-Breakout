using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    Rigidbody rb;

    public float ballSpeed = 1000;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.GetComponent<SphereCollider>().enabled = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.parent = null;
            rb.AddForce(ballSpeed, ballSpeed, 0);
        }
    }
}
