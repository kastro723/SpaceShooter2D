using UnityEngine;

public class PlyaerController : MonoBehaviour
{
    public GameObject bulletPrefab; // 발사할 총알 프리팹
    public Transform firePoint;     // 총알이 발사될 위치

    int speed = 5;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(h, v).normalized;  // 정규화

        Vector2 currentPosition = transform.position;

        if (currentPosition.x >= 2.27f && h > 0)
        {
            moveDirection.x = 0; // 오른쪽 이동 제한
        }
        else if (currentPosition.x <= -2.29f && h < 0)
        {
            moveDirection.x = 0; // 왼쪽 이동 제한
        }

        if (currentPosition.y >= 4.4f && v > 0)
        {
            moveDirection.y = 0; // 위쪽 이동 제한
        }
        else if (currentPosition.y <= -4.49f && v < 0)
        {
            moveDirection.y = 0; // 아래쪽 이동 제한
        }

        this.transform.Translate(moveDirection * speed * Time.deltaTime);

        if (h > 0)
        {
            animator.SetInteger("state", 2); // 오른쪽 애니메이션
        }
        else if (h < 0)
        {
            animator.SetInteger("state", 1); // 왼쪽 애니메이션
        }
        else
        {
            animator.SetInteger("state", 0); // 중앙 애니메이션
        }

        // 스페이스바 눌릴 경우 총알 발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }
}
