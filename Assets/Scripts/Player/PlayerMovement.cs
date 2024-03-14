using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] // 제약. 애니메이터에 대한 요구. 반드시 필요함. 없을 경우 자동 추가.
// Animator를 에디터에서 컴포넌트 제거 할 수 없음
//만약 Animator 컴포넌트가 없다면 게임 실행 안함.
public class PlayerMovement : MonoBehaviour
{
    protected Animator avatar;
    protected PlayerAttack playerAttack; // 2024.03.14 플레이어 공격 기능 추가
    float h, v;

    // 애니메이션 진행된 시간 체크용 변수
    float lastAttackTime, lastSkillTime, lastDashTime;

    [Header("Animation Condition Flag")]
    public bool attacking = false;
    public bool dashing = false;

    // Start is called before the first frame update
    void Start()
    {
        avatar = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
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
        if (avatar)
        {
            float back = 1.0f;
            if (v < 0.0f)
            {
                back = -1.0f;
            }

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

    #region EventTrigger
    public void AttackDown()
    {
        attacking = true;
        avatar.SetBool("Combo", true);
        StartCoroutine(StartAttack()); // 코루틴 작동
        //StartCoroutine("StartAttack");

        // Coroutine - Update가 아닌 영역에서 반복적으로 코드가 실행되어야 할 때 사용함
        // Update에서 무분별하게 돌리는 코드를 코루틴으로 전환하면 자원 관리에 효과적.
        // 일정 시간 멈춘 후에 움직이는 작업, 특정 조건을 부여해 코드를 실행하는 작업에 용이.
        // IEnumerator 형태의 함수로 시작, 해당 함수 내에는 yield return문이 반드시 존재해야함.
    }

    public void AttackUp()
    {
        avatar.SetBool("Combo", false);
        attacking = false;
    }

    IEnumerator StartAttack()
    {
        if (Time.time - lastAttackTime > 1.0f)
        {
            lastAttackTime = Time.time;
            while (attacking)
            {
                avatar.SetTrigger("AttackStart");
                playerAttack.NormalAttack(); // 2024.03.14 플레이어 어택의 일반공격 호출
                yield return new WaitForSeconds(1.0f); // yield문은 다음 요소를 제공하는 키워드
            }
        }
    }

    /// <summary>
    /// 버튼 2번 누를 때 스킬
    /// </summary>
    public void OnSkillDown()
    {
        if(Time.time - lastSkillTime > 1.0f)
        {
            avatar.SetBool("Skill", true);
            lastSkillTime = Time.time;
            playerAttack.SkillAttack(); // 2024.03.14 스킬 어택 추가
        }
    }

    public void OnSkillUp()
    {
        avatar.SetBool("Skill", false);
    }

    /// <summary>
    /// 버튼 1번 누를 때 스킬
    /// </summary>
    public void OnDashDown()
    {
        if (Time.time - lastDashTime > 1.0f)
        {
            lastDashTime = Time.time;
            dashing = true;
            avatar.SetTrigger("Dash");
            playerAttack.DashAttack(); // 2024.03.14 대쉬 어택 추가
        }
    }

    public void OnDashUp()
    {
        dashing = false;
    }

    #endregion
}
