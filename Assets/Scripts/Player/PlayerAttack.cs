using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("플레이어 데미지")]
    public int normalDamage = 10;
    public int skillDamage = 20;
    public int dashDamage = 30;

    [Header("공격 대상")]
    public NormalTarget normalTarget;
    public SkillTraget skillTraget;

    /// <summary>
    /// 일반 공격 시 호출 될 함수
    /// </summary>
    public void NormalAttack()
    {
        // 1. 노멀 타겟의 리스트 조회
        List<Collider> targetList = new List<Collider>(normalTarget.targetList);

        //타겟 리스트 안의 몬스터 전체 조회
        foreach(var one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();

            if (enemy != null) // 몬스터에게 데미지 줌
            {
                // 데미지 주고 얼마나 뒤로 밀려날지 정함(pushback)
                StartCoroutine(enemy.StartDamage(normalDamage, transform.position, 0.5f, 0.5f));
            }
        }
    }

    /// <summary>
    /// 스킬 공격 시 호출 될 함수
    /// </summary>
    public void SkillAttack()
    {
        List<Collider> targetList = new List<Collider>(skillTraget.targetList);

        foreach(var one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                StartCoroutine(enemy.StartDamage(skillDamage, transform.position, 1f, 2f));
            }
        }
    }

    /// <summary>
    /// 대쉬 공격 시 호출 될 함수
    /// </summary>
    public void DashAttack()
    {
        List<Collider> targetList = new List<Collider>(skillTraget.targetList);

        foreach (var one in targetList)
        {
            EnemyHealth enemy = one.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                StartCoroutine(enemy.StartDamage(dashDamage, transform.position, 1f, 2f));
            }
        }
    }
}
