using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateExample2 : MonoBehaviour
{
    static int coin = 0;
    static int point = 0;
    static int exp = 0;

    public delegate void PlusDelegate(int _num);


    static void PlusCoin(int _coin)
    {
        coin = _coin;
        Debug.Log($"{_coin}획득!");
    }

    static void PlusPoint(int _point)
    {
        coin = _point;
        Debug.Log($"{_point}획득!");
    }

    static void PlusExp(int _exp)
    {
        coin = _exp;
        Debug.Log($"{_exp}획득!");
    }

    private void Start()
    {
        // 코인 100, 포인트 50, 경험치 500 획득
        //PlusCoin(100);
        //PlusPoint(50);
        //PlusExp(500);


        // 델리게이트 체인
        // 델리게이트에 함수를 +, -를 통해 추가 제거 가능. 추가할 경우 추가 순서대로 함수 호출 시 실행(함수 동시 실행)
        PlusDelegate killUint = PlusCoin;

        killUint += PlusPoint;
        killUint += PlusExp;

        killUint(100);
    }
}
