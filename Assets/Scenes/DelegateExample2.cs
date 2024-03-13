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
        Debug.Log($"{_coin}ȹ��!");
    }

    static void PlusPoint(int _point)
    {
        coin = _point;
        Debug.Log($"{_point}ȹ��!");
    }

    static void PlusExp(int _exp)
    {
        coin = _exp;
        Debug.Log($"{_exp}ȹ��!");
    }

    private void Start()
    {
        // ���� 100, ����Ʈ 50, ����ġ 500 ȹ��
        //PlusCoin(100);
        //PlusPoint(50);
        //PlusExp(500);


        // ��������Ʈ ü��
        // ��������Ʈ�� �Լ��� +, -�� ���� �߰� ���� ����. �߰��� ��� �߰� ������� �Լ� ȣ�� �� ����(�Լ� ���� ����)
        PlusDelegate killUint = PlusCoin;

        killUint += PlusPoint;
        killUint += PlusExp;

        killUint(100);
    }
}
