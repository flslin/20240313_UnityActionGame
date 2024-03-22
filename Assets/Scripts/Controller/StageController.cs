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
    #region  Field
    public int stagePoint = 10; // 스테이지에서 획득한 포인트 저장

    public Text PointText; // 포인트 표시용
    #endregion

    #region Singleton
    public static StageController instance; // 스테이지 컨트롤러의 인스턴스를 저장하는 static변수
                                            // 다른코드 내에서 StageController.instance.AddPoint(10)과 같은 형태로 사용 가능

    // 2024.03.15 Awake -> Start로 변경
    public void Start()
    {
        instance = this;
        // 안내창 값 설정
        DialogDataAlert alert = new DialogDataAlert("게임 시작", "슬라임을 모두 처치하세요!", delegate () { Debug.Log("OK를 눌렀습니다!"); });
        // 매니저에 등록
        DialogManager.Instance.Push(alert);
    }
    #endregion

    public void AddPoint(int point)
    {
        stagePoint += point;
        PointText.text = stagePoint.ToString();
    }

    public void FinishGame()
    {
        //Application.LoadLevel(Application.loadedLevel); // 옛날 코드(현재는 사용안함)
        DialogDataConfirm confirm = new DialogDataConfirm("재시작", "재시작 하시겠습니깤ㅋㅋㅋㅋ?",
        delegate (bool yn)
        {
            if (yn)
                SceneManager.LoadScene("Game");
            else
                Application.Quit();

        });

        DialogManager.Instance.Push(confirm);
    }
}

