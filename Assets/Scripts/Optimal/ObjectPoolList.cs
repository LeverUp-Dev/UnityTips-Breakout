using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolList : MonoBehaviour
{
    public GameObject objectPrefab;
    int maxLength = 10;
    List<GameObject> objectPool;

    void Start()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < maxLength; i++)
        {
            GameObject tempOBJ = Instantiate(objectPrefab);
            tempOBJ.name = "OBJ" + i;
            tempOBJ.transform.parent = transform;
            tempOBJ.SetActive(false);
            objectPool.Add(tempOBJ);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            foreach (GameObject obj in objectPool)
            {
                if (obj.activeSelf == false)
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
