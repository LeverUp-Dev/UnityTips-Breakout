using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    public GameObject bomb;
    float time = 5f;
    bool paused = false;

    void Start()
    {
        StartCoroutine("FiveToZero");
    }

    IEnumerator FiveToZero()
    {
        print(time);
        while(time > 0f)
        {
            yield return new WaitForSeconds(1f);
            --time;
            print(time);
            Flip();
            if(time <= 0f)
            {
                bomb.AddComponent<Rigidbody>().AddExplosionForce(1000, transform.position, 10f);
            }
        }
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.z *= -1f;
        transform.localScale = theScale;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
        }

        if(paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1f;
    }
}
