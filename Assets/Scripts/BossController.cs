using UnityEngine;

public class BossController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 평상시에는 idle 애니메이션 재생
        animator.SetInteger("state", 0);
    }

    // 총알과 충돌할 경우 호출될 메서드
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 총알의 태그가 "Bullet"인 경우만 처리
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // 피격 애니메이션 재생
            animator.SetInteger("state", 1);

            // 총알 파괴 (옵션)
            Destroy(collision.gameObject);
        }
    }
}
