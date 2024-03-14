using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public PlayerHp playerHealth;
    public GameObject enemy;
    public float spawnTime = 3.0f;
    public Transform[] spawnPoints;

    // Use this for initialization
    void Start()
    {
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHp>(); // 플레이어가 퍼블릭이 아닐경우
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        // InvokeRepeating("함수이름", 딜레이시간, 반복시간);
        // 해당 함수를 딜레이 시간 이후에 호출하고 반복 시간을 추가로 해당함수를 반복적으로 호출
        // 코루틴으로 대체 가능
    }

    void Spawn()
    {
        if(playerHealth.currentHealth <= 0.0f)
        {
            return;
        }

        int spawnPoolIndex = Random.Range(0, spawnPoints.Length); // 생성 지역의 개수만큼 랜덤한 수치의 값을 인덱스에 넣음

        Instantiate(enemy, spawnPoints[spawnPoolIndex].position, spawnPoints[spawnPoolIndex].rotation);
    }

}
