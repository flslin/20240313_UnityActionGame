using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionExample : MonoBehaviour
{
    public bool isUse;
    public float coolTime = 10.0f;
    public float coolTimeMax = 10.0f;

    public void OnPotionDown()
    {
        if (isUse == false)
        {
            Debug.Log("���� ���");
            StartCoroutine(CoolTimeCheck());
        }
    }

    IEnumerator CoolTimeCheck()
    {
        while (coolTime > 0.0f)
        {
            GetComponent<Image>().color = Color.black;
            isUse = true;

            coolTime -= Time.deltaTime;
            GetComponent<Image>().fillAmount = coolTime / coolTimeMax;

            yield return null; // null�� �ѱ�� ���������� �Ѿ
        }
        // �ڷ�ƾ�� ������������ ���ư��� �ʾ� �浹 ���� ����
        Debug.Log("��Ÿ�� ��");
        GetComponent<Image>().color = Color.red;
        GetComponent<Image>().fillAmount = 1.0f;
        coolTime = coolTimeMax;
        isUse = false;
    }
}
