using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    public event EventHandler OnButton;
    public Text text;
    public int check = 100;

    // Start is called before the first frame update
    void Awake()
    {
        OnButton += buttonClick;
    }

    private void buttonClick(object sender, EventArgs e)
    {

        text.text += "�����մϴ�! 100��° ���� �����Դϴ�!" + "�̺�Ʈ�� ��÷�ƽ��ϴ�!";

    }

    // Update is called once per frame
    void Update()
    {
        if (check == 100)
        {

            OnButton?.Invoke(this, EventArgs.Empty);

        }
    }

    //IEnumerator TypingText(string message)
    //{
    //    messgaeT.text = null;

    //    for(int i = 0; i < Message.Length; i++)
    //    {
    //        message.text += message[i];
    //        yield return new WaitForSeconds(1.0f);

    //    }
    //}
}
