using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    #region Field
    [Header("체력 정보")]
    public int startingHealth = 100;
    public int currentHealth;

    [Header("색 변경")]
    public float flashSpeed = 5.0f;
    public Color flashColor = new Color(1, 0, 0, 0.1f);

    [Header("사후 처리")]
    public float sinkSpeed = 1.0f;

    AudioSource enemyAudio;

    // 슬라임의 상태에 따라 상황에 맞는 효과 전달용
    bool isDead;
    bool isSinking;
    bool damaged;
    #endregion
    // Use this for initialization
    void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged) // 데미지를 받았을 경우 색을 설정한 색으로 변경
        {
            transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", flashColor); // 슬라임 프리팹 밑에 Model이 있기 때문에 접근하기 위해
        }
        else // 그게 아닐 경우 다시 자연스럽게 색이 변할 수 있도록 처리
        // Color.Lerp(A, B); A컬러를 B컬러로 천천히 바꾸는 코드
        {
            transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(transform.GetChild(0).GetComponent<Renderer>().material.GetColor("_Color"), Color.white, flashSpeed * Time.deltaTime));
        }

        damaged = false; // 데미지 처리를 비활성화

        // 싱크 처리(사후 처리) 시 슬라임을 아래로 서서히 내려가게 연출
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// 슬라임이 플레이어에게 공격을 받았을 때 처리하는 함수
    /// </summary>
    /// <param name="amount">데미지 수치</param>
    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;

        // 죽음 처리가 되지않고, 체력이 0 이하일 때
        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    /// <summary>
    /// 플레이어로 부터 공격을 받았을 때 넉백 효과
    /// </summary>
    /// <param name="damage">데미지</param>
    /// <param name="playerPosition">플레이어 위치</param>
    /// <param name="delay">딜레이</param>
    /// <param name="pushBack">푸쉬백</param>
    /// <returns></returns>
    public IEnumerator StartDamage(int damage, Vector3 playerPosition, float delay, float pushBack)
    {
        yield return new WaitForSeconds(delay); // 딜레이 시간 뒤 다시 작업을 진행

        // 예외 사항이 발생할수 있는 코드에 작성해주는 예외처리문
        try
        {
            // 데미지 주기
            TakeDamage(damage);
            //거리 측정
            Vector3 diff = playerPosition - transform.position;
            // 계산한 거리만큼 나눔
            diff /= diff.sqrMagnitude;
            // 물체에서 그 수치만큼 튕겨 나가도록 연출
            GetComponent<Rigidbody>().AddForce((transform.position - new Vector3(diff.x, diff.y, 0.0f)) * 50f * pushBack);
        }
        catch(MissingReferenceException e)
        // 코루틴을 돌리는 상황에서 객체가 사라진 상태에서 그 객체를 참조하려고 할 때 발생하는 오류
        {
            Debug.LogError(e.ToString());
        }
    }

    /// <summary>
    /// 슬라임의 죽음 시 호출 할 함수
    /// </summary>
    void Death()
    {
        isDead = true;

        transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = true;

        // 애니메이션 트리거 작동
        // 죽음 때 사용할 클립으로 변경후 오디오 실행

        StartSinking();
    }

    /// <summary>
    /// 사후 처리
    /// </summary>
    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false; // NavMeshAgent 비활성화

        GetComponent<Rigidbody>().isKinematic = true; // 외부에서 가해지는 물리적인 힘에 반응하지 않음

        isSinking = true;

        Destroy(gameObject, 5.0f);
    }
}
