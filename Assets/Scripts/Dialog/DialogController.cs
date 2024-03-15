using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 일반 팝업, 확인 팝업 관리하는 DialogControllerAlert, DialogControllerConfirm의 부모 클래스
public class DialogController : MonoBehaviour
{
    public Transform window; // 팝업창 트랜스폼

    public bool Visible
    {
        get
        {
            return window.gameObject.activeSelf;
            // 해당 오브젝트의 활성화 유무 판단하는 읽기 전용 값
        }

        private set
        {
            window.gameObject.SetActive(value); // Visible의 결과에 따라 활성화 처리 코드. 외부 간섭 불가능
        }
    }

    // 가상 함수 : 자식쪽에서 오버라이딩 할 것이 예상될 경우 쓰는 키워드
    public virtual void Awake() { }

    public virtual void Start() { }

    public virtual void Build(DialogData data) { }


    public void Show(Action callback)
    {
        // 팝업이 화면에 나타날때
        StartCoroutine(OnEnter(callback));
    }

    public void Close(Action callback)
    {
        // 팝업이 화면에서 사라질때
        StartCoroutine(OnExit(callback));
    }

    // 전달받은 기능 실행
    IEnumerator OnEnter(Action callback)
    {
        Visible = true;

        if (callback != null)
        {
            callback();
        }
        yield break; // 작업 종료
    }

    IEnumerator OnExit(Action callback)
    {
        Visible = false;

        if (callback != null)
        {
            callback();
        }
        yield break; // 작업 종료
    }
}
