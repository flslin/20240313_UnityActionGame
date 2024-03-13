using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] // ����. �ִϸ����Ϳ� ���� �䱸. �ݵ�� �ʿ���. ���� ��� �ڵ� �߰�.
// Animator�� �����Ϳ��� ������Ʈ ���� �� �� ����
//���� Animator ������Ʈ�� ���ٸ� ���� ���� ����.
public class PlayerMovement : MonoBehaviour
{
    protected Animator avatar;
    float h, v;

    // �ִϸ��̼� ����� �ð� üũ�� ����
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
