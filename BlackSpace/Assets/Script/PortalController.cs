using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public float timeToClose;
    [SerializeField]
    float currentTime;
    bool portalClosed;

    void Start()
    {
        timeToClose = GameManager.instance.portalTime;

        currentTime = timeToClose;

        portalClosed = false;

        print("PORTAL SPAWNED");
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        
        if (currentTime <= 0 && !portalClosed)
            ClosePortal();
    }

    void ClosePortal()
    {
        print("PORTAL CLOSED");

        GameManager.instance.SetPortalClosed();

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
            GameManager.instance.WinGame();
    }
}
