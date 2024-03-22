using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

// 알림창
public class DialogControllerAlert : DialogController
{
    public Text LabelTitle; // 제목
    public Text LabelMessgae; // 내용

    // 클래스에서 사용할 알림창의 데이터 객체 선언
    DialogDataAlert Data {  get; set; }

    // 버튼 클릭 시 처리할 함수
    public void OnClickOK()
    {
        if (Data != null && Data.Callback != null)
        {
            Data.Callback();
        }

        // 작업이 끝난 후 현재의 팝업창을 관리자에서 제거
        DialogManager.Instance.Pop();
    }

    public override void Awake()
    {
        base.Awake();
    }

    public override void Build(DialogData data)
    {
        base.Build(data);

        if (!(data is DialogDataAlert))
        {
            Debug.LogError("Invaild dialog data!"); // 에러 메세지 출력
            return; // 작업 종료
        }

        // 데이터를 안내 데이터로 받아옴
        Data = data as DialogDataAlert; // 상위클래스 에서 하위클래스로 변형할 때 쓰는 코드
        // 텍스트 값에 데이터 속성을 적용
        LabelTitle.text = Data.Title;
        LabelMessgae.text = Data.Message;
    }

    public override void Start()
    {
        base.Start();
    }

    public DialogControllerAlert()
    {
        DialogManager.Instance.Regist(DialogType.Alert, this); // 인스턴스를 통해 Alert 타입의 컨트롤러를 다루고 있음을 등록
    }
}

