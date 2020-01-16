using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float forceMagnitude = 100f;
    public float forceRadius = 1.5f;
    public float maxDistanceToDelete = 80f;

    PointEffector2D effector;
    CircleCollider2D circleCollider;
    GameObject player;

    void Start()
    {
        effector = gameObject.GetComponentInChildren<PointEffector2D>();
        circleCollider = gameObject.GetComponentInChildren<CircleCollider2D>();

       effector.forceMode = EffectorForceMode2D.Constant;

        player = GameObject.Find("Player");
    }

    void Update()
    {
        effector.forceMagnitude = forceMagnitude;
        circleCollider.radius = forceRadius;

        if (player == null)
            return;

        float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);

        if (distance > maxDistanceToDelete)
            Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDistanceToDelete);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, forceRadius);
    }
}
