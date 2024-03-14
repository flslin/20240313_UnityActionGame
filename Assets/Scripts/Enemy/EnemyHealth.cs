using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
