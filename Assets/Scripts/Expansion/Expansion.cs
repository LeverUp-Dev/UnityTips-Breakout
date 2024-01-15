using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expansion : MonoBehaviour
{
    [SerializeField] Transform[] childes; //확장시킬 오브젝트들

    Vector3[] nextPos; //확장될 위치
    Vector3[] initPos; //초기위치

    public float scale = 4.0f;
    bool flag = false;

    void Start()
    {
        childes = GetComponentsInChildren<Transform>(); //0번 인덱스는 부모의 위치를 가져오기 때문에 주의할 것!!! 1번부터 자식의 위치값임

        nextPos = new Vector3[childes.Length];
        initPos = new Vector3[childes.Length];

        for (int i = 1; i < childes.Length; i++)
        {
            initPos[i] = childes[i].position; //초기화

            float distance = Vector3.Distance(childes[i].position, transform.position); //확장시킬 오브젝트들의 원점과에 거리
            Vector3 dir = (childes[i].position - transform.position).normalized; //각각의 오브젝트들이 확장될 방향(정규화로 힘은 뺴버리자 필수!!)
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
