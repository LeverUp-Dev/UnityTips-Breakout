using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float x;
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        x = transform.position.x + Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        transform.position = new Vector3(Mathf.Clamp(x, -5.5f, 5.5f), -9.5f, 0);
    }
}
