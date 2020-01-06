using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	public float speed;
	public float moveSmooth = .3f;

	Rigidbody2D rb;
	Vector2 moveInput;
	Vector2 velocity = Vector2.zero;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}

	private void FixedUpdate()
	{
		rb.velocity = (moveInput * speed);

		Vector2 desiredVelocity = moveInput * speed;
		rb.velocity = Vector2.SmoothDamp(rb.velocity, desiredVelocity, ref velocity, moveSmooth);

		Vector3 mouseScreen = Input.mousePosition;
		Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
		transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg - 90);
	}
}
