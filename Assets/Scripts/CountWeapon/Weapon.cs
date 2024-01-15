using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    int index = 0;

    void Start()
    {
        SelectWeapon(index);
    }

    void SelectWeapon(int index)
    {
        for (int i = 0; i < transform.childCount - 3; i++)
        {
            if(i == index)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            SelectWeapon(0);
        }
        else if(Input.GetKeyDown("2"))
        {
            SelectWeapon(1);
        }
        else if(Input.GetKeyDown("3"))
        {
            SelectWeapon(2);
        }
    }
}
