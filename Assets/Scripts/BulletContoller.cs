using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContoller : MonoBehaviour
{
    public float speed = 10f;  // �Ѿ��� �ӵ�
    void Update()
    {
        // �Ѿ��� ������ �̵�
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Destroy(this.gameObject, 2f);
    }
}
