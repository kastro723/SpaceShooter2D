using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContoller : MonoBehaviour
{
    public float speed = 10f;  // 총알의 속도
    void Update()
    {
        // 총알을 앞으로 이동
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Destroy(this.gameObject, 2f);
    }
}
