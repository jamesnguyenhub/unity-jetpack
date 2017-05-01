using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
	public float jetpackForce = 75.0f;
	public float forwardMovementSpeed = 3.0f;

	private Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		bool jetpackActive = Input.GetButton("Fire1");

		if (jetpackActive) {
			rb.AddForce(new Vector2(0, jetpackForce));
		}

		rb.velocity = new Vector2(forwardMovementSpeed, rb.velocity.y);
	}
}
