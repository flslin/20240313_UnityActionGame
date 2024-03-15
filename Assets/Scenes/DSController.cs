using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// 이벤트 트리거로 전달
public class DSController : MonoBehaviour
{
    public Text ResultText; // 사용한 결과를 출력할 텍스트

    // 배열 사용
    public void DSArray()
    {
        // 배열 생성 - 자료형[] 배열명 = new 자료형[배열 길이]
        int[] exp = new int[10];

        for (int i = 0; i < exp.Length; i++)
        {
            exp[i] = i * 100 + (i * 50);
            ResultText.text += $"[DSArray] 다음 레벨{i} 까지 요구 경험치 {exp[i]} \n";
        }
    }

    public void DSList()
    {
        // List<T> 리스트명 = new List<T>();
        List<int> exp = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            exp.Add(i * 100 + (i * 50));
        }

        //exp.RemoveAll(x => (x % 4) == 0); // 4의 배수 삭제
        exp.Sort((a, b) => b.CompareTo(a));

        for (int i = 0; i < exp.Count; i++)
        {
            ResultText.text += $"[DSList] 다음 레벨{i} 까지 요구 경험치 {exp[i]} \n";
        }
    }

    // C#에서 사용되는 리스트 문법
    // 1. Add(값) : 해당 값을 리스트에 추가
    // 2. Remove(값) : 해당 값을 리스트에서 제거
    // 3. Insert(위치, 값) : 리스트의 해당 위치에 값 제거
    // 4. Contains(값) : 리스트가 해당 값을 가지고 있는지 판단 (bool)
    // 5. Clear() : 리스트의 모든 값 제거
    // 6. Reverse() : 요소를 역순 정렬
    // 7. RemoveAll(조건식) : 해당 조건을 만족하는 모든 요소 삭제
    // 8. Sort() : 오름차순 정렬
    // 9. Sort((a, b) => b.CompareTo(a)) : 내림차순

    public void DSDictonary()
    {
        // Dictionary<K, V> 딕셔너리명 = new Dictionary<K, V>();
        // 생성 및 초기화
        Dictionary<string, int> items = new Dictionary<string, int>
        {
            {"red apple", 10}, {"blue apple", 10}, {"meat", 100}
        };

        // 기능 추가
        items.Add("cake", 20);

        if (items.ContainsKey("cake"))
        {
            items.Remove("blue apple");
        }

        if (items.ContainsValue(100))
        {
            Debug.Log("값이 돈재합ㄴ다");
        }

        // 딕셔너리 핵심
        // 1. 키를 이용한 값에 대한 접근
        // 2. 해당 키가 존재하는가 여부
        // 3. 키, 값을 각각 분할해 보관할 수 있는가(리스트 변환)
        // 4. 딕셔너리는 키의 경우에는 중복을 허용하지 않고, 값은 중복을 허용
        // Add 진행 시, 기존에 있는 키를 다시 Add하는 경우 그 키가 가진 값만 변경

        // 딕셔너리 키 -> 리스트로 바꾸는 기능
        var KList = new List<string>(items.Keys);

        // 딕셔너리 값 -> 리스트로 바꾸는 기능
        var VList = new List<int>(items.Values);

        // 리스트 -> 딕셔너리
        // 1. 키와 값이 될 리스트 준비
        var KtoD = new List<string>() { "a", "b", "c", "d", "e" };
        var VtoD = new List<int>() { 1, 2, 3, 4, 5 };

        // 2. 리스트를 생성하고 Zip함수 호출
        // 키.Zip(값, (k,v) => new {k,v}) 키와 값이 {키, 값}의 형태로 변함
        // ToDictionary에 의해 키와 값을 설정하고 딕셔너리 형태로 반환
        var newDictonary = KtoD.Zip(VtoD, (k, v) => new {k, v}).ToDictionary(a => a.k, a => a.v);
    }

    public void DSResultReset()
    {
        ResultText.text = "";
    }
}
