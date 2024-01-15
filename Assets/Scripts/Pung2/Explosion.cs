using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float expPower;
    public Vector3 offset;

    public void CastingExplosion()
    {
        Rigidbody[] rigids = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rigids.Length; i++)
        {
            rigids[i].AddExplosionForce(expPower, transform.position + offset, 10f);
        }
    }
}
