using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Delegate
// c/c++ 함수 포인터와 비슷한 개념
// 델리게이트로 함수타입에 대한 정의를 진행하고 매개변수에 대한 설계를 진행 할 경우
// 같은 타입, 같은 매개변수를 가진 메소드를 불러서 사용할 수 있는 도구 (대리자)

public class DelegateExample : MonoBehaviour
{
    // 1. delegate 선언
    delegate void DelegateTest();

    // 2. delegate로 선언한 형태와 동일한 함수를 구현
    void DelegateTest01()
    {
        Debug.Log("대리자 테스트1");
    }

    void DelegateTest02()
    {
        Debug.Log("대리자 테스트2");
    }

    // Start is called before the first frame update
    void Start()
    {
        // 델리게이트 생성 - 델리게이트 변수명 = new 델리게이트명(함수명);
        DelegateTest delegateTest = new DelegateTest(DelegateTest01);

        // 델리게이트 호출
        delegateTest();

        delegateTest = DelegateTest02; // 델리게이트로 처리할 함수 변경

        delegateTest();
    }
    // 사용 목적 - 
}
