using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 다이얼로그 종류를 구분하는 enum변수
/// </summary>
public enum DialogType
{
    Alert, Confirm, Ranking
}

// 상속 받지 못하게 제한
// 런타임 시 특정함수 호출 경우 부모, 자식 클래스 전체 조사해 최종적으로 사용할 함수를 찾음
// sealed 처리된 클래스는 이 과정을 생략함
public sealed class DialogManager
{
    List<DialogData> _dialogQueue;
    Dictionary<DialogType, DialogController> _dialogMap;
    DialogController _currentDialog; // 현재 사용중인 다이얼로그(대화창)

    #region Singleton
    // 자기자신에 대한 static 변수 생성
    private static DialogManager instance = new DialogManager();

    // 프로퍼티를 통해 접근
    public static DialogManager Instance
    {
        get {
            return instance;
        }
    }
    // 생성시 다이얼로그 큐와 맵을 초기화
    private DialogManager()
    {
        _dialogQueue = new List<DialogData>();
        _dialogMap = new Dictionary<DialogType, DialogController>();
    }
    #endregion

    public void Regist(DialogType type, DialogController controller)
    {
        // 딕셔너리명[키] = 값;
        // 해당키를 가진 값이 만들어짐 (키:값)
        _dialogMap[type] = controller;
        //_dialogMap.Add(type, controller);
    }

    // 다이얼로그 리스트 저장하는 다이얼로그 큐에 새로운 다이얼로그 데이터를 추가하는 행위(로 만듦)
    public void Push(DialogData data) // 데이터를 최상단에 저장
    {
        _dialogQueue.Add(data);

        if (_currentDialog == null)
        {
            ShowNext();
        }
    }

    // 리스트에서 마지막으로 열린 다이얼로그를 닫는 기능()
    public void Pop() // 최상단 데이터 삭제
    {
        if(_currentDialog != null)
        {
            // 익명 delegate. delegate(매개 변수 목록) {실행 하고자 하는 코드}; 형식으로 작성하면 델리게이트로 작동
            // 함수 이름없이 기능만 델리게이트에 할당하기 위한 수단
            _currentDialog.Close( 
                delegate
                {
                    _currentDialog = null;
                    if (_dialogQueue.Count > 0 )
                    {
                        ShowNext();
                    }
                });
        }
    }

    private void ShowNext()
    {
        // 다이얼로그를 리스트에서 첫번째 값을 가져옴
        var next = _dialogQueue[0];

        // 가져온 값이 어떤 컨트롤러인지 형태 확인
        DialogController controller = _dialogMap[next.Type].GetComponent<DialogController>();

        // 조회한 다이얼로그 컨트롤러를 현재의 다이얼로그 컨트롤러로 지정
        _currentDialog = controller;

        // 현재의 다이얼로그를 빌드
        _currentDialog.Build(next);

        // 다이얼로그를 화면에 보여줌
        _currentDialog.Show(delegate { });

        // 다이얼로그 리스트에서 꺼내온 데이터 제거
        _dialogQueue.RemoveAt(0); // 첫번째 값 제거
    }

    // 현재 팝업창이 표시되고 있는지를 확인 하는 변수
    // _current가 비어있는 경우는 없다고 판단
    public bool isShowing() => _currentDialog != null;
}

