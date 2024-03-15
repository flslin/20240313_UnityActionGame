using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �Ϲ� �˾�, Ȯ�� �˾� �����ϴ� DialogControllerAlert, DialogControllerConfirm�� �θ� Ŭ����
public class DialogController : MonoBehaviour
{
    public Transform window; // �˾�â Ʈ������

    public bool Visible
    {
        get
        {
            return window.gameObject.activeSelf;
            // �ش� ������Ʈ�� Ȱ��ȭ ���� �Ǵ��ϴ� �б� ���� ��
        }

        private set
        {
            window.gameObject.SetActive(value); // Visible�� ����� ���� Ȱ��ȭ ó�� �ڵ�. �ܺ� ���� �Ұ���
        }
    }

    // ���� �Լ� : �ڽ��ʿ��� �������̵� �� ���� ����� ��� ���� Ű����
    public virtual void Awake() { }

    public virtual void Start() { }

    public virtual void Build(DialogData data) { }


    public void Show(Action callback)
    {
        // �˾��� ȭ�鿡 ��Ÿ����
        StartCoroutine(OnEnter(callback));
    }

    public void Close(Action callback)
    {
        // �˾��� ȭ�鿡�� �������
        StartCoroutine(OnExit(callback));
    }

    // ���޹��� ��� ����
    IEnumerator OnEnter(Action callback)
    {
        Visible = true;

        if (callback != null)
        {
            callback();
        }
        yield break; // �۾� ����
    }

    IEnumerator OnExit(Action callback)
    {
        Visible = false;

        if (callback != null)
        {
            callback();
        }
        yield break; // �۾� ����
    }
}
