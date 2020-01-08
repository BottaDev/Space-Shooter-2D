using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public int hp = 50;
    public float speed = 0.1f;
    public float rotationSpeed = 10f;
    public float maxDistanceToDelete = 50f;
    public GameObject sprite;

    GameObject player;
    Vector2 direction;
    bool goToRight;

    void Start()
    {
        player = GameObject.Find("Player");

        direction = player.transform.position - transform.position;

        goToRight = Random.Range(0, 2) == 0 ? true : false;
    }

    void Update()
    {
        if (goToRight)
            sprite.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        else
            sprite.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * -1);

        transform.Translate(direction * speed * Time.deltaTime);

        if (player == null)
            return;

        float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);

        if (distance > maxDistanceToDelete)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 10)
            TakeDamage();
    }

    void TakeDamage()
    {
        hp -= 1;

        if (hp <= 0)
            Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, maxDistanceToDelete);
    }
}
