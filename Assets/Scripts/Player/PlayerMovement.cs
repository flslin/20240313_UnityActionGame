using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] // 제약. 애니메이터에 대한 요구. 반드시 필요함. 없을 경우 자동 추가.
// Animator를 에디터에서 컴포넌트 제거 할 수 없음
//만약 Animator 컴포넌트가 없다면 게임 실행 안함.
public class PlayerMovement : MonoBehaviour
{
    protected Animator avatar;
    float h, v;

    // 애니메이션 진행된 시간 체크용 변수
    float lastAttackTime, lastSkillTime, lastDashTime;

    [Header("Animation Condition"/* Flag"*/)]
    public bool attacking = false;
    public bool dashing = false;

    // Start is called before the first frame update
    void Start()
    {
        avatar = GetComponent<Animator>();
    }

    /// <summary>
    /// 방향 컨트롤러에서 컨트롤러의 변경이 일어날 경우 호출할 함수
    /// </summary>
    /// <param name="stickpos">스틱의 좌표</param>
    public void OnStickChange(Vector2 stickpos)
    {
        h = stickpos.x;
        v = stickpos.y;
    }

    // Update is called once per frame
    void Update()
    {

        avatar.SetFloat("Speed", (h * h + v * v));
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb)
        {
            if (h != 0.0f && v != 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(new Vector3(h, 0.0f, v));
                // 해당 벡터 방향을 바라보는 회전 상태를 반환
            }
        }

    }
}
