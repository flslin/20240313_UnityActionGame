using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Delegate
// c/c++ �Լ� �����Ϳ� ����� ����
// ��������Ʈ�� �Լ�Ÿ�Կ� ���� ���Ǹ� �����ϰ� �Ű������� ���� ���踦 ���� �� ���
// ���� Ÿ��, ���� �Ű������� ���� �޼ҵ带 �ҷ��� ����� �� �ִ� ���� (�븮��)

public class DelegateExample : MonoBehaviour
{
    // 1. delegate ����
    delegate void DelegateTest();

    // 2. delegate�� ������ ���¿� ������ �Լ��� ����
    void DelegateTest01()
    {
        Debug.Log("�븮�� �׽�Ʈ1");
    }

    void DelegateTest02()
    {
        Debug.Log("�븮�� �׽�Ʈ2");
    }

    // Start is called before the first frame update
    void Start()
    {
        // ��������Ʈ ���� - ��������Ʈ ������ = new ��������Ʈ��(�Լ���);
        DelegateTest delegateTest = new DelegateTest(DelegateTest01);

        // ��������Ʈ ȣ��
        delegateTest();

        delegateTest = DelegateTest02; // ��������Ʈ�� ó���� �Լ� ����

        delegateTest();
    }
    // ��� ���� - 
}
