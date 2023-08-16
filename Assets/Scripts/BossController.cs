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
        // ���ÿ��� idle �ִϸ��̼� ���
        animator.SetInteger("state", 0);
    }

    // �Ѿ˰� �浹�� ��� ȣ��� �޼���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �Ѿ��� �±װ� "Bullet"�� ��츸 ó��
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // �ǰ� �ִϸ��̼� ���
            animator.SetInteger("state", 1);

            // �Ѿ� �ı� (�ɼ�)
            Destroy(collision.gameObject);
        }
    }
}
