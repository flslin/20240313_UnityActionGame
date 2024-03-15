using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DialogDataAlert : DialogData
{
    public string Title { get; private set; } // 읽기 전용

    public string Message { get; private set; }

    // 유니티에서 사용 하는 delegate Action
    // 유저가 확인버튼 눌렀을 때 호출되는 콜백 함수 저장
    public Action Callback { get; private set; }

    // Action callback = null 매개 변수 생략 가능
    // default parameter 매개변수에 값을 초기화해두는 것으로
    // 함수 호출시에 해당 값을 넣지 않고 호출하는 경우 설정해둔 초기값으로 자동으로 처리
    public DialogDataAlert(string title, string message, Action callback = null) : base(DialogType.Alert)
    {
        Title = title;
        Message = message;
        Callback = callback;
    }
}

