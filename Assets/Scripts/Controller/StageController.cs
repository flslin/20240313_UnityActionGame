using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 스테이지 관리 컨트롤러
// 스테이지 시작과 마감을 처리하는 기능
// 스테이지 내에서 획득하는 포인트를 관리
public class StageController : MonoBehaviour
{
    public int stagePoint = 10; // 스테이지에서 획득한 포인트 저장

    public Text PointText; // 포인트 표시용

    public static StageController instance; // 스테이지 컨트롤러의 인스턴스를 저장하는 static변수
    // 다른코드 내에서 StageController.instance.AddPoint(10)과 같은 형태로 사용 가능


    public void Awake()
    {
        instance = this;
    }

    public void AddPoint(int point)
    {
        stagePoint += point;
        PointText.text = stagePoint.ToString();
    }

    public void FinishGame()
    {
        //Application.LoadLevel(Application.loadedLevel); // 옛날 코드(현재는 사용안함)
        SceneManager.LoadScene("Game");
    }
}
