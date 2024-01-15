using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectPrefab;
    int maxLength = 10;
    GameObject[] objectPool;

    void Start()
    {
        objectPool = new GameObject[maxLength];

        for (int i = 0; i < maxLength; i++)
        {
            objectPool[i] = Instantiate(objectPrefab);
            objectPool[i].name = "OBJ" + i;
            objectPool[i].transform.parent = transform;
            objectPool[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            foreach (GameObject obj in objectPool)
            {
                if(obj.activeSelf == false)
                {
                    obj.transform.position = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
                    obj.SetActive(true);
                    StartCoroutine(DeadCondition(obj));
                    break;
                }
            }
        }
    }

    IEnumerator DeadCondition(GameObject obj)
    {
        yield return new WaitForSeconds(Random.Range(3, 6));

        obj.SetActive(false);
    }
}
