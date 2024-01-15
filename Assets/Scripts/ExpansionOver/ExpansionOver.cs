using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpansionOver : MonoBehaviour
{
    [SerializeField] List<Transform> childes = new List<Transform>();
    List<Vector3> nextPos = new List<Vector3>();
    List<Vector3> initPos = new List<Vector3>();

    [Range(1.0f, 10.0f)] public float scale = 4.0f;

    [Range(1.0f, 30.0f)] public float expansionObjectRange = 10.0f; //Ư�� �������κ��� �ҷ��� ������Ʈ Ž�� ����

    bool flag = false;

    void Start()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, expansionObjectRange); //������ ExpansionController ������Ʈ�� ��

        foreach (Collider col in cols)
        {
            childes.Add(col.transform);
        }

        foreach (Transform iPos in childes)
        {
            initPos.Add(iPos.position);

            float distance = Vector3.Distance(transform.position, iPos.position);
            Vector3 dir = (iPos.position - transform.position).normalized;
            nextPos.Add(dir * distance * scale);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, expansionObjectRange);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            flag = !flag;
        }

        if (flag)
        {
            int i = 0;
            foreach (Transform child in childes)
            {
                child.position = Vector3.Lerp(child.position, nextPos[i++], 0.01f);
                child.localScale = Vector3.Lerp(child.localScale, Vector3.one * (scale/2), 0.05f);
            }
        }
        else
        {
            int i = 0;
            foreach (Transform child in childes)
            {
                child.position = Vector3.Lerp(child.position, initPos[i++], 0.01f);
                child.localScale = Vector3.Lerp(child.localScale, Vector3.one, 0.05f);
            }
        }
    }
}
