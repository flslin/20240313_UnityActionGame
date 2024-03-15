using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 객체 지향 프로그래밍 (OOP)
// 기존의 방식 : 프로그램은 명령어들의 집합
// 객체 지향식 설계 : 프로그램은 객체들의 모임

// 클래스 : 객체 지향 프로그램의 기본 구성요소이자 사용자 정의 데이터 타입
// -> 변수와 함수를 같이 저장 할 수 있는 자료구조
// 객체 : 클래스가 실제로 메모리 상에 할당된 인스턴트
// 필드 : 클래스 내부에 설계된 변수, 객체의 속성을 표현
// 메소드 : 클래스 내부에 설계된 함수, 객체의 기능, 동작을 표현

// 객체 지향 설계의 목적(특징)
// 1. 캡슐화 : 클래스 내부의 서로 연관되어 있는 속성과 기능을 하나의 캡슐처럼 만들어
//            데이터가 외부로 노출되는 것을 방지하는 설계법

// 2. 상속 : class 자식클래스명 : 부모클래스명의 형태로 설계
// 부모 클래스가 가진 모든 변수와 함수를 상속받고 그 기능을 사용가능
// 상황에 맞게 재정의하여 새로운 기능으로 만들어주는 것도 가능

// 3. 다형성 : 같은 이름의 변수, 함수여도 상황에 따라 다른 의미로 사용 될 수 있음(조건에 따라 다르게 수행)

/*자료 구조 (Data Struct)
효율적인 접근과 수정을 가능하게하는 자료의 조직, 관리, 저장, 데이터 값의 모임, 데이터의 관계 등을 종합해 일컫는 말

유형별 정리
T는 타입, K는 키, V는 값을 의미
명칭                       용도
LinkedList<T>           데이터의 등록과 삭제가 빈번한 경우 사용
List<T>                 데이터가 저장된 순서(인덱스)를 빠르게 탐색 가능
Stack<T>                데이터를 후입선출(LIFO) 방식으로 사용
Queue<T>                데이터를 선입선출(FIFO) 방식으로 사용
Dictionary<K, V>        특정 Key를 이용해 특정 값을 조회할 때 사용
HashSet<T>              중복되지 않은 데이터를 저장할 때 사용 (수작적으로 집합의 개념 표현시)
T[]                     데이터가 인덱스에 의해 관리되며 메모리상에 연속적으로 저장됨
                        고정된 크기를 가지고 있고, 추가 소모되는 메모리 없이 크기에 맞게 제공
                        유니티 에디터 상에서는 배열과 리스트느 동일하게 취급되나 
                        스크립트 작업 시에는 배열과 리스트의 사용법이 다름

자료구조별 알고리즘 단계의 수 파악
데이터 원소 N개에 대한 알고리즘의 단계 수를 파악하면 해당 자료구조의 속도 판단 가능
O(1) :     데이터의 증가, 감소에 영항을 받지 않음
O(n) :     데이터 추가 당 알고리즘이 1단계씩 증가, 데이터양에 비례
O(log n) : 아주 조금씩 증가하는 형태의 곡선, 데이터 약 두배 정도 증가에 1단계 늘어남

효율 O(1) > O(log n) > O(n)
O(1)은 O(log n)과 비등하다가 데이터 개수가 약 100개 넘어가면 O(1)이 효율적

    명칭              추가      검색      삭제      인덱스로 인한 접근
LinkedList<T>        O(1)     O(n)     O(n)           O(n)
List<T>              O(1)     O(n)     O(n)           O(1)
Stack <T>            O(1)      -       O(1)            - 
Queue<T>             O(1)      -       O(1)            - 
Dictionary<K, V>     O(1)     O(1)     O(1)            - (키를 인덱스 처럼 사용)
HashSet<T>           O(1)     O(1)     O(1)            -
T[] O(n)     O(n)     O(n)           O(1)
배열의 경우 추가 검색 삭제의 기능이 없어 로직을 짜서 실행 해야함
배열은 다 만들어진 고정형 데이터에 대한 불필요한 메모리 낭비를 막기위해 사용하는 경우가 가장 좋음 */

public class OOPExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
