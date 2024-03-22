using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// �̺�Ʈ : ��ü���� �۾� ������ �˸��� ���� ������ �޼���
// �̺�Ʈ �ܺ� ������(Subscirber)���� Ư�� ���� �˷��ִ� ����� ��

// EventHandler(�̺�Ʈ �ڵ鷯) : �����ڰ� �̺�Ʈ�� �߻��� ��� � ����� ���� ���� ������ �ִ°�
// +=�� ���� �̺�Ʈ�� ���� �߰��� �����ϸ�, -=�� ���� ����
// �̺�Ʈ �߻� �� �߰��� �ڵ鷯�� ���������� ȣ���

class ClickEvent
{
    public event EventHandler Click;

    public void MouseButtonDown()
    {
        if (Click != null)
        {
            Click(this, EventArgs.Empty);
            // EventArgs �̺�Ʈ ���� �� �Ķ���ͷ� �����͸� �ް� ���� ��� �ش� Ŭ������ ��� �޾� ���
            // EventArgs�� �̺�Ʈ �߻��� ���õ� ������ ������ ����. �̺�Ʈ �ڵ鷯�� ����ϴ� �Ķ���� ��.
        }
    }
}

public class UnityEventExample : MonoBehaviour
{
    ClickEvent clickEvent;

    // Start is called before the first frame update
    void Start()
    {
        clickEvent = new ClickEvent();
        clickEvent.Click += new EventHandler(ButtonClick);
    }

    private void ButtonClick(object sender, EventArgs e)
    {
        Debug.Log("���� Ʋ��");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            clickEvent.MouseButtonDown();
        }
    }
}
