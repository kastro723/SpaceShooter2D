using UnityEngine;

public class PlyaerController : MonoBehaviour
{
    public GameObject bulletPrefab; // �߻��� �Ѿ� ������
    public Transform firePoint;     // �Ѿ��� �߻�� ��ġ

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

        Vector2 moveDirection = new Vector2(h, v).normalized;  // ����ȭ

        Vector2 currentPosition = transform.position;

        if (currentPosition.x >= 2.27f && h > 0)
        {
            moveDirection.x = 0; // ������ �̵� ����
        }
        else if (currentPosition.x <= -2.29f && h < 0)
        {
            moveDirection.x = 0; // ���� �̵� ����
        }

        if (currentPosition.y >= 4.4f && v > 0)
        {
            moveDirection.y = 0; // ���� �̵� ����
        }
        else if (currentPosition.y <= -4.49f && v < 0)
        {
            moveDirection.y = 0; // �Ʒ��� �̵� ����
        }

        this.transform.Translate(moveDirection * speed * Time.deltaTime);

        if (h > 0)
        {
            animator.SetInteger("state", 2); // ������ �ִϸ��̼�
        }
        else if (h < 0)
        {
            animator.SetInteger("state", 1); // ���� �ִϸ��̼�
        }
        else
        {
            animator.SetInteger("state", 0); // �߾� �ִϸ��̼�
        }

        // �����̽��� ���� ��� �Ѿ� �߻�
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
