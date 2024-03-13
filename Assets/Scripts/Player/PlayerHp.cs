using UnityEngine;
using UnityEngine.UI;

class PlayerHp : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;

    public Slider headlthSlider; // 체력 UI 연결
    public Image damageImage; // 데미지 받았을 때 화면 색 변경
    public AudioClip deathClip; // 플레이어 데미지 받았을 때 오디오

    Animator anim;
    AudioClip playerAudio;
    PlayerMovement playerMovement;

    // 플레이어 죽었는지 판단
    bool isDead;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}

