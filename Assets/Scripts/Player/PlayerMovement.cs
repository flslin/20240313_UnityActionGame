using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] // ����. �ִϸ����Ϳ� ���� �䱸. �ݵ�� �ʿ���. ���� ��� �ڵ� �߰�.
// Animator�� �����Ϳ��� ������Ʈ ���� �� �� ����
//���� Animator ������Ʈ�� ���ٸ� ���� ���� ����.
public class PlayerMovement : MonoBehaviour
{
    protected Animator avatar;
    protected PlayerAttack playerAttack; // 2024.03.14 �÷��̾� ���� ��� �߰�
    float h, v;

    // �ִϸ��̼� ����� �ð� üũ�� ����
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
    /// ���� ��Ʈ�ѷ����� ��Ʈ�ѷ��� ������ �Ͼ ��� ȣ���� �Լ�
    /// </summary>
    /// <param name="stickpos">��ƽ�� ��ǥ</param>
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
                    // �ش� ���� ������ �ٶ󺸴� ȸ�� ���¸� ��ȯ
                }
            }
        }
    }

    #region EventTrigger
    public void AttackDown()
    {
        attacking = true;
        avatar.SetBool("Combo", true);
        StartCoroutine(StartAttack()); // �ڷ�ƾ �۵�
        //StartCoroutine("StartAttack");

        // Coroutine - Update�� �ƴ� �������� �ݺ������� �ڵ尡 ����Ǿ�� �� �� �����
        // Update���� ���к��ϰ� ������ �ڵ带 �ڷ�ƾ���� ��ȯ�ϸ� �ڿ� ������ ȿ����.
        // ���� �ð� ���� �Ŀ� �����̴� �۾�, Ư�� ������ �ο��� �ڵ带 �����ϴ� �۾��� ����.
        // IEnumerator ������ �Լ��� ����, �ش� �Լ� ������ yield return���� �ݵ�� �����ؾ���.
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
                playerAttack.NormalAttack(); // 2024.03.14 �÷��̾� ������ �Ϲݰ��� ȣ��
                yield return new WaitForSeconds(1.0f); // yield���� ���� ��Ҹ� �����ϴ� Ű����
            }
        }
    }

    /// <summary>
    /// ��ư 2�� ���� �� ��ų
    /// </summary>
    public void OnSkillDown()
    {
        if(Time.time - lastSkillTime > 1.0f)
        {
            avatar.SetBool("Skill", true);
            lastSkillTime = Time.time;
            playerAttack.SkillAttack(); // 2024.03.14 ��ų ���� �߰�
        }
    }

    public void OnSkillUp()
    {
        avatar.SetBool("Skill", false);
    }

    /// <summary>
    /// ��ư 1�� ���� �� ��ų
    /// </summary>
    public void OnDashDown()
    {
        if (Time.time - lastDashTime > 1.0f)
        {
            lastDashTime = Time.time;
            dashing = true;
            avatar.SetTrigger("Dash");
            playerAttack.DashAttack(); // 2024.03.14 �뽬 ���� �߰�
        }
    }

    public void OnDashUp()
    {
        dashing = false;
    }

    #endregion
}
