using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        if (gameObject.layer == 9)
            Destroy(gameObject, 2f);
        else if (gameObject.layer == 10)
            Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.layer == 8 && gameObject.layer == 9) || (collision.gameObject.layer == 11 && gameObject.layer == 10))
            Destroy(gameObject);
    }
}
