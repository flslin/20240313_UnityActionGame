using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;

    public Slider headlthSlider; // 체력 UI 연결
    public Image damageImage; // 데미지 받았을 때 화면 색 변경
    public AudioClip deathClip; // 플레이어 데미지 받았을 때 오디오
    //public GameObject textUI;

    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;

    // 플레이어 죽었는지 판단
    bool isDead;

    // 오브젝트 시작시 호출, Start보다 빨리 호출됨
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = startingHealth;
        headlthSlider.value = currentHealth;
        //textUI.SetActive(false);
    }

    /// <summary>
    /// 플레이어가 공격을 받았을 때 호출되는 함수
    /// </summary>
    /// <param name="amount">공격 받는 수치</param>
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        headlthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
        else
        {
            anim.SetTrigger("Damage");
        }
    }

    public void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
        playerMovement.enabled = false;
        //textUI.SetActive(true);
    }

    private void Update()
    {
        
    }
}

