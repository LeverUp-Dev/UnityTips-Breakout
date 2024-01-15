using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expansion : MonoBehaviour
{
    [SerializeField] Transform[] childes; //Ȯ���ų ������Ʈ��

    Vector3[] nextPos; //Ȯ��� ��ġ
    Vector3[] initPos; //�ʱ���ġ

    public float scale = 4.0f;
    bool flag = false;

    void Start()
    {
        childes = GetComponentsInChildren<Transform>(); //0�� �ε����� �θ��� ��ġ�� �������� ������ ������ ��!!! 1������ �ڽ��� ��ġ����

        nextPos = new Vector3[childes.Length];
        initPos = new Vector3[childes.Length];

        for (int i = 1; i < childes.Length; i++)
        {
            initPos[i] = childes[i].position; //�ʱ�ȭ

            float distance = Vector3.Distance(childes[i].position, transform.position); //Ȯ���ų ������Ʈ���� �������� �Ÿ�
            Vector3 dir = (childes[i].position - transform.position).normalized; //������ ������Ʈ���� Ȯ��� ����(����ȭ�� ���� �������� �ʼ�!!)
            nextPos[i] = dir * distance * scale;
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            flag = !flag;
        }

        if (flag)
        {
            for (int i = 1; i < childes.Length; i++)
            {
                childes[i].position = Vector3.Lerp(childes[i].position, nextPos[i], 0.01f);
                childes[i].localScale = Vector3.Lerp(childes[i].localScale, Vector3.one * (scale/2), 0.05f);
            }
        }
        else
        {
            for (int i = 1; i < childes.Length; i++)
            {
                childes[i].position = Vector3.Lerp(childes[i].position, initPos[i], 0.01f);
                childes[i].localScale = Vector3.Lerp(childes[i].localScale, Vector3.one, 0.05f);
            }
        }
    }
}
