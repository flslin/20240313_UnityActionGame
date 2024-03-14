using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTarget : MonoBehaviour
{
    public List<Collider> targetList; // 타겟 리스트

    // Use this for initialization
    void Start()
    {
        targetList = new List<Collider>();
    }

    // 트리거 충돌시 리스트에 타겟 등록
    private void OnTriggerEnter(Collider other)
    {
        targetList.Add(other);
    }
    // 트리거 충돌이 끝나면 명단에서 타겟 제거
    private void OnTriggerExit(Collider other)
    {
        targetList.Remove(other);
    }
}
