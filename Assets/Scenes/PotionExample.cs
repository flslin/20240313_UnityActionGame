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
            Debug.Log("포션 사용");
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

            yield return null; // null을 넘기면 한프레임이 넘어감
        }
        // 코루틴이 끝나기전까진 돌아가지 않아 충돌 위험 없음
        Debug.Log("쿨타임 끗");
        GetComponent<Image>().color = Color.red;
        GetComponent<Image>().fillAmount = 1.0f;
        coolTime = coolTimeMax;
        isUse = false;
    }
}
