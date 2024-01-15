using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1);
    }
}
